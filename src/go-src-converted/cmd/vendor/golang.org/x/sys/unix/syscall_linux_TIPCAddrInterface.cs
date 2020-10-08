//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 08 04:47:22 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using binary = go.encoding.binary_package;
using runtime = go.runtime_package;
using syscall = go.syscall_package;
using @unsafe = go.@unsafe_package;
using go;

#pragma warning disable CS0660, CS0661

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
        public partial interface TIPCAddr
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
            public static TIPCAddr As<T>(in T target) => (TIPCAddr<T>)target!;

            [MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
            public static TIPCAddr As<T>(ptr<T> target_ptr) => (TIPCAddr<T>)target_ptr;

            [MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
            public static TIPCAddr? As(object target) =>
                typeof(TIPCAddr<>).CreateInterfaceHandler<TIPCAddr>(target);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        public class TIPCAddr<T> : TIPCAddr
        {
            private T m_target;
            private readonly ptr<T>? m_target_ptr;
            private readonly bool m_target_is_ptr;

            public ref T Target
            {
                get
                {
                    if (m_target_is_ptr && !(m_target_ptr is null))
                        return ref m_target_ptr.val;

                    return ref m_target;
                }
            }

            public TIPCAddr(in T target) => m_target = target;

            public TIPCAddr(ptr<T> target_ptr)
            {
                m_target_ptr = target_ptr;
                m_target_is_ptr = true;
            }

            private delegate array<byte> tipcAddrtypeByPtr(ptr<T> value);
            private delegate array<byte> tipcAddrtypeByVal(T value);

            private static readonly tipcAddrtypeByPtr s_tipcAddrtypeByPtr;
            private static readonly tipcAddrtypeByVal s_tipcAddrtypeByVal;

            [DebuggerNonUserCode, MethodImpl(MethodImplOptions.AggressiveInlining)]
            public array<byte> tipcAddrtype()
            {
                T target = m_target;

                if (m_target_is_ptr && !(m_target_ptr is null))
                    target = m_target_ptr.val;

                if (s_tipcAddrtypeByPtr is null || !m_target_is_ptr)
                    return s_tipcAddrtypeByVal!(target);

                return s_tipcAddrtypeByPtr(m_target_ptr);
            }

            private delegate array<byte> tipcAddrByPtr(ptr<T> value);
            private delegate array<byte> tipcAddrByVal(T value);

            private static readonly tipcAddrByPtr s_tipcAddrByPtr;
            private static readonly tipcAddrByVal s_tipcAddrByVal;

            [DebuggerNonUserCode, MethodImpl(MethodImplOptions.AggressiveInlining)]
            public array<byte> tipcAddr()
            {
                T target = m_target;

                if (m_target_is_ptr && !(m_target_ptr is null))
                    target = m_target_ptr.val;

                if (s_tipcAddrByPtr is null || !m_target_is_ptr)
                    return s_tipcAddrByVal!(target);

                return s_tipcAddrByPtr(m_target_ptr);
            }
            
            public string ToString(string format, IFormatProvider formatProvider) => format;

            [DebuggerStepperBoundary]
            static TIPCAddr()
            {
                Type targetType = typeof(T);
                Type targetTypeByPtr = typeof(ptr<T>);
                MethodInfo extensionMethod;

               extensionMethod = targetTypeByPtr.GetExtensionMethod("tipcAddrtype");

                if (!(extensionMethod is null))
                    s_tipcAddrtypeByPtr = extensionMethod.CreateStaticDelegate(typeof(tipcAddrtypeByPtr)) as tipcAddrtypeByPtr;

                extensionMethod = targetType.GetExtensionMethod("tipcAddrtype");

                if (!(extensionMethod is null))
                    s_tipcAddrtypeByVal = extensionMethod.CreateStaticDelegate(typeof(tipcAddrtypeByVal)) as tipcAddrtypeByVal;

                if (s_tipcAddrtypeByPtr is null && s_tipcAddrtypeByVal is null)
                    throw new NotImplementedException($"{targetType.FullName} does not implement TIPCAddr.tipcAddrtype method", new Exception("tipcAddrtype"));

               extensionMethod = targetTypeByPtr.GetExtensionMethod("tipcAddr");

                if (!(extensionMethod is null))
                    s_tipcAddrByPtr = extensionMethod.CreateStaticDelegate(typeof(tipcAddrByPtr)) as tipcAddrByPtr;

                extensionMethod = targetType.GetExtensionMethod("tipcAddr");

                if (!(extensionMethod is null))
                    s_tipcAddrByVal = extensionMethod.CreateStaticDelegate(typeof(tipcAddrByVal)) as tipcAddrByVal;

                if (s_tipcAddrByPtr is null && s_tipcAddrByVal is null)
                    throw new NotImplementedException($"{targetType.FullName} does not implement TIPCAddr.tipcAddr method", new Exception("tipcAddr"));
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
            public static explicit operator TIPCAddr<T>(in ptr<T> target_ptr) => new TIPCAddr<T>(target_ptr);

            [MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
            public static explicit operator TIPCAddr<T>(in T target) => new TIPCAddr<T>(target);

            // Enable comparisons between nil and TIPCAddr<T> interface instance
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(TIPCAddr<T> value, NilType nil) => Activator.CreateInstance<TIPCAddr<T>>().Equals(value);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(TIPCAddr<T> value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, TIPCAddr<T> value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, TIPCAddr<T> value) => value != nil;
        }
    }
}}}}}}

namespace go
{
    public static class unix_TIPCAddrExtensions
    {
        private static readonly ConcurrentDictionary<Type, MethodInfo> s_conversionOperators = new ConcurrentDictionary<Type, MethodInfo>();

        [GeneratedCode("go2cs", "0.1.0.0"), MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
        public static T _<T>(this go.cmd.vendor.golang.org.x.sys.unix_package.TIPCAddr target)
        {
            try
            {
                return ((go.cmd.vendor.golang.org.x.sys.unix_package.TIPCAddr<T>)target).Target;
            }
            catch (NotImplementedException ex)
            {
                throw new PanicException($"interface conversion: {GetGoTypeName(target.GetType())} is not {GetGoTypeName(typeof(T))}: missing method {ex.InnerException?.Message}");
            }
        }

        [GeneratedCode("go2cs", "0.1.0.0"), MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
        public static bool _<T>(this go.cmd.vendor.golang.org.x.sys.unix_package.TIPCAddr target, out T result)
        {
            try
            {
                result = target._<T>();
                return true;
            }
            catch (PanicException)
            {
                result = default!;
                return false;
            }
        }

        [GeneratedCode("go2cs", "0.1.0.0"), MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
        public static object? _(this go.cmd.vendor.golang.org.x.sys.unix_package.TIPCAddr target, Type type)
        {
            try
            {
                MethodInfo? conversionOperator = s_conversionOperators.GetOrAdd(type, _ => typeof(go.cmd.vendor.golang.org.x.sys.unix_package.TIPCAddr<>).GetExplicitGenericConversionOperator(type));

                if (conversionOperator is null)
                    throw new PanicException($"interface conversion: failed to create converter for {GetGoTypeName(target.GetType())} to {GetGoTypeName(type)}");

                dynamic? result = conversionOperator.Invoke(null, new object[] { target });
                return result?.Target;
            }
            catch (NotImplementedException ex)
            {
                throw new PanicException($"interface conversion: {GetGoTypeName(target.GetType())} is not {GetGoTypeName(type)}: missing method {ex.InnerException?.Message}");
            }
        }

        [GeneratedCode("go2cs", "0.1.0.0"), MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
        public static bool _(this go.cmd.vendor.golang.org.x.sys.unix_package.TIPCAddr target, Type type, out object? result)
        {
            try
            {
                result = target._(type);
                return true;
            }
            catch (PanicException)
            {
                result = type.IsValueType ? Activator.CreateInstance(type) : null;
                return false;
            }
        }
    }
}