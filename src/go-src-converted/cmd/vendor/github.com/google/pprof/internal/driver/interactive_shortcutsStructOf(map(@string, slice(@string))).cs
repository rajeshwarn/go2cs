//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 05:53:31 UTC
// </auto-generated>
//---------------------------------------------------------
using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;
using go;

#nullable enable

namespace go {
namespace cmd {
namespace vendor {
namespace github.com {
namespace google {
namespace pprof {
namespace @internal
{
    public static partial class driver_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct shortcuts
        {
            // Value of the shortcuts struct
            private readonly map<@string, slice<@string>> m_value;

            public shortcuts(map<@string, slice<@string>> value) => m_value = value;

            // Enable implicit conversions between map<@string, slice<@string>> and shortcuts struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator shortcuts(map<@string, slice<@string>> value) => new shortcuts(value);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator map<@string, slice<@string>>(shortcuts value) => value.m_value;
            
            // Enable comparisons between nil and shortcuts struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(shortcuts value, NilType nil) => value.Equals(default(shortcuts));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(shortcuts value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, shortcuts value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, shortcuts value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator shortcuts(NilType nil) => default(shortcuts);
        }
    }
}}}}}}}
