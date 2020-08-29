//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 August 29 08:32:22 UTC
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
using io = go.io_package;
using mime = go.mime_package;
using multipart = go.mime.multipart_package;
using textproto = go.net.textproto_package;
using url = go.net.url_package;
using os = go.os_package;
using path = go.path_package;
using filepath = go.path.filepath_package;
using sort = go.sort_package;
using strconv = go.strconv_package;
using strings = go.strings_package;
using time = go.time_package;
using go;

namespace go {
namespace net
{
    public static partial class http_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct httpRange
        {
            // Constructors
            public httpRange(NilType _)
            {
                this.start = default;
                this.length = default;
            }

            public httpRange(long start = default, long length = default)
            {
                this.start = start;
                this.length = length;
            }

            // Enable comparisons between nil and httpRange struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(httpRange value, NilType nil) => value.Equals(default(httpRange));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(httpRange value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, httpRange value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, httpRange value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator httpRange(NilType nil) => default(httpRange);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        private static httpRange httpRange_cast(dynamic value)
        {
            return new httpRange(value.start, value.length);
        }
    }
}}