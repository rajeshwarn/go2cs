//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 08 03:19:33 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using @unsafe = go.@unsafe_package;

namespace go
{
    public static partial class runtime_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct ucontext
        {
            // Constructors
            public ucontext(NilType _)
            {
                this.uc_sigmask = default;
                this.uc_mcontext = default;
                this.uc_link = default;
                this.uc_stack = default;
                this.uc_flags = default;
                this.__spare__ = default;
                this.pad_cgo_0 = default;
            }

            public ucontext(sigset uc_sigmask = default, mcontext uc_mcontext = default, ref ptr<ucontext> uc_link = default, stackt uc_stack = default, int uc_flags = default, array<int> __spare__ = default, array<byte> pad_cgo_0 = default)
            {
                this.uc_sigmask = uc_sigmask;
                this.uc_mcontext = uc_mcontext;
                this.uc_link = uc_link;
                this.uc_stack = uc_stack;
                this.uc_flags = uc_flags;
                this.__spare__ = __spare__;
                this.pad_cgo_0 = pad_cgo_0;
            }

            // Enable comparisons between nil and ucontext struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(ucontext value, NilType nil) => value.Equals(default(ucontext));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(ucontext value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, ucontext value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, ucontext value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator ucontext(NilType nil) => default(ucontext);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        private static ucontext ucontext_cast(dynamic value)
        {
            return new ucontext(value.uc_sigmask, value.uc_mcontext, ref value.uc_link, value.uc_stack, value.uc_flags, value.__spare__, value.pad_cgo_0);
        }
    }
}