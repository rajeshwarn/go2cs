//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 August 29 10:05:40 UTC
// </auto-generated>
//---------------------------------------------------------
using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;
using go;

namespace go {
namespace cmd {
namespace vendor {
namespace github.com {
namespace google {
namespace pprof {
namespace @internal
{
    public static partial class graph_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        public partial struct NodeSet
        {
            // Value of the NodeSet struct
            private readonly map<NodeInfo, bool> m_value;

            public NodeSet(map<NodeInfo, bool> value) => m_value = value;

            // Enable implicit conversions between map<NodeInfo, bool> and NodeSet struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator NodeSet(map<NodeInfo, bool> value) => new NodeSet(value);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator map<NodeInfo, bool>(NodeSet value) => value.m_value;
            
            // Enable comparisons between nil and NodeSet struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NodeSet value, NilType nil) => value.Equals(default(NodeSet));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NodeSet value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, NodeSet value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, NodeSet value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator NodeSet(NilType nil) => default(NodeSet);
        }
    }
}}}}}}}