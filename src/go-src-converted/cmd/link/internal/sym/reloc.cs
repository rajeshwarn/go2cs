// Copyright 2017 The Go Authors. All rights reserved.
// Use of this source code is governed by a BSD-style
// license that can be found in the LICENSE file.

// package sym -- go2cs converted at 2020 August 29 10:02:54 UTC
// import "cmd/link/internal/sym" ==> using sym = go.cmd.link.@internal.sym_package
// Original source: C:\Go\src\cmd\link\internal\sym\reloc.go
using objabi = go.cmd.@internal.objabi_package;
using sys = go.cmd.@internal.sys_package;
using elf = go.debug.elf_package;
using static go.builtin;

namespace go {
namespace cmd {
namespace link {
namespace @internal
{
    public static partial class sym_package
    {
        // Reloc is a relocation.
        //
        // The typical Reloc rewrites part of a symbol at offset Off to address Sym.
        // A Reloc is stored in a slice on the Symbol it rewrites.
        //
        // Relocations are generated by the compiler as the type
        // cmd/internal/obj.Reloc, which is encoded into the object file wire
        // format and decoded by the linker into this type. A separate type is
        // used to hold linker-specific state about the relocation.
        //
        // Some relocations are created by cmd/link.
        public partial struct Reloc
        {
            public int Off; // offset to rewrite
            public byte Siz; // number of bytes to rewrite, 1, 2, or 4
            public bool Done; // set to true when relocation is complete
            public RelocVariant Variant; // variation on Type
            public objabi.RelocType Type; // the relocation type
            public long Add; // addend
            public long Xadd; // addend passed to external linker
            public ptr<Symbol> Sym; // symbol the relocation addresses
            public ptr<Symbol> Xsym; // symbol passed to external linker
        }

        // RelocVariant is a linker-internal variation on a relocation.
        public partial struct RelocVariant // : byte
        {
        }

        public static readonly RelocVariant RV_NONE = iota;
        public static readonly var RV_POWER_LO = 0;
        public static readonly var RV_POWER_HI = 1;
        public static readonly var RV_POWER_HA = 2;
        public static readonly var RV_POWER_DS = 3; 

        // RV_390_DBL is a s390x-specific relocation variant that indicates that
        // the value to be placed into the relocatable field should first be
        // divided by 2.
        public static readonly var RV_390_DBL = 4;

        public static readonly RelocVariant RV_CHECK_OVERFLOW = 1L << (int)(7L);
        public static readonly RelocVariant RV_TYPE_MASK = RV_CHECK_OVERFLOW - 1L;

        public static @string RelocName(ref sys.Arch _arch, objabi.RelocType r) => func(_arch, (ref sys.Arch arch, Defer _, Panic panic, Recover __) =>
        { 
            // We didn't have some relocation types at Go1.4.
            // Uncomment code when we include those in bootstrap code.


            if (r >= 512L)             else if (r >= 256L) // ELF
                var nr = r - 256L;

                if (arch.Family == sys.AMD64) 
                    return elf.R_X86_64(nr).String();
                else if (arch.Family == sys.ARM) 
                    return elf.R_ARM(nr).String();
                else if (arch.Family == sys.ARM64) 
                    return elf.R_AARCH64(nr).String();
                else if (arch.Family == sys.I386) 
                    return elf.R_386(nr).String();
                else if (arch.Family == sys.MIPS || arch.Family == sys.MIPS64)                 else if (arch.Family == sys.PPC64)                 else if (arch.Family == sys.S390X)                 else 
                    panic("unreachable");
                                        return r.String();
        });

        // RelocByOff implements sort.Interface for sorting relocations by offset.
        public partial struct RelocByOff // : slice<Reloc>
        {
        }

        public static long Len(this RelocByOff x)
        {
            return len(x);
        }

        public static void Swap(this RelocByOff x, long i, long j)
        {
            x[i] = x[j];
            x[j] = x[i];

        }

        public static bool Less(this RelocByOff x, long i, long j)
        {
            var a = ref x[i];
            var b = ref x[j];
            if (a.Off < b.Off)
            {
                return true;
            }
            if (a.Off > b.Off)
            {
                return false;
            }
            return false;
        }
    }
}}}}