//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 05:46:57 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using errors = go.errors_package;
using fmt = go.fmt_package;
using os = go.os_package;
using pathpkg = go.path_package;
using filepath = go.path.filepath_package;
using strings = go.strings_package;
using sync = go.sync_package;
using cfg = go.cmd.go.@internal.cfg_package;
using imports = go.cmd.go.@internal.imports_package;
using modfetch = go.cmd.go.@internal.modfetch_package;
using search = go.cmd.go.@internal.search_package;
using str = go.cmd.go.@internal.str_package;
using module = go.golang.org.x.mod.module_package;
using semver = go.golang.org.x.mod.semver_package;
using go;

#nullable enable

namespace go {
namespace cmd {
namespace go {
namespace @internal
{
    public static partial class modload_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        public partial struct NoMatchingVersionError
        {
            // Constructors
            public NoMatchingVersionError(NilType _)
            {
                this.query = default;
                this.current = default;
            }

            public NoMatchingVersionError(@string query = default, @string current = default)
            {
                this.query = query;
                this.current = current;
            }

            // Enable comparisons between nil and NoMatchingVersionError struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NoMatchingVersionError value, NilType nil) => value.Equals(default(NoMatchingVersionError));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NoMatchingVersionError value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, NoMatchingVersionError value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, NoMatchingVersionError value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator NoMatchingVersionError(NilType nil) => default(NoMatchingVersionError);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        public static NoMatchingVersionError NoMatchingVersionError_cast(dynamic value)
        {
            return new NoMatchingVersionError(value.query, value.current);
        }
    }
}}}}