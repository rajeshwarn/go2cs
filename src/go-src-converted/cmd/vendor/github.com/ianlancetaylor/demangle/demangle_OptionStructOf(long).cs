//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 05:54:22 UTC
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
namespace ianlancetaylor
{
    public static partial class demangle_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        public partial struct Option
        {
            // Value of the Option struct
            private readonly long m_value;

            public Option(long value) => m_value = value;

            // Enable implicit conversions between long and Option struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator Option(long value) => new Option(value);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator long(Option value) => value.m_value;
            
            // Enable comparisons between nil and Option struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(Option value, NilType nil) => value.Equals(default(Option));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(Option value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, Option value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, Option value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator Option(NilType nil) => default(Option);
        }
    }
}}}}}
