// Copyright 2012 The Go Authors. All rights reserved.
// Use of this source code is governed by a BSD-style
// license that can be found in the LICENSE file.

// package main -- go2cs converted at 2020 October 09 05:44:32 UTC
// Original source: C:\Go\src\cmd\dist\buildruntime.go
using bytes = go.bytes_package;
using fmt = go.fmt_package;
using os = go.os_package;
using strings = go.strings_package;
using static go.builtin;

namespace go
{
    public static partial class main_package
    {
        /*
         * Helpers for building runtime.
         */

        // mkzversion writes zversion.go:
        //
        //    package sys
        //
        //    const TheVersion = <version>
        //    const Goexperiment = <goexperiment>
        //    const StackGuardMultiplier = <multiplier value>
        //
        private static void mkzversion(@string dir, @string file)
        {
            ref bytes.Buffer buf = ref heap(out ptr<bytes.Buffer> _addr_buf);
            fmt.Fprintf(_addr_buf, "// Code generated by go tool dist; DO NOT EDIT.\n");
            fmt.Fprintln(_addr_buf);
            fmt.Fprintf(_addr_buf, "package sys\n");
            fmt.Fprintln(_addr_buf);
            fmt.Fprintf(_addr_buf, "const TheVersion = `%s`\n", findgoversion());
            fmt.Fprintf(_addr_buf, "const Goexperiment = `%s`\n", os.Getenv("GOEXPERIMENT"));
            fmt.Fprintf(_addr_buf, "const StackGuardMultiplierDefault = %d\n", stackGuardMultiplierDefault());

            writefile(buf.String(), file, writeSkipSame);
        }

        // mkzbootstrap writes cmd/internal/objabi/zbootstrap.go:
        //
        //    package objabi
        //
        //    const defaultGOROOT = <goroot>
        //    const defaultGO386 = <go386>
        //    const defaultGOARM = <goarm>
        //    const defaultGOMIPS = <gomips>
        //    const defaultGOMIPS64 = <gomips64>
        //    const defaultGOPPC64 = <goppc64>
        //    const defaultGOOS = runtime.GOOS
        //    const defaultGOARCH = runtime.GOARCH
        //    const defaultGO_EXTLINK_ENABLED = <goextlinkenabled>
        //    const version = <version>
        //    const stackGuardMultiplierDefault = <multiplier value>
        //    const goexperiment = <goexperiment>
        //
        // The use of runtime.GOOS and runtime.GOARCH makes sure that
        // a cross-compiled compiler expects to compile for its own target
        // system. That is, if on a Mac you do:
        //
        //    GOOS=linux GOARCH=ppc64 go build cmd/compile
        //
        // the resulting compiler will default to generating linux/ppc64 object files.
        // This is more useful than having it default to generating objects for the
        // original target (in this example, a Mac).
        private static void mkzbootstrap(@string file)
        {
            ref bytes.Buffer buf = ref heap(out ptr<bytes.Buffer> _addr_buf);
            fmt.Fprintf(_addr_buf, "// Code generated by go tool dist; DO NOT EDIT.\n");
            fmt.Fprintln(_addr_buf);
            fmt.Fprintf(_addr_buf, "package objabi\n");
            fmt.Fprintln(_addr_buf);
            fmt.Fprintf(_addr_buf, "import \"runtime\"\n");
            fmt.Fprintln(_addr_buf);
            fmt.Fprintf(_addr_buf, "const defaultGO386 = `%s`\n", go386);
            fmt.Fprintf(_addr_buf, "const defaultGOARM = `%s`\n", goarm);
            fmt.Fprintf(_addr_buf, "const defaultGOMIPS = `%s`\n", gomips);
            fmt.Fprintf(_addr_buf, "const defaultGOMIPS64 = `%s`\n", gomips64);
            fmt.Fprintf(_addr_buf, "const defaultGOPPC64 = `%s`\n", goppc64);
            fmt.Fprintf(_addr_buf, "const defaultGOOS = runtime.GOOS\n");
            fmt.Fprintf(_addr_buf, "const defaultGOARCH = runtime.GOARCH\n");
            fmt.Fprintf(_addr_buf, "const defaultGO_EXTLINK_ENABLED = `%s`\n", goextlinkenabled);
            fmt.Fprintf(_addr_buf, "const defaultGO_LDSO = `%s`\n", defaultldso);
            fmt.Fprintf(_addr_buf, "const version = `%s`\n", findgoversion());
            fmt.Fprintf(_addr_buf, "const stackGuardMultiplierDefault = %d\n", stackGuardMultiplierDefault());
            fmt.Fprintf(_addr_buf, "const goexperiment = `%s`\n", os.Getenv("GOEXPERIMENT"));

            writefile(buf.String(), file, writeSkipSame);
        }

        // stackGuardMultiplierDefault returns a multiplier to apply to the default
        // stack guard size. Larger multipliers are used for non-optimized
        // builds that have larger stack frames.
        private static long stackGuardMultiplierDefault()
        {
            foreach (var (_, s) in strings.Split(os.Getenv("GO_GCFLAGS"), " "))
            {
                if (s == "-N")
                {
                    return 2L;
                }

            }
            return 1L;

        }
    }
}
