//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 06:00:29 UTC
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
        public partial struct Statfs_t
        {
            // Constructors
            public Statfs_t(NilType _)
            {
                this.Spare2 = default;
                this.Bsize = default;
                this.Iosize = default;
                this.Blocks = default;
                this.Bfree = default;
                this.Bavail = default;
                this.Files = default;
                this.Ffree = default;
                this.Fsid = default;
                this.Owner = default;
                this.Type = default;
                this.Flags = default;
                this._ = default;
                this.Syncwrites = default;
                this.Asyncwrites = default;
                this.Fstypename = default;
                this.Mntonname = default;
                this.Syncreads = default;
                this.Asyncreads = default;
                this.Spares1 = default;
                this.Mntfromname = default;
                this.Spares2 = default;
                this._ = default;
                this.Spare = default;
            }

            public Statfs_t(long Spare2 = default, long Bsize = default, long Iosize = default, long Blocks = default, long Bfree = default, long Bavail = default, long Files = default, long Ffree = default, Fsid Fsid = default, uint Owner = default, int Type = default, int Flags = default, array<byte> _ = default, long Syncwrites = default, long Asyncwrites = default, array<sbyte> Fstypename = default, array<sbyte> Mntonname = default, long Syncreads = default, long Asyncreads = default, short Spares1 = default, array<sbyte> Mntfromname = default, short Spares2 = default, array<byte> _ = default, array<long> Spare = default)
            {
                this.Spare2 = Spare2;
                this.Bsize = Bsize;
                this.Iosize = Iosize;
                this.Blocks = Blocks;
                this.Bfree = Bfree;
                this.Bavail = Bavail;
                this.Files = Files;
                this.Ffree = Ffree;
                this.Fsid = Fsid;
                this.Owner = Owner;
                this.Type = Type;
                this.Flags = Flags;
                this._ = _;
                this.Syncwrites = Syncwrites;
                this.Asyncwrites = Asyncwrites;
                this.Fstypename = Fstypename;
                this.Mntonname = Mntonname;
                this.Syncreads = Syncreads;
                this.Asyncreads = Asyncreads;
                this.Spares1 = Spares1;
                this.Mntfromname = Mntfromname;
                this.Spares2 = Spares2;
                this._ = _;
                this.Spare = Spare;
            }

            // Enable comparisons between nil and Statfs_t struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(Statfs_t value, NilType nil) => value.Equals(default(Statfs_t));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(Statfs_t value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, Statfs_t value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, Statfs_t value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator Statfs_t(NilType nil) => default(Statfs_t);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        public static Statfs_t Statfs_t_cast(dynamic value)
        {
            return new Statfs_t(value.Spare2, value.Bsize, value.Iosize, value.Blocks, value.Bfree, value.Bavail, value.Files, value.Ffree, value.Fsid, value.Owner, value.Type, value.Flags, value._, value.Syncwrites, value.Asyncwrites, value.Fstypename, value.Mntonname, value.Syncreads, value.Asyncreads, value.Spares1, value.Mntfromname, value.Spares2, value._, value.Spare);
        }
    }
}}}}}}