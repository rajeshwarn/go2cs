//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 August 29 08:23:16 UTC
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
        private partial struct slicing8Table
        {
            // Value of the slicing8Table struct
            private readonly array<Table> m_value;

            public slicing8Table(array<Table> value) => m_value = value;

            // Enable implicit conversions between array<Table> and slicing8Table struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator slicing8Table(array<Table> value) => new slicing8Table(value);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator array<Table>(slicing8Table value) => value.m_value;
            
            // Enable comparisons between nil and slicing8Table struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(slicing8Table value, NilType nil) => value.Equals(default(slicing8Table));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(slicing8Table value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, slicing8Table value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, slicing8Table value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator slicing8Table(NilType nil) => default(slicing8Table);
        }
    }
}}