//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 05:41:14 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using bytes = go.bytes_package;
using types = go.cmd.compile.@internal.types_package;
using obj = go.cmd.@internal.obj_package;
using src = go.cmd.@internal.src_package;
using fmt = go.fmt_package;
using strings = go.strings_package;
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
        private partial struct nowritebarrierrecChecker
        {
            // Constructors
            public nowritebarrierrecChecker(NilType _)
            {
                this.extraCalls = default;
                this.curfn = default;
            }

            public nowritebarrierrecChecker(map<ptr<Node>, slice<nowritebarrierrecCall>> extraCalls = default, ref ptr<Node> curfn = default)
            {
                this.extraCalls = extraCalls;
                this.curfn = curfn;
            }

            // Enable comparisons between nil and nowritebarrierrecChecker struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(nowritebarrierrecChecker value, NilType nil) => value.Equals(default(nowritebarrierrecChecker));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(nowritebarrierrecChecker value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, nowritebarrierrecChecker value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, nowritebarrierrecChecker value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator nowritebarrierrecChecker(NilType nil) => default(nowritebarrierrecChecker);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        private static nowritebarrierrecChecker nowritebarrierrecChecker_cast(dynamic value)
        {
            return new nowritebarrierrecChecker(value.extraCalls, ref value.curfn);
        }
    }
}}}}