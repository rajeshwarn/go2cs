//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 August 29 09:25:56 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

using go;

namespace go {
namespace cmd {
namespace compile {
namespace @internal
{
    public static partial class gc_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct bvec
        {
            // Constructors
            public bvec(NilType _)
            {
                this.n = default;
                this.b = default;
            }

            public bvec(int n = default, slice<uint> b = default)
            {
                this.n = n;
                this.b = b;
            }

            // Enable comparisons between nil and bvec struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(bvec value, NilType nil) => value.Equals(default(bvec));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(bvec value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, bvec value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, bvec value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator bvec(NilType nil) => default(bvec);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        private static bvec bvec_cast(dynamic value)
        {
            return new bvec(value.n, value.b);
        }
    }
}}}}