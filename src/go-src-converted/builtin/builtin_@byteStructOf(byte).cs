//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 05:08:14 UTC
// </auto-generated>
//---------------------------------------------------------
using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;

#nullable enable

namespace go
{
    public static partial class builtin_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct @byte
        {
            // Value of the @byte struct
            private readonly byte m_value;

            public @byte(byte value) => m_value = value;

            // Enable implicit conversions between byte and @byte struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator @byte(byte value) => new @byte(value);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator byte(@byte value) => value.m_value;
            
            // Enable comparisons between nil and @byte struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(@byte value, NilType nil) => value.Equals(default(@byte));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(@byte value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, @byte value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, @byte value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator @byte(NilType nil) => default(@byte);
        }
    }
}
