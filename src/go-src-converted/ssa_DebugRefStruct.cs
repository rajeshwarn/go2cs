//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 06:03:30 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using fmt = go.fmt_package;
using ast = go.go.ast_package;
using constant = go.go.constant_package;
using token = go.go.token_package;
using types = go.go.types_package;
using sync = go.sync_package;
using typeutil = go.golang.org.x.tools.go.types.typeutil_package;
using go;

#nullable enable

namespace go {
namespace golang.org {
namespace x {
namespace tools {
namespace go
{
    public static partial class ssa_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        [PromotedStruct(typeof(anInstruction))]
        public partial struct DebugRef
        {
            // anInstruction structure promotion - sourced from value copy
            private readonly ptr<anInstruction> m_anInstructionRef;

            private ref anInstruction anInstruction_val => ref m_anInstructionRef.Value;

            public ref ptr<BasicBlock> block => ref m_anInstructionRef.Value.block;

            // Constructors
            public DebugRef(NilType _)
            {
                this.m_anInstructionRef = new ptr<anInstruction>(new anInstruction(nil));
                this.Expr = default;
                this.@object = default;
                this.IsAddr = default;
                this.X = default;
            }

            public DebugRef(anInstruction anInstruction = default, ast.Expr Expr = default, types.Object @object = default, bool IsAddr = default, Value X = default)
            {
                this.m_anInstructionRef = new ptr<anInstruction>(anInstruction);
                this.Expr = Expr;
                this.@object = @object;
                this.IsAddr = IsAddr;
                this.X = X;
            }

            // Enable comparisons between nil and DebugRef struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(DebugRef value, NilType nil) => value.Equals(default(DebugRef));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(DebugRef value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, DebugRef value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, DebugRef value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator DebugRef(NilType nil) => default(DebugRef);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        public static DebugRef DebugRef_cast(dynamic value)
        {
            return new DebugRef(value.anInstruction, value.Expr, value.@object, value.IsAddr, value.X);
        }
    }
}}}}}