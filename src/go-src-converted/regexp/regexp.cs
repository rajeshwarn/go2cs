// Copyright 2009 The Go Authors. All rights reserved.
// Use of this source code is governed by a BSD-style
// license that can be found in the LICENSE file.

// Package regexp implements regular expression search.
//
// The syntax of the regular expressions accepted is the same
// general syntax used by Perl, Python, and other languages.
// More precisely, it is the syntax accepted by RE2 and described at
// https://golang.org/s/re2syntax, except for \C.
// For an overview of the syntax, run
//   go doc regexp/syntax
//
// The regexp implementation provided by this package is
// guaranteed to run in time linear in the size of the input.
// (This is a property not guaranteed by most open source
// implementations of regular expressions.) For more information
// about this property, see
//    https://swtch.com/~rsc/regexp/regexp1.html
// or any book about automata theory.
//
// All characters are UTF-8-encoded code points.
//
// There are 16 methods of Regexp that match a regular expression and identify
// the matched text. Their names are matched by this regular expression:
//
//    Find(All)?(String)?(Submatch)?(Index)?
//
// If 'All' is present, the routine matches successive non-overlapping
// matches of the entire expression. Empty matches abutting a preceding
// match are ignored. The return value is a slice containing the successive
// return values of the corresponding non-'All' routine. These routines take
// an extra integer argument, n. If n >= 0, the function returns at most n
// matches/submatches; otherwise, it returns all of them.
//
// If 'String' is present, the argument is a string; otherwise it is a slice
// of bytes; return values are adjusted as appropriate.
//
// If 'Submatch' is present, the return value is a slice identifying the
// successive submatches of the expression. Submatches are matches of
// parenthesized subexpressions (also known as capturing groups) within the
// regular expression, numbered from left to right in order of opening
// parenthesis. Submatch 0 is the match of the entire expression, submatch 1
// the match of the first parenthesized subexpression, and so on.
//
// If 'Index' is present, matches and submatches are identified by byte index
// pairs within the input string: result[2*n:2*n+1] identifies the indexes of
// the nth submatch. The pair for n==0 identifies the match of the entire
// expression. If 'Index' is not present, the match is identified by the text
// of the match/submatch. If an index is negative or text is nil, it means that
// subexpression did not match any string in the input. For 'String' versions
// an empty string means either no match or an empty match.
//
// There is also a subset of the methods that can be applied to text read
// from a RuneReader:
//
//    MatchReader, FindReaderIndex, FindReaderSubmatchIndex
//
// This set may grow. Note that regular expression matches may need to
// examine text beyond the text returned by a match, so the methods that
// match text from a RuneReader may read arbitrarily far into the input
// before returning.
//
// (There are a few other methods that do not match this pattern.)
//
// package regexp -- go2cs converted at 2020 October 09 04:58:42 UTC
// import "regexp" ==> using regexp = go.regexp_package
// Original source: C:\Go\src\regexp\regexp.go
using bytes = go.bytes_package;
using io = go.io_package;
using syntax = go.regexp.syntax_package;
using strconv = go.strconv_package;
using strings = go.strings_package;
using sync = go.sync_package;
using unicode = go.unicode_package;
using utf8 = go.unicode.utf8_package;
using static go.builtin;
using System;

namespace go
{
    public static partial class regexp_package
    {
        // Regexp is the representation of a compiled regular expression.
        // A Regexp is safe for concurrent use by multiple goroutines,
        // except for configuration methods, such as Longest.
        public partial struct Regexp
        {
            public @string expr; // as passed to Compile
            public ptr<syntax.Prog> prog; // compiled program
            public ptr<onePassProg> onepass; // onepass program or nil
            public long numSubexp;
            public long maxBitStateLen;
            public slice<@string> subexpNames;
            public @string prefix; // required prefix in unanchored matches
            public slice<byte> prefixBytes; // prefix, as a []byte
            public int prefixRune; // first rune in prefix
            public uint prefixEnd; // pc for last rune in prefix
            public long mpool; // pool for machines
            public long matchcap; // size of recorded match lengths
            public bool prefixComplete; // prefix is the entire regexp
            public syntax.EmptyOp cond; // empty-width conditions required at start of match
            public long minInputLen; // minimum length of the input in bytes

// This field can be modified by the Longest method,
// but it is otherwise read-only.
            public bool longest; // whether regexp prefers leftmost-longest match
        }

        // String returns the source text used to compile the regular expression.
        private static @string String(this ptr<Regexp> _addr_re)
        {
            ref Regexp re = ref _addr_re.val;

            return re.expr;
        }

        // Copy returns a new Regexp object copied from re.
        // Calling Longest on one copy does not affect another.
        //
        // Deprecated: In earlier releases, when using a Regexp in multiple goroutines,
        // giving each goroutine its own copy helped to avoid lock contention.
        // As of Go 1.12, using Copy is no longer necessary to avoid lock contention.
        // Copy may still be appropriate if the reason for its use is to make
        // two copies with different Longest settings.
        private static ptr<Regexp> Copy(this ptr<Regexp> _addr_re)
        {
            ref Regexp re = ref _addr_re.val;

            ref var re2 = ref heap(re.val, out ptr<var> _addr_re2);
            return _addr__addr_re2!;
        }

        // Compile parses a regular expression and returns, if successful,
        // a Regexp object that can be used to match against text.
        //
        // When matching against text, the regexp returns a match that
        // begins as early as possible in the input (leftmost), and among those
        // it chooses the one that a backtracking search would have found first.
        // This so-called leftmost-first matching is the same semantics
        // that Perl, Python, and other implementations use, although this
        // package implements it without the expense of backtracking.
        // For POSIX leftmost-longest matching, see CompilePOSIX.
        public static (ptr<Regexp>, error) Compile(@string expr)
        {
            ptr<Regexp> _p0 = default!;
            error _p0 = default!;

            return _addr_compile(expr, syntax.Perl, false)!;
        }

        // CompilePOSIX is like Compile but restricts the regular expression
        // to POSIX ERE (egrep) syntax and changes the match semantics to
        // leftmost-longest.
        //
        // That is, when matching against text, the regexp returns a match that
        // begins as early as possible in the input (leftmost), and among those
        // it chooses a match that is as long as possible.
        // This so-called leftmost-longest matching is the same semantics
        // that early regular expression implementations used and that POSIX
        // specifies.
        //
        // However, there can be multiple leftmost-longest matches, with different
        // submatch choices, and here this package diverges from POSIX.
        // Among the possible leftmost-longest matches, this package chooses
        // the one that a backtracking search would have found first, while POSIX
        // specifies that the match be chosen to maximize the length of the first
        // subexpression, then the second, and so on from left to right.
        // The POSIX rule is computationally prohibitive and not even well-defined.
        // See https://swtch.com/~rsc/regexp/regexp2.html#posix for details.
        public static (ptr<Regexp>, error) CompilePOSIX(@string expr)
        {
            ptr<Regexp> _p0 = default!;
            error _p0 = default!;

            return _addr_compile(expr, syntax.POSIX, true)!;
        }

        // Longest makes future searches prefer the leftmost-longest match.
        // That is, when matching against text, the regexp returns a match that
        // begins as early as possible in the input (leftmost), and among those
        // it chooses a match that is as long as possible.
        // This method modifies the Regexp and may not be called concurrently
        // with any other methods.
        private static void Longest(this ptr<Regexp> _addr_re)
        {
            ref Regexp re = ref _addr_re.val;

            re.longest = true;
        }

        private static (ptr<Regexp>, error) compile(@string expr, syntax.Flags mode, bool longest)
        {
            ptr<Regexp> _p0 = default!;
            error _p0 = default!;

            var (re, err) = syntax.Parse(expr, mode);
            if (err != null)
            {
                return (_addr_null!, error.As(err)!);
            }

            var maxCap = re.MaxCap();
            var capNames = re.CapNames();

            re = re.Simplify();
            var (prog, err) = syntax.Compile(re);
            if (err != null)
            {
                return (_addr_null!, error.As(err)!);
            }

            var matchcap = prog.NumCap;
            if (matchcap < 2L)
            {
                matchcap = 2L;
            }

            ptr<Regexp> regexp = addr(new Regexp(expr:expr,prog:prog,onepass:compileOnePass(prog),numSubexp:maxCap,subexpNames:capNames,cond:prog.StartCond(),longest:longest,matchcap:matchcap,minInputLen:minInputLen(re),));
            if (regexp.onepass == null)
            {
                regexp.prefix, regexp.prefixComplete = prog.Prefix();
                regexp.maxBitStateLen = maxBitStateLen(prog);
            }
            else
            {
                regexp.prefix, regexp.prefixComplete, regexp.prefixEnd = onePassPrefix(prog);
            }

            if (regexp.prefix != "")
            { 
                // TODO(rsc): Remove this allocation by adding
                // IndexString to package bytes.
                regexp.prefixBytes = (slice<byte>)regexp.prefix;
                regexp.prefixRune, _ = utf8.DecodeRuneInString(regexp.prefix);

            }

            var n = len(prog.Inst);
            long i = 0L;
            while (matchSize[i] != 0L && matchSize[i] < n)
            {
                i++;
            }

            regexp.mpool = i;

            return (_addr_regexp!, error.As(null!)!);

        }

        // Pools of *machine for use during (*Regexp).doExecute,
        // split up by the size of the execution queues.
        // matchPool[i] machines have queue size matchSize[i].
        // On a 64-bit system each queue entry is 16 bytes,
        // so matchPool[0] has 16*2*128 = 4kB queues, etc.
        // The final matchPool is a catch-all for very large queues.
        private static array<long> matchSize = new array<long>(new long[] { 128, 512, 2048, 16384, 0 });        private static array<sync.Pool> matchPool = new array<sync.Pool>(len(matchSize));

        // get returns a machine to use for matching re.
        // It uses the re's machine cache if possible, to avoid
        // unnecessary allocation.
        private static ptr<machine> get(this ptr<Regexp> _addr_re)
        {
            ref Regexp re = ref _addr_re.val;

            ptr<machine> (m, ok) = matchPool[re.mpool].Get()._<ptr<machine>>();
            if (!ok)
            {
                m = @new<machine>();
            }

            m.re = re;
            m.p = re.prog;
            if (cap(m.matchcap) < re.matchcap)
            {
                m.matchcap = make_slice<long>(re.matchcap);
                foreach (var (_, t) in m.pool)
                {
                    t.cap = make_slice<long>(re.matchcap);
                }

            } 

            // Allocate queues if needed.
            // Or reallocate, for "large" match pool.
            var n = matchSize[re.mpool];
            if (n == 0L)
            { // large pool
                n = len(re.prog.Inst);

            }

            if (len(m.q0.sparse) < n)
            {
                m.q0 = new queue(make([]uint32,n),make([]entry,0,n));
                m.q1 = new queue(make([]uint32,n),make([]entry,0,n));
            }

            return _addr_m!;

        }

        // put returns a machine to the correct machine pool.
        private static void put(this ptr<Regexp> _addr_re, ptr<machine> _addr_m)
        {
            ref Regexp re = ref _addr_re.val;
            ref machine m = ref _addr_m.val;

            m.re = null;
            m.p = null;
            m.inputs.clear();
            matchPool[re.mpool].Put(m);
        }

        // minInputLen walks the regexp to find the minimum length of any matchable input
        private static long minInputLen(ptr<syntax.Regexp> _addr_re)
        {
            ref syntax.Regexp re = ref _addr_re.val;


            if (re.Op == syntax.OpAnyChar || re.Op == syntax.OpAnyCharNotNL || re.Op == syntax.OpCharClass) 
                return 1L;
            else if (re.Op == syntax.OpLiteral) 
                long l = 0L;
                foreach (var (_, r) in re.Rune)
                {
                    l += utf8.RuneLen(r);
                }
                return l;
            else if (re.Op == syntax.OpCapture || re.Op == syntax.OpPlus) 
                return minInputLen(_addr_re.Sub[0L]);
            else if (re.Op == syntax.OpRepeat) 
                return re.Min * minInputLen(_addr_re.Sub[0L]);
            else if (re.Op == syntax.OpConcat) 
                l = 0L;
                {
                    var sub__prev1 = sub;

                    foreach (var (_, __sub) in re.Sub)
                    {
                        sub = __sub;
                        l += minInputLen(_addr_sub);
                    }

                    sub = sub__prev1;
                }

                return l;
            else if (re.Op == syntax.OpAlternate) 
                l = minInputLen(_addr_re.Sub[0L]);
                long lnext = default;
                {
                    var sub__prev1 = sub;

                    foreach (var (_, __sub) in re.Sub[1L..])
                    {
                        sub = __sub;
                        lnext = minInputLen(_addr_sub);
                        if (lnext < l)
                        {
                            l = lnext;
                        }

                    }

                    sub = sub__prev1;
                }

                return l;
            else 
                return 0L;
            
        }

        // MustCompile is like Compile but panics if the expression cannot be parsed.
        // It simplifies safe initialization of global variables holding compiled regular
        // expressions.
        public static ptr<Regexp> MustCompile(@string str) => func((_, panic, __) =>
        {
            var (regexp, err) = Compile(str);
            if (err != null)
            {
                panic("regexp: Compile(" + quote(str) + "): " + err.Error());
            }

            return _addr_regexp!;

        });

        // MustCompilePOSIX is like CompilePOSIX but panics if the expression cannot be parsed.
        // It simplifies safe initialization of global variables holding compiled regular
        // expressions.
        public static ptr<Regexp> MustCompilePOSIX(@string str) => func((_, panic, __) =>
        {
            var (regexp, err) = CompilePOSIX(str);
            if (err != null)
            {
                panic("regexp: CompilePOSIX(" + quote(str) + "): " + err.Error());
            }

            return _addr_regexp!;

        });

        private static @string quote(@string s)
        {
            if (strconv.CanBackquote(s))
            {
                return "`" + s + "`";
            }

            return strconv.Quote(s);

        }

        // NumSubexp returns the number of parenthesized subexpressions in this Regexp.
        private static long NumSubexp(this ptr<Regexp> _addr_re)
        {
            ref Regexp re = ref _addr_re.val;

            return re.numSubexp;
        }

        // SubexpNames returns the names of the parenthesized subexpressions
        // in this Regexp. The name for the first sub-expression is names[1],
        // so that if m is a match slice, the name for m[i] is SubexpNames()[i].
        // Since the Regexp as a whole cannot be named, names[0] is always
        // the empty string. The slice should not be modified.
        private static slice<@string> SubexpNames(this ptr<Regexp> _addr_re)
        {
            ref Regexp re = ref _addr_re.val;

            return re.subexpNames;
        }

        // SubexpIndex returns the index of the first subexpression with the given name,
        // or -1 if there is no subexpression with that name.
        //
        // Note that multiple subexpressions can be written using the same name, as in
        // (?P<bob>a+)(?P<bob>b+), which declares two subexpressions named "bob".
        // In this case, SubexpIndex returns the index of the leftmost such subexpression
        // in the regular expression.
        private static long SubexpIndex(this ptr<Regexp> _addr_re, @string name)
        {
            ref Regexp re = ref _addr_re.val;

            if (name != "")
            {
                foreach (var (i, s) in re.subexpNames)
                {
                    if (name == s)
                    {
                        return i;
                    }

                }

            }

            return -1L;

        }

        private static readonly int endOfText = (int)-1L;

        // input abstracts different representations of the input text. It provides
        // one-character lookahead.


        // input abstracts different representations of the input text. It provides
        // one-character lookahead.
        private partial interface input
        {
            lazyFlag step(long pos); // advance one rune
            lazyFlag canCheckPrefix(); // can we look ahead without losing info?
            lazyFlag hasPrefix(ptr<Regexp> re);
            lazyFlag index(ptr<Regexp> re, long pos);
            lazyFlag context(long pos);
        }

        // inputString scans a string.
        private partial struct inputString
        {
            public @string str;
        }

        private static (int, long) step(this ptr<inputString> _addr_i, long pos)
        {
            int _p0 = default;
            long _p0 = default;
            ref inputString i = ref _addr_i.val;

            if (pos < len(i.str))
            {
                var c = i.str[pos];
                if (c < utf8.RuneSelf)
                {
                    return (rune(c), 1L);
                }

                return utf8.DecodeRuneInString(i.str[pos..]);

            }

            return (endOfText, 0L);

        }

        private static bool canCheckPrefix(this ptr<inputString> _addr_i)
        {
            ref inputString i = ref _addr_i.val;

            return true;
        }

        private static bool hasPrefix(this ptr<inputString> _addr_i, ptr<Regexp> _addr_re)
        {
            ref inputString i = ref _addr_i.val;
            ref Regexp re = ref _addr_re.val;

            return strings.HasPrefix(i.str, re.prefix);
        }

        private static long index(this ptr<inputString> _addr_i, ptr<Regexp> _addr_re, long pos)
        {
            ref inputString i = ref _addr_i.val;
            ref Regexp re = ref _addr_re.val;

            return strings.Index(i.str[pos..], re.prefix);
        }

        private static lazyFlag context(this ptr<inputString> _addr_i, long pos)
        {
            ref inputString i = ref _addr_i.val;

            var r1 = endOfText;
            var r2 = endOfText; 
            // 0 < pos && pos <= len(i.str)
            if (uint(pos - 1L) < uint(len(i.str)))
            {
                r1 = rune(i.str[pos - 1L]);
                if (r1 >= utf8.RuneSelf)
                {
                    r1, _ = utf8.DecodeLastRuneInString(i.str[..pos]);
                }

            } 
            // 0 <= pos && pos < len(i.str)
            if (uint(pos) < uint(len(i.str)))
            {
                r2 = rune(i.str[pos]);
                if (r2 >= utf8.RuneSelf)
                {
                    r2, _ = utf8.DecodeRuneInString(i.str[pos..]);
                }

            }

            return newLazyFlag(r1, r2);

        }

        // inputBytes scans a byte slice.
        private partial struct inputBytes
        {
            public slice<byte> str;
        }

        private static (int, long) step(this ptr<inputBytes> _addr_i, long pos)
        {
            int _p0 = default;
            long _p0 = default;
            ref inputBytes i = ref _addr_i.val;

            if (pos < len(i.str))
            {
                var c = i.str[pos];
                if (c < utf8.RuneSelf)
                {
                    return (rune(c), 1L);
                }

                return utf8.DecodeRune(i.str[pos..]);

            }

            return (endOfText, 0L);

        }

        private static bool canCheckPrefix(this ptr<inputBytes> _addr_i)
        {
            ref inputBytes i = ref _addr_i.val;

            return true;
        }

        private static bool hasPrefix(this ptr<inputBytes> _addr_i, ptr<Regexp> _addr_re)
        {
            ref inputBytes i = ref _addr_i.val;
            ref Regexp re = ref _addr_re.val;

            return bytes.HasPrefix(i.str, re.prefixBytes);
        }

        private static long index(this ptr<inputBytes> _addr_i, ptr<Regexp> _addr_re, long pos)
        {
            ref inputBytes i = ref _addr_i.val;
            ref Regexp re = ref _addr_re.val;

            return bytes.Index(i.str[pos..], re.prefixBytes);
        }

        private static lazyFlag context(this ptr<inputBytes> _addr_i, long pos)
        {
            ref inputBytes i = ref _addr_i.val;

            var r1 = endOfText;
            var r2 = endOfText; 
            // 0 < pos && pos <= len(i.str)
            if (uint(pos - 1L) < uint(len(i.str)))
            {
                r1 = rune(i.str[pos - 1L]);
                if (r1 >= utf8.RuneSelf)
                {
                    r1, _ = utf8.DecodeLastRune(i.str[..pos]);
                }

            } 
            // 0 <= pos && pos < len(i.str)
            if (uint(pos) < uint(len(i.str)))
            {
                r2 = rune(i.str[pos]);
                if (r2 >= utf8.RuneSelf)
                {
                    r2, _ = utf8.DecodeRune(i.str[pos..]);
                }

            }

            return newLazyFlag(r1, r2);

        }

        // inputReader scans a RuneReader.
        private partial struct inputReader
        {
            public io.RuneReader r;
            public bool atEOT;
            public long pos;
        }

        private static (int, long) step(this ptr<inputReader> _addr_i, long pos)
        {
            int _p0 = default;
            long _p0 = default;
            ref inputReader i = ref _addr_i.val;

            if (!i.atEOT && pos != i.pos)
            {
                return (endOfText, 0L);
            }

            var (r, w, err) = i.r.ReadRune();
            if (err != null)
            {
                i.atEOT = true;
                return (endOfText, 0L);
            }

            i.pos += w;
            return (r, w);

        }

        private static bool canCheckPrefix(this ptr<inputReader> _addr_i)
        {
            ref inputReader i = ref _addr_i.val;

            return false;
        }

        private static bool hasPrefix(this ptr<inputReader> _addr_i, ptr<Regexp> _addr_re)
        {
            ref inputReader i = ref _addr_i.val;
            ref Regexp re = ref _addr_re.val;

            return false;
        }

        private static long index(this ptr<inputReader> _addr_i, ptr<Regexp> _addr_re, long pos)
        {
            ref inputReader i = ref _addr_i.val;
            ref Regexp re = ref _addr_re.val;

            return -1L;
        }

        private static lazyFlag context(this ptr<inputReader> _addr_i, long pos)
        {
            ref inputReader i = ref _addr_i.val;

            return 0L; // not used
        }

        // LiteralPrefix returns a literal string that must begin any match
        // of the regular expression re. It returns the boolean true if the
        // literal string comprises the entire regular expression.
        private static (@string, bool) LiteralPrefix(this ptr<Regexp> _addr_re)
        {
            @string prefix = default;
            bool complete = default;
            ref Regexp re = ref _addr_re.val;

            return (re.prefix, re.prefixComplete);
        }

        // MatchReader reports whether the text returned by the RuneReader
        // contains any match of the regular expression re.
        private static bool MatchReader(this ptr<Regexp> _addr_re, io.RuneReader r)
        {
            ref Regexp re = ref _addr_re.val;

            return re.doMatch(r, null, "");
        }

        // MatchString reports whether the string s
        // contains any match of the regular expression re.
        private static bool MatchString(this ptr<Regexp> _addr_re, @string s)
        {
            ref Regexp re = ref _addr_re.val;

            return re.doMatch(null, null, s);
        }

        // Match reports whether the byte slice b
        // contains any match of the regular expression re.
        private static bool Match(this ptr<Regexp> _addr_re, slice<byte> b)
        {
            ref Regexp re = ref _addr_re.val;

            return re.doMatch(null, b, "");
        }

        // MatchReader reports whether the text returned by the RuneReader
        // contains any match of the regular expression pattern.
        // More complicated queries need to use Compile and the full Regexp interface.
        public static (bool, error) MatchReader(@string pattern, io.RuneReader r)
        {
            bool matched = default;
            error err = default!;

            var (re, err) = Compile(pattern);
            if (err != null)
            {
                return (false, error.As(err)!);
            }

            return (re.MatchReader(r), error.As(null!)!);

        }

        // MatchString reports whether the string s
        // contains any match of the regular expression pattern.
        // More complicated queries need to use Compile and the full Regexp interface.
        public static (bool, error) MatchString(@string pattern, @string s)
        {
            bool matched = default;
            error err = default!;

            var (re, err) = Compile(pattern);
            if (err != null)
            {
                return (false, error.As(err)!);
            }

            return (re.MatchString(s), error.As(null!)!);

        }

        // Match reports whether the byte slice b
        // contains any match of the regular expression pattern.
        // More complicated queries need to use Compile and the full Regexp interface.
        public static (bool, error) Match(@string pattern, slice<byte> b)
        {
            bool matched = default;
            error err = default!;

            var (re, err) = Compile(pattern);
            if (err != null)
            {
                return (false, error.As(err)!);
            }

            return (re.Match(b), error.As(null!)!);

        }

        // ReplaceAllString returns a copy of src, replacing matches of the Regexp
        // with the replacement string repl. Inside repl, $ signs are interpreted as
        // in Expand, so for instance $1 represents the text of the first submatch.
        private static @string ReplaceAllString(this ptr<Regexp> _addr_re, @string src, @string repl)
        {
            ref Regexp re = ref _addr_re.val;

            long n = 2L;
            if (strings.Contains(repl, "$"))
            {
                n = 2L * (re.numSubexp + 1L);
            }

            var b = re.replaceAll(null, src, n, (dst, match) =>
            {
                return re.expand(dst, repl, null, src, match);
            });
            return string(b);

        }

        // ReplaceAllLiteralString returns a copy of src, replacing matches of the Regexp
        // with the replacement string repl. The replacement repl is substituted directly,
        // without using Expand.
        private static @string ReplaceAllLiteralString(this ptr<Regexp> _addr_re, @string src, @string repl)
        {
            ref Regexp re = ref _addr_re.val;

            return string(re.replaceAll(null, src, 2L, (dst, match) =>
            {
                return append(dst, repl);
            }));

        }

        // ReplaceAllStringFunc returns a copy of src in which all matches of the
        // Regexp have been replaced by the return value of function repl applied
        // to the matched substring. The replacement returned by repl is substituted
        // directly, without using Expand.
        private static @string ReplaceAllStringFunc(this ptr<Regexp> _addr_re, @string src, Func<@string, @string> repl)
        {
            ref Regexp re = ref _addr_re.val;

            var b = re.replaceAll(null, src, 2L, (dst, match) =>
            {
                return append(dst, repl(src[match[0L]..match[1L]]));
            });
            return string(b);

        }

        private static slice<byte> replaceAll(this ptr<Regexp> _addr_re, slice<byte> bsrc, @string src, long nmatch, Func<slice<byte>, slice<long>, slice<byte>> repl)
        {
            ref Regexp re = ref _addr_re.val;

            long lastMatchEnd = 0L; // end position of the most recent match
            long searchPos = 0L; // position where we next look for a match
            slice<byte> buf = default;
            long endPos = default;
            if (bsrc != null)
            {
                endPos = len(bsrc);
            }
            else
            {
                endPos = len(src);
            }

            if (nmatch > re.prog.NumCap)
            {
                nmatch = re.prog.NumCap;
            }

            array<long> dstCap = new array<long>(2L);
            while (searchPos <= endPos)
            {
                var a = re.doExecute(null, bsrc, src, searchPos, nmatch, dstCap[..0L]);
                if (len(a) == 0L)
                {
                    break; // no more matches
                } 

                // Copy the unmatched characters before this match.
                if (bsrc != null)
                {
                    buf = append(buf, bsrc[lastMatchEnd..a[0L]]);
                }
                else
                {
                    buf = append(buf, src[lastMatchEnd..a[0L]]);
                } 

                // Now insert a copy of the replacement string, but not for a
                // match of the empty string immediately after another match.
                // (Otherwise, we get double replacement for patterns that
                // match both empty and nonempty strings.)
                if (a[1L] > lastMatchEnd || a[0L] == 0L)
                {
                    buf = repl(buf, a);
                }

                lastMatchEnd = a[1L]; 

                // Advance past this match; always advance at least one character.
                long width = default;
                if (bsrc != null)
                {
                    _, width = utf8.DecodeRune(bsrc[searchPos..]);
                }
                else
                {
                    _, width = utf8.DecodeRuneInString(src[searchPos..]);
                }

                if (searchPos + width > a[1L])
                {
                    searchPos += width;
                }
                else if (searchPos + 1L > a[1L])
                { 
                    // This clause is only needed at the end of the input
                    // string. In that case, DecodeRuneInString returns width=0.
                    searchPos++;

                }
                else
                {
                    searchPos = a[1L];
                }

            } 

            // Copy the unmatched characters after the last match.
 

            // Copy the unmatched characters after the last match.
            if (bsrc != null)
            {
                buf = append(buf, bsrc[lastMatchEnd..]);
            }
            else
            {
                buf = append(buf, src[lastMatchEnd..]);
            }

            return buf;

        }

        // ReplaceAll returns a copy of src, replacing matches of the Regexp
        // with the replacement text repl. Inside repl, $ signs are interpreted as
        // in Expand, so for instance $1 represents the text of the first submatch.
        private static slice<byte> ReplaceAll(this ptr<Regexp> _addr_re, slice<byte> src, slice<byte> repl)
        {
            ref Regexp re = ref _addr_re.val;

            long n = 2L;
            if (bytes.IndexByte(repl, '$') >= 0L)
            {
                n = 2L * (re.numSubexp + 1L);
            }

            @string srepl = "";
            var b = re.replaceAll(src, "", n, (dst, match) =>
            {
                if (len(srepl) != len(repl))
                {
                    srepl = string(repl);
                }

                return re.expand(dst, srepl, src, "", match);

            });
            return b;

        }

        // ReplaceAllLiteral returns a copy of src, replacing matches of the Regexp
        // with the replacement bytes repl. The replacement repl is substituted directly,
        // without using Expand.
        private static slice<byte> ReplaceAllLiteral(this ptr<Regexp> _addr_re, slice<byte> src, slice<byte> repl)
        {
            ref Regexp re = ref _addr_re.val;

            return re.replaceAll(src, "", 2L, (dst, match) =>
            {
                return append(dst, repl);
            });

        }

        // ReplaceAllFunc returns a copy of src in which all matches of the
        // Regexp have been replaced by the return value of function repl applied
        // to the matched byte slice. The replacement returned by repl is substituted
        // directly, without using Expand.
        private static slice<byte> ReplaceAllFunc(this ptr<Regexp> _addr_re, slice<byte> src, Func<slice<byte>, slice<byte>> repl)
        {
            ref Regexp re = ref _addr_re.val;

            return re.replaceAll(src, "", 2L, (dst, match) =>
            {
                return append(dst, repl(src[match[0L]..match[1L]]));
            });

        }

        // Bitmap used by func special to check whether a character needs to be escaped.
        private static array<byte> specialBytes = new array<byte>(16L);

        // special reports whether byte b needs to be escaped by QuoteMeta.
        private static bool special(byte b)
        {
            return b < utf8.RuneSelf && specialBytes[b % 16L] & (1L << (int)((b / 16L))) != 0L;
        }

        private static void init()
        {
            foreach (var (_, b) in (slice<byte>)"\\.+*?()|[]{}^$")
            {
                specialBytes[b % 16L] |= 1L << (int)((b / 16L));
            }

        }

        // QuoteMeta returns a string that escapes all regular expression metacharacters
        // inside the argument text; the returned string is a regular expression matching
        // the literal text.
        public static @string QuoteMeta(@string s)
        { 
            // A byte loop is correct because all metacharacters are ASCII.
            long i = default;
            for (i = 0L; i < len(s); i++)
            {
                if (special(s[i]))
                {
                    break;
                }

            } 
            // No meta characters found, so return original string.
 
            // No meta characters found, so return original string.
            if (i >= len(s))
            {
                return s;
            }

            var b = make_slice<byte>(2L * len(s) - i);
            copy(b, s[..i]);
            var j = i;
            while (i < len(s))
            {
                if (special(s[i]))
                {
                    b[j] = '\\';
                    j++;
                i++;
                }

                b[j] = s[i];
                j++;

            }

            return string(b[..j]);

        }

        // The number of capture values in the program may correspond
        // to fewer capturing expressions than are in the regexp.
        // For example, "(a){0}" turns into an empty program, so the
        // maximum capture in the program is 0 but we need to return
        // an expression for \1.  Pad appends -1s to the slice a as needed.
        private static slice<long> pad(this ptr<Regexp> _addr_re, slice<long> a)
        {
            ref Regexp re = ref _addr_re.val;

            if (a == null)
            { 
                // No match.
                return null;

            }

            long n = (1L + re.numSubexp) * 2L;
            while (len(a) < n)
            {
                a = append(a, -1L);
            }

            return a;

        }

        // allMatches calls deliver at most n times
        // with the location of successive matches in the input text.
        // The input text is b if non-nil, otherwise s.
        private static void allMatches(this ptr<Regexp> _addr_re, @string s, slice<byte> b, long n, Action<slice<long>> deliver)
        {
            ref Regexp re = ref _addr_re.val;

            long end = default;
            if (b == null)
            {
                end = len(s);
            }
            else
            {
                end = len(b);
            }

            {
                long pos = 0L;
                long i = 0L;
                long prevMatchEnd = -1L;

                while (i < n && pos <= end)
                {
                    var matches = re.doExecute(null, b, s, pos, re.prog.NumCap, null);
                    if (len(matches) == 0L)
                    {
                        break;
                    }

                    var accept = true;
                    if (matches[1L] == pos)
                    { 
                        // We've found an empty match.
                        if (matches[0L] == prevMatchEnd)
                        { 
                            // We don't allow an empty match right
                            // after a previous match, so ignore it.
                            accept = false;

                        }

                        long width = default; 
                        // TODO: use step()
                        if (b == null)
                        {
                            _, width = utf8.DecodeRuneInString(s[pos..end]);
                        }
                        else
                        {
                            _, width = utf8.DecodeRune(b[pos..end]);
                        }

                        if (width > 0L)
                        {
                            pos += width;
                        }
                        else
                        {
                            pos = end + 1L;
                        }

                    }
                    else
                    {
                        pos = matches[1L];
                    }

                    prevMatchEnd = matches[1L];

                    if (accept)
                    {
                        deliver(re.pad(matches));
                        i++;
                    }

                }

            }

        }

        // Find returns a slice holding the text of the leftmost match in b of the regular expression.
        // A return value of nil indicates no match.
        private static slice<byte> Find(this ptr<Regexp> _addr_re, slice<byte> b)
        {
            ref Regexp re = ref _addr_re.val;

            array<long> dstCap = new array<long>(2L);
            var a = re.doExecute(null, b, "", 0L, 2L, dstCap[..0L]);
            if (a == null)
            {
                return null;
            }

            return b.slice(a[0L], a[1L], a[1L]);

        }

        // FindIndex returns a two-element slice of integers defining the location of
        // the leftmost match in b of the regular expression. The match itself is at
        // b[loc[0]:loc[1]].
        // A return value of nil indicates no match.
        private static slice<long> FindIndex(this ptr<Regexp> _addr_re, slice<byte> b)
        {
            slice<long> loc = default;
            ref Regexp re = ref _addr_re.val;

            var a = re.doExecute(null, b, "", 0L, 2L, null);
            if (a == null)
            {
                return null;
            }

            return a[0L..2L];

        }

        // FindString returns a string holding the text of the leftmost match in s of the regular
        // expression. If there is no match, the return value is an empty string,
        // but it will also be empty if the regular expression successfully matches
        // an empty string. Use FindStringIndex or FindStringSubmatch if it is
        // necessary to distinguish these cases.
        private static @string FindString(this ptr<Regexp> _addr_re, @string s)
        {
            ref Regexp re = ref _addr_re.val;

            array<long> dstCap = new array<long>(2L);
            var a = re.doExecute(null, null, s, 0L, 2L, dstCap[..0L]);
            if (a == null)
            {
                return "";
            }

            return s[a[0L]..a[1L]];

        }

        // FindStringIndex returns a two-element slice of integers defining the
        // location of the leftmost match in s of the regular expression. The match
        // itself is at s[loc[0]:loc[1]].
        // A return value of nil indicates no match.
        private static slice<long> FindStringIndex(this ptr<Regexp> _addr_re, @string s)
        {
            slice<long> loc = default;
            ref Regexp re = ref _addr_re.val;

            var a = re.doExecute(null, null, s, 0L, 2L, null);
            if (a == null)
            {
                return null;
            }

            return a[0L..2L];

        }

        // FindReaderIndex returns a two-element slice of integers defining the
        // location of the leftmost match of the regular expression in text read from
        // the RuneReader. The match text was found in the input stream at
        // byte offset loc[0] through loc[1]-1.
        // A return value of nil indicates no match.
        private static slice<long> FindReaderIndex(this ptr<Regexp> _addr_re, io.RuneReader r)
        {
            slice<long> loc = default;
            ref Regexp re = ref _addr_re.val;

            var a = re.doExecute(r, null, "", 0L, 2L, null);
            if (a == null)
            {
                return null;
            }

            return a[0L..2L];

        }

        // FindSubmatch returns a slice of slices holding the text of the leftmost
        // match of the regular expression in b and the matches, if any, of its
        // subexpressions, as defined by the 'Submatch' descriptions in the package
        // comment.
        // A return value of nil indicates no match.
        private static slice<slice<byte>> FindSubmatch(this ptr<Regexp> _addr_re, slice<byte> b)
        {
            ref Regexp re = ref _addr_re.val;

            array<long> dstCap = new array<long>(4L);
            var a = re.doExecute(null, b, "", 0L, re.prog.NumCap, dstCap[..0L]);
            if (a == null)
            {
                return null;
            }

            var ret = make_slice<slice<byte>>(1L + re.numSubexp);
            foreach (var (i) in ret)
            {
                if (2L * i < len(a) && a[2L * i] >= 0L)
                {
                    ret[i] = b.slice(a[2L * i], a[2L * i + 1L], a[2L * i + 1L]);
                }

            }
            return ret;

        }

        // Expand appends template to dst and returns the result; during the
        // append, Expand replaces variables in the template with corresponding
        // matches drawn from src. The match slice should have been returned by
        // FindSubmatchIndex.
        //
        // In the template, a variable is denoted by a substring of the form
        // $name or ${name}, where name is a non-empty sequence of letters,
        // digits, and underscores. A purely numeric name like $1 refers to
        // the submatch with the corresponding index; other names refer to
        // capturing parentheses named with the (?P<name>...) syntax. A
        // reference to an out of range or unmatched index or a name that is not
        // present in the regular expression is replaced with an empty slice.
        //
        // In the $name form, name is taken to be as long as possible: $1x is
        // equivalent to ${1x}, not ${1}x, and, $10 is equivalent to ${10}, not ${1}0.
        //
        // To insert a literal $ in the output, use $$ in the template.
        private static slice<byte> Expand(this ptr<Regexp> _addr_re, slice<byte> dst, slice<byte> template, slice<byte> src, slice<long> match)
        {
            ref Regexp re = ref _addr_re.val;

            return re.expand(dst, string(template), src, "", match);
        }

        // ExpandString is like Expand but the template and source are strings.
        // It appends to and returns a byte slice in order to give the calling
        // code control over allocation.
        private static slice<byte> ExpandString(this ptr<Regexp> _addr_re, slice<byte> dst, @string template, @string src, slice<long> match)
        {
            ref Regexp re = ref _addr_re.val;

            return re.expand(dst, template, null, src, match);
        }

        private static slice<byte> expand(this ptr<Regexp> _addr_re, slice<byte> dst, @string template, slice<byte> bsrc, @string src, slice<long> match)
        {
            ref Regexp re = ref _addr_re.val;

            while (len(template) > 0L)
            {
                var i = strings.Index(template, "$");
                if (i < 0L)
                {
                    break;
                }

                dst = append(dst, template[..i]);
                template = template[i..];
                if (len(template) > 1L && template[1L] == '$')
                { 
                    // Treat $$ as $.
                    dst = append(dst, '$');
                    template = template[2L..];
                    continue;

                }

                var (name, num, rest, ok) = extract(template);
                if (!ok)
                { 
                    // Malformed; treat $ as raw text.
                    dst = append(dst, '$');
                    template = template[1L..];
                    continue;

                }

                template = rest;
                if (num >= 0L)
                {
                    if (2L * num + 1L < len(match) && match[2L * num] >= 0L)
                    {
                        if (bsrc != null)
                        {
                            dst = append(dst, bsrc[match[2L * num]..match[2L * num + 1L]]);
                        }
                        else
                        {
                            dst = append(dst, src[match[2L * num]..match[2L * num + 1L]]);
                        }

                    }

                }
                else
                {
                    {
                        var i__prev2 = i;

                        foreach (var (__i, __namei) in re.subexpNames)
                        {
                            i = __i;
                            namei = __namei;
                            if (name == namei && 2L * i + 1L < len(match) && match[2L * i] >= 0L)
                            {
                                if (bsrc != null)
                                {
                                    dst = append(dst, bsrc[match[2L * i]..match[2L * i + 1L]]);
                                }
                                else
                                {
                                    dst = append(dst, src[match[2L * i]..match[2L * i + 1L]]);
                                }

                                break;

                            }

                        }

                        i = i__prev2;
                    }
                }

            }

            dst = append(dst, template);
            return dst;

        }

        // extract returns the name from a leading "$name" or "${name}" in str.
        // If it is a number, extract returns num set to that number; otherwise num = -1.
        private static (@string, long, @string, bool) extract(@string str)
        {
            @string name = default;
            long num = default;
            @string rest = default;
            bool ok = default;

            if (len(str) < 2L || str[0L] != '$')
            {
                return ;
            }

            var brace = false;
            if (str[1L] == '{')
            {
                brace = true;
                str = str[2L..];
            }
            else
            {
                str = str[1L..];
            }

            long i = 0L;
            while (i < len(str))
            {
                var (rune, size) = utf8.DecodeRuneInString(str[i..]);
                if (!unicode.IsLetter(rune) && !unicode.IsDigit(rune) && rune != '_')
                {
                    break;
                }

                i += size;

            }

            if (i == 0L)
            { 
                // empty name is not okay
                return ;

            }

            name = str[..i];
            if (brace)
            {
                if (i >= len(str) || str[i] != '}')
                { 
                    // missing closing brace
                    return ;

                }

                i++;

            } 

            // Parse number.
            num = 0L;
            {
                long i__prev1 = i;

                for (i = 0L; i < len(name); i++)
                {
                    if (name[i] < '0' || '9' < name[i] || num >= 1e8F)
                    {
                        num = -1L;
                        break;
                    }

                    num = num * 10L + int(name[i]) - '0';

                } 
                // Disallow leading zeros.


                i = i__prev1;
            } 
            // Disallow leading zeros.
            if (name[0L] == '0' && len(name) > 1L)
            {
                num = -1L;
            }

            rest = str[i..];
            ok = true;
            return ;

        }

        // FindSubmatchIndex returns a slice holding the index pairs identifying the
        // leftmost match of the regular expression in b and the matches, if any, of
        // its subexpressions, as defined by the 'Submatch' and 'Index' descriptions
        // in the package comment.
        // A return value of nil indicates no match.
        private static slice<long> FindSubmatchIndex(this ptr<Regexp> _addr_re, slice<byte> b)
        {
            ref Regexp re = ref _addr_re.val;

            return re.pad(re.doExecute(null, b, "", 0L, re.prog.NumCap, null));
        }

        // FindStringSubmatch returns a slice of strings holding the text of the
        // leftmost match of the regular expression in s and the matches, if any, of
        // its subexpressions, as defined by the 'Submatch' description in the
        // package comment.
        // A return value of nil indicates no match.
        private static slice<@string> FindStringSubmatch(this ptr<Regexp> _addr_re, @string s)
        {
            ref Regexp re = ref _addr_re.val;

            array<long> dstCap = new array<long>(4L);
            var a = re.doExecute(null, null, s, 0L, re.prog.NumCap, dstCap[..0L]);
            if (a == null)
            {
                return null;
            }

            var ret = make_slice<@string>(1L + re.numSubexp);
            foreach (var (i) in ret)
            {
                if (2L * i < len(a) && a[2L * i] >= 0L)
                {
                    ret[i] = s[a[2L * i]..a[2L * i + 1L]];
                }

            }
            return ret;

        }

        // FindStringSubmatchIndex returns a slice holding the index pairs
        // identifying the leftmost match of the regular expression in s and the
        // matches, if any, of its subexpressions, as defined by the 'Submatch' and
        // 'Index' descriptions in the package comment.
        // A return value of nil indicates no match.
        private static slice<long> FindStringSubmatchIndex(this ptr<Regexp> _addr_re, @string s)
        {
            ref Regexp re = ref _addr_re.val;

            return re.pad(re.doExecute(null, null, s, 0L, re.prog.NumCap, null));
        }

        // FindReaderSubmatchIndex returns a slice holding the index pairs
        // identifying the leftmost match of the regular expression of text read by
        // the RuneReader, and the matches, if any, of its subexpressions, as defined
        // by the 'Submatch' and 'Index' descriptions in the package comment. A
        // return value of nil indicates no match.
        private static slice<long> FindReaderSubmatchIndex(this ptr<Regexp> _addr_re, io.RuneReader r)
        {
            ref Regexp re = ref _addr_re.val;

            return re.pad(re.doExecute(r, null, "", 0L, re.prog.NumCap, null));
        }

        private static readonly long startSize = (long)10L; // The size at which to start a slice in the 'All' routines.

        // FindAll is the 'All' version of Find; it returns a slice of all successive
        // matches of the expression, as defined by the 'All' description in the
        // package comment.
        // A return value of nil indicates no match.
 // The size at which to start a slice in the 'All' routines.

        // FindAll is the 'All' version of Find; it returns a slice of all successive
        // matches of the expression, as defined by the 'All' description in the
        // package comment.
        // A return value of nil indicates no match.
        private static slice<slice<byte>> FindAll(this ptr<Regexp> _addr_re, slice<byte> b, long n)
        {
            ref Regexp re = ref _addr_re.val;

            if (n < 0L)
            {
                n = len(b) + 1L;
            }

            slice<slice<byte>> result = default;
            re.allMatches("", b, n, match =>
            {
                if (result == null)
                {
                    result = make_slice<slice<byte>>(0L, startSize);
                }

                result = append(result, b.slice(match[0L], match[1L], match[1L]));

            });
            return result;

        }

        // FindAllIndex is the 'All' version of FindIndex; it returns a slice of all
        // successive matches of the expression, as defined by the 'All' description
        // in the package comment.
        // A return value of nil indicates no match.
        private static slice<slice<long>> FindAllIndex(this ptr<Regexp> _addr_re, slice<byte> b, long n)
        {
            ref Regexp re = ref _addr_re.val;

            if (n < 0L)
            {
                n = len(b) + 1L;
            }

            slice<slice<long>> result = default;
            re.allMatches("", b, n, match =>
            {
                if (result == null)
                {
                    result = make_slice<slice<long>>(0L, startSize);
                }

                result = append(result, match[0L..2L]);

            });
            return result;

        }

        // FindAllString is the 'All' version of FindString; it returns a slice of all
        // successive matches of the expression, as defined by the 'All' description
        // in the package comment.
        // A return value of nil indicates no match.
        private static slice<@string> FindAllString(this ptr<Regexp> _addr_re, @string s, long n)
        {
            ref Regexp re = ref _addr_re.val;

            if (n < 0L)
            {
                n = len(s) + 1L;
            }

            slice<@string> result = default;
            re.allMatches(s, null, n, match =>
            {
                if (result == null)
                {
                    result = make_slice<@string>(0L, startSize);
                }

                result = append(result, s[match[0L]..match[1L]]);

            });
            return result;

        }

        // FindAllStringIndex is the 'All' version of FindStringIndex; it returns a
        // slice of all successive matches of the expression, as defined by the 'All'
        // description in the package comment.
        // A return value of nil indicates no match.
        private static slice<slice<long>> FindAllStringIndex(this ptr<Regexp> _addr_re, @string s, long n)
        {
            ref Regexp re = ref _addr_re.val;

            if (n < 0L)
            {
                n = len(s) + 1L;
            }

            slice<slice<long>> result = default;
            re.allMatches(s, null, n, match =>
            {
                if (result == null)
                {
                    result = make_slice<slice<long>>(0L, startSize);
                }

                result = append(result, match[0L..2L]);

            });
            return result;

        }

        // FindAllSubmatch is the 'All' version of FindSubmatch; it returns a slice
        // of all successive matches of the expression, as defined by the 'All'
        // description in the package comment.
        // A return value of nil indicates no match.
        private static slice<slice<slice<byte>>> FindAllSubmatch(this ptr<Regexp> _addr_re, slice<byte> b, long n)
        {
            ref Regexp re = ref _addr_re.val;

            if (n < 0L)
            {
                n = len(b) + 1L;
            }

            slice<slice<slice<byte>>> result = default;
            re.allMatches("", b, n, match =>
            {
                if (result == null)
                {
                    result = make_slice<slice<slice<byte>>>(0L, startSize);
                }

                var slice = make_slice<slice<byte>>(len(match) / 2L);
                foreach (var (j) in slice)
                {
                    if (match[2L * j] >= 0L)
                    {
                        slice[j] = b.slice(match[2L * j], match[2L * j + 1L], match[2L * j + 1L]);
                    }

                }
                result = append(result, slice);

            });
            return result;

        }

        // FindAllSubmatchIndex is the 'All' version of FindSubmatchIndex; it returns
        // a slice of all successive matches of the expression, as defined by the
        // 'All' description in the package comment.
        // A return value of nil indicates no match.
        private static slice<slice<long>> FindAllSubmatchIndex(this ptr<Regexp> _addr_re, slice<byte> b, long n)
        {
            ref Regexp re = ref _addr_re.val;

            if (n < 0L)
            {
                n = len(b) + 1L;
            }

            slice<slice<long>> result = default;
            re.allMatches("", b, n, match =>
            {
                if (result == null)
                {
                    result = make_slice<slice<long>>(0L, startSize);
                }

                result = append(result, match);

            });
            return result;

        }

        // FindAllStringSubmatch is the 'All' version of FindStringSubmatch; it
        // returns a slice of all successive matches of the expression, as defined by
        // the 'All' description in the package comment.
        // A return value of nil indicates no match.
        private static slice<slice<@string>> FindAllStringSubmatch(this ptr<Regexp> _addr_re, @string s, long n)
        {
            ref Regexp re = ref _addr_re.val;

            if (n < 0L)
            {
                n = len(s) + 1L;
            }

            slice<slice<@string>> result = default;
            re.allMatches(s, null, n, match =>
            {
                if (result == null)
                {
                    result = make_slice<slice<@string>>(0L, startSize);
                }

                var slice = make_slice<@string>(len(match) / 2L);
                foreach (var (j) in slice)
                {
                    if (match[2L * j] >= 0L)
                    {
                        slice[j] = s[match[2L * j]..match[2L * j + 1L]];
                    }

                }
                result = append(result, slice);

            });
            return result;

        }

        // FindAllStringSubmatchIndex is the 'All' version of
        // FindStringSubmatchIndex; it returns a slice of all successive matches of
        // the expression, as defined by the 'All' description in the package
        // comment.
        // A return value of nil indicates no match.
        private static slice<slice<long>> FindAllStringSubmatchIndex(this ptr<Regexp> _addr_re, @string s, long n)
        {
            ref Regexp re = ref _addr_re.val;

            if (n < 0L)
            {
                n = len(s) + 1L;
            }

            slice<slice<long>> result = default;
            re.allMatches(s, null, n, match =>
            {
                if (result == null)
                {
                    result = make_slice<slice<long>>(0L, startSize);
                }

                result = append(result, match);

            });
            return result;

        }

        // Split slices s into substrings separated by the expression and returns a slice of
        // the substrings between those expression matches.
        //
        // The slice returned by this method consists of all the substrings of s
        // not contained in the slice returned by FindAllString. When called on an expression
        // that contains no metacharacters, it is equivalent to strings.SplitN.
        //
        // Example:
        //   s := regexp.MustCompile("a*").Split("abaabaccadaaae", 5)
        //   // s: ["", "b", "b", "c", "cadaaae"]
        //
        // The count determines the number of substrings to return:
        //   n > 0: at most n substrings; the last substring will be the unsplit remainder.
        //   n == 0: the result is nil (zero substrings)
        //   n < 0: all substrings
        private static slice<@string> Split(this ptr<Regexp> _addr_re, @string s, long n)
        {
            ref Regexp re = ref _addr_re.val;

            if (n == 0L)
            {
                return null;
            }

            if (len(re.expr) > 0L && len(s) == 0L)
            {
                return new slice<@string>(new @string[] { "" });
            }

            var matches = re.FindAllStringIndex(s, n);
            var strings = make_slice<@string>(0L, len(matches));

            long beg = 0L;
            long end = 0L;
            foreach (var (_, match) in matches)
            {
                if (n > 0L && len(strings) >= n - 1L)
                {
                    break;
                }

                end = match[0L];
                if (match[1L] != 0L)
                {
                    strings = append(strings, s[beg..end]);
                }

                beg = match[1L];

            }
            if (end != len(s))
            {
                strings = append(strings, s[beg..]);
            }

            return strings;

        }
    }
}
