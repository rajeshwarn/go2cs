//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 05:53:39 UTC
// </auto-generated>
//---------------------------------------------------------
using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;
using go;

#nullable enable

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
        public partial struct TagMap
        {
            // Value of the TagMap struct
            private readonly map<@string, ptr<Tag>> m_value;

            public TagMap(map<@string, ptr<Tag>> value) => m_value = value;

            // Enable implicit conversions between map<@string, ptr<Tag>> and TagMap struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator TagMap(map<@string, ptr<Tag>> value) => new TagMap(value);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator map<@string, ptr<Tag>>(TagMap value) => value.m_value;
            
            // Enable comparisons between nil and TagMap struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(TagMap value, NilType nil) => value.Equals(default(TagMap));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(TagMap value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, TagMap value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, TagMap value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator TagMap(NilType nil) => default(TagMap);
        }
    }
}}}}}}}
