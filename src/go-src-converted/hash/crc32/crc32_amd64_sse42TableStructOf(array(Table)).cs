//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 August 29 08:23:15 UTC
// </auto-generated>
//---------------------------------------------------------
using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;
using go;

namespace go {
namespace hash
{
    public static partial class crc32_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct sse42Table
        {
            // Value of the sse42Table struct
            private readonly array<Table> m_value;

            public sse42Table(array<Table> value) => m_value = value;

            // Enable implicit conversions between array<Table> and sse42Table struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator sse42Table(array<Table> value) => new sse42Table(value);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator array<Table>(sse42Table value) => value.m_value;
            
            // Enable comparisons between nil and sse42Table struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(sse42Table value, NilType nil) => value.Equals(default(sse42Table));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(sse42Table value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, sse42Table value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, sse42Table value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator sse42Table(NilType nil) => default(sse42Table);
        }
    }
}}