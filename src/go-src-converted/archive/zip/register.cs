// Copyright 2010 The Go Authors. All rights reserved.
// Use of this source code is governed by a BSD-style
// license that can be found in the LICENSE file.

// package zip -- go2cs converted at 2020 October 09 05:08:10 UTC
// import "archive/zip" ==> using zip = go.archive.zip_package
// Original source: C:\Go\src\archive\zip\register.go
using flate = go.compress.flate_package;
using errors = go.errors_package;
using io = go.io_package;
using ioutil = go.io.ioutil_package;
using sync = go.sync_package;
using static go.builtin;
using System;

namespace go {
namespace archive
{
    public static partial class zip_package
    {
        // A Compressor returns a new compressing writer, writing to w.
        // The WriteCloser's Close method must be used to flush pending data to w.
        // The Compressor itself must be safe to invoke from multiple goroutines
        // simultaneously, but each returned writer will be used only by
        // one goroutine at a time.
        public delegate  error) Compressor(io.Writer,  (io.WriteCloser);

        // A Decompressor returns a new decompressing reader, reading from r.
        // The ReadCloser's Close method must be used to release associated resources.
        // The Decompressor itself must be safe to invoke from multiple goroutines
        // simultaneously, but each returned reader will be used only by
        // one goroutine at a time.
        public delegate  io.ReadCloser Decompressor(io.Reader);

        private static sync.Pool flateWriterPool = default;

        private static io.WriteCloser newFlateWriter(io.Writer w)
        {
            ptr<flate.Writer> (fw, ok) = flateWriterPool.Get()._<ptr<flate.Writer>>();
            if (ok)
            {
                fw.Reset(w);
            }
            else
            {
                fw, _ = flate.NewWriter(w, 5L);
            }

            return addr(new pooledFlateWriter(fw:fw));

        }

        private partial struct pooledFlateWriter
        {
            public sync.Mutex mu; // guards Close and Write
            public ptr<flate.Writer> fw;
        }

        private static (long, error) Write(this ptr<pooledFlateWriter> _addr_w, slice<byte> p) => func((defer, _, __) =>
        {
            long n = default;
            error err = default!;
            ref pooledFlateWriter w = ref _addr_w.val;

            w.mu.Lock();
            defer(w.mu.Unlock());
            if (w.fw == null)
            {
                return (0L, error.As(errors.New("Write after Close"))!);
            }

            return w.fw.Write(p);

        });

        private static error Close(this ptr<pooledFlateWriter> _addr_w) => func((defer, _, __) =>
        {
            ref pooledFlateWriter w = ref _addr_w.val;

            w.mu.Lock();
            defer(w.mu.Unlock());
            error err = default!;
            if (w.fw != null)
            {
                err = error.As(w.fw.Close())!;
                flateWriterPool.Put(w.fw);
                w.fw = null;
            }

            return error.As(err)!;

        });

        private static sync.Pool flateReaderPool = default;

        private static io.ReadCloser newFlateReader(io.Reader r)
        {
            io.ReadCloser (fr, ok) = flateReaderPool.Get()._<io.ReadCloser>();
            if (ok)
            {
                fr._<flate.Resetter>().Reset(r, null);
            }
            else
            {
                fr = flate.NewReader(r);
            }

            return addr(new pooledFlateReader(fr:fr));

        }

        private partial struct pooledFlateReader
        {
            public sync.Mutex mu; // guards Close and Read
            public io.ReadCloser fr;
        }

        private static (long, error) Read(this ptr<pooledFlateReader> _addr_r, slice<byte> p) => func((defer, _, __) =>
        {
            long n = default;
            error err = default!;
            ref pooledFlateReader r = ref _addr_r.val;

            r.mu.Lock();
            defer(r.mu.Unlock());
            if (r.fr == null)
            {
                return (0L, error.As(errors.New("Read after Close"))!);
            }

            return r.fr.Read(p);

        });

        private static error Close(this ptr<pooledFlateReader> _addr_r) => func((defer, _, __) =>
        {
            ref pooledFlateReader r = ref _addr_r.val;

            r.mu.Lock();
            defer(r.mu.Unlock());
            error err = default!;
            if (r.fr != null)
            {
                err = error.As(r.fr.Close())!;
                flateReaderPool.Put(r.fr);
                r.fr = null;
            }

            return error.As(err)!;

        });

        private static sync.Map compressors = default;        private static sync.Map decompressors = default;

        private static void init()
        {
            compressors.Store(Store, Compressor(w => (addr(new nopCloser(w)), null)));
            compressors.Store(Deflate, Compressor(w => (newFlateWriter(w), null)));

            decompressors.Store(Store, Decompressor(ioutil.NopCloser));
            decompressors.Store(Deflate, Decompressor(newFlateReader));
        }

        // RegisterDecompressor allows custom decompressors for a specified method ID.
        // The common methods Store and Deflate are built in.
        public static void RegisterDecompressor(ushort method, Decompressor dcomp) => func((_, panic, __) =>
        {
            {
                var (_, dup) = decompressors.LoadOrStore(method, dcomp);

                if (dup)
                {
                    panic("decompressor already registered");
                }

            }

        });

        // RegisterCompressor registers custom compressors for a specified method ID.
        // The common methods Store and Deflate are built in.
        public static void RegisterCompressor(ushort method, Compressor comp) => func((_, panic, __) =>
        {
            {
                var (_, dup) = compressors.LoadOrStore(method, comp);

                if (dup)
                {
                    panic("compressor already registered");
                }

            }

        });

        private static Compressor compressor(ushort method)
        {
            var (ci, ok) = compressors.Load(method);
            if (!ok)
            {
                return null;
            }

            return ci._<Compressor>();

        }

        private static Decompressor decompressor(ushort method)
        {
            var (di, ok) = decompressors.Load(method);
            if (!ok)
            {
                return null;
            }

            return di._<Decompressor>();

        }
    }
}}
