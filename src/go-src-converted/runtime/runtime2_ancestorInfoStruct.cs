//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 04:48:09 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using cpu = go.@internal.cpu_package;
using atomic = go.runtime.@internal.atomic_package;
using sys = go.runtime.@internal.sys_package;
using @unsafe = go.@unsafe_package;

#nullable enable

namespace go
{
    public static partial class runtime_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct ancestorInfo
        {
            // Constructors
            public ancestorInfo(NilType _)
            {
                this.pcs = default;
                this.goid = default;
                this.gopc = default;
            }

            public ancestorInfo(slice<System.UIntPtr> pcs = default, long goid = default, System.UIntPtr gopc = default)
            {
                this.pcs = pcs;
                this.goid = goid;
                this.gopc = gopc;
            }

            // Enable comparisons between nil and ancestorInfo struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(ancestorInfo value, NilType nil) => value.Equals(default(ancestorInfo));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(ancestorInfo value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, ancestorInfo value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, ancestorInfo value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator ancestorInfo(NilType nil) => default(ancestorInfo);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        private static ancestorInfo ancestorInfo_cast(dynamic value)
        {
            return new ancestorInfo(value.pcs, value.goid, value.gopc);
        }
    }
}