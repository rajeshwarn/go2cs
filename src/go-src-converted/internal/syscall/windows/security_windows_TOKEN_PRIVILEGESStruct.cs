//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 04:51:13 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using syscall = go.syscall_package;
using @unsafe = go.@unsafe_package;
using go;

#nullable enable

namespace go {
namespace @internal {
namespace syscall
{
    public static partial class windows_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        public partial struct TOKEN_PRIVILEGES
        {
            // Constructors
            public TOKEN_PRIVILEGES(NilType _)
            {
                this.PrivilegeCount = default;
                this.Privileges = default;
            }

            public TOKEN_PRIVILEGES(uint PrivilegeCount = default, array<LUID_AND_ATTRIBUTES> Privileges = default)
            {
                this.PrivilegeCount = PrivilegeCount;
                this.Privileges = Privileges;
            }

            // Enable comparisons between nil and TOKEN_PRIVILEGES struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(TOKEN_PRIVILEGES value, NilType nil) => value.Equals(default(TOKEN_PRIVILEGES));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(TOKEN_PRIVILEGES value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, TOKEN_PRIVILEGES value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, TOKEN_PRIVILEGES value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator TOKEN_PRIVILEGES(NilType nil) => default(TOKEN_PRIVILEGES);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        public static TOKEN_PRIVILEGES TOKEN_PRIVILEGES_cast(dynamic value)
        {
            return new TOKEN_PRIVILEGES(value.PrivilegeCount, value.Privileges);
        }
    }
}}}