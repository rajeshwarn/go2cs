//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 August 29 08:47:43 UTC
// </auto-generated>
//---------------------------------------------------------
using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;
using go;

namespace go {
namespace go
{
    public static partial class types_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct fieldSet
        {
            // Value of the fieldSet struct
            private readonly map<@string, ref Var> m_value;

            public fieldSet(map<@string, ref Var> value) => m_value = value;

            // Enable implicit conversions between map<@string, ref Var> and fieldSet struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator fieldSet(map<@string, ref Var> value) => new fieldSet(value);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator map<@string, ref Var>(fieldSet value) => value.m_value;
            
            // Enable comparisons between nil and fieldSet struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(fieldSet value, NilType nil) => value.Equals(default(fieldSet));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(fieldSet value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, fieldSet value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, fieldSet value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator fieldSet(NilType nil) => default(fieldSet);
        }
    }
}}