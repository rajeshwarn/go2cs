//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 08 04:56:21 UTC
// </auto-generated>
//---------------------------------------------------------
using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;
using go;

namespace go {
namespace go {
namespace @internal
{
    public static partial class aliases_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        public partial struct C2
        {
            // Value of the C2 struct
            private readonly C1 m_value;

            public C2(C1 value) => m_value = value;

            // Enable implicit conversions between C1 and C2 struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator C2(C1 value) => new C2(value);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator C1(C2 value) => value.m_value;
            
            // Enable comparisons between nil and C2 struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(C2 value, NilType nil) => value.Equals(default(C2));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(C2 value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, C2 value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, C2 value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator C2(NilType nil) => default(C2);
        }
    }
}}}