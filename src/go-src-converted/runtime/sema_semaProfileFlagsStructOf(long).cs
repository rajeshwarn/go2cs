//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 04:48:12 UTC
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
        private partial struct semaProfileFlags
        {
            // Value of the semaProfileFlags struct
            private readonly long m_value;

            public semaProfileFlags(long value) => m_value = value;

            // Enable implicit conversions between long and semaProfileFlags struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator semaProfileFlags(long value) => new semaProfileFlags(value);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator long(semaProfileFlags value) => value.m_value;
            
            // Enable comparisons between nil and semaProfileFlags struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(semaProfileFlags value, NilType nil) => value.Equals(default(semaProfileFlags));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(semaProfileFlags value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, semaProfileFlags value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, semaProfileFlags value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator semaProfileFlags(NilType nil) => default(semaProfileFlags);
        }
    }
}
