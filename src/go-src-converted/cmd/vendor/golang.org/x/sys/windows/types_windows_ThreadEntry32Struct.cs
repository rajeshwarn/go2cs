//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 06:00:58 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using net = go.net_package;
using syscall = go.syscall_package;
using @unsafe = go.@unsafe_package;
using go;

#nullable enable

namespace go {
namespace cmd {
namespace vendor {
namespace golang.org {
namespace x {
namespace sys
{
    public static partial class windows_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        public partial struct ThreadEntry32
        {
            // Constructors
            public ThreadEntry32(NilType _)
            {
                this.Size = default;
                this.Usage = default;
                this.ThreadID = default;
                this.OwnerProcessID = default;
                this.BasePri = default;
                this.DeltaPri = default;
                this.Flags = default;
            }

            public ThreadEntry32(uint Size = default, uint Usage = default, uint ThreadID = default, uint OwnerProcessID = default, int BasePri = default, int DeltaPri = default, uint Flags = default)
            {
                this.Size = Size;
                this.Usage = Usage;
                this.ThreadID = ThreadID;
                this.OwnerProcessID = OwnerProcessID;
                this.BasePri = BasePri;
                this.DeltaPri = DeltaPri;
                this.Flags = Flags;
            }

            // Enable comparisons between nil and ThreadEntry32 struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(ThreadEntry32 value, NilType nil) => value.Equals(default(ThreadEntry32));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(ThreadEntry32 value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, ThreadEntry32 value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, ThreadEntry32 value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator ThreadEntry32(NilType nil) => default(ThreadEntry32);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        public static ThreadEntry32 ThreadEntry32_cast(dynamic value)
        {
            return new ThreadEntry32(value.Size, value.Usage, value.ThreadID, value.OwnerProcessID, value.BasePri, value.DeltaPri, value.Flags);
        }
    }
}}}}}}