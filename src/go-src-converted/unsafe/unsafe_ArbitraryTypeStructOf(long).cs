//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 04:45:19 UTC
// </auto-generated>
//---------------------------------------------------------
using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;

#nullable enable

namespace go
{
    public static partial class @unsafe_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        public partial struct ArbitraryType
        {
            // Value of the ArbitraryType struct
            private readonly long m_value;

            public ArbitraryType(long value) => m_value = value;

            // Enable implicit conversions between long and ArbitraryType struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator ArbitraryType(long value) => new ArbitraryType(value);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator long(ArbitraryType value) => value.m_value;
            
            // Enable comparisons between nil and ArbitraryType struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(ArbitraryType value, NilType nil) => value.Equals(default(ArbitraryType));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(ArbitraryType value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, ArbitraryType value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, ArbitraryType value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator ArbitraryType(NilType nil) => default(ArbitraryType);
        }
    }
}
