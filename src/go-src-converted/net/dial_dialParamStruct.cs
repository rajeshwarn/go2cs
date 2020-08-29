//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 August 29 08:25:16 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using context = go.context_package;
using nettrace = go.@internal.nettrace_package;
using poll = go.@internal.poll_package;
using time = go.time_package;

namespace go
{
    public static partial class net_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        [PromotedStruct(typeof(Dialer))]
        private partial struct dialParam
        {
            // Dialer structure promotion - sourced from value copy
            private readonly ptr<Dialer> m_DialerRef;

            private ref Dialer Dialer_val => ref m_DialerRef.Value;

            public ref time.Duration Timeout => ref m_DialerRef.Value.Timeout;

            public ref time.Time Deadline => ref m_DialerRef.Value.Deadline;

            public ref Addr LocalAddr => ref m_DialerRef.Value.LocalAddr;

            public ref bool DualStack => ref m_DialerRef.Value.DualStack;

            public ref time.Duration FallbackDelay => ref m_DialerRef.Value.FallbackDelay;

            public ref time.Duration KeepAlive => ref m_DialerRef.Value.KeepAlive;

            public ref ptr<Resolver> Resolver => ref m_DialerRef.Value.Resolver;

            public ref channel<object> Cancel => ref m_DialerRef.Value.Cancel;

            // Constructors
            public dialParam(NilType _)
            {
                this.m_DialerRef = new ptr<Dialer>(new Dialer(nil));
                this.network = default;
                this.address = default;
            }

            public dialParam(Dialer Dialer = default, @string network = default, @string address = default)
            {
                this.m_DialerRef = new ptr<Dialer>(Dialer);
                this.network = network;
                this.address = address;
            }

            // Enable comparisons between nil and dialParam struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(dialParam value, NilType nil) => value.Equals(default(dialParam));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(dialParam value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, dialParam value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, dialParam value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator dialParam(NilType nil) => default(dialParam);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        private static dialParam dialParam_cast(dynamic value)
        {
            return new dialParam(value.Dialer, value.network, value.address);
        }
    }
}