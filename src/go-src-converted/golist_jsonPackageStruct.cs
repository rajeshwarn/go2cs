//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 06:01:39 UTC
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
using json = go.encoding.json_package;
using fmt = go.fmt_package;
using types = go.go.types_package;
using log = go.log_package;
using os = go.os_package;
using exec = go.os.exec_package;
using path = go.path_package;
using filepath = go.path.filepath_package;
using reflect = go.reflect_package;
using sort = go.sort_package;
using strconv = go.strconv_package;
using strings = go.strings_package;
using sync = go.sync_package;
using unicode = go.unicode_package;
using packagesdriver = go.golang.org.x.tools.go.@internal.packagesdriver_package;
using gocommand = go.golang.org.x.tools.@internal.gocommand_package;
using xerrors = go.golang.org.x.xerrors_package;
using go;

#nullable enable

namespace go {
namespace golang.org {
namespace x {
namespace tools {
namespace go
{
    public static partial class packages_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct jsonPackage
        {
            // Constructors
            public jsonPackage(NilType _)
            {
                this.ImportPath = default;
                this.Dir = default;
                this.Name = default;
                this.Export = default;
                this.GoFiles = default;
                this.CompiledGoFiles = default;
                this.CFiles = default;
                this.CgoFiles = default;
                this.CXXFiles = default;
                this.MFiles = default;
                this.HFiles = default;
                this.FFiles = default;
                this.SFiles = default;
                this.SwigFiles = default;
                this.SwigCXXFiles = default;
                this.SysoFiles = default;
                this.Imports = default;
                this.ImportMap = default;
                this.Deps = default;
                this.Module = default;
                this.TestGoFiles = default;
                this.TestImports = default;
                this.XTestGoFiles = default;
                this.XTestImports = default;
                this.ForTest = default;
                this.DepOnly = default;
                this.Error = default;
            }

            public jsonPackage(@string ImportPath = default, @string Dir = default, @string Name = default, @string Export = default, slice<@string> GoFiles = default, slice<@string> CompiledGoFiles = default, slice<@string> CFiles = default, slice<@string> CgoFiles = default, slice<@string> CXXFiles = default, slice<@string> MFiles = default, slice<@string> HFiles = default, slice<@string> FFiles = default, slice<@string> SFiles = default, slice<@string> SwigFiles = default, slice<@string> SwigCXXFiles = default, slice<@string> SysoFiles = default, slice<@string> Imports = default, map<@string, @string> ImportMap = default, slice<@string> Deps = default, ref ptr<Module> Module = default, slice<@string> TestGoFiles = default, slice<@string> TestImports = default, slice<@string> XTestGoFiles = default, slice<@string> XTestImports = default, @string ForTest = default, bool DepOnly = default, ref ptr<jsonPackageError> Error = default)
            {
                this.ImportPath = ImportPath;
                this.Dir = Dir;
                this.Name = Name;
                this.Export = Export;
                this.GoFiles = GoFiles;
                this.CompiledGoFiles = CompiledGoFiles;
                this.CFiles = CFiles;
                this.CgoFiles = CgoFiles;
                this.CXXFiles = CXXFiles;
                this.MFiles = MFiles;
                this.HFiles = HFiles;
                this.FFiles = FFiles;
                this.SFiles = SFiles;
                this.SwigFiles = SwigFiles;
                this.SwigCXXFiles = SwigCXXFiles;
                this.SysoFiles = SysoFiles;
                this.Imports = Imports;
                this.ImportMap = ImportMap;
                this.Deps = Deps;
                this.Module = Module;
                this.TestGoFiles = TestGoFiles;
                this.TestImports = TestImports;
                this.XTestGoFiles = XTestGoFiles;
                this.XTestImports = XTestImports;
                this.ForTest = ForTest;
                this.DepOnly = DepOnly;
                this.Error = Error;
            }

            // Enable comparisons between nil and jsonPackage struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(jsonPackage value, NilType nil) => value.Equals(default(jsonPackage));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(jsonPackage value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, jsonPackage value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, jsonPackage value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator jsonPackage(NilType nil) => default(jsonPackage);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        private static jsonPackage jsonPackage_cast(dynamic value)
        {
            return new jsonPackage(value.ImportPath, value.Dir, value.Name, value.Export, value.GoFiles, value.CompiledGoFiles, value.CFiles, value.CgoFiles, value.CXXFiles, value.MFiles, value.HFiles, value.FFiles, value.SFiles, value.SwigFiles, value.SwigCXXFiles, value.SysoFiles, value.Imports, value.ImportMap, value.Deps, ref value.Module, value.TestGoFiles, value.TestImports, value.XTestGoFiles, value.XTestImports, value.ForTest, value.DepOnly, ref value.Error);
        }
    }
}}}}}