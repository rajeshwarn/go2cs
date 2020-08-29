//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 August 29 08:35:12 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;


#pragma warning disable CS0660, CS0661

namespace go
{
    public static partial class encoding_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        public partial interface BinaryMarshaler
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
            public static BinaryMarshaler As<T>(in T target) => (BinaryMarshaler<T>)target!;

            [MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
            public static BinaryMarshaler As<T>(ptr<T> target_ptr) => (BinaryMarshaler<T>)target_ptr;

            [MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
            public static BinaryMarshaler? As(object target) =>
                typeof(BinaryMarshaler<>).CreateInterfaceHandler<BinaryMarshaler>(target);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        public class BinaryMarshaler<T> : BinaryMarshaler
        {
            private T m_target;
            private readonly ptr<T>? m_target_ptr;
            private readonly bool m_target_is_ptr;

            public ref T Target
            {
                get
                {
                    if (m_target_is_ptr && !(m_target_ptr is null))
                        return ref m_target_ptr.Value;

                    return ref m_target;
                }
            }

            public BinaryMarshaler(in T target) => m_target = target;

            public BinaryMarshaler(ptr<T> target_ptr)
            {
                m_target_ptr = target_ptr;
                m_target_is_ptr = true;
            }

            private delegate (slice<byte>, error) MarshalBinaryByRef(ref T value);
            private delegate (slice<byte>, error) MarshalBinaryByVal(T value);

            private static readonly MarshalBinaryByRef s_MarshalBinaryByRef;
            private static readonly MarshalBinaryByVal s_MarshalBinaryByVal;

            [DebuggerNonUserCode, MethodImpl(MethodImplOptions.AggressiveInlining)]
            public (slice<byte>, error) MarshalBinary()
            {
                T target = m_target;

                if (m_target_is_ptr && !(m_target_ptr is null))
                    target = m_target_ptr.Value;
                if (s_MarshalBinaryByRef is null)
                    return s_MarshalBinaryByVal!(target);

                return s_MarshalBinaryByRef(ref target);
            }
            
            public string ToString(string format, IFormatProvider formatProvider) => format;

            [DebuggerStepperBoundary]
            static BinaryMarshaler()
            {
                Type targetType = typeof(T);
                Type targetTypeByRef = targetType.MakeByRefType();
                MethodInfo extensionMethod;

               extensionMethod = targetTypeByRef.GetExtensionMethod("MarshalBinary");

                if (!(extensionMethod is null))
                    s_MarshalBinaryByRef = extensionMethod.CreateStaticDelegate(typeof(MarshalBinaryByRef)) as MarshalBinaryByRef;

                if (s_MarshalBinaryByRef is null)
                {
                    extensionMethod = targetType.GetExtensionMethod("MarshalBinary");

                    if (!(extensionMethod is null))
                        s_MarshalBinaryByVal = extensionMethod.CreateStaticDelegate(typeof(MarshalBinaryByVal)) as MarshalBinaryByVal;
                }

                if (s_MarshalBinaryByRef is null && s_MarshalBinaryByVal is null)
                    throw new NotImplementedException($"{targetType.FullName} does not implement BinaryMarshaler.MarshalBinary method", new Exception("MarshalBinary"));
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
            public static explicit operator BinaryMarshaler<T>(in ptr<T> target_ptr) => new BinaryMarshaler<T>(target_ptr);

            [MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
            public static explicit operator BinaryMarshaler<T>(in T target) => new BinaryMarshaler<T>(target);

            // Enable comparisons between nil and BinaryMarshaler<T> interface instance
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(BinaryMarshaler<T> value, NilType nil) => Activator.CreateInstance<BinaryMarshaler<T>>().Equals(value);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(BinaryMarshaler<T> value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, BinaryMarshaler<T> value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, BinaryMarshaler<T> value) => value != nil;
        }
    }
}

namespace go
{
    public static class encoding_BinaryMarshalerExtensions
    {
        private static readonly ConcurrentDictionary<Type, MethodInfo> s_conversionOperators = new ConcurrentDictionary<Type, MethodInfo>();

        [GeneratedCode("go2cs", "0.1.0.0"), MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
        public static T _<T>(this go.encoding_package.BinaryMarshaler target)
        {
            try
            {
                return ((go.encoding_package.BinaryMarshaler<T>)target).Target;
            }
            catch (NotImplementedException ex)
            {
                throw new PanicException($"interface conversion: {GetGoTypeName(target.GetType())} is not {GetGoTypeName(typeof(T))}: missing method {ex.InnerException?.Message}");
            }
        }

        [GeneratedCode("go2cs", "0.1.0.0"), MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
        public static bool _<T>(this go.encoding_package.BinaryMarshaler target, out T result)
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
        public static object? _(this go.encoding_package.BinaryMarshaler target, Type type)
        {
            try
            {
                MethodInfo? conversionOperator = s_conversionOperators.GetOrAdd(type, _ => typeof(go.encoding_package.BinaryMarshaler<>).GetExplicitGenericConversionOperator(type));

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
        public static bool _(this go.encoding_package.BinaryMarshaler target, Type type, out object? result)
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