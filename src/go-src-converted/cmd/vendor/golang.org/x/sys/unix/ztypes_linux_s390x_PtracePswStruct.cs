//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 06:00:41 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

using go;

#nullable enable

namespace go {
namespace cmd {
namespace vendor {
namespace golang.org {
namespace x {
namespace sys
{
    public static partial class unix_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        public partial struct PtracePsw
        {
            // Constructors
            public PtracePsw(NilType _)
            {
                this.Mask = default;
                this.Addr = default;
            }

            public PtracePsw(ulong Mask = default, ulong Addr = default)
            {
                this.Mask = Mask;
                this.Addr = Addr;
            }

            // Enable comparisons between nil and PtracePsw struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(PtracePsw value, NilType nil) => value.Equals(default(PtracePsw));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(PtracePsw value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, PtracePsw value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, PtracePsw value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator PtracePsw(NilType nil) => default(PtracePsw);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        public static PtracePsw PtracePsw_cast(dynamic value)
        {
            return new PtracePsw(value.Mask, value.Addr);
        }
    }
}}}}}}