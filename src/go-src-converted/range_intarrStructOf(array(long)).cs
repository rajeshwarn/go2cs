//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 06:03:47 UTC
// </auto-generated>
//---------------------------------------------------------
using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;

#nullable enable

namespace go
{
    public static partial class main_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct intarr
        {
            // Value of the intarr struct
            private readonly array<long> m_value;

            public intarr(array<long> value) => m_value = value;

            // Enable implicit conversions between array<long> and intarr struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator intarr(array<long> value) => new intarr(value);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator array<long>(intarr value) => value.m_value;
            
            // Enable comparisons between nil and intarr struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(intarr value, NilType nil) => value.Equals(default(intarr));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(intarr value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, intarr value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, intarr value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator intarr(NilType nil) => default(intarr);
        }
    }
}
