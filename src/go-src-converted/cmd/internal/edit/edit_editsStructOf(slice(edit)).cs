//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 August 29 08:52:44 UTC
// </auto-generated>
//---------------------------------------------------------
using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;
using go;

namespace go {
namespace cmd {
namespace @internal
{
    public static partial class edit_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct edits
        {
            // Value of the edits struct
            private readonly slice<edit> m_value;

            public edits(slice<edit> value) => m_value = value;

            // Enable implicit conversions between slice<edit> and edits struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator edits(slice<edit> value) => new edits(value);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator slice<edit>(edits value) => value.m_value;
            
            // Enable comparisons between nil and edits struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(edits value, NilType nil) => value.Equals(default(edits));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(edits value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, edits value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, edits value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator edits(NilType nil) => default(edits);
        }
    }
}}}