//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 08 05:01:36 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

using go;

#pragma warning disable CS0660, CS0661

namespace go {
namespace vendor {
namespace golang.org {
namespace x {
namespace net
{
    public static partial class route_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial interface binaryByteOrder
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
            public static binaryByteOrder As<T>(in T target) => (binaryByteOrder<T>)target!;

            [MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
            public static binaryByteOrder As<T>(ptr<T> target_ptr) => (binaryByteOrder<T>)target_ptr;

            [MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
            public static binaryByteOrder? As(object target) =>
                typeof(binaryByteOrder<>).CreateInterfaceHandler<binaryByteOrder>(target);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        private class binaryByteOrder<T> : binaryByteOrder
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

            public binaryByteOrder(in T target) => m_target = target;

            public binaryByteOrder(ptr<T> target_ptr)
            {
                m_target_ptr = target_ptr;
                m_target_is_ptr = true;
            }

            private delegate ulong Uint16ByPtr(ptr<T> value, slice<byte> _p0);
            private delegate ulong Uint16ByVal(T value, slice<byte> _p0);

            private static readonly Uint16ByPtr s_Uint16ByPtr;
            private static readonly Uint16ByVal s_Uint16ByVal;

            [DebuggerNonUserCode, MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ulong Uint16(slice<byte> _p0)
            {
                T target = m_target;

                if (m_target_is_ptr && !(m_target_ptr is null))
                    target = m_target_ptr.val;

                if (s_Uint16ByPtr is null || !m_target_is_ptr)
                    return s_Uint16ByVal!(target, _p0);

                return s_Uint16ByPtr(m_target_ptr, _p0);
            }

            private delegate ulong Uint32ByPtr(ptr<T> value, slice<byte> _p0);
            private delegate ulong Uint32ByVal(T value, slice<byte> _p0);

            private static readonly Uint32ByPtr s_Uint32ByPtr;
            private static readonly Uint32ByVal s_Uint32ByVal;

            [DebuggerNonUserCode, MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ulong Uint32(slice<byte> _p0)
            {
                T target = m_target;

                if (m_target_is_ptr && !(m_target_ptr is null))
                    target = m_target_ptr.val;

                if (s_Uint32ByPtr is null || !m_target_is_ptr)
                    return s_Uint32ByVal!(target, _p0);

                return s_Uint32ByPtr(m_target_ptr, _p0);
            }

            private delegate ulong PutUint16ByPtr(ptr<T> value, slice<byte> _p0, ushort _p0);
            private delegate ulong PutUint16ByVal(T value, slice<byte> _p0, ushort _p0);

            private static readonly PutUint16ByPtr s_PutUint16ByPtr;
            private static readonly PutUint16ByVal s_PutUint16ByVal;

            [DebuggerNonUserCode, MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ulong PutUint16(slice<byte> _p0, ushort _p0)
            {
                T target = m_target;

                if (m_target_is_ptr && !(m_target_ptr is null))
                    target = m_target_ptr.val;

                if (s_PutUint16ByPtr is null || !m_target_is_ptr)
                    return s_PutUint16ByVal!(target, _p0, _p0);

                return s_PutUint16ByPtr(m_target_ptr, _p0, _p0);
            }

            private delegate ulong PutUint32ByPtr(ptr<T> value, slice<byte> _p0, uint _p0);
            private delegate ulong PutUint32ByVal(T value, slice<byte> _p0, uint _p0);

            private static readonly PutUint32ByPtr s_PutUint32ByPtr;
            private static readonly PutUint32ByVal s_PutUint32ByVal;

            [DebuggerNonUserCode, MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ulong PutUint32(slice<byte> _p0, uint _p0)
            {
                T target = m_target;

                if (m_target_is_ptr && !(m_target_ptr is null))
                    target = m_target_ptr.val;

                if (s_PutUint32ByPtr is null || !m_target_is_ptr)
                    return s_PutUint32ByVal!(target, _p0, _p0);

                return s_PutUint32ByPtr(m_target_ptr, _p0, _p0);
            }

            private delegate ulong Uint64ByPtr(ptr<T> value, slice<byte> _p0);
            private delegate ulong Uint64ByVal(T value, slice<byte> _p0);

            private static readonly Uint64ByPtr s_Uint64ByPtr;
            private static readonly Uint64ByVal s_Uint64ByVal;

            [DebuggerNonUserCode, MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ulong Uint64(slice<byte> _p0)
            {
                T target = m_target;

                if (m_target_is_ptr && !(m_target_ptr is null))
                    target = m_target_ptr.val;

                if (s_Uint64ByPtr is null || !m_target_is_ptr)
                    return s_Uint64ByVal!(target, _p0);

                return s_Uint64ByPtr(m_target_ptr, _p0);
            }
            
            public string ToString(string format, IFormatProvider formatProvider) => format;

            [DebuggerStepperBoundary]
            static binaryByteOrder()
            {
                Type targetType = typeof(T);
                Type targetTypeByPtr = typeof(ptr<T>);
                MethodInfo extensionMethod;

               extensionMethod = targetTypeByPtr.GetExtensionMethod("Uint16");

                if (!(extensionMethod is null))
                    s_Uint16ByPtr = extensionMethod.CreateStaticDelegate(typeof(Uint16ByPtr)) as Uint16ByPtr;

                extensionMethod = targetType.GetExtensionMethod("Uint16");

                if (!(extensionMethod is null))
                    s_Uint16ByVal = extensionMethod.CreateStaticDelegate(typeof(Uint16ByVal)) as Uint16ByVal;

                if (s_Uint16ByPtr is null && s_Uint16ByVal is null)
                    throw new NotImplementedException($"{targetType.FullName} does not implement binaryByteOrder.Uint16 method", new Exception("Uint16"));

               extensionMethod = targetTypeByPtr.GetExtensionMethod("Uint32");

                if (!(extensionMethod is null))
                    s_Uint32ByPtr = extensionMethod.CreateStaticDelegate(typeof(Uint32ByPtr)) as Uint32ByPtr;

                extensionMethod = targetType.GetExtensionMethod("Uint32");

                if (!(extensionMethod is null))
                    s_Uint32ByVal = extensionMethod.CreateStaticDelegate(typeof(Uint32ByVal)) as Uint32ByVal;

                if (s_Uint32ByPtr is null && s_Uint32ByVal is null)
                    throw new NotImplementedException($"{targetType.FullName} does not implement binaryByteOrder.Uint32 method", new Exception("Uint32"));

               extensionMethod = targetTypeByPtr.GetExtensionMethod("PutUint16");

                if (!(extensionMethod is null))
                    s_PutUint16ByPtr = extensionMethod.CreateStaticDelegate(typeof(PutUint16ByPtr)) as PutUint16ByPtr;

                extensionMethod = targetType.GetExtensionMethod("PutUint16");

                if (!(extensionMethod is null))
                    s_PutUint16ByVal = extensionMethod.CreateStaticDelegate(typeof(PutUint16ByVal)) as PutUint16ByVal;

                if (s_PutUint16ByPtr is null && s_PutUint16ByVal is null)
                    throw new NotImplementedException($"{targetType.FullName} does not implement binaryByteOrder.PutUint16 method", new Exception("PutUint16"));

               extensionMethod = targetTypeByPtr.GetExtensionMethod("PutUint32");

                if (!(extensionMethod is null))
                    s_PutUint32ByPtr = extensionMethod.CreateStaticDelegate(typeof(PutUint32ByPtr)) as PutUint32ByPtr;

                extensionMethod = targetType.GetExtensionMethod("PutUint32");

                if (!(extensionMethod is null))
                    s_PutUint32ByVal = extensionMethod.CreateStaticDelegate(typeof(PutUint32ByVal)) as PutUint32ByVal;

                if (s_PutUint32ByPtr is null && s_PutUint32ByVal is null)
                    throw new NotImplementedException($"{targetType.FullName} does not implement binaryByteOrder.PutUint32 method", new Exception("PutUint32"));

               extensionMethod = targetTypeByPtr.GetExtensionMethod("Uint64");

                if (!(extensionMethod is null))
                    s_Uint64ByPtr = extensionMethod.CreateStaticDelegate(typeof(Uint64ByPtr)) as Uint64ByPtr;

                extensionMethod = targetType.GetExtensionMethod("Uint64");

                if (!(extensionMethod is null))
                    s_Uint64ByVal = extensionMethod.CreateStaticDelegate(typeof(Uint64ByVal)) as Uint64ByVal;

                if (s_Uint64ByPtr is null && s_Uint64ByVal is null)
                    throw new NotImplementedException($"{targetType.FullName} does not implement binaryByteOrder.Uint64 method", new Exception("Uint64"));
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
            public static explicit operator binaryByteOrder<T>(in ptr<T> target_ptr) => new binaryByteOrder<T>(target_ptr);

            [MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
            public static explicit operator binaryByteOrder<T>(in T target) => new binaryByteOrder<T>(target);

            // Enable comparisons between nil and binaryByteOrder<T> interface instance
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(binaryByteOrder<T> value, NilType nil) => Activator.CreateInstance<binaryByteOrder<T>>().Equals(value);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(binaryByteOrder<T> value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, binaryByteOrder<T> value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, binaryByteOrder<T> value) => value != nil;
        }
    }
}}}}}

namespace go
{
    public static class route_binaryByteOrderExtensions
    {
        private static readonly ConcurrentDictionary<Type, MethodInfo> s_conversionOperators = new ConcurrentDictionary<Type, MethodInfo>();

        [GeneratedCode("go2cs", "0.1.0.0"), MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
        public static T _<T>(this go.vendor.golang.org.x.net.route_package.binaryByteOrder target)
        {
            try
            {
                return ((go.vendor.golang.org.x.net.route_package.binaryByteOrder<T>)target).Target;
            }
            catch (NotImplementedException ex)
            {
                throw new PanicException($"interface conversion: {GetGoTypeName(target.GetType())} is not {GetGoTypeName(typeof(T))}: missing method {ex.InnerException?.Message}");
            }
        }

        [GeneratedCode("go2cs", "0.1.0.0"), MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
        public static bool _<T>(this go.vendor.golang.org.x.net.route_package.binaryByteOrder target, out T result)
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
        public static object? _(this go.vendor.golang.org.x.net.route_package.binaryByteOrder target, Type type)
        {
            try
            {
                MethodInfo? conversionOperator = s_conversionOperators.GetOrAdd(type, _ => typeof(go.vendor.golang.org.x.net.route_package.binaryByteOrder<>).GetExplicitGenericConversionOperator(type));

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
        public static bool _(this go.vendor.golang.org.x.net.route_package.binaryByteOrder target, Type type, out object? result)
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