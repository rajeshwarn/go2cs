// Copyright 2018 The Go Authors. All rights reserved.
// Use of this source code is governed by a BSD-style
// license that can be found in the LICENSE file.

// package objabi -- go2cs converted at 2020 October 09 05:08:52 UTC
// import "cmd/internal/objabi" ==> using objabi = go.cmd.@internal.objabi_package
// Original source: C:\Go\src\cmd\internal\objabi\funcid.go
using strconv = go.strconv_package;
using strings = go.strings_package;
using static go.builtin;

namespace go {
namespace cmd {
namespace @internal
{
    public static partial class objabi_package
    {
        // A FuncID identifies particular functions that need to be treated
        // specially by the runtime.
        // Note that in some situations involving plugins, there may be multiple
        // copies of a particular special runtime function.
        // Note: this list must match the list in runtime/symtab.go.
        public partial struct FuncID // : byte
        {
        }

        public static readonly FuncID FuncID_normal = (FuncID)iota; // not a special function
        public static readonly var FuncID_runtime_main = 0;
        public static readonly var FuncID_goexit = 1;
        public static readonly var FuncID_jmpdefer = 2;
        public static readonly var FuncID_mcall = 3;
        public static readonly var FuncID_morestack = 4;
        public static readonly var FuncID_mstart = 5;
        public static readonly var FuncID_rt0_go = 6;
        public static readonly var FuncID_asmcgocall = 7;
        public static readonly var FuncID_sigpanic = 8;
        public static readonly var FuncID_runfinq = 9;
        public static readonly var FuncID_gcBgMarkWorker = 10;
        public static readonly var FuncID_systemstack_switch = 11;
        public static readonly var FuncID_systemstack = 12;
        public static readonly var FuncID_cgocallback_gofunc = 13;
        public static readonly var FuncID_gogo = 14;
        public static readonly var FuncID_externalthreadhandler = 15;
        public static readonly var FuncID_debugCallV1 = 16;
        public static readonly var FuncID_gopanic = 17;
        public static readonly var FuncID_panicwrap = 18;
        public static readonly var FuncID_handleAsyncEvent = 19;
        public static readonly var FuncID_asyncPreempt = 20;
        public static readonly var FuncID_wrapper = 21; // any autogenerated code (hash/eq algorithms, method wrappers, etc.)

        // Get the function ID for the named function in the named file.
        // The function should be package-qualified.
        public static FuncID GetFuncID(@string name, @string file)
        {
            switch (name)
            {
                case "runtime.main": 
                    return FuncID_runtime_main;
                    break;
                case "runtime.goexit": 
                    return FuncID_goexit;
                    break;
                case "runtime.jmpdefer": 
                    return FuncID_jmpdefer;
                    break;
                case "runtime.mcall": 
                    return FuncID_mcall;
                    break;
                case "runtime.morestack": 
                    return FuncID_morestack;
                    break;
                case "runtime.mstart": 
                    return FuncID_mstart;
                    break;
                case "runtime.rt0_go": 
                    return FuncID_rt0_go;
                    break;
                case "runtime.asmcgocall": 
                    return FuncID_asmcgocall;
                    break;
                case "runtime.sigpanic": 
                    return FuncID_sigpanic;
                    break;
                case "runtime.runfinq": 
                    return FuncID_runfinq;
                    break;
                case "runtime.gcBgMarkWorker": 
                    return FuncID_gcBgMarkWorker;
                    break;
                case "runtime.systemstack_switch": 
                    return FuncID_systemstack_switch;
                    break;
                case "runtime.systemstack": 
                    return FuncID_systemstack;
                    break;
                case "runtime.cgocallback_gofunc": 
                    return FuncID_cgocallback_gofunc;
                    break;
                case "runtime.gogo": 
                    return FuncID_gogo;
                    break;
                case "runtime.externalthreadhandler": 
                    return FuncID_externalthreadhandler;
                    break;
                case "runtime.debugCallV1": 
                    return FuncID_debugCallV1;
                    break;
                case "runtime.gopanic": 
                    return FuncID_gopanic;
                    break;
                case "runtime.panicwrap": 
                    return FuncID_panicwrap;
                    break;
                case "runtime.handleAsyncEvent": 
                    return FuncID_handleAsyncEvent;
                    break;
                case "runtime.asyncPreempt": 
                    return FuncID_asyncPreempt;
                    break;
                case "runtime.deferreturn": 
                    // Don't show in the call stack (used when invoking defer functions)
                    return FuncID_wrapper;
                    break;
                case "runtime.runOpenDeferFrame": 
                    // Don't show in the call stack (used when invoking defer functions)
                    return FuncID_wrapper;
                    break;
                case "runtime.reflectcallSave": 
                    // Don't show in the call stack (used when invoking defer functions)
                    return FuncID_wrapper;
                    break;
            }
            if (file == "<autogenerated>")
            {
                return FuncID_wrapper;
            }

            if (strings.HasPrefix(name, "runtime.call"))
            {
                {
                    var (_, err) = strconv.Atoi(name[12L..]);

                    if (err == null)
                    { 
                        // runtime.callXX reflect call wrappers.
                        return FuncID_wrapper;

                    }

                }

            }

            if (strings.HasSuffix(name, "-fm"))
            {
                return FuncID_wrapper;
            }

            return FuncID_normal;

        }
    }
}}}
