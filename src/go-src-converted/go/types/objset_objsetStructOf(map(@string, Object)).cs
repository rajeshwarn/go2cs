//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 05:19:33 UTC
// </auto-generated>
//---------------------------------------------------------
using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;
using go;

#nullable enable

namespace go {
namespace go
{
    public static partial class types_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct objset
        {
            // Value of the objset struct
            private readonly map<@string, Object> m_value;

            public objset(map<@string, Object> value) => m_value = value;

            // Enable implicit conversions between map<@string, Object> and objset struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator objset(map<@string, Object> value) => new objset(value);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator map<@string, Object>(objset value) => value.m_value;
            
            // Enable comparisons between nil and objset struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(objset value, NilType nil) => value.Equals(default(objset));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(objset value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, objset value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, objset value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator objset(NilType nil) => default(objset);
        }
    }
}}
