//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 04:59:09 UTC
// </auto-generated>
//---------------------------------------------------------
using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;
using go;

#nullable enable

namespace go {
namespace @internal
{
    public static partial class profile_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct sectionType
        {
            // Value of the sectionType struct
            private readonly long m_value;

            public sectionType(long value) => m_value = value;

            // Enable implicit conversions between long and sectionType struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator sectionType(long value) => new sectionType(value);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator long(sectionType value) => value.m_value;
            
            // Enable comparisons between nil and sectionType struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(sectionType value, NilType nil) => value.Equals(default(sectionType));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(sectionType value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, sectionType value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, sectionType value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator sectionType(NilType nil) => default(sectionType);
        }
    }
}}
