//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 05:01:55 UTC
// </auto-generated>
//---------------------------------------------------------
using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;

#nullable enable

namespace go
{
    public static partial class syscall_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        public partial struct ErrorString
        {
            // Value of the ErrorString struct
            private readonly @string m_value;

            public ErrorString(@string value) => m_value = value;

            // Enable implicit conversions between @string and ErrorString struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator ErrorString(@string value) => new ErrorString(value);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator @string(ErrorString value) => value.m_value;
            
            // Enable comparisons between nil and ErrorString struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(ErrorString value, NilType nil) => value.Equals(default(ErrorString));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(ErrorString value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, ErrorString value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, ErrorString value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator ErrorString(NilType nil) => default(ErrorString);
        }
    }
}
