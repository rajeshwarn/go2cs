//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 06:00:34 UTC
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
        public partial struct XDPMmapOffsets
        {
            // Constructors
            public XDPMmapOffsets(NilType _)
            {
                this.Rx = default;
                this.Tx = default;
                this.Fr = default;
                this.Cr = default;
            }

            public XDPMmapOffsets(XDPRingOffset Rx = default, XDPRingOffset Tx = default, XDPRingOffset Fr = default, XDPRingOffset Cr = default)
            {
                this.Rx = Rx;
                this.Tx = Tx;
                this.Fr = Fr;
                this.Cr = Cr;
            }

            // Enable comparisons between nil and XDPMmapOffsets struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(XDPMmapOffsets value, NilType nil) => value.Equals(default(XDPMmapOffsets));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(XDPMmapOffsets value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, XDPMmapOffsets value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, XDPMmapOffsets value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator XDPMmapOffsets(NilType nil) => default(XDPMmapOffsets);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        public static XDPMmapOffsets XDPMmapOffsets_cast(dynamic value)
        {
            return new XDPMmapOffsets(value.Rx, value.Tx, value.Fr, value.Cr);
        }
    }
}}}}}}