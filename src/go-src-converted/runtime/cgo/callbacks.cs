// Copyright 2011 The Go Authors. All rights reserved.
// Use of this source code is governed by a BSD-style
// license that can be found in the LICENSE file.

// package cgo -- go2cs converted at 2020 August 29 08:21:41 UTC
// import "runtime/cgo" ==> using cgo = go.runtime.cgo_package
// Original source: C:\Go\src\runtime\cgo\callbacks.go
using @unsafe = go.@unsafe_package;
using static go.builtin;

namespace go {
namespace runtime
{
    public static partial class cgo_package
    {
        // These utility functions are available to be called from code
        // compiled with gcc via crosscall2.

        // cgocallback is defined in runtime
        //go:linkname _runtime_cgocallback runtime.cgocallback
        private static void _runtime_cgocallback(unsafe.Pointer _p0, unsafe.Pointer _p0, System.UIntPtr _p0, System.UIntPtr _p0)
;

        // The declaration of crosscall2 is:
        //   void crosscall2(void (*fn)(void *, int), void *, int);
        //
        // We need to export the symbol crosscall2 in order to support
        // callbacks from shared libraries. This applies regardless of
        // linking mode.
        //
        // Compatibility note: crosscall2 actually takes four arguments, but
        // it works to call it with three arguments when calling _cgo_panic.
        // That is supported for backward compatibility.
        //go:cgo_export_static crosscall2
        //go:cgo_export_dynamic crosscall2

        // Panic. The argument is converted into a Go string.

        // Call like this in code compiled with gcc:
        //   struct { const char *p; } a;
        //   a.p = /* string to pass to panic */;
        //   crosscall2(_cgo_panic, &a, sizeof a);
        //   /* The function call will not return.  */

        //go:linkname _runtime_cgo_panic_internal runtime._cgo_panic_internal
        private static byte _runtime_cgo_panic_internal = default;

        //go:linkname _cgo_panic _cgo_panic
        //go:cgo_export_static _cgo_panic
        //go:cgo_export_dynamic _cgo_panic
        //go:nosplit
        //go:norace
        private static void _cgo_panic(unsafe.Pointer a, int n)
        {
            _runtime_cgocallback(@unsafe.Pointer(ref _runtime_cgo_panic_internal), a, uintptr(n), 0L);
        }

        //go:cgo_import_static x_cgo_init
        //go:linkname x_cgo_init x_cgo_init
        //go:linkname _cgo_init _cgo_init
        private static byte x_cgo_init = default;
        private static var _cgo_init = ref x_cgo_init;

        //go:cgo_import_static x_cgo_thread_start
        //go:linkname x_cgo_thread_start x_cgo_thread_start
        //go:linkname _cgo_thread_start _cgo_thread_start
        private static byte x_cgo_thread_start = default;
        private static var _cgo_thread_start = ref x_cgo_thread_start;

        // Creates a new system thread without updating any Go state.
        //
        // This method is invoked during shared library loading to create a new OS
        // thread to perform the runtime initialization. This method is similar to
        // _cgo_sys_thread_start except that it doesn't update any Go state.

        //go:cgo_import_static x_cgo_sys_thread_create
        //go:linkname x_cgo_sys_thread_create x_cgo_sys_thread_create
        //go:linkname _cgo_sys_thread_create _cgo_sys_thread_create
        private static byte x_cgo_sys_thread_create = default;
        private static var _cgo_sys_thread_create = ref x_cgo_sys_thread_create;

        // Notifies that the runtime has been initialized.
        //
        // We currently block at every CGO entry point (via _cgo_wait_runtime_init_done)
        // to ensure that the runtime has been initialized before the CGO call is
        // executed. This is necessary for shared libraries where we kickoff runtime
        // initialization in a separate thread and return without waiting for this
        // thread to complete the init.

        //go:cgo_import_static x_cgo_notify_runtime_init_done
        //go:linkname x_cgo_notify_runtime_init_done x_cgo_notify_runtime_init_done
        //go:linkname _cgo_notify_runtime_init_done _cgo_notify_runtime_init_done
        private static byte x_cgo_notify_runtime_init_done = default;
        private static var _cgo_notify_runtime_init_done = ref x_cgo_notify_runtime_init_done;

        // Sets the traceback context function. See runtime.SetCgoTraceback.

        //go:cgo_import_static x_cgo_set_context_function
        //go:linkname x_cgo_set_context_function x_cgo_set_context_function
        //go:linkname _cgo_set_context_function _cgo_set_context_function
        private static byte x_cgo_set_context_function = default;
        private static var _cgo_set_context_function = ref x_cgo_set_context_function;

        // Calls a libc function to execute background work injected via libc
        // interceptors, such as processing pending signals under the thread
        // sanitizer.
        //
        // Left as a nil pointer if no libc interceptors are expected.

        //go:cgo_import_static _cgo_yield
        //go:linkname _cgo_yield _cgo_yield
        private static unsafe.Pointer _cgo_yield = default;

        //go:cgo_export_static _cgo_topofstack
        //go:cgo_export_dynamic _cgo_topofstack
    }
}}