//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 August 29 09:27:29 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using fmt = go.fmt_package;
using math = go.math_package;
using big = go.math.big_package;
using go;

namespace go {
namespace cmd {
namespace compile {
namespace @internal
{
    public static partial class gc_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        public partial struct Mpcplx
        {
            // Constructors
            public Mpcplx(NilType _)
            {
                this.Real = default;
                this.Imag = default;
            }

            public Mpcplx(Mpflt Real = default, Mpflt Imag = default)
            {
                this.Real = Real;
                this.Imag = Imag;
            }

            // Enable comparisons between nil and Mpcplx struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(Mpcplx value, NilType nil) => value.Equals(default(Mpcplx));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(Mpcplx value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, Mpcplx value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, Mpcplx value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator Mpcplx(NilType nil) => default(Mpcplx);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        public static Mpcplx Mpcplx_cast(dynamic value)
        {
            return new Mpcplx(value.Real, value.Imag);
        }
    }
}}}}