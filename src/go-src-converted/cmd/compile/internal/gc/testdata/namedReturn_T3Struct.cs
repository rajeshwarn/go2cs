//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 August 29 09:58:24 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using fmt = go.fmt_package;
using runtime = go.runtime_package;

namespace go
{
    public static partial class main_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        public partial struct T3
        {
            // Constructors
            public T3(NilType _)
            {
                this.a = default;
                this.b = default;
                this.c = default;
            }

            public T3(ref ptr<B> a = default, ref ptr<B> b = default, ref ptr<B> c = default)
            {
                this.a = a;
                this.b = b;
                this.c = c;
            }

            // Enable comparisons between nil and T3 struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(T3 value, NilType nil) => value.Equals(default(T3));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(T3 value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, T3 value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, T3 value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator T3(NilType nil) => default(T3);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        public static T3 T3_cast(dynamic value)
        {
            return new T3(ref value.a, ref value.b, ref value.c);
        }
    }
}