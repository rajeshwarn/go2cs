//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 04:49:54 UTC
// </auto-generated>
//---------------------------------------------------------
using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;
using go;

#nullable enable

namespace go {
namespace runtime
{
    public static partial class pprof_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct stackProfile
        {
            // Value of the stackProfile struct
            private readonly slice<slice<System.UIntPtr>> m_value;

            public stackProfile(slice<slice<System.UIntPtr>> value) => m_value = value;

            // Enable implicit conversions between slice<slice<System.UIntPtr>> and stackProfile struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator stackProfile(slice<slice<System.UIntPtr>> value) => new stackProfile(value);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator slice<slice<System.UIntPtr>>(stackProfile value) => value.m_value;
            
            // Enable comparisons between nil and stackProfile struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(stackProfile value, NilType nil) => value.Equals(default(stackProfile));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(stackProfile value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, stackProfile value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, stackProfile value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator stackProfile(NilType nil) => default(stackProfile);
        }
    }
}}
