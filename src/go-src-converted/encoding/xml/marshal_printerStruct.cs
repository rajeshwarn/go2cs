//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 August 29 08:36:00 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using bufio = go.bufio_package;
using bytes = go.bytes_package;
using encoding = go.encoding_package;
using fmt = go.fmt_package;
using io = go.io_package;
using reflect = go.reflect_package;
using strconv = go.strconv_package;
using strings = go.strings_package;
using go;

namespace go {
namespace encoding
{
    public static partial class xml_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        [PromotedStruct(typeof(bufio.Writer))]
        private partial struct printer
        {
            // Writer structure promotion - sourced from pointer
            private readonly ptr<Writer> m_WriterRef;

            private ref Writer Writer_ptr => ref m_WriterRef.Value;

            public ref error err => ref m_WriterRef.Value.err;

            public ref slice<byte> buf => ref m_WriterRef.Value.buf;

            public ref long n => ref m_WriterRef.Value.n;

            public ref io.Writer wr => ref m_WriterRef.Value.wr;

            // Constructors
            public printer(NilType _)
            {
                this.m_WriterRef = new ptr<bufio.Writer>(new bufio.Writer(nil));
                this.encoder = default;
                this.seq = default;
                this.indent = default;
                this.prefix = default;
                this.depth = default;
                this.indentedIn = default;
                this.putNewline = default;
                this.attrNS = default;
                this.attrPrefix = default;
                this.prefixes = default;
                this.tags = default;
            }

            public printer(ref bufio.Writer Writer = default, ref ptr<Encoder> encoder = default, long seq = default, @string indent = default, @string prefix = default, long depth = default, bool indentedIn = default, bool putNewline = default, map<@string, @string> attrNS = default, map<@string, @string> attrPrefix = default, slice<@string> prefixes = default, slice<Name> tags = default)
            {
                this.m_WriterRef = new ptr<bufio.Writer>(ref Writer);
                this.encoder = encoder;
                this.seq = seq;
                this.indent = indent;
                this.prefix = prefix;
                this.depth = depth;
                this.indentedIn = indentedIn;
                this.putNewline = putNewline;
                this.attrNS = attrNS;
                this.attrPrefix = attrPrefix;
                this.prefixes = prefixes;
                this.tags = tags;
            }

            // Enable comparisons between nil and printer struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(printer value, NilType nil) => value.Equals(default(printer));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(printer value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, printer value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, printer value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator printer(NilType nil) => default(printer);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        private static printer printer_cast(dynamic value)
        {
            return new printer(ref value.Writer, ref value.encoder, value.seq, value.indent, value.prefix, value.depth, value.indentedIn, value.putNewline, value.attrNS, value.attrPrefix, value.prefixes, value.tags);
        }
    }
}}