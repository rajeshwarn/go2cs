//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 August 29 09:26:27 UTC
// </auto-generated>
//---------------------------------------------------------
using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;
using go;

namespace go {
namespace cmd {
namespace compile {
namespace @internal
{
    public static partial class syntax_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        public partial struct Pragma
        {
            // Value of the Pragma struct
            private readonly ushort m_value;

            public Pragma(ushort value) => m_value = value;

            // Enable implicit conversions between ushort and Pragma struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator Pragma(ushort value) => new Pragma(value);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator ushort(Pragma value) => value.m_value;
            
            // Enable comparisons between nil and Pragma struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(Pragma value, NilType nil) => value.Equals(default(Pragma));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(Pragma value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, Pragma value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, Pragma value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator Pragma(NilType nil) => default(Pragma);
        }
    }
}}}}