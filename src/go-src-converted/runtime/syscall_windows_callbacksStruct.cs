//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 04:48:52 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using @unsafe = go.@unsafe_package;

#nullable enable

namespace go
{
    public static partial class runtime_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct callbacks
        {
            // Constructors
            public callbacks(NilType _)
            {
                this.@lock = default;
                this.ctxt = default;
                this.n = default;
            }

            public callbacks(mutex @lock = default, array<ptr<wincallbackcontext>> ctxt = default, long n = default)
            {
                this.@lock = @lock;
                this.ctxt = ctxt;
                this.n = n;
            }

            // Enable comparisons between nil and callbacks struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(callbacks value, NilType nil) => value.Equals(default(callbacks));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(callbacks value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, callbacks value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, callbacks value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator callbacks(NilType nil) => default(callbacks);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        private static callbacks callbacks_cast(dynamic value)
        {
            return new callbacks(value.@lock, value.ctxt, value.n);
        }
    }
}