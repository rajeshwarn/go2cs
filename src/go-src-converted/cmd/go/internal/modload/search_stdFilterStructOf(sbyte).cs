//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 08 04:35:43 UTC
// </auto-generated>
//---------------------------------------------------------
using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;
using go;

namespace go {
namespace cmd {
namespace go {
namespace @internal
{
    public static partial class modload_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct stdFilter
        {
            // Value of the stdFilter struct
            private readonly sbyte m_value;

            public stdFilter(sbyte value) => m_value = value;

            // Enable implicit conversions between sbyte and stdFilter struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator stdFilter(sbyte value) => new stdFilter(value);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator sbyte(stdFilter value) => value.m_value;
            
            // Enable comparisons between nil and stdFilter struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(stdFilter value, NilType nil) => value.Equals(default(stdFilter));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(stdFilter value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, stdFilter value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, stdFilter value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator stdFilter(NilType nil) => default(stdFilter);
        }
    }
}}}}