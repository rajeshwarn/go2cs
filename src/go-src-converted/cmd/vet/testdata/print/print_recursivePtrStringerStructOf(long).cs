//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 06:05:11 UTC
// </auto-generated>
//---------------------------------------------------------
using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;
using go;

#nullable enable

namespace go {
namespace cmd {
namespace vet {
namespace testdata
{
    public static partial class print_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct recursivePtrStringer
        {
            // Value of the recursivePtrStringer struct
            private readonly long m_value;

            public recursivePtrStringer(long value) => m_value = value;

            // Enable implicit conversions between long and recursivePtrStringer struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator recursivePtrStringer(long value) => new recursivePtrStringer(value);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator long(recursivePtrStringer value) => value.m_value;
            
            // Enable comparisons between nil and recursivePtrStringer struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(recursivePtrStringer value, NilType nil) => value.Equals(default(recursivePtrStringer));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(recursivePtrStringer value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, recursivePtrStringer value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, recursivePtrStringer value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator recursivePtrStringer(NilType nil) => default(recursivePtrStringer);
        }
    }
}}}}
