//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 04:45:47 UTC
// </auto-generated>
//---------------------------------------------------------
using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;

#nullable enable

namespace go
{
    public static partial class runtime_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct semt
        {
            // Value of the semt struct
            private readonly int m_value;

            public semt(int value) => m_value = value;

            // Enable implicit conversions between int and semt struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator semt(int value) => new semt(value);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator int(semt value) => value.m_value;
            
            // Enable comparisons between nil and semt struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(semt value, NilType nil) => value.Equals(default(semt));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(semt value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, semt value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, semt value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator semt(NilType nil) => default(semt);
        }
    }
}
