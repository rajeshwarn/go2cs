//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 08 04:57:10 UTC
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

namespace go {
namespace golang.org {
namespace x {
namespace tools {
namespace go
{
    public static partial class ssa_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        public partial struct Parameter
        {
            // Constructors
            public Parameter(NilType _)
            {
                this.name = default;
                this.@object = default;
                this.typ = default;
                this.pos = default;
                this.parent = default;
                this.referrers = default;
            }

            public Parameter(@string name = default, types.Object @object = default, types.Type typ = default, token.Pos pos = default, ref ptr<Function> parent = default, slice<Instruction> referrers = default)
            {
                this.name = name;
                this.@object = @object;
                this.typ = typ;
                this.pos = pos;
                this.parent = parent;
                this.referrers = referrers;
            }

            // Enable comparisons between nil and Parameter struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(Parameter value, NilType nil) => value.Equals(default(Parameter));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(Parameter value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, Parameter value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, Parameter value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator Parameter(NilType nil) => default(Parameter);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        public static Parameter Parameter_cast(dynamic value)
        {
            return new Parameter(value.name, value.@object, value.typ, value.pos, ref value.parent, value.referrers);
        }
    }
}}}}}