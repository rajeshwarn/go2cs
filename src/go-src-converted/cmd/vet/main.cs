// package main -- go2cs converted at 2020 October 09 06:05:08 UTC
// Original source: C:\Go\src\cmd\vet\main.go
using objabi = go.cmd.@internal.objabi_package;

using unitchecker = go.golang.org.x.tools.go.analysis.unitchecker_package;

using asmdecl = go.golang.org.x.tools.go.analysis.passes.asmdecl_package;
using assign = go.golang.org.x.tools.go.analysis.passes.assign_package;
using atomic = go.golang.org.x.tools.go.analysis.passes.atomic_package;
using bools = go.golang.org.x.tools.go.analysis.passes.bools_package;
using buildtag = go.golang.org.x.tools.go.analysis.passes.buildtag_package;
using cgocall = go.golang.org.x.tools.go.analysis.passes.cgocall_package;
using composite = go.golang.org.x.tools.go.analysis.passes.composite_package;
using copylock = go.golang.org.x.tools.go.analysis.passes.copylock_package;
using errorsas = go.golang.org.x.tools.go.analysis.passes.errorsas_package;
using httpresponse = go.golang.org.x.tools.go.analysis.passes.httpresponse_package;
using ifaceassert = go.golang.org.x.tools.go.analysis.passes.ifaceassert_package;
using loopclosure = go.golang.org.x.tools.go.analysis.passes.loopclosure_package;
using lostcancel = go.golang.org.x.tools.go.analysis.passes.lostcancel_package;
using nilfunc = go.golang.org.x.tools.go.analysis.passes.nilfunc_package;
using printf = go.golang.org.x.tools.go.analysis.passes.printf_package;
using shift = go.golang.org.x.tools.go.analysis.passes.shift_package;
using stdmethods = go.golang.org.x.tools.go.analysis.passes.stdmethods_package;
using stringintconv = go.golang.org.x.tools.go.analysis.passes.stringintconv_package;
using structtag = go.golang.org.x.tools.go.analysis.passes.structtag_package;
using tests = go.golang.org.x.tools.go.analysis.passes.tests_package;
using unmarshal = go.golang.org.x.tools.go.analysis.passes.unmarshal_package;
using unreachable = go.golang.org.x.tools.go.analysis.passes.unreachable_package;
using unsafeptr = go.golang.org.x.tools.go.analysis.passes.unsafeptr_package;
using unusedresult = go.golang.org.x.tools.go.analysis.passes.unusedresult_package;
using static go.builtin;

namespace go
{
    public static partial class main_package
    {
        private static void Main()
        {
            objabi.AddVersionFlag();

            unitchecker.Main(asmdecl.Analyzer, assign.Analyzer, atomic.Analyzer, bools.Analyzer, buildtag.Analyzer, cgocall.Analyzer, composite.Analyzer, copylock.Analyzer, errorsas.Analyzer, httpresponse.Analyzer, ifaceassert.Analyzer, loopclosure.Analyzer, lostcancel.Analyzer, nilfunc.Analyzer, printf.Analyzer, shift.Analyzer, stdmethods.Analyzer, stringintconv.Analyzer, structtag.Analyzer, tests.Analyzer, unmarshal.Analyzer, unreachable.Analyzer, unsafeptr.Analyzer, unusedresult.Analyzer);
        }
    }
}
