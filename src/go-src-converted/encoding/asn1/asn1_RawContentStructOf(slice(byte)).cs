//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 August 29 08:29:45 UTC
// </auto-generated>
//---------------------------------------------------------
using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;
using go;

namespace go {
namespace encoding
{
    public static partial class asn1_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        public partial struct RawContent
        {
            // Value of the RawContent struct
            private readonly slice<byte> m_value;

            public RawContent(slice<byte> value) => m_value = value;

            // Enable implicit conversions between slice<byte> and RawContent struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator RawContent(slice<byte> value) => new RawContent(value);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator slice<byte>(RawContent value) => value.m_value;
            
            // Enable comparisons between nil and RawContent struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(RawContent value, NilType nil) => value.Equals(default(RawContent));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(RawContent value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, RawContent value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, RawContent value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator RawContent(NilType nil) => default(RawContent);
        }
    }
}}