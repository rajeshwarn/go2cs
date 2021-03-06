//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 05:41:30 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using ssa = go.cmd.compile.@internal.ssa_package;
using types = go.cmd.compile.@internal.types_package;
using obj = go.cmd.@internal.obj_package;
using src = go.cmd.@internal.src_package;
using sync = go.sync_package;
using go;

#nullable enable

namespace go {
namespace cmd {
namespace compile {
namespace @internal
{
    public static partial class gc_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        public partial struct Arch
        {
            // Constructors
            public Arch(NilType _)
            {
                this.LinkArch = default;
                this.REGSP = default;
                this.MAXWIDTH = default;
                this.Use387 = default;
                this.SoftFloat = default;
                this.PadFrame = default;
                this.ZeroRange = default;
                this.Ginsnop = default;
                this.Ginsnopdefer = default;
                this.SSAMarkMoves = default;
                this.SSAGenValue = default;
                this.SSAGenBlock = default;
            }

            public Arch(ref ptr<obj.LinkArch> LinkArch = default, long REGSP = default, long MAXWIDTH = default, bool Use387 = default, bool SoftFloat = default, Func<long, long> PadFrame = default, Func<ptr<Progs>, ptr<obj.Prog>, long, long, ptr<uint>, ptr<obj.Prog>> ZeroRange = default, Func<ptr<Progs>, ptr<obj.Prog>> Ginsnop = default, Func<ptr<Progs>, ptr<obj.Prog>> Ginsnopdefer = default, Action<ptr<SSAGenState>, ptr<ssa.Block>> SSAMarkMoves = default, Action<ptr<SSAGenState>, ptr<ssa.Value>> SSAGenValue = default, Action<ptr<SSAGenState>, ptr<ssa.Block>, ptr<ssa.Block>> SSAGenBlock = default)
            {
                this.LinkArch = LinkArch;
                this.REGSP = REGSP;
                this.MAXWIDTH = MAXWIDTH;
                this.Use387 = Use387;
                this.SoftFloat = SoftFloat;
                this.PadFrame = PadFrame;
                this.ZeroRange = ZeroRange;
                this.Ginsnop = Ginsnop;
                this.Ginsnopdefer = Ginsnopdefer;
                this.SSAMarkMoves = SSAMarkMoves;
                this.SSAGenValue = SSAGenValue;
                this.SSAGenBlock = SSAGenBlock;
            }

            // Enable comparisons between nil and Arch struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(Arch value, NilType nil) => value.Equals(default(Arch));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(Arch value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, Arch value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, Arch value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator Arch(NilType nil) => default(Arch);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        public static Arch Arch_cast(dynamic value)
        {
            return new Arch(ref value.LinkArch, value.REGSP, value.MAXWIDTH, value.Use387, value.SoftFloat, value.PadFrame, value.ZeroRange, value.Ginsnop, value.Ginsnopdefer, value.SSAMarkMoves, value.SSAGenValue, value.SSAGenBlock);
        }
    }
}}}}