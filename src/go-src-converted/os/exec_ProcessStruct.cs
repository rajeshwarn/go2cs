//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 August 29 08:43:41 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using testlog = go.@internal.testlog_package;
using runtime = go.runtime_package;
using sync = go.sync_package;
using atomic = go.sync.atomic_package;
using syscall = go.syscall_package;
using time = go.time_package;

namespace go
{
    public static partial class os_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        public partial struct Process
        {
            // Constructors
            public Process(NilType _)
            {
                this.Pid = default;
                this.handle = default;
                this.isdone = default;
                this.sigMu = default;
            }

            public Process(long Pid = default, System.UIntPtr handle = default, uint isdone = default, sync.RWMutex sigMu = default)
            {
                this.Pid = Pid;
                this.handle = handle;
                this.isdone = isdone;
                this.sigMu = sigMu;
            }

            // Enable comparisons between nil and Process struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(Process value, NilType nil) => value.Equals(default(Process));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(Process value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, Process value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, Process value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator Process(NilType nil) => default(Process);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        public static Process Process_cast(dynamic value)
        {
            return new Process(value.Pid, value.handle, value.isdone, value.sigMu);
        }
    }
}