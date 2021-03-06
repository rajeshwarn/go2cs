//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 06:01:41 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using bytes = go.bytes_package;
using context = go.context_package;
using fmt = go.fmt_package;
using io = go.io_package;
using os = go.os_package;
using exec = go.os.exec_package;
using regexp = go.regexp_package;
using strings = go.strings_package;
using sync = go.sync_package;
using time = go.time_package;
using @event = go.golang.org.x.tools.@internal.@event_package;
using go;

#nullable enable

namespace go {
namespace golang.org {
namespace x {
namespace tools {
namespace @internal
{
    public static partial class gocommand_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        public partial struct Invocation
        {
            // Constructors
            public Invocation(NilType _)
            {
                this.Verb = default;
                this.Args = default;
                this.BuildFlags = default;
                this.Env = default;
                this.WorkingDir = default;
                this.Logf = default;
            }

            public Invocation(@string Verb = default, slice<@string> Args = default, slice<@string> BuildFlags = default, slice<@string> Env = default, @string WorkingDir = default, Action<@string, object[]> Logf = default)
            {
                this.Verb = Verb;
                this.Args = Args;
                this.BuildFlags = BuildFlags;
                this.Env = Env;
                this.WorkingDir = WorkingDir;
                this.Logf = Logf;
            }

            // Enable comparisons between nil and Invocation struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(Invocation value, NilType nil) => value.Equals(default(Invocation));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(Invocation value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, Invocation value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, Invocation value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator Invocation(NilType nil) => default(Invocation);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        public static Invocation Invocation_cast(dynamic value)
        {
            return new Invocation(value.Verb, value.Args, value.BuildFlags, value.Env, value.WorkingDir, value.Logf);
        }
    }
}}}}}