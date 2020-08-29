//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 August 29 08:30:45 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using crypto = go.crypto_package;
using errors = go.errors_package;
using hash = go.hash_package;
using go;

namespace go {
namespace crypto
{
    public static partial class md5_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct digest
        {
            // Constructors
            public digest(NilType _)
            {
                this.s = default;
                this.x = default;
                this.nx = default;
                this.len = default;
            }

            public digest(array<uint> s = default, array<byte> x = default, long nx = default, ulong len = default)
            {
                this.s = s;
                this.x = x;
                this.nx = nx;
                this.len = len;
            }

            // Enable comparisons between nil and digest struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(digest value, NilType nil) => value.Equals(default(digest));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(digest value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, digest value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, digest value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator digest(NilType nil) => default(digest);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        private static digest digest_cast(dynamic value)
        {
            return new digest(value.s, value.x, value.nx, value.len);
        }
    }
}}