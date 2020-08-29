// Copyright 2009 The Go Authors. All rights reserved.
// Use of this source code is governed by a BSD-style
// license that can be found in the LICENSE file.

// package main -- go2cs converted at 2020 August 29 08:52:55 UTC
// Original source: C:\Go\src\cmd\cgo\out.go
using bytes = go.bytes_package;
using elf = go.debug.elf_package;
using macho = go.debug.macho_package;
using pe = go.debug.pe_package;
using fmt = go.fmt_package;
using ast = go.go.ast_package;
using printer = go.go.printer_package;
using token = go.go.token_package;
using io = go.io_package;
using os = go.os_package;
using filepath = go.path.filepath_package;
using sort = go.sort_package;
using strings = go.strings_package;
using static go.builtin;
using System;

namespace go
{
    public static partial class main_package
    {
        private static printer.Config conf = new printer.Config(Mode:printer.SourcePos,Tabwidth:8);        private static printer.Config noSourceConf = new printer.Config(Tabwidth:8);

        // writeDefs creates output files to be compiled by gc and gcc.
        private static void writeDefs(this ref Package _p) => func(_p, (ref Package p, Defer defer, Panic panic, Recover _) =>
        {
            io.Writer fgo2 = default;            io.Writer fc = default;

            var f = creat(objDir + "_cgo_gotypes.go".Value);
            defer(f.Close());
            fgo2 = f;
            if (gccgo.Value)
            {
                f = creat(objDir + "_cgo_defun.c".Value);
                defer(f.Close());
                fc = f;
            }
            var fm = creat(objDir + "_cgo_main.c".Value);

            bytes.Buffer gccgoInit = default;

            var fflg = creat(objDir + "_cgo_flags".Value);
            foreach (var (k, v) in p.CgoFlags)
            {
                fmt.Fprintf(fflg, "_CGO_%s=%s\n", k, strings.Join(v, " "));
                if (k == "LDFLAGS" && !gccgo.Value)
                {
                    foreach (var (_, arg) in v)
                    {
                        fmt.Fprintf(fgo2, "//go:cgo_ldflag %q\n", arg);
                    }
                }
            }
            fflg.Close(); 

            // Write C main file for using gcc to resolve imports.
            fmt.Fprintf(fm, "int main() { return 0; }\n");
            if (importRuntimeCgo.Value)
            {
                fmt.Fprintf(fm, "void crosscall2(void(*fn)(void*, int, __SIZE_TYPE__), void *a, int c, __SIZE_TYPE__ ctxt) { }\n");
                fmt.Fprintf(fm, "__SIZE_TYPE__ _cgo_wait_runtime_init_done() { return 0; }\n");
                fmt.Fprintf(fm, "void _cgo_release_context(__SIZE_TYPE__ ctxt) { }\n");
                fmt.Fprintf(fm, "char* _cgo_topofstack(void) { return (char*)0; }\n");
            }
            else
            { 
                // If we're not importing runtime/cgo, we *are* runtime/cgo,
                // which provides these functions. We just need a prototype.
                fmt.Fprintf(fm, "void crosscall2(void(*fn)(void*, int, __SIZE_TYPE__), void *a, int c, __SIZE_TYPE__ ctxt);\n");
                fmt.Fprintf(fm, "__SIZE_TYPE__ _cgo_wait_runtime_init_done();\n");
                fmt.Fprintf(fm, "void _cgo_release_context(__SIZE_TYPE__);\n");
            }
            fmt.Fprintf(fm, "void _cgo_allocate(void *a, int c) { }\n");
            fmt.Fprintf(fm, "void _cgo_panic(void *a, int c) { }\n");
            fmt.Fprintf(fm, "void _cgo_reginit(void) { }\n"); 

            // Write second Go output: definitions of _C_xxx.
            // In a separate file so that the import of "unsafe" does not
            // pollute the original file.
            fmt.Fprintf(fgo2, "// Created by cgo - DO NOT EDIT\n\n");
            fmt.Fprintf(fgo2, "package %s\n\n", p.PackageName);
            fmt.Fprintf(fgo2, "import \"unsafe\"\n\n");
            if (!gccgo && importRuntimeCgo.Value.Value)
            {
                fmt.Fprintf(fgo2, "import _ \"runtime/cgo\"\n\n");
            }
            if (importSyscall.Value)
            {
                fmt.Fprintf(fgo2, "import \"syscall\"\n\n");
                fmt.Fprintf(fgo2, "var _ syscall.Errno\n");
            }
            fmt.Fprintf(fgo2, "func _Cgo_ptr(ptr unsafe.Pointer) unsafe.Pointer { return ptr }\n\n");

            if (!gccgo.Value)
            {
                fmt.Fprintf(fgo2, "//go:linkname _Cgo_always_false runtime.cgoAlwaysFalse\n");
                fmt.Fprintf(fgo2, "var _Cgo_always_false bool\n");
                fmt.Fprintf(fgo2, "//go:linkname _Cgo_use runtime.cgoUse\n");
                fmt.Fprintf(fgo2, "func _Cgo_use(interface{})\n");
            }
            var typedefNames = make_slice<@string>(0L, len(typedef));
            {
                var name__prev1 = name;

                foreach (var (__name) in typedef)
                {
                    name = __name;
                    typedefNames = append(typedefNames, name);
                }

                name = name__prev1;
            }

            sort.Strings(typedefNames);
            {
                var name__prev1 = name;

                foreach (var (_, __name) in typedefNames)
                {
                    name = __name;
                    var def = typedef[name];
                    fmt.Fprintf(fgo2, "type %s ", name); 
                    // We don't have source info for these types, so write them out without source info.
                    // Otherwise types would look like:
                    //
                    // type _Ctype_struct_cb struct {
                    // //line :1
                    //        on_test *[0]byte
                    // //line :1
                    // }
                    //
                    // Which is not useful. Moreover we never override source info,
                    // so subsequent source code uses the same source info.
                    // Moreover, empty file name makes compile emit no source debug info at all.
                    bytes.Buffer buf = default;
                    noSourceConf.Fprint(ref buf, fset, def.Go);
                    if (bytes.HasPrefix(buf.Bytes(), (slice<byte>)"_Ctype_"))
                    { 
                        // This typedef is of the form `typedef a b` and should be an alias.
                        fmt.Fprintf(fgo2, "= ");
                    }
                    fmt.Fprintf(fgo2, "%s", buf.Bytes());
                    fmt.Fprintf(fgo2, "\n\n");
                }

                name = name__prev1;
            }

            if (gccgo.Value)
            {
                fmt.Fprintf(fgo2, "type _Ctype_void byte\n");
            }
            else
            {
                fmt.Fprintf(fgo2, "type _Ctype_void [0]byte\n");
            }
            if (gccgo.Value)
            {
                fmt.Fprint(fgo2, gccgoGoProlog);
                fmt.Fprint(fc, p.cPrologGccgo());
            }
            else
            {
                fmt.Fprint(fgo2, goProlog);
            }
            if (fc != null)
            {
                fmt.Fprintf(fc, "#line 1 \"cgo-generated-wrappers\"\n");
            }
            if (fm != null)
            {
                fmt.Fprintf(fm, "#line 1 \"cgo-generated-wrappers\"\n");
            }
            var gccgoSymbolPrefix = p.gccgoSymbolPrefix();

            var cVars = make_map<@string, bool>();
            {
                var key__prev1 = key;

                foreach (var (_, __key) in nameKeys(p.Name))
                {
                    key = __key;
                    var n = p.Name[key];
                    if (!n.IsVar())
                    {
                        continue;
                    }
                    if (!cVars[n.C])
                    {
                        if (gccgo.Value)
                        {
                            fmt.Fprintf(fc, "extern byte *%s;\n", n.C);
                        }
                        else
                        {
                            fmt.Fprintf(fm, "extern char %s[];\n", n.C);
                            fmt.Fprintf(fm, "void *_cgohack_%s = %s;\n\n", n.C, n.C);
                            fmt.Fprintf(fgo2, "//go:linkname __cgo_%s %s\n", n.C, n.C);
                            fmt.Fprintf(fgo2, "//go:cgo_import_static %s\n", n.C);
                            fmt.Fprintf(fgo2, "var __cgo_%s byte\n", n.C);
                        }
                        cVars[n.C] = true;
                    }
                    ast.Node node = default;
                    if (n.Kind == "var")
                    {
                        node = ref new ast.StarExpr(X:n.Type.Go);
                    }
                    else if (n.Kind == "fpvar")
                    {
                        node = n.Type.Go;
                    }
                    else
                    {
                        panic(fmt.Errorf("invalid var kind %q", n.Kind));
                    }
                    if (gccgo.Value)
                    {
                        fmt.Fprintf(fc, "extern void *%s __asm__(\"%s.%s\");", n.Mangle, gccgoSymbolPrefix, n.Mangle);
                        fmt.Fprintf(ref gccgoInit, "\t%s = &%s;\n", n.Mangle, n.C);
                        fmt.Fprintf(fc, "\n");
                    }
                    fmt.Fprintf(fgo2, "var %s ", n.Mangle);
                    conf.Fprint(fgo2, fset, node);
                    if (!gccgo.Value)
                    {
                        fmt.Fprintf(fgo2, " = (");
                        conf.Fprint(fgo2, fset, node);
                        fmt.Fprintf(fgo2, ")(unsafe.Pointer(&__cgo_%s))", n.C);
                    }
                    fmt.Fprintf(fgo2, "\n");
                }

                key = key__prev1;
            }

            if (gccgo.Value)
            {
                fmt.Fprintf(fc, "\n");
            }
            {
                var key__prev1 = key;

                foreach (var (_, __key) in nameKeys(p.Name))
                {
                    key = __key;
                    n = p.Name[key];
                    if (n.Const != "")
                    {
                        fmt.Fprintf(fgo2, "const %s = %s\n", n.Mangle, n.Const);
                    }
                }

                key = key__prev1;
            }

            fmt.Fprintf(fgo2, "\n");

            var callsMalloc = false;
            {
                var key__prev1 = key;

                foreach (var (_, __key) in nameKeys(p.Name))
                {
                    key = __key;
                    n = p.Name[key];
                    if (n.FuncType != null)
                    {
                        p.writeDefsFunc(fgo2, n, ref callsMalloc);
                    }
                }

                key = key__prev1;
            }

            var fgcc = creat(objDir + "_cgo_export.c".Value);
            var fgcch = creat(objDir + "_cgo_export.h".Value);
            if (gccgo.Value)
            {
                p.writeGccgoExports(fgo2, fm, fgcc, fgcch);
            }
            else
            {
                p.writeExports(fgo2, fm, fgcc, fgcch);
            }
            if (callsMalloc && !gccgo.Value)
            {
                fmt.Fprint(fgo2, strings.Replace(cMallocDefGo, "PREFIX", cPrefix, -1L));
                fmt.Fprint(fgcc, strings.Replace(strings.Replace(cMallocDefC, "PREFIX", cPrefix, -1L), "PACKED", p.packedAttribute(), -1L));
            }
            {
                var err__prev1 = err;

                var err = fgcc.Close();

                if (err != null)
                {
                    fatalf("%s", err);
                }

                err = err__prev1;

            }
            {
                var err__prev1 = err;

                err = fgcch.Close();

                if (err != null)
                {
                    fatalf("%s", err);
                }

                err = err__prev1;

            }

            if (exportHeader != "" && len(p.ExpFunc) > 0L.Value)
            {
                var fexp = creat(exportHeader.Value);
                var (fgcch, err) = os.Open(objDir + "_cgo_export.h".Value);
                if (err != null)
                {
                    fatalf("%s", err);
                }
                _, err = io.Copy(fexp, fgcch);
                if (err != null)
                {
                    fatalf("%s", err);
                }
                err = fexp.Close();

                if (err != null)
                {
                    fatalf("%s", err);
                }
            }
            var init = gccgoInit.String();
            if (init != "")
            {
                fmt.Fprintln(fc, "static void init(void) __attribute__ ((constructor));");
                fmt.Fprintln(fc, "static void init(void) {");
                fmt.Fprint(fc, init);
                fmt.Fprintln(fc, "}");
            }
        });

        private static void dynimport(@string obj)
        {
            var stdout = os.Stdout;
            if (dynout != "".Value)
            {
                var (f, err) = os.Create(dynout.Value);
                if (err != null)
                {
                    fatalf("%s", err);
                }
                stdout = f;
            }
            fmt.Fprintf(stdout, "package %s\n", dynpackage.Value);

            {
                var f__prev1 = f;

                (f, err) = elf.Open(obj);

                if (err == null)
                {
                    if (dynlinker.Value)
                    { 
                        // Emit the cgo_dynamic_linker line.
                        {
                            var sec = f.Section(".interp");

                            if (sec != null)
                            {
                                {
                                    var (data, err) = sec.Data();

                                    if (err == null && len(data) > 1L)
                                    { 
                                        // skip trailing \0 in data
                                        fmt.Fprintf(stdout, "//go:cgo_dynamic_linker %q\n", string(data[..len(data) - 1L]));
                                    }

                                }
                            }

                        }
                    }
                    var (sym, err) = f.ImportedSymbols();
                    if (err != null)
                    {
                        fatalf("cannot load imported symbols from ELF file %s: %v", obj, err);
                    }
                    {
                        var s__prev1 = s;

                        foreach (var (_, __s) in sym)
                        {
                            s = __s;
                            var targ = s.Name;
                            if (s.Version != "")
                            {
                                targ += "#" + s.Version;
                            }
                            fmt.Fprintf(stdout, "//go:cgo_import_dynamic %s %s %q\n", s.Name, targ, s.Library);
                        }

                        s = s__prev1;
                    }

                    var (lib, err) = f.ImportedLibraries();
                    if (err != null)
                    {
                        fatalf("cannot load imported libraries from ELF file %s: %v", obj, err);
                    }
                    {
                        var l__prev1 = l;

                        foreach (var (_, __l) in lib)
                        {
                            l = __l;
                            fmt.Fprintf(stdout, "//go:cgo_import_dynamic _ _ %q\n", l);
                        }

                        l = l__prev1;
                    }

                    return;
                }

                f = f__prev1;

            }

            {
                var f__prev1 = f;

                (f, err) = macho.Open(obj);

                if (err == null)
                {
                    (sym, err) = f.ImportedSymbols();
                    if (err != null)
                    {
                        fatalf("cannot load imported symbols from Mach-O file %s: %v", obj, err);
                    }
                    {
                        var s__prev1 = s;

                        foreach (var (_, __s) in sym)
                        {
                            s = __s;
                            if (len(s) > 0L && s[0L] == '_')
                            {
                                s = s[1L..];
                            }
                            fmt.Fprintf(stdout, "//go:cgo_import_dynamic %s %s %q\n", s, s, "");
                        }

                        s = s__prev1;
                    }

                    (lib, err) = f.ImportedLibraries();
                    if (err != null)
                    {
                        fatalf("cannot load imported libraries from Mach-O file %s: %v", obj, err);
                    }
                    {
                        var l__prev1 = l;

                        foreach (var (_, __l) in lib)
                        {
                            l = __l;
                            fmt.Fprintf(stdout, "//go:cgo_import_dynamic _ _ %q\n", l);
                        }

                        l = l__prev1;
                    }

                    return;
                }

                f = f__prev1;

            }

            {
                var f__prev1 = f;

                (f, err) = pe.Open(obj);

                if (err == null)
                {
                    (sym, err) = f.ImportedSymbols();
                    if (err != null)
                    {
                        fatalf("cannot load imported symbols from PE file %s: %v", obj, err);
                    }
                    {
                        var s__prev1 = s;

                        foreach (var (_, __s) in sym)
                        {
                            s = __s;
                            var ss = strings.Split(s, ":");
                            var name = strings.Split(ss[0L], "@")[0L];
                            fmt.Fprintf(stdout, "//go:cgo_import_dynamic %s %s %q\n", name, ss[0L], strings.ToLower(ss[1L]));
                        }

                        s = s__prev1;
                    }

                    return;
                }

                f = f__prev1;

            }

            fatalf("cannot parse %s as ELF, Mach-O or PE", obj);
        }

        // Construct a gcc struct matching the gc argument frame.
        // Assumes that in gcc, char is 1 byte, short 2 bytes, int 4 bytes, long long 8 bytes.
        // These assumptions are checked by the gccProlog.
        // Also assumes that gc convention is to word-align the
        // input and output parameters.
        private static (@string, long) structType(this ref Package p, ref Name n)
        {
            bytes.Buffer buf = default;
            fmt.Fprint(ref buf, "struct {\n");
            var off = int64(0L);
            {
                var t__prev1 = t;

                foreach (var (__i, __t) in n.FuncType.Params)
                {
                    i = __i;
                    t = __t;
                    if (off % t.Align != 0L)
                    {
                        var pad = t.Align - off % t.Align;
                        fmt.Fprintf(ref buf, "\t\tchar __pad%d[%d];\n", off, pad);
                        off += pad;
                    }
                    var c = t.Typedef;
                    if (c == "")
                    {
                        c = t.C.String();
                    }
                    fmt.Fprintf(ref buf, "\t\t%s p%d;\n", c, i);
                    off += t.Size;
                }

                t = t__prev1;
            }

            if (off % p.PtrSize != 0L)
            {
                pad = p.PtrSize - off % p.PtrSize;
                fmt.Fprintf(ref buf, "\t\tchar __pad%d[%d];\n", off, pad);
                off += pad;
            }
            {
                var t__prev1 = t;

                var t = n.FuncType.Result;

                if (t != null)
                {
                    if (off % t.Align != 0L)
                    {
                        pad = t.Align - off % t.Align;
                        fmt.Fprintf(ref buf, "\t\tchar __pad%d[%d];\n", off, pad);
                        off += pad;
                    }
                    fmt.Fprintf(ref buf, "\t\t%s r;\n", t.C);
                    off += t.Size;
                }

                t = t__prev1;

            }
            if (off % p.PtrSize != 0L)
            {
                pad = p.PtrSize - off % p.PtrSize;
                fmt.Fprintf(ref buf, "\t\tchar __pad%d[%d];\n", off, pad);
                off += pad;
            }
            if (off == 0L)
            {
                fmt.Fprintf(ref buf, "\t\tchar unused;\n"); // avoid empty struct
            }
            fmt.Fprintf(ref buf, "\t}");
            return (buf.String(), off);
        }

        private static void writeDefsFunc(this ref Package p, io.Writer fgo2, ref Name n, ref bool callsMalloc)
        {
            var name = n.Go;
            var gtype = n.FuncType.Go;
            var @void = gtype.Results == null || len(gtype.Results.List) == 0L;
            if (n.AddError)
            { 
                // Add "error" to return type list.
                // Type list is known to be 0 or 1 element - it's a C function.
                ast.Field err = ref new ast.Field(Type:ast.NewIdent("error"));
                var l = gtype.Results.List;
                if (len(l) == 0L)
                {
                    l = new slice<ref ast.Field>(new ref ast.Field[] { err });
                }
                else
                {
                    l = new slice<ref ast.Field>(new ref ast.Field[] { l[0], err });
                }
                ptr<object> t = @new<ast.FuncType>();
                t.Value = gtype.Value;
                t.Results = ref new ast.FieldList(List:l);
                gtype = t;
            } 

            // Go func declaration.
            ast.FuncDecl d = ref new ast.FuncDecl(Name:ast.NewIdent(n.Mangle),Type:gtype,); 

            // Builtins defined in the C prolog.
            var inProlog = builtinDefs[name] != "";
            var cname = fmt.Sprintf("_cgo%s%s", cPrefix, n.Mangle);
            slice<@string> paramnames = (slice<@string>)null;
            if (d.Type.Params != null)
            {
                {
                    var i__prev1 = i;

                    foreach (var (__i, __param) in d.Type.Params.List)
                    {
                        i = __i;
                        param = __param;
                        var paramName = fmt.Sprintf("p%d", i);
                        param.Names = new slice<ref ast.Ident>(new ref ast.Ident[] { ast.NewIdent(paramName) });
                        paramnames = append(paramnames, paramName);
                    }

                    i = i__prev1;
                }

            }
            if (gccgo.Value)
            { 
                // Gccgo style hooks.
                fmt.Fprint(fgo2, "\n");
                conf.Fprint(fgo2, fset, d);
                fmt.Fprint(fgo2, " {\n");
                if (!inProlog)
                {
                    fmt.Fprint(fgo2, "\tdefer syscall.CgocallDone()\n");
                    fmt.Fprint(fgo2, "\tsyscall.Cgocall()\n");
                }
                if (n.AddError)
                {
                    fmt.Fprint(fgo2, "\tsyscall.SetErrno(0)\n");
                }
                fmt.Fprint(fgo2, "\t");
                if (!void)
                {
                    fmt.Fprint(fgo2, "r := ");
                }
                fmt.Fprintf(fgo2, "%s(%s)\n", cname, strings.Join(paramnames, ", "));

                if (n.AddError)
                {
                    fmt.Fprint(fgo2, "\te := syscall.GetErrno()\n");
                    fmt.Fprint(fgo2, "\tif e != 0 {\n");
                    fmt.Fprint(fgo2, "\t\treturn ");
                    if (!void)
                    {
                        fmt.Fprint(fgo2, "r, ");
                    }
                    fmt.Fprint(fgo2, "e\n");
                    fmt.Fprint(fgo2, "\t}\n");
                    fmt.Fprint(fgo2, "\treturn ");
                    if (!void)
                    {
                        fmt.Fprint(fgo2, "r, ");
                    }
                    fmt.Fprint(fgo2, "nil\n");
                }
                else if (!void)
                {
                    fmt.Fprint(fgo2, "\treturn r\n");
                }
                fmt.Fprint(fgo2, "}\n"); 

                // declare the C function.
                fmt.Fprintf(fgo2, "//extern %s\n", cname);
                d.Name = ast.NewIdent(cname);
                if (n.AddError)
                {
                    l = d.Type.Results.List;
                    d.Type.Results.List = l[..len(l) - 1L];
                }
                conf.Fprint(fgo2, fset, d);
                fmt.Fprint(fgo2, "\n");

                return;
            }
            if (inProlog)
            {
                fmt.Fprint(fgo2, builtinDefs[name]);
                if (strings.Contains(builtinDefs[name], "_cgo_cmalloc"))
                {
                    callsMalloc.Value = true;
                }
                return;
            } 

            // Wrapper calls into gcc, passing a pointer to the argument frame.
            fmt.Fprintf(fgo2, "//go:cgo_import_static %s\n", cname);
            fmt.Fprintf(fgo2, "//go:linkname __cgofn_%s %s\n", cname, cname);
            fmt.Fprintf(fgo2, "var __cgofn_%s byte\n", cname);
            fmt.Fprintf(fgo2, "var %s = unsafe.Pointer(&__cgofn_%s)\n", cname, cname);

            long nret = 0L;
            if (!void)
            {
                d.Type.Results.List[0L].Names = new slice<ref ast.Ident>(new ref ast.Ident[] { ast.NewIdent("r1") });
                nret = 1L;
            }
            if (n.AddError)
            {
                d.Type.Results.List[nret].Names = new slice<ref ast.Ident>(new ref ast.Ident[] { ast.NewIdent("r2") });
            }
            fmt.Fprint(fgo2, "\n");
            fmt.Fprint(fgo2, "//go:cgo_unsafe_args\n");
            conf.Fprint(fgo2, fset, d);
            fmt.Fprint(fgo2, " {\n"); 

            // NOTE: Using uintptr to hide from escape analysis.
            @string arg = "0";
            if (len(paramnames) > 0L)
            {
                arg = "uintptr(unsafe.Pointer(&p0))";
            }
            else if (!void)
            {
                arg = "uintptr(unsafe.Pointer(&r1))";
            }
            @string prefix = "";
            if (n.AddError)
            {
                prefix = "errno := ";
            }
            fmt.Fprintf(fgo2, "\t%s_cgo_runtime_cgocall(%s, %s)\n", prefix, cname, arg);
            if (n.AddError)
            {
                fmt.Fprintf(fgo2, "\tif errno != 0 { r2 = syscall.Errno(errno) }\n");
            }
            fmt.Fprintf(fgo2, "\tif _Cgo_always_false {\n");
            if (d.Type.Params != null)
            {
                {
                    var i__prev1 = i;

                    foreach (var (__i) in d.Type.Params.List)
                    {
                        i = __i;
                        fmt.Fprintf(fgo2, "\t\t_Cgo_use(p%d)\n", i);
                    }

                    i = i__prev1;
                }

            }
            fmt.Fprintf(fgo2, "\t}\n");
            fmt.Fprintf(fgo2, "\treturn\n");
            fmt.Fprintf(fgo2, "}\n");
        }

        // writeOutput creates stubs for a specific source file to be compiled by gc
        private static void writeOutput(this ref Package p, ref File f, @string srcfile)
        {
            var @base = srcfile;
            if (strings.HasSuffix(base, ".go"))
            {
                base = base[0L..len(base) - 3L];
            }
            base = filepath.Base(base);
            var fgo1 = creat(objDir + base + ".cgo1.go".Value);
            var fgcc = creat(objDir + base + ".cgo2.c".Value);

            p.GoFiles = append(p.GoFiles, base + ".cgo1.go");
            p.GccFiles = append(p.GccFiles, base + ".cgo2.c"); 

            // Write Go output: Go input with rewrites of C.xxx to _C_xxx.
            fmt.Fprintf(fgo1, "// Created by cgo - DO NOT EDIT\n\n");
            fmt.Fprintf(fgo1, "//line %s:1\n", srcfile);
            fgo1.Write(f.Edit.Bytes()); 

            // While we process the vars and funcs, also write gcc output.
            // Gcc output starts with the preamble.
            fmt.Fprintf(fgcc, "%s\n", builtinProlog);
            fmt.Fprintf(fgcc, "%s\n", f.Preamble);
            fmt.Fprintf(fgcc, "%s\n", gccProlog);
            fmt.Fprintf(fgcc, "%s\n", tsanProlog);

            foreach (var (_, key) in nameKeys(f.Name))
            {
                var n = f.Name[key];
                if (n.FuncType != null)
                {
                    p.writeOutputFunc(fgcc, n);
                }
            }
            fgo1.Close();
            fgcc.Close();
        }

        // fixGo converts the internal Name.Go field into the name we should show
        // to users in error messages. There's only one for now: on input we rewrite
        // C.malloc into C._CMalloc, so change it back here.
        private static @string fixGo(@string name)
        {
            if (name == "_CMalloc")
            {
                return "malloc";
            }
            return name;
        }

        private static map isBuiltin = /* TODO: Fix this in ScannerBase_Expression::ExitCompositeLit */ new map<@string, bool>{"_Cfunc_CString":true,"_Cfunc_CBytes":true,"_Cfunc_GoString":true,"_Cfunc_GoStringN":true,"_Cfunc_GoBytes":true,"_Cfunc__CMalloc":true,};

        private static void writeOutputFunc(this ref Package p, ref os.File fgcc, ref Name n)
        {
            var name = n.Mangle;
            if (isBuiltin[name] || p.Written[name])
            { 
                // The builtins are already defined in the C prolog, and we don't
                // want to duplicate function definitions we've already done.
                return;
            }
            p.Written[name] = true;

            if (gccgo.Value)
            {
                p.writeGccgoOutputFunc(fgcc, n);
                return;
            }
            var (ctype, _) = p.structType(n); 

            // Gcc wrapper unpacks the C argument struct
            // and calls the actual C function.
            fmt.Fprintf(fgcc, "CGO_NO_SANITIZE_THREAD\n");
            if (n.AddError)
            {
                fmt.Fprintf(fgcc, "int\n");
            }
            else
            {
                fmt.Fprintf(fgcc, "void\n");
            }
            fmt.Fprintf(fgcc, "_cgo%s%s(void *v)\n", cPrefix, n.Mangle);
            fmt.Fprintf(fgcc, "{\n");
            if (n.AddError)
            {
                fmt.Fprintf(fgcc, "\tint _cgo_errno;\n");
            } 
            // We're trying to write a gcc struct that matches gc's layout.
            // Use packed attribute to force no padding in this struct in case
            // gcc has different packing requirements.
            fmt.Fprintf(fgcc, "\t%s %v *a = v;\n", ctype, p.packedAttribute());
            if (n.FuncType.Result != null)
            { 
                // Save the stack top for use below.
                fmt.Fprintf(fgcc, "\tchar *stktop = _cgo_topofstack();\n");
            }
            var tr = n.FuncType.Result;
            if (tr != null)
            {
                fmt.Fprintf(fgcc, "\t__typeof__(a->r) r;\n");
            }
            fmt.Fprintf(fgcc, "\t_cgo_tsan_acquire();\n");
            if (n.AddError)
            {
                fmt.Fprintf(fgcc, "\terrno = 0;\n");
            }
            fmt.Fprintf(fgcc, "\t");
            if (tr != null)
            {
                fmt.Fprintf(fgcc, "r = ");
                {
                    var c = tr.C.String();

                    if (c[len(c) - 1L] == '*')
                    {
                        fmt.Fprint(fgcc, "(__typeof__(a->r)) ");
                    }

                }
            }
            if (n.Kind == "macro")
            {
                fmt.Fprintf(fgcc, "%s;\n", n.C);
            }
            else
            {
                fmt.Fprintf(fgcc, "%s(", n.C);
                foreach (var (i) in n.FuncType.Params)
                {
                    if (i > 0L)
                    {
                        fmt.Fprintf(fgcc, ", ");
                    }
                    fmt.Fprintf(fgcc, "a->p%d", i);
                }
                fmt.Fprintf(fgcc, ");\n");
            }
            if (n.AddError)
            {
                fmt.Fprintf(fgcc, "\t_cgo_errno = errno;\n");
            }
            fmt.Fprintf(fgcc, "\t_cgo_tsan_release();\n");
            if (n.FuncType.Result != null)
            { 
                // The cgo call may have caused a stack copy (via a callback).
                // Adjust the return value pointer appropriately.
                fmt.Fprintf(fgcc, "\ta = (void*)((char*)a + (_cgo_topofstack() - stktop));\n"); 
                // Save the return value.
                fmt.Fprintf(fgcc, "\ta->r = r;\n");
            }
            if (n.AddError)
            {
                fmt.Fprintf(fgcc, "\treturn _cgo_errno;\n");
            }
            fmt.Fprintf(fgcc, "}\n");
            fmt.Fprintf(fgcc, "\n");
        }

        // Write out a wrapper for a function when using gccgo. This is a
        // simple wrapper that just calls the real function. We only need a
        // wrapper to support static functions in the prologue--without a
        // wrapper, we can't refer to the function, since the reference is in
        // a different file.
        private static void writeGccgoOutputFunc(this ref Package p, ref os.File fgcc, ref Name n)
        {
            fmt.Fprintf(fgcc, "CGO_NO_SANITIZE_THREAD\n");
            {
                var t__prev1 = t;

                var t = n.FuncType.Result;

                if (t != null)
                {
                    fmt.Fprintf(fgcc, "%s\n", t.C.String());
                }
                else
                {
                    fmt.Fprintf(fgcc, "void\n");
                }

                t = t__prev1;

            }
            fmt.Fprintf(fgcc, "_cgo%s%s(", cPrefix, n.Mangle);
            {
                var i__prev1 = i;
                var t__prev1 = t;

                foreach (var (__i, __t) in n.FuncType.Params)
                {
                    i = __i;
                    t = __t;
                    if (i > 0L)
                    {
                        fmt.Fprintf(fgcc, ", ");
                    }
                    var c = t.Typedef;
                    if (c == "")
                    {
                        c = t.C.String();
                    }
                    fmt.Fprintf(fgcc, "%s p%d", c, i);
                }

                i = i__prev1;
                t = t__prev1;
            }

            fmt.Fprintf(fgcc, ")\n");
            fmt.Fprintf(fgcc, "{\n");
            {
                var t__prev1 = t;

                t = n.FuncType.Result;

                if (t != null)
                {
                    fmt.Fprintf(fgcc, "\t%s r;\n", t.C.String());
                }

                t = t__prev1;

            }
            fmt.Fprintf(fgcc, "\t_cgo_tsan_acquire();\n");
            fmt.Fprintf(fgcc, "\t");
            {
                var t__prev1 = t;

                t = n.FuncType.Result;

                if (t != null)
                {
                    fmt.Fprintf(fgcc, "r = "); 
                    // Cast to void* to avoid warnings due to omitted qualifiers.
                    {
                        var c__prev2 = c;

                        c = t.C.String();

                        if (c[len(c) - 1L] == '*')
                        {
                            fmt.Fprintf(fgcc, "(void*)");
                        }

                        c = c__prev2;

                    }
                }

                t = t__prev1;

            }
            if (n.Kind == "macro")
            {
                fmt.Fprintf(fgcc, "%s;\n", n.C);
            }
            else
            {
                fmt.Fprintf(fgcc, "%s(", n.C);
                {
                    var i__prev1 = i;

                    foreach (var (__i) in n.FuncType.Params)
                    {
                        i = __i;
                        if (i > 0L)
                        {
                            fmt.Fprintf(fgcc, ", ");
                        }
                        fmt.Fprintf(fgcc, "p%d", i);
                    }

                    i = i__prev1;
                }

                fmt.Fprintf(fgcc, ");\n");
            }
            fmt.Fprintf(fgcc, "\t_cgo_tsan_release();\n");
            {
                var t__prev1 = t;

                t = n.FuncType.Result;

                if (t != null)
                {
                    fmt.Fprintf(fgcc, "\treturn "); 
                    // Cast to void* to avoid warnings due to omitted qualifiers
                    // and explicit incompatible struct types.
                    {
                        var c__prev2 = c;

                        c = t.C.String();

                        if (c[len(c) - 1L] == '*')
                        {
                            fmt.Fprintf(fgcc, "(void*)");
                        }

                        c = c__prev2;

                    }
                    fmt.Fprintf(fgcc, "r;\n");
                }

                t = t__prev1;

            }
            fmt.Fprintf(fgcc, "}\n");
            fmt.Fprintf(fgcc, "\n");
        }

        // packedAttribute returns host compiler struct attribute that will be
        // used to match gc's struct layout. For example, on 386 Windows,
        // gcc wants to 8-align int64s, but gc does not.
        // Use __gcc_struct__ to work around http://gcc.gnu.org/PR52991 on x86,
        // and https://golang.org/issue/5603.
        private static @string packedAttribute(this ref Package p)
        {
            @string s = "__attribute__((__packed__";
            if (!p.GccIsClang && (goarch == "amd64" || goarch == "386"))
            {
                s += ", __gcc_struct__";
            }
            return s + "))";
        }

        // Write out the various stubs we need to support functions exported
        // from Go so that they are callable from C.
        private static void writeExports(this ref Package p, io.Writer fgo2, io.Writer fm, io.Writer fgcc, io.Writer fgcch)
        {
            p.writeExportHeader(fgcch);

            fmt.Fprintf(fgcc, "/* Created by cgo - DO NOT EDIT. */\n");
            fmt.Fprintf(fgcc, "#include <stdlib.h>\n");
            fmt.Fprintf(fgcc, "#include \"_cgo_export.h\"\n\n");

            fmt.Fprintf(fgcc, "extern void crosscall2(void (*fn)(void *, int, __SIZE_TYPE__), void *, int, __SIZE_TYPE__);\n");
            fmt.Fprintf(fgcc, "extern __SIZE_TYPE__ _cgo_wait_runtime_init_done();\n");
            fmt.Fprintf(fgcc, "extern void _cgo_release_context(__SIZE_TYPE__);\n\n");
            fmt.Fprintf(fgcc, "extern char* _cgo_topofstack(void);");
            fmt.Fprintf(fgcc, "%s\n", tsanProlog);

            foreach (var (_, exp) in p.ExpFunc)
            {
                var fn = exp.Func; 

                // Construct a gcc struct matching the gc argument and
                // result frame. The gcc struct will be compiled with
                // __attribute__((packed)) so all padding must be accounted
                // for explicitly.
                @string ctype = "struct {\n";
                var off = int64(0L);
                long npad = 0L;
                if (fn.Recv != null)
                {
                    var t = p.cgoType(fn.Recv.List[0L].Type);
                    ctype += fmt.Sprintf("\t\t%s recv;\n", t.C);
                    off += t.Size;
                }
                var fntype = fn.Type;
                forFieldList(fntype.Params, (i, aname, atype) =>
                {
                    t = p.cgoType(atype);
                    if (off % t.Align != 0L)
                    {
                        var pad = t.Align - off % t.Align;
                        ctype += fmt.Sprintf("\t\tchar __pad%d[%d];\n", npad, pad);
                        off += pad;
                        npad++;
                    }
                    ctype += fmt.Sprintf("\t\t%s p%d;\n", t.C, i);
                    off += t.Size;
                });
                if (off % p.PtrSize != 0L)
                {
                    pad = p.PtrSize - off % p.PtrSize;
                    ctype += fmt.Sprintf("\t\tchar __pad%d[%d];\n", npad, pad);
                    off += pad;
                    npad++;
                }
                forFieldList(fntype.Results, (i, aname, atype) =>
                {
                    t = p.cgoType(atype);
                    if (off % t.Align != 0L)
                    {
                        pad = t.Align - off % t.Align;
                        ctype += fmt.Sprintf("\t\tchar __pad%d[%d];\n", npad, pad);
                        off += pad;
                        npad++;
                    }
                    ctype += fmt.Sprintf("\t\t%s r%d;\n", t.C, i);
                    off += t.Size;
                });
                if (off % p.PtrSize != 0L)
                {
                    pad = p.PtrSize - off % p.PtrSize;
                    ctype += fmt.Sprintf("\t\tchar __pad%d[%d];\n", npad, pad);
                    off += pad;
                    npad++;
                }
                if (ctype == "struct {\n")
                {
                    ctype += "\t\tchar unused;\n"; // avoid empty struct
                }
                ctype += "\t}"; 

                // Get the return type of the wrapper function
                // compiled by gcc.
                @string gccResult = "";
                if (fntype.Results == null || len(fntype.Results.List) == 0L)
                {
                    gccResult = "void";
                }
                else if (len(fntype.Results.List) == 1L && len(fntype.Results.List[0L].Names) <= 1L)
                {
                    gccResult = p.cgoType(fntype.Results.List[0L].Type).C.String();
                }
                else
                {
                    fmt.Fprintf(fgcch, "\n/* Return type for %s */\n", exp.ExpName);
                    fmt.Fprintf(fgcch, "struct %s_return {\n", exp.ExpName);
                    forFieldList(fntype.Results, (i, aname, atype) =>
                    {
                        fmt.Fprintf(fgcch, "\t%s r%d;", p.cgoType(atype).C, i);
                        if (len(aname) > 0L)
                        {
                            fmt.Fprintf(fgcch, " /* %s */", aname);
                        }
                        fmt.Fprint(fgcch, "\n");
                    });
                    fmt.Fprintf(fgcch, "};\n");
                    gccResult = "struct " + exp.ExpName + "_return";
                } 

                // Build the wrapper function compiled by gcc.
                var s = fmt.Sprintf("%s %s(", gccResult, exp.ExpName);
                if (fn.Recv != null)
                {
                    s += p.cgoType(fn.Recv.List[0L].Type).C.String();
                    s += " recv";
                }
                forFieldList(fntype.Params, (i, aname, atype) =>
                {
                    if (i > 0L || fn.Recv != null)
                    {
                        s += ", ";
                    }
                    s += fmt.Sprintf("%s p%d", p.cgoType(atype).C, i);
                });
                s += ")";

                if (len(exp.Doc) > 0L)
                {
                    fmt.Fprintf(fgcch, "\n%s", exp.Doc);
                }
                fmt.Fprintf(fgcch, "\nextern %s;\n", s);

                fmt.Fprintf(fgcc, "extern void _cgoexp%s_%s(void *, int, __SIZE_TYPE__);\n", cPrefix, exp.ExpName);
                fmt.Fprintf(fgcc, "\nCGO_NO_SANITIZE_THREAD");
                fmt.Fprintf(fgcc, "\n%s\n", s);
                fmt.Fprintf(fgcc, "{\n");
                fmt.Fprintf(fgcc, "\t__SIZE_TYPE__ _cgo_ctxt = _cgo_wait_runtime_init_done();\n");
                fmt.Fprintf(fgcc, "\t%s %v a;\n", ctype, p.packedAttribute());
                if (gccResult != "void" && (len(fntype.Results.List) > 1L || len(fntype.Results.List[0L].Names) > 1L))
                {
                    fmt.Fprintf(fgcc, "\t%s r;\n", gccResult);
                }
                if (fn.Recv != null)
                {
                    fmt.Fprintf(fgcc, "\ta.recv = recv;\n");
                }
                forFieldList(fntype.Params, (i, aname, atype) =>
                {
                    fmt.Fprintf(fgcc, "\ta.p%d = p%d;\n", i, i);
                });
                fmt.Fprintf(fgcc, "\t_cgo_tsan_release();\n");
                fmt.Fprintf(fgcc, "\tcrosscall2(_cgoexp%s_%s, &a, %d, _cgo_ctxt);\n", cPrefix, exp.ExpName, off);
                fmt.Fprintf(fgcc, "\t_cgo_tsan_acquire();\n");
                fmt.Fprintf(fgcc, "\t_cgo_release_context(_cgo_ctxt);\n");
                if (gccResult != "void")
                {
                    if (len(fntype.Results.List) == 1L && len(fntype.Results.List[0L].Names) <= 1L)
                    {
                        fmt.Fprintf(fgcc, "\treturn a.r0;\n");
                    }
                    else
                    {
                        forFieldList(fntype.Results, (i, aname, atype) =>
                        {
                            fmt.Fprintf(fgcc, "\tr.r%d = a.r%d;\n", i, i);
                        });
                        fmt.Fprintf(fgcc, "\treturn r;\n");
                    }
                }
                fmt.Fprintf(fgcc, "}\n"); 

                // Build the wrapper function compiled by cmd/compile.
                @string goname = "_cgoexpwrap" + cPrefix + "_";
                if (fn.Recv != null)
                {
                    goname += fn.Recv.List[0L].Names[0L].Name + "_";
                }
                goname += exp.Func.Name.Name;
                fmt.Fprintf(fgo2, "//go:cgo_export_dynamic %s\n", exp.ExpName);
                fmt.Fprintf(fgo2, "//go:linkname _cgoexp%s_%s _cgoexp%s_%s\n", cPrefix, exp.ExpName, cPrefix, exp.ExpName);
                fmt.Fprintf(fgo2, "//go:cgo_export_static _cgoexp%s_%s\n", cPrefix, exp.ExpName);
                fmt.Fprintf(fgo2, "//go:nosplit\n"); // no split stack, so no use of m or g
                fmt.Fprintf(fgo2, "//go:norace\n"); // must not have race detector calls inserted
                fmt.Fprintf(fgo2, "func _cgoexp%s_%s(a unsafe.Pointer, n int32, ctxt uintptr) {\n", cPrefix, exp.ExpName);
                fmt.Fprintf(fgo2, "\tfn := %s\n", goname); 
                // The indirect here is converting from a Go function pointer to a C function pointer.
                fmt.Fprintf(fgo2, "\t_cgo_runtime_cgocallback(**(**unsafe.Pointer)(unsafe.Pointer(&fn)), a, uintptr(n), ctxt);\n");
                fmt.Fprintf(fgo2, "}\n");

                fmt.Fprintf(fm, "int _cgoexp%s_%s;\n", cPrefix, exp.ExpName); 

                // This code uses printer.Fprint, not conf.Fprint,
                // because we don't want //line comments in the middle
                // of the function types.
                fmt.Fprintf(fgo2, "\n");
                fmt.Fprintf(fgo2, "func %s(", goname);
                var comma = false;
                if (fn.Recv != null)
                {
                    fmt.Fprintf(fgo2, "recv ");
                    printer.Fprint(fgo2, fset, fn.Recv.List[0L].Type);
                    comma = true;
                }
                forFieldList(fntype.Params, (i, aname, atype) =>
                {
                    if (comma)
                    {
                        fmt.Fprintf(fgo2, ", ");
                    }
                    fmt.Fprintf(fgo2, "p%d ", i);
                    printer.Fprint(fgo2, fset, atype);
                    comma = true;
                });
                fmt.Fprintf(fgo2, ")");
                if (gccResult != "void")
                {
                    fmt.Fprint(fgo2, " (");
                    forFieldList(fntype.Results, (i, aname, atype) =>
                    {
                        if (i > 0L)
                        {
                            fmt.Fprint(fgo2, ", ");
                        }
                        fmt.Fprintf(fgo2, "r%d ", i);
                        printer.Fprint(fgo2, fset, atype);
                    });
                    fmt.Fprint(fgo2, ")");
                }
                fmt.Fprint(fgo2, " {\n");
                if (gccResult == "void")
                {
                    fmt.Fprint(fgo2, "\t");
                }
                else
                { 
                    // Verify that any results don't contain any
                    // Go pointers.
                    var addedDefer = false;
                    forFieldList(fntype.Results, (i, aname, atype) =>
                    {
                        if (!p.hasPointer(null, atype, false))
                        {
                            return;
                        }
                        if (!addedDefer)
                        {
                            fmt.Fprint(fgo2, "\tdefer func() {\n");
                            addedDefer = true;
                        }
                        fmt.Fprintf(fgo2, "\t\t_cgoCheckResult(r%d)\n", i);
                    });
                    if (addedDefer)
                    {
                        fmt.Fprint(fgo2, "\t}()\n");
                    }
                    fmt.Fprint(fgo2, "\treturn ");
                }
                if (fn.Recv != null)
                {
                    fmt.Fprintf(fgo2, "recv.");
                }
                fmt.Fprintf(fgo2, "%s(", exp.Func.Name);
                forFieldList(fntype.Params, (i, aname, atype) =>
                {
                    if (i > 0L)
                    {
                        fmt.Fprint(fgo2, ", ");
                    }
                    fmt.Fprintf(fgo2, "p%d", i);
                });
                fmt.Fprint(fgo2, ")\n");
                fmt.Fprint(fgo2, "}\n");
            }
            fmt.Fprintf(fgcch, "%s", gccExportHeaderEpilog);
        }

        // Write out the C header allowing C code to call exported gccgo functions.
        private static void writeGccgoExports(this ref Package p, io.Writer fgo2, io.Writer fm, io.Writer fgcc, io.Writer fgcch)
        {
            var gccgoSymbolPrefix = p.gccgoSymbolPrefix();

            p.writeExportHeader(fgcch);

            fmt.Fprintf(fgcc, "/* Created by cgo - DO NOT EDIT. */\n");
            fmt.Fprintf(fgcc, "#include \"_cgo_export.h\"\n");

            fmt.Fprintf(fgcc, "%s\n", gccgoExportFileProlog);
            fmt.Fprintf(fgcc, "%s\n", tsanProlog);

            foreach (var (_, exp) in p.ExpFunc)
            {
                var fn = exp.Func;
                var fntype = fn.Type;

                ptr<bytes.Buffer> cdeclBuf = @new<bytes.Buffer>();
                long resultCount = 0L;
                forFieldList(fntype.Results, (i, aname, atype) =>
                {
                    resultCount++;

                });
                switch (resultCount)
                {
                    case 0L: 
                        fmt.Fprintf(cdeclBuf, "void");
                        break;
                    case 1L: 
                        forFieldList(fntype.Results, (i, aname, atype) =>
                        {
                            var t = p.cgoType(atype);
                            fmt.Fprintf(cdeclBuf, "%s", t.C);
                        });
                        break;
                    default: 
                        // Declare a result struct.
                        fmt.Fprintf(fgcch, "\n/* Return type for %s */\n", exp.ExpName);
                        fmt.Fprintf(fgcch, "struct %s_return {\n", exp.ExpName);
                        forFieldList(fntype.Results, (i, aname, atype) =>
                        {
                            t = p.cgoType(atype);
                            fmt.Fprintf(fgcch, "\t%s r%d;", t.C, i);
                            if (len(aname) > 0L)
                            {
                                fmt.Fprintf(fgcch, " /* %s */", aname);
                            }
                            fmt.Fprint(fgcch, "\n");
                        });
                        fmt.Fprintf(fgcch, "};\n");
                        fmt.Fprintf(cdeclBuf, "struct %s_return", exp.ExpName);
                        break;
                }

                var cRet = cdeclBuf.String();

                cdeclBuf = @new<bytes.Buffer>();
                fmt.Fprintf(cdeclBuf, "(");
                if (fn.Recv != null)
                {
                    fmt.Fprintf(cdeclBuf, "%s recv", p.cgoType(fn.Recv.List[0L].Type).C.String());
                } 
                // Function parameters.
                forFieldList(fntype.Params, (i, aname, atype) =>
                {
                    if (i > 0L || fn.Recv != null)
                    {
                        fmt.Fprintf(cdeclBuf, ", ");
                    }
                    t = p.cgoType(atype);
                    fmt.Fprintf(cdeclBuf, "%s p%d", t.C, i);
                });
                fmt.Fprintf(cdeclBuf, ")");
                var cParams = cdeclBuf.String();

                if (len(exp.Doc) > 0L)
                {
                    fmt.Fprintf(fgcch, "\n%s", exp.Doc);
                }
                fmt.Fprintf(fgcch, "extern %s %s%s;\n", cRet, exp.ExpName, cParams); 

                // We need to use a name that will be exported by the
                // Go code; otherwise gccgo will make it static and we
                // will not be able to link against it from the C
                // code.
                @string goName = "Cgoexp_" + exp.ExpName;
                fmt.Fprintf(fgcc, "extern %s %s %s __asm__(\"%s.%s\");", cRet, goName, cParams, gccgoSymbolPrefix, goName);
                fmt.Fprint(fgcc, "\n");

                fmt.Fprint(fgcc, "\nCGO_NO_SANITIZE_THREAD\n");
                fmt.Fprintf(fgcc, "%s %s %s {\n", cRet, exp.ExpName, cParams);
                if (resultCount > 0L)
                {
                    fmt.Fprintf(fgcc, "\t%s r;\n", cRet);
                }
                fmt.Fprintf(fgcc, "\tif(_cgo_wait_runtime_init_done)\n");
                fmt.Fprintf(fgcc, "\t\t_cgo_wait_runtime_init_done();\n");
                fmt.Fprintf(fgcc, "\t_cgo_tsan_release();\n");
                fmt.Fprint(fgcc, "\t");
                if (resultCount > 0L)
                {
                    fmt.Fprint(fgcc, "r = ");
                }
                fmt.Fprintf(fgcc, "%s(", goName);
                if (fn.Recv != null)
                {
                    fmt.Fprint(fgcc, "recv");
                }
                forFieldList(fntype.Params, (i, aname, atype) =>
                {
                    if (i > 0L || fn.Recv != null)
                    {
                        fmt.Fprintf(fgcc, ", ");
                    }
                    fmt.Fprintf(fgcc, "p%d", i);
                });
                fmt.Fprint(fgcc, ");\n");
                fmt.Fprintf(fgcc, "\t_cgo_tsan_acquire();\n");
                if (resultCount > 0L)
                {
                    fmt.Fprint(fgcc, "\treturn r;\n");
                }
                fmt.Fprint(fgcc, "}\n"); 

                // Dummy declaration for _cgo_main.c
                fmt.Fprintf(fm, "char %s[1] __asm__(\"%s.%s\");", goName, gccgoSymbolPrefix, goName);
                fmt.Fprint(fm, "\n"); 

                // For gccgo we use a wrapper function in Go, in order
                // to call CgocallBack and CgocallBackDone.

                // This code uses printer.Fprint, not conf.Fprint,
                // because we don't want //line comments in the middle
                // of the function types.
                fmt.Fprint(fgo2, "\n");
                fmt.Fprintf(fgo2, "func %s(", goName);
                if (fn.Recv != null)
                {
                    fmt.Fprint(fgo2, "recv ");
                    printer.Fprint(fgo2, fset, fn.Recv.List[0L].Type);
                }
                forFieldList(fntype.Params, (i, aname, atype) =>
                {
                    if (i > 0L || fn.Recv != null)
                    {
                        fmt.Fprintf(fgo2, ", ");
                    }
                    fmt.Fprintf(fgo2, "p%d ", i);
                    printer.Fprint(fgo2, fset, atype);
                });
                fmt.Fprintf(fgo2, ")");
                if (resultCount > 0L)
                {
                    fmt.Fprintf(fgo2, " (");
                    forFieldList(fntype.Results, (i, aname, atype) =>
                    {
                        if (i > 0L)
                        {
                            fmt.Fprint(fgo2, ", ");
                        }
                        printer.Fprint(fgo2, fset, atype);
                    });
                    fmt.Fprint(fgo2, ")");
                }
                fmt.Fprint(fgo2, " {\n");
                fmt.Fprint(fgo2, "\tsyscall.CgocallBack()\n");
                fmt.Fprint(fgo2, "\tdefer syscall.CgocallBackDone()\n");
                fmt.Fprint(fgo2, "\t");
                if (resultCount > 0L)
                {
                    fmt.Fprint(fgo2, "return ");
                }
                if (fn.Recv != null)
                {
                    fmt.Fprint(fgo2, "recv.");
                }
                fmt.Fprintf(fgo2, "%s(", exp.Func.Name);
                forFieldList(fntype.Params, (i, aname, atype) =>
                {
                    if (i > 0L)
                    {
                        fmt.Fprint(fgo2, ", ");
                    }
                    fmt.Fprintf(fgo2, "p%d", i);
                });
                fmt.Fprint(fgo2, ")\n");
                fmt.Fprint(fgo2, "}\n");
            }
            fmt.Fprintf(fgcch, "%s", gccExportHeaderEpilog);
        }

        // writeExportHeader writes out the start of the _cgo_export.h file.
        private static void writeExportHeader(this ref Package p, io.Writer fgcch)
        {
            fmt.Fprintf(fgcch, "/* Created by \"go tool cgo\" - DO NOT EDIT. */\n\n");
            var pkg = importPath.Value;
            if (pkg == "")
            {
                pkg = p.PackagePath;
            }
            fmt.Fprintf(fgcch, "/* package %s */\n\n", pkg);
            fmt.Fprintf(fgcch, "%s\n", builtinExportProlog);

            fmt.Fprintf(fgcch, "/* Start of preamble from import \"C\" comments.  */\n\n");
            fmt.Fprintf(fgcch, "%s\n", p.Preamble);
            fmt.Fprintf(fgcch, "\n/* End of preamble from import \"C\" comments.  */\n\n");

            fmt.Fprintf(fgcch, "%s\n", p.gccExportHeaderProlog());
        }

        // Return the package prefix when using gccgo.
        private static @string gccgoSymbolPrefix(this ref Package p)
        {
            if (!gccgo.Value)
            {
                return "";
            }
            Func<int, int> clean = r =>
            {

                if ('A' <= r && r <= 'Z' || 'a' <= r && r <= 'z' || '0' <= r && r <= '9') 
                    return r;
                                return '_';
            }
;

            if (gccgopkgpath != "".Value)
            {
                return strings.Map(clean, gccgopkgpath.Value);
            }
            if (gccgoprefix == "" && p.PackageName == "main".Value)
            {
                return "main";
            }
            var prefix = strings.Map(clean, gccgoprefix.Value);
            if (prefix == "")
            {
                prefix = "go";
            }
            return prefix + "." + p.PackageName;
        }

        // Call a function for each entry in an ast.FieldList, passing the
        // index into the list, the name if any, and the type.
        private static void forFieldList(ref ast.FieldList fl, Action<long, @string, ast.Expr> fn)
        {
            if (fl == null)
            {
                return;
            }
            long i = 0L;
            foreach (var (_, r) in fl.List)
            {
                if (r.Names == null)
                {
                    fn(i, "", r.Type);
                    i++;
                }
                else
                {
                    foreach (var (_, n) in r.Names)
                    {
                        fn(i, n.Name, r.Type);
                        i++;
                    }
                }
            }
        }

        private static ref TypeRepr c(@string repr, params object[] args)
        {
            args = args.Clone();

            return ref new TypeRepr(repr,args);
        }

        // Map predeclared Go types to Type.
        private static map goTypes = /* TODO: Fix this in ScannerBase_Expression::ExitCompositeLit */ new map<@string, ref Type>{"bool":{Size:1,Align:1,C:c("GoUint8")},"byte":{Size:1,Align:1,C:c("GoUint8")},"int":{Size:0,Align:0,C:c("GoInt")},"uint":{Size:0,Align:0,C:c("GoUint")},"rune":{Size:4,Align:4,C:c("GoInt32")},"int8":{Size:1,Align:1,C:c("GoInt8")},"uint8":{Size:1,Align:1,C:c("GoUint8")},"int16":{Size:2,Align:2,C:c("GoInt16")},"uint16":{Size:2,Align:2,C:c("GoUint16")},"int32":{Size:4,Align:4,C:c("GoInt32")},"uint32":{Size:4,Align:4,C:c("GoUint32")},"int64":{Size:8,Align:8,C:c("GoInt64")},"uint64":{Size:8,Align:8,C:c("GoUint64")},"float32":{Size:4,Align:4,C:c("GoFloat32")},"float64":{Size:8,Align:8,C:c("GoFloat64")},"complex64":{Size:8,Align:4,C:c("GoComplex64")},"complex128":{Size:16,Align:8,C:c("GoComplex128")},};

        // Map an ast type to a Type.
        private static ref Type cgoType(this ref Package p, ast.Expr e)
        {
            switch (e.type())
            {
                case ref ast.StarExpr t:
                    var x = p.cgoType(t.X);
                    return ref new Type(Size:p.PtrSize,Align:p.PtrSize,C:c("%s*",x.C));
                    break;
                case ref ast.ArrayType t:
                    if (t.Len == null)
                    { 
                        // Slice: pointer, len, cap.
                        return ref new Type(Size:p.PtrSize*3,Align:p.PtrSize,C:c("GoSlice"));
                    } 
                    // Non-slice array types are not supported.
                    break;
                case ref ast.StructType t:
                    break;
                case ref ast.FuncType t:
                    return ref new Type(Size:p.PtrSize,Align:p.PtrSize,C:c("void*"));
                    break;
                case ref ast.InterfaceType t:
                    return ref new Type(Size:2*p.PtrSize,Align:p.PtrSize,C:c("GoInterface"));
                    break;
                case ref ast.MapType t:
                    return ref new Type(Size:p.PtrSize,Align:p.PtrSize,C:c("GoMap"));
                    break;
                case ref ast.ChanType t:
                    return ref new Type(Size:p.PtrSize,Align:p.PtrSize,C:c("GoChan"));
                    break;
                case ref ast.Ident t:
                    foreach (var (_, d) in p.Decl)
                    {
                        ref ast.GenDecl (gd, ok) = d._<ref ast.GenDecl>();
                        if (!ok || gd.Tok != token.TYPE)
                        {
                            continue;
                        }
                        foreach (var (_, spec) in gd.Specs)
                        {
                            ref ast.TypeSpec (ts, ok) = spec._<ref ast.TypeSpec>();
                            if (!ok)
                            {
                                continue;
                            }
                            if (ts.Name.Name == t.Name)
                            {
                                return p.cgoType(ts.Type);
                            }
                        }
                    }
                    {
                        var def = typedef[t.Name];

                        if (def != null)
                        {
                            return def;
                        }

                    }
                    if (t.Name == "uintptr")
                    {
                        return ref new Type(Size:p.PtrSize,Align:p.PtrSize,C:c("GoUintptr"));
                    }
                    if (t.Name == "string")
                    { 
                        // The string data is 1 pointer + 1 (pointer-sized) int.
                        return ref new Type(Size:2*p.PtrSize,Align:p.PtrSize,C:c("GoString"));
                    }
                    if (t.Name == "error")
                    {
                        return ref new Type(Size:2*p.PtrSize,Align:p.PtrSize,C:c("GoInterface"));
                    }
                    {
                        var (r, ok) = goTypes[t.Name];

                        if (ok)
                        {
                            if (r.Size == 0L)
                            { // int or uint
                                ptr<Type> rr = @new<Type>();
                                rr.Value = r.Value;
                                rr.Size = p.IntSize;
                                rr.Align = p.IntSize;
                                r = rr;
                            }
                            if (r.Align > p.PtrSize)
                            {
                                r.Align = p.PtrSize;
                            }
                            return r;
                        }

                    }
                    error_(e.Pos(), "unrecognized Go type %s", t.Name);
                    return ref new Type(Size:4,Align:4,C:c("int"));
                    break;
                case ref ast.SelectorExpr t:
                    ref ast.Ident (id, ok) = t.X._<ref ast.Ident>();
                    if (ok && id.Name == "unsafe" && t.Sel.Name == "Pointer")
                    {
                        return ref new Type(Size:p.PtrSize,Align:p.PtrSize,C:c("void*"));
                    }
                    break;
            }
            error_(e.Pos(), "Go type not supported in export: %s", gofmt(e));
            return ref new Type(Size:4,Align:4,C:c("int"));
        }

        private static readonly @string gccProlog = @"
#line 1 ""cgo-gcc-prolog""
/*
  If x and y are not equal, the type will be invalid
  (have a negative array count) and an inscrutable error will come
  out of the compiler and hopefully mention ""name"".
*/
#define __cgo_compile_assert_eq(x, y, name) typedef char name[(x-y)*(x-y)*-2+1];

/* Check at compile time that the sizes we use match our expectations. */
#define __cgo_size_assert(t, n) __cgo_compile_assert_eq(sizeof(t), n, _cgo_sizeof_##t##_is_not_##n)

__cgo_size_assert(char, 1)
__cgo_size_assert(short, 2)
__cgo_size_assert(int, 4)
typedef long long __cgo_long_long;
__cgo_size_assert(__cgo_long_long, 8)
__cgo_size_assert(float, 4)
__cgo_size_assert(double, 8)

extern char* _cgo_topofstack(void);

#include <errno.h>
#include <string.h>
";

        // Prologue defining TSAN functions in C.


        // Prologue defining TSAN functions in C.
        private static readonly @string noTsanProlog = "\n#define CGO_NO_SANITIZE_THREAD\n#define _cgo_tsan_acquire()\n#define _cgo_tsan_rel" +
    "ease()\n";

        // This must match the TSAN code in runtime/cgo/libcgo.h.
        // This is used when the code is built with the C/C++ Thread SANitizer,
        // which is not the same as the Go race detector.
        // __tsan_acquire tells TSAN that we are acquiring a lock on a variable,
        // in this case _cgo_sync. __tsan_release releases the lock.
        // (There is no actual lock, we are just telling TSAN that there is.)
        //
        // When we call from Go to C we call _cgo_tsan_acquire.
        // When the C function returns we call _cgo_tsan_release.
        // Similarly, when C calls back into Go we call _cgo_tsan_release
        // and then call _cgo_tsan_acquire when we return to C.
        // These calls tell TSAN that there is a serialization point at the C call.
        //
        // This is necessary because TSAN, which is a C/C++ tool, can not see
        // the synchronization in the Go code. Without these calls, when
        // multiple goroutines call into C code, TSAN does not understand
        // that the calls are properly synchronized on the Go side.
        //
        // To be clear, if the calls are not properly synchronized on the Go side,
        // we will be hiding races. But when using TSAN on mixed Go C/C++ code
        // it is more important to avoid false positives, which reduce confidence
        // in the tool, than to avoid false negatives.


        // This must match the TSAN code in runtime/cgo/libcgo.h.
        // This is used when the code is built with the C/C++ Thread SANitizer,
        // which is not the same as the Go race detector.
        // __tsan_acquire tells TSAN that we are acquiring a lock on a variable,
        // in this case _cgo_sync. __tsan_release releases the lock.
        // (There is no actual lock, we are just telling TSAN that there is.)
        //
        // When we call from Go to C we call _cgo_tsan_acquire.
        // When the C function returns we call _cgo_tsan_release.
        // Similarly, when C calls back into Go we call _cgo_tsan_release
        // and then call _cgo_tsan_acquire when we return to C.
        // These calls tell TSAN that there is a serialization point at the C call.
        //
        // This is necessary because TSAN, which is a C/C++ tool, can not see
        // the synchronization in the Go code. Without these calls, when
        // multiple goroutines call into C code, TSAN does not understand
        // that the calls are properly synchronized on the Go side.
        //
        // To be clear, if the calls are not properly synchronized on the Go side,
        // we will be hiding races. But when using TSAN on mixed Go C/C++ code
        // it is more important to avoid false positives, which reduce confidence
        // in the tool, than to avoid false negatives.
        private static readonly @string yesTsanProlog = @"
#line 1 ""cgo-tsan-prolog""
#define CGO_NO_SANITIZE_THREAD __attribute__ ((no_sanitize_thread))

long long _cgo_sync __attribute__ ((common));

extern void __tsan_acquire(void*);
extern void __tsan_release(void*);

__attribute__ ((unused))
static void _cgo_tsan_acquire() {
	__tsan_acquire(&_cgo_sync);
}

__attribute__ ((unused))
static void _cgo_tsan_release() {
	__tsan_release(&_cgo_sync);
}
";

        // Set to yesTsanProlog if we see -fsanitize=thread in the flags for gcc.


        // Set to yesTsanProlog if we see -fsanitize=thread in the flags for gcc.
        private static var tsanProlog = noTsanProlog;

        private static readonly @string builtinProlog = @"
#line 1 ""cgo-builtin-prolog""
#include <stddef.h> /* for ptrdiff_t and size_t below */

/* Define intgo when compiling with GCC.  */
typedef ptrdiff_t intgo;

typedef struct { const char *p; intgo n; } _GoString_;
typedef struct { char *p; intgo n; intgo c; } _GoBytes_;
_GoString_ GoString(char *p);
_GoString_ GoStringN(char *p, int l);
_GoBytes_ GoBytes(void *p, int n);
char *CString(_GoString_);
void *CBytes(_GoBytes_);
void *_CMalloc(size_t);

__attribute__ ((unused))
static size_t _GoStringLen(_GoString_ s) { return s.n; }

__attribute__ ((unused))
static const char *_GoStringPtr(_GoString_ s) { return s.p; }
";



        private static readonly @string goProlog = @"
//go:linkname _cgo_runtime_cgocall runtime.cgocall
func _cgo_runtime_cgocall(unsafe.Pointer, uintptr) int32

//go:linkname _cgo_runtime_cgocallback runtime.cgocallback
func _cgo_runtime_cgocallback(unsafe.Pointer, unsafe.Pointer, uintptr, uintptr)

//go:linkname _cgoCheckPointer runtime.cgoCheckPointer
func _cgoCheckPointer(interface{}, ...interface{})

//go:linkname _cgoCheckResult runtime.cgoCheckResult
func _cgoCheckResult(interface{})
";



        private static readonly @string gccgoGoProlog = "\nfunc _cgoCheckPointer(interface{}, ...interface{})\n\nfunc _cgoCheckResult(interfa" +
    "ce{})\n";



        private static readonly @string goStringDef = "\n//go:linkname _cgo_runtime_gostring runtime.gostring\nfunc _cgo_runtime_gostring(" +
    "*_Ctype_char) string\n\nfunc _Cfunc_GoString(p *_Ctype_char) string {\n\treturn _cgo" +
    "_runtime_gostring(p)\n}\n";



        private static readonly @string goStringNDef = "\n//go:linkname _cgo_runtime_gostringn runtime.gostringn\nfunc _cgo_runtime_gostrin" +
    "gn(*_Ctype_char, int) string\n\nfunc _Cfunc_GoStringN(p *_Ctype_char, l _Ctype_int" +
    ") string {\n\treturn _cgo_runtime_gostringn(p, int(l))\n}\n";



        private static readonly @string goBytesDef = "\n//go:linkname _cgo_runtime_gobytes runtime.gobytes\nfunc _cgo_runtime_gobytes(uns" +
    "afe.Pointer, int) []byte\n\nfunc _Cfunc_GoBytes(p unsafe.Pointer, l _Ctype_int) []" +
    "byte {\n\treturn _cgo_runtime_gobytes(p, int(l))\n}\n";



        private static readonly @string cStringDef = "\nfunc _Cfunc_CString(s string) *_Ctype_char {\n\tp := _cgo_cmalloc(uint64(len(s)+1)" +
    ")\n\tpp := (*[1<<30]byte)(p)\n\tcopy(pp[:], s)\n\tpp[len(s)] = 0\n\treturn (*_Ctype_char" +
    ")(p)\n}\n";



        private static readonly @string cBytesDef = "\nfunc _Cfunc_CBytes(b []byte) unsafe.Pointer {\n\tp := _cgo_cmalloc(uint64(len(b)))" +
    "\n\tpp := (*[1<<30]byte)(p)\n\tcopy(pp[:], b)\n\treturn p\n}\n";



        private static readonly @string cMallocDef = "\nfunc _Cfunc__CMalloc(n _Ctype_size_t) unsafe.Pointer {\n\treturn _cgo_cmalloc(uint" +
    "64(n))\n}\n";



        private static map builtinDefs = /* TODO: Fix this in ScannerBase_Expression::ExitCompositeLit */ new map<@string, @string>{"GoString":goStringDef,"GoStringN":goStringNDef,"GoBytes":goBytesDef,"CString":cStringDef,"CBytes":cBytesDef,"_CMalloc":cMallocDef,};

        // Definitions for C.malloc in Go and in C. We define it ourselves
        // since we call it from functions we define, such as C.CString.
        // Also, we have historically ensured that C.malloc does not return
        // nil even for an allocation of 0.

        private static readonly @string cMallocDefGo = @"
//go:cgo_import_static _cgoPREFIX_Cfunc__Cmalloc
//go:linkname __cgofn__cgoPREFIX_Cfunc__Cmalloc _cgoPREFIX_Cfunc__Cmalloc
var __cgofn__cgoPREFIX_Cfunc__Cmalloc byte
var _cgoPREFIX_Cfunc__Cmalloc = unsafe.Pointer(&__cgofn__cgoPREFIX_Cfunc__Cmalloc)

//go:linkname runtime_throw runtime.throw
func runtime_throw(string)

//go:cgo_unsafe_args
func _cgo_cmalloc(p0 uint64) (r1 unsafe.Pointer) {
	_cgo_runtime_cgocall(_cgoPREFIX_Cfunc__Cmalloc, uintptr(unsafe.Pointer(&p0)))
	if r1 == nil {
		runtime_throw(""runtime: C malloc failed"")
	}
	return
}
";

        // cMallocDefC defines the C version of C.malloc for the gc compiler.
        // It is defined here because C.CString and friends need a definition.
        // We define it by hand, rather than simply inventing a reference to
        // C.malloc, because <stdlib.h> may not have been included.
        // This is approximately what writeOutputFunc would generate, but
        // skips the cgo_topofstack code (which is only needed if the C code
        // calls back into Go). This also avoids returning nil for an
        // allocation of 0 bytes.


        // cMallocDefC defines the C version of C.malloc for the gc compiler.
        // It is defined here because C.CString and friends need a definition.
        // We define it by hand, rather than simply inventing a reference to
        // C.malloc, because <stdlib.h> may not have been included.
        // This is approximately what writeOutputFunc would generate, but
        // skips the cgo_topofstack code (which is only needed if the C code
        // calls back into Go). This also avoids returning nil for an
        // allocation of 0 bytes.
        private static readonly @string cMallocDefC = @"
CGO_NO_SANITIZE_THREAD
void _cgoPREFIX_Cfunc__Cmalloc(void *v) {
	struct {
		unsigned long long p0;
		void *r1;
	} PACKED *a = v;
	void *ret;
	_cgo_tsan_acquire();
	ret = malloc(a->p0);
	if (ret == 0 && a->p0 == 0) {
		ret = malloc(1);
	}
	a->r1 = ret;
	_cgo_tsan_release();
}
";



        private static @string cPrologGccgo(this ref Package p)
        {
            return strings.Replace(strings.Replace(cPrologGccgo, "PREFIX", cPrefix, -1L), "GCCGOSYMBOLPREF", p.gccgoSymbolPrefix(), -1L);
        }

        private static readonly @string cPrologGccgo = "\n#line 1 \"cgo-c-prolog-gccgo\"\n#include <stdint.h>\n#include <stdlib.h>\n#include <s" +
    "tring.h>\n\ntypedef unsigned char byte;\ntypedef intptr_t intgo;\n\nstruct __go_strin" +
    "g {\n\tconst unsigned char *__data;\n\tintgo __length;\n};\n\ntypedef struct __go_open_" +
    "array {\n\tvoid* __values;\n\tintgo __count;\n\tintgo __capacity;\n} Slice;\n\nstruct __g" +
    "o_string __go_byte_array_to_string(const void* p, intgo len);\nstruct __go_open_a" +
    "rray __go_string_to_byte_array (struct __go_string str);\n\nconst char *_cgoPREFIX" +
    "_Cfunc_CString(struct __go_string s) {\n\tchar *p = malloc(s.__length+1);\n\tmemmove" +
    "(p, s.__data, s.__length);\n\tp[s.__length] = 0;\n\treturn p;\n}\n\nvoid *_cgoPREFIX_Cf" +
    "unc_CBytes(struct __go_open_array b) {\n\tchar *p = malloc(b.__count);\n\tmemmove(p," +
    " b.__values, b.__count);\n\treturn p;\n}\n\nstruct __go_string _cgoPREFIX_Cfunc_GoStr" +
    "ing(char *p) {\n\tintgo len = (p != NULL) ? strlen(p) : 0;\n\treturn __go_byte_array" +
    "_to_string(p, len);\n}\n\nstruct __go_string _cgoPREFIX_Cfunc_GoStringN(char *p, in" +
    "t32_t n) {\n\treturn __go_byte_array_to_string(p, n);\n}\n\nSlice _cgoPREFIX_Cfunc_Go" +
    "Bytes(char *p, int32_t n) {\n\tstruct __go_string s = { (const unsigned char *)p, " +
    "n };\n\treturn __go_string_to_byte_array(s);\n}\n\nextern void runtime_throw(const ch" +
    "ar *);\nvoid *_cgoPREFIX_Cfunc__CMalloc(size_t n) {\n        void *p = malloc(n);\n" +
    "        if(p == NULL && n == 0)\n                p = malloc(1);\n        if(p == N" +
    "ULL)\n                runtime_throw(\"runtime: C malloc failed\");\n        return p" +
    ";\n}\n\nstruct __go_type_descriptor;\ntypedef struct __go_empty_interface {\n\tconst s" +
    "truct __go_type_descriptor *__type_descriptor;\n\tvoid *__object;\n} Eface;\n\nextern" +
    " void runtimeCgoCheckPointer(Eface, Slice)\n\t__asm__(\"runtime.cgoCheckPointer\")\n\t" +
    "__attribute__((weak));\n\nextern void localCgoCheckPointer(Eface, Slice)\n\t__asm__(" +
    "\"GCCGOSYMBOLPREF._cgoCheckPointer\");\n\nvoid localCgoCheckPointer(Eface ptr, Slice" +
    " args) {\n\tif(runtimeCgoCheckPointer) {\n\t\truntimeCgoCheckPointer(ptr, args);\n\t}\n}" +
    "\n\nextern void runtimeCgoCheckResult(Eface)\n\t__asm__(\"runtime.cgoCheckResult\")\n\t_" +
    "_attribute__((weak));\n\nextern void localCgoCheckResult(Eface)\n\t__asm__(\"GCCGOSYM" +
    "BOLPREF._cgoCheckResult\");\n\nvoid localCgoCheckResult(Eface val) {\n\tif(runtimeCgo" +
    "CheckResult) {\n\t\truntimeCgoCheckResult(val);\n\t}\n}\n";

        // builtinExportProlog is a shorter version of builtinProlog,
        // to be put into the _cgo_export.h file.
        // For historical reasons we can't use builtinProlog in _cgo_export.h,
        // because _cgo_export.h defines GoString as a struct while builtinProlog
        // defines it as a function. We don't change this to avoid unnecessarily
        // breaking existing code.


        // builtinExportProlog is a shorter version of builtinProlog,
        // to be put into the _cgo_export.h file.
        // For historical reasons we can't use builtinProlog in _cgo_export.h,
        // because _cgo_export.h defines GoString as a struct while builtinProlog
        // defines it as a function. We don't change this to avoid unnecessarily
        // breaking existing code.
        private static readonly @string builtinExportProlog = "\n#line 1 \"cgo-builtin-prolog\"\n\n#include <stddef.h> /* for ptrdiff_t below */\n\n#if" +
    "ndef GO_CGO_EXPORT_PROLOGUE_H\n#define GO_CGO_EXPORT_PROLOGUE_H\n\ntypedef struct {" +
    " const char *p; ptrdiff_t n; } _GoString_;\n\n#endif\n";



        private static @string gccExportHeaderProlog(this ref Package p)
        {
            return strings.Replace(gccExportHeaderProlog, "GOINTBITS", fmt.Sprint(8L * p.IntSize), -1L);
        }

        private static readonly @string gccExportHeaderProlog = @"
/* Start of boilerplate cgo prologue.  */
#line 1 ""cgo-gcc-export-header-prolog""

#ifndef GO_CGO_PROLOGUE_H
#define GO_CGO_PROLOGUE_H

typedef signed char GoInt8;
typedef unsigned char GoUint8;
typedef short GoInt16;
typedef unsigned short GoUint16;
typedef int GoInt32;
typedef unsigned int GoUint32;
typedef long long GoInt64;
typedef unsigned long long GoUint64;
typedef GoIntGOINTBITS GoInt;
typedef GoUintGOINTBITS GoUint;
typedef __SIZE_TYPE__ GoUintptr;
typedef float GoFloat32;
typedef double GoFloat64;
typedef float _Complex GoComplex64;
typedef double _Complex GoComplex128;

/*
  static assertion to make sure the file is being used on architecture
  at least with matching size of GoInt.
*/
typedef char _check_for_GOINTBITS_bit_pointer_matching_GoInt[sizeof(void*)==GOINTBITS/8 ? 1:-1];

typedef _GoString_ GoString;
typedef void *GoMap;
typedef void *GoChan;
typedef struct { void *t; void *v; } GoInterface;
typedef struct { void *data; GoInt len; GoInt cap; } GoSlice;

#endif

/* End of boilerplate cgo prologue.  */

#ifdef __cplusplus
extern ""C"" {
#endif
";

        // gccExportHeaderEpilog goes at the end of the generated header file.


        // gccExportHeaderEpilog goes at the end of the generated header file.
        private static readonly @string gccExportHeaderEpilog = "\n#ifdef __cplusplus\n}\n#endif\n";

        // gccgoExportFileProlog is written to the _cgo_export.c file when
        // using gccgo.
        // We use weak declarations, and test the addresses, so that this code
        // works with older versions of gccgo.


        // gccgoExportFileProlog is written to the _cgo_export.c file when
        // using gccgo.
        // We use weak declarations, and test the addresses, so that this code
        // works with older versions of gccgo.
        private static readonly @string gccgoExportFileProlog = @"
#line 1 ""cgo-gccgo-export-file-prolog""
extern _Bool runtime_iscgo __attribute__ ((weak));

static void GoInit(void) __attribute__ ((constructor));
static void GoInit(void) {
	if(&runtime_iscgo)
		runtime_iscgo = 1;
}

extern __SIZE_TYPE__ _cgo_wait_runtime_init_done() __attribute__ ((weak));
";

    }
}