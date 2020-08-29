// Copyright 2015 The Go Authors. All rights reserved.
// Use of this source code is governed by a BSD-style
// license that can be found in the LICENSE file.

// package ssa -- go2cs converted at 2020 August 29 08:53:48 UTC
// import "cmd/compile/internal/ssa" ==> using ssa = go.cmd.compile.@internal.ssa_package
// Original source: C:\Go\src\cmd\compile\internal\ssa\dom.go

using static go.builtin;
using System;

namespace go {
namespace cmd {
namespace compile {
namespace @internal
{
    public static partial class ssa_package
    {
        // mark values
        private partial struct markKind // : byte
        {
        }

        private static readonly markKind notFound = 0L; // block has not been discovered yet
        private static readonly markKind notExplored = 1L; // discovered and in queue, outedges not processed yet
        private static readonly markKind explored = 2L; // discovered and in queue, outedges processed
        private static readonly markKind done = 3L; // all done, in output ordering

        // This file contains code to compute the dominator tree
        // of a control-flow graph.

        // postorder computes a postorder traversal ordering for the
        // basic blocks in f. Unreachable blocks will not appear.
        private static slice<ref Block> postorder(ref Func f)
        {
            return postorderWithNumbering(f, new slice<int>(new int[] {  }));
        }

        private partial struct blockAndIndex
        {
            public ptr<Block> b;
            public long index; // index is the number of successor edges of b that have already been explored.
        }

        // postorderWithNumbering provides a DFS postordering.
        // This seems to make loop-finding more robust.
        private static slice<ref Block> postorderWithNumbering(ref Func f, slice<int> ponums)
        {
            var mark = make_slice<markKind>(f.NumBlocks()); 

            // result ordering
            slice<ref Block> order = default; 

            // stack of blocks and next child to visit
            slice<blockAndIndex> s = default;
            s = append(s, new blockAndIndex(b:f.Entry));
            mark[f.Entry.ID] = explored;
            while (len(s) > 0L)
            {
                var tos = len(s) - 1L;
                var x = s[tos];
                var b = x.b;
                var i = x.index;
                if (i < len(b.Succs))
                {
                    s[tos].index++;
                    var bb = b.Succs[i].Block();
                    if (mark[bb.ID] == notFound)
                    {
                        mark[bb.ID] = explored;
                        s = append(s, new blockAndIndex(b:bb));
                    }
                }
                else
                {
                    s = s[..tos];
                    if (len(ponums) > 0L)
                    {
                        ponums[b.ID] = int32(len(order));
                    }
                    order = append(order, b);
                }
            }

            return order;
        }

        public delegate  slice<Edge> linkedBlocks(ref Block);

        private static readonly long nscratchslices = 7L;

        // experimentally, functions with 512 or fewer blocks account
        // for 75% of memory (size) allocation for dominator computation
        // in make.bash.


        // experimentally, functions with 512 or fewer blocks account
        // for 75% of memory (size) allocation for dominator computation
        // in make.bash.
        private static readonly long minscratchblocks = 512L;



        private static (slice<ID>, slice<ID>, slice<ID>, slice<ID>, slice<ID>, slice<ID>, slice<ID>) scratchBlocksForDom(this ref Cache cache, long maxBlockID)
        {
            var tot = maxBlockID * nscratchslices;
            var scratch = cache.domblockstore;
            if (len(scratch) < tot)
            { 
                // req = min(1.5*tot, nscratchslices*minscratchblocks)
                // 50% padding allows for graph growth in later phases.
                var req = (tot * 3L) >> (int)(1L);
                if (req < nscratchslices * minscratchblocks)
                {
                    req = nscratchslices * minscratchblocks;
                }
                scratch = make_slice<ID>(req);
                cache.domblockstore = scratch;
            }
            else
            { 
                // Clear as much of scratch as we will (re)use
                scratch = scratch[0L..tot];
                foreach (var (i) in scratch)
                {
                    scratch[i] = 0L;
                }
            }
            a = scratch[0L * maxBlockID..1L * maxBlockID];
            b = scratch[1L * maxBlockID..2L * maxBlockID];
            c = scratch[2L * maxBlockID..3L * maxBlockID];
            d = scratch[3L * maxBlockID..4L * maxBlockID];
            e = scratch[4L * maxBlockID..5L * maxBlockID];
            f = scratch[5L * maxBlockID..6L * maxBlockID];
            g = scratch[6L * maxBlockID..7L * maxBlockID];

            return;
        }

        private static slice<ref Block> dominators(ref Func f)
        {
            Func<ref Block, slice<Edge>> preds = b => b.Preds;
            Func<ref Block, slice<Edge>> succs = b => b.Succs;
            } 

            //TODO: benchmark and try to find criteria for swapping between
            // dominatorsSimple and dominatorsLT; 

            //TODO: benchmark and try to find criteria for swapping between
            // dominatorsSimple and dominatorsLT
            return f.dominatorsLTOrig(f.Entry, preds, succs);
        }

        // dominatorsLTOrig runs Lengauer-Tarjan to compute a dominator tree starting at
        // entry and using predFn/succFn to find predecessors/successors to allow
        // computing both dominator and post-dominator trees.
        private static slice<ref Block> dominatorsLTOrig(this ref Func f, ref Block entry, linkedBlocks predFn, linkedBlocks succFn)
        { 
            // Adapted directly from the original TOPLAS article's "simple" algorithm

            var maxBlockID = entry.Func.NumBlocks();
            var (semi, vertex, label, parent, ancestor, bucketHead, bucketLink) = f.Cache.scratchBlocksForDom(maxBlockID); 

            // This version uses integers for most of the computation,
            // to make the work arrays smaller and pointer-free.
            // fromID translates from ID to *Block where that is needed.
            var fromID = make_slice<ref Block>(maxBlockID);
            {
                var v__prev1 = v;

                foreach (var (_, __v) in f.Blocks)
                {
                    v = __v;
                    fromID[v.ID] = v;
                }

                v = v__prev1;
            }

            var idom = make_slice<ref Block>(maxBlockID); 

            // Step 1. Carry out a depth first search of the problem graph. Number
            // the vertices from 1 to n as they are reached during the search.
            var n = f.dfsOrig(entry, succFn, semi, vertex, label, parent);

            {
                var i__prev1 = i;

                for (var i = n; i >= 2L; i--)
                {
                    var w = vertex[i]; 

                    // step2 in TOPLAS paper
                    foreach (var (_, e) in predFn(fromID[w]))
                    {
                        var v = e.b;
                        if (semi[v.ID] == 0L)
                        { 
                            // skip unreachable predecessor
                            // not in original, but we're using existing pred instead of building one.
                            continue;
                        }
                        var u = evalOrig(v.ID, ancestor, semi, label);
                        if (semi[u] < semi[w])
                        {
                            semi[w] = semi[u];
                        }
                    } 

                    // add w to bucket[vertex[semi[w]]]
                    // implement bucket as a linked list implemented
                    // in a pair of arrays.
                    var vsw = vertex[semi[w]];
                    bucketLink[w] = bucketHead[vsw];
                    bucketHead[vsw] = w;

                    linkOrig(parent[w], w, ancestor); 

                    // step3 in TOPLAS paper
                    {
                        var v__prev2 = v;

                        v = bucketHead[parent[w]];

                        while (v != 0L)
                        {
                            u = evalOrig(v, ancestor, semi, label);
                            if (semi[u] < semi[v])
                            {
                                idom[v] = fromID[u];
                            v = bucketLink[v];
                            }
                            else
                            {
                                idom[v] = fromID[parent[w]];
                            }
                        }


                        v = v__prev2;
                    }
                } 
                // step 4 in toplas paper


                i = i__prev1;
            } 
            // step 4 in toplas paper
            {
                var i__prev1 = i;

                for (i = ID(2L); i <= n; i++)
                {
                    w = vertex[i];
                    if (idom[w].ID != vertex[semi[w]])
                    {
                        idom[w] = idom[idom[w].ID];
                    }
                }


                i = i__prev1;
            }

            return idom;
        }

        // dfs performs a depth first search over the blocks starting at entry block
        // (in arbitrary order).  This is a de-recursed version of dfs from the
        // original Tarjan-Lengauer TOPLAS article.  It's important to return the
        // same values for parent as the original algorithm.
        private static ID dfsOrig(this ref Func f, ref Block entry, linkedBlocks succFn, slice<ID> semi, slice<ID> vertex, slice<ID> label, slice<ID> parent)
        {
            var n = ID(0L);
            var s = make_slice<ref Block>(0L, 256L);
            s = append(s, entry);

            while (len(s) > 0L)
            {
                var v = s[len(s) - 1L];
                s = s[..len(s) - 1L]; 
                // recursing on v

                if (semi[v.ID] != 0L)
                {
                    continue; // already visited
                }
                n++;
                semi[v.ID] = n;
                vertex[n] = v.ID;
                label[v.ID] = v.ID; 
                // ancestor[v] already zero
                foreach (var (_, e) in succFn(v))
                {
                    var w = e.b; 
                    // if it has a dfnum, we've already visited it
                    if (semi[w.ID] == 0L)
                    { 
                        // yes, w can be pushed multiple times.
                        s = append(s, w);
                        parent[w.ID] = v.ID; // keep overwriting this till it is visited.
                    }
                }
            }

            return n;
        }

        // compressOrig is the "simple" compress function from LT paper
        private static void compressOrig(ID v, slice<ID> ancestor, slice<ID> semi, slice<ID> label)
        {
            if (ancestor[ancestor[v]] != 0L)
            {
                compressOrig(ancestor[v], ancestor, semi, label);
                if (semi[label[ancestor[v]]] < semi[label[v]])
                {
                    label[v] = label[ancestor[v]];
                }
                ancestor[v] = ancestor[ancestor[v]];
            }
        }

        // evalOrig is the "simple" eval function from LT paper
        private static ID evalOrig(ID v, slice<ID> ancestor, slice<ID> semi, slice<ID> label)
        {
            if (ancestor[v] == 0L)
            {
                return v;
            }
            compressOrig(v, ancestor, semi, label);
            return label[v];
        }

        private static void linkOrig(ID v, ID w, slice<ID> ancestor)
        {
            ancestor[w] = v;
        }

        // dominators computes the dominator tree for f. It returns a slice
        // which maps block ID to the immediate dominator of that block.
        // Unreachable blocks map to nil. The entry block maps to nil.
        private static slice<ref Block> dominatorsSimple(ref Func f)
        { 
            // A simple algorithm for now
            // Cooper, Harvey, Kennedy
            var idom = make_slice<ref Block>(f.NumBlocks()); 

            // Compute postorder walk
            var post = f.postorder(); 

            // Make map from block id to order index (for intersect call)
            var postnum = make_slice<long>(f.NumBlocks());
            {
                var i__prev1 = i;
                var b__prev1 = b;

                foreach (var (__i, __b) in post)
                {
                    i = __i;
                    b = __b;
                    postnum[b.ID] = i;
                } 

                // Make the entry block a self-loop

                i = i__prev1;
                b = b__prev1;
            }

            idom[f.Entry.ID] = f.Entry;
            if (postnum[f.Entry.ID] != len(post) - 1L)
            {
                f.Fatalf("entry block %v not last in postorder", f.Entry);
            } 

            // Compute relaxation of idom entries
            while (true)
            {
                var changed = false;

                {
                    var i__prev2 = i;

                    for (var i = len(post) - 2L; i >= 0L; i--)
                    {
                        var b = post[i];
                        ref Block d = default;
                        foreach (var (_, e) in b.Preds)
                        {
                            var p = e.b;
                            if (idom[p.ID] == null)
                            {
                                continue;
                            }
                            if (d == null)
                            {
                                d = p;
                                continue;
                            }
                            d = intersect(d, p, postnum, idom);
                        }
                        if (d != idom[b.ID])
                        {
                            idom[b.ID] = d;
                            changed = true;
                        }
                    }


                    i = i__prev2;
                }
                if (!changed)
                {
                    break;
                }
            } 
            // Set idom of entry block to nil instead of itself.
 
            // Set idom of entry block to nil instead of itself.
            idom[f.Entry.ID] = null;
            return idom;
        }

        // intersect finds the closest dominator of both b and c.
        // It requires a postorder numbering of all the blocks.
        private static ref Block intersect(ref Block b, ref Block c, slice<long> postnum, slice<ref Block> idom)
        { 
            // TODO: This loop is O(n^2). It used to be used in nilcheck,
            // see BenchmarkNilCheckDeep*.
            while (b != c)
            {
                if (postnum[b.ID] < postnum[c.ID])
                {
                    b = idom[b.ID];
                }
                else
                {
                    c = idom[c.ID];
                }
            }

            return b;
        }
    }
}}}}