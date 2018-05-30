﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 15.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace go2cs.Templates
{
    using System.Linq;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "D:\Projects\go2cs\src\go2cs\Templates\InterfaceTypeTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public partial class InterfaceTypeTemplate : TemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            
            #line 1 "D:\Projects\go2cs\src\go2cs\Templates\InterfaceTypeTemplate.tt"
 // This template creates a <PackageName>_<InterfaceName>Interface.cs file 
            
            #line default
            #line hidden
            this.Write(@"//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.CompilerServices;
");
            
            #line 16 "D:\Projects\go2cs\src\go2cs\Templates\InterfaceTypeTemplate.tt"
if (!NamespacePrefix.Equals("go")) {
            
            #line default
            #line hidden
            this.Write("using go;\r\n");
            
            #line 18 "D:\Projects\go2cs\src\go2cs\Templates\InterfaceTypeTemplate.tt"
}
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 20 "D:\Projects\go2cs\src\go2cs\Templates\InterfaceTypeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(NamespaceHeader));
            
            #line default
            #line hidden
            this.Write("\r\n    public static unsafe partial class ");
            
            #line 21 "D:\Projects\go2cs\src\go2cs\Templates\InterfaceTypeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(PackageName));
            
            #line default
            #line hidden
            this.Write("_package\r\n    {\r\n        [");
            
            #line 23 "D:\Projects\go2cs\src\go2cs\Templates\InterfaceTypeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GeneratedCodeAttribute));
            
            #line default
            #line hidden
            this.Write("]\r\n        ");
            
            #line 24 "D:\Projects\go2cs\src\go2cs\Templates\InterfaceTypeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Scope));
            
            #line default
            #line hidden
            this.Write(" struct ");
            
            #line 24 "D:\Projects\go2cs\src\go2cs\Templates\InterfaceTypeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(InterfaceName));
            
            #line default
            #line hidden
            this.Write("<T> : ");
            
            #line 24 "D:\Projects\go2cs\src\go2cs\Templates\InterfaceTypeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(InterfaceName));
            
            #line default
            #line hidden
            this.Write("\r\n        {\r\n            private T m_target;\r\n");
            
            #line 27 "D:\Projects\go2cs\src\go2cs\Templates\InterfaceTypeTemplate.tt"

        
            foreach (var decl in Functions.Where(function => !function.resultType.Equals("void")))
            {
                
            
            #line default
            #line hidden
            
            #line 31 "D:\Projects\go2cs\src\go2cs\Templates\InterfaceTypeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(new InterfaceFuncDeclTemplate
                {
                    FunctionName = decl.functionName,
                    Scope = "public",
                    ParameterSignature = decl.parameterSignature,
                    NamedParameters = decl.namedParameters,
                    ParameterTypes = decl.parameterTypes,
                    ResultType = decl.resultType
                }
                .TransformText()));
            
            #line default
            #line hidden
            
            #line 40 "D:\Projects\go2cs\src\go2cs\Templates\InterfaceTypeTemplate.tt"

            }
        
            foreach (var decl in Functions.Where(function => function.resultType.Equals("void")))
            {
                
            
            #line default
            #line hidden
            
            #line 45 "D:\Projects\go2cs\src\go2cs\Templates\InterfaceTypeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(new InterfaceActionDeclTemplate
                {
                    ActionName = decl.functionName,
                    Scope = "public",
                    ParameterSignature = decl.parameterSignature,
                    NamedParameters = decl.namedParameters,
                    ParameterTypes = decl.parameterTypes
                }
                .TransformText()));
            
            #line default
            #line hidden
            
            #line 53 "D:\Projects\go2cs\src\go2cs\Templates\InterfaceTypeTemplate.tt"

            }
            
            #line default
            #line hidden
            this.Write("\r\n\r\n            [DebuggerStepperBoundary]\r\n            static ");
            
            #line 58 "D:\Projects\go2cs\src\go2cs\Templates\InterfaceTypeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(InterfaceName));
            
            #line default
            #line hidden
            this.Write("()\r\n            {\r\n                Type targetType = typeof(T);\r\n");
            
            #line 61 "D:\Projects\go2cs\src\go2cs\Templates\InterfaceTypeTemplate.tt"

        
                foreach (var decl in Functions.Where(function => !function.resultType.Equals("void")))
                {
                    
            
            #line default
            #line hidden
            
            #line 65 "D:\Projects\go2cs\src\go2cs\Templates\InterfaceTypeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(new InterfaceFuncInitTemplate
                    {
                        FunctionName = decl.functionName,
                        InterfaceName = InterfaceName,
                        ParameterTypes = decl.parameterTypes,
                        ResultType = decl.resultType
                    }
                    .TransformText()));
            
            #line default
            #line hidden
            
            #line 72 "D:\Projects\go2cs\src\go2cs\Templates\InterfaceTypeTemplate.tt"

                }
            
                foreach (var decl in Functions.Where(function => function.resultType.Equals("void")))
                {
                    
            
            #line default
            #line hidden
            
            #line 77 "D:\Projects\go2cs\src\go2cs\Templates\InterfaceTypeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(new InterfaceActionInitTemplate
                    {
                        ActionName = decl.functionName,
                        InterfaceName = InterfaceName,
                        ParameterTypes = decl.parameterTypes
                    }
                    .TransformText()));
            
            #line default
            #line hidden
            
            #line 83 "D:\Projects\go2cs\src\go2cs\Templates\InterfaceTypeTemplate.tt"

                }
            
            #line default
            #line hidden
            this.Write("\r\n            }\r\n\r\n            [MethodImpl(MethodImplOptions.AggressiveInlining)," +
                    " DebuggerNonUserCode]\r\n            public static explicit operator ");
            
            #line 89 "D:\Projects\go2cs\src\go2cs\Templates\InterfaceTypeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(InterfaceName));
            
            #line default
            #line hidden
            this.Write("<T>(T target) => new ");
            
            #line 89 "D:\Projects\go2cs\src\go2cs\Templates\InterfaceTypeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(InterfaceName));
            
            #line default
            #line hidden
            this.Write("<T> { m_target = target };\r\n\r\n            // Enable comparisons between nil and ");
            
            #line 91 "D:\Projects\go2cs\src\go2cs\Templates\InterfaceTypeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(InterfaceName));
            
            #line default
            #line hidden
            this.Write("<T> interface instance\r\n            [MethodImpl(MethodImplOptions.AggressiveInlin" +
                    "ing)]\r\n            public static bool operator ==(");
            
            #line 93 "D:\Projects\go2cs\src\go2cs\Templates\InterfaceTypeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(InterfaceName));
            
            #line default
            #line hidden
            this.Write("<T> value, NilType nil) => (object)value == null || Activator.CreateInstance<");
            
            #line 93 "D:\Projects\go2cs\src\go2cs\Templates\InterfaceTypeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(InterfaceName));
            
            #line default
            #line hidden
            this.Write("<T>>().Equals(value);\r\n\r\n            [MethodImpl(MethodImplOptions.AggressiveInli" +
                    "ning)]\r\n            public static bool operator !=(");
            
            #line 96 "D:\Projects\go2cs\src\go2cs\Templates\InterfaceTypeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(InterfaceName));
            
            #line default
            #line hidden
            this.Write("<T> value, NilType nil) => !(value == nil);\r\n\r\n            [MethodImpl(MethodImpl" +
                    "Options.AggressiveInlining)]\r\n            public static bool operator ==(NilType" +
                    " nil, ");
            
            #line 99 "D:\Projects\go2cs\src\go2cs\Templates\InterfaceTypeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(InterfaceName));
            
            #line default
            #line hidden
            this.Write("<T> value) => value == nil;\r\n\r\n            [MethodImpl(MethodImplOptions.Aggressi" +
                    "veInlining)]\r\n            public static bool operator !=(NilType nil, ");
            
            #line 102 "D:\Projects\go2cs\src\go2cs\Templates\InterfaceTypeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(InterfaceName));
            
            #line default
            #line hidden
            this.Write("<T> value) => value != nil;\r\n        }\r\n\r\n        [");
            
            #line 105 "D:\Projects\go2cs\src\go2cs\Templates\InterfaceTypeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GeneratedCodeAttribute));
            
            #line default
            #line hidden
            this.Write(", MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]\r\n       " +
                    " ");
            
            #line 106 "D:\Projects\go2cs\src\go2cs\Templates\InterfaceTypeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Scope));
            
            #line default
            #line hidden
            this.Write(" static ");
            
            #line 106 "D:\Projects\go2cs\src\go2cs\Templates\InterfaceTypeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(InterfaceName));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 106 "D:\Projects\go2cs\src\go2cs\Templates\InterfaceTypeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(InterfaceName));
            
            #line default
            #line hidden
            this.Write("_cast<T>(T target) => (");
            
            #line 106 "D:\Projects\go2cs\src\go2cs\Templates\InterfaceTypeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(InterfaceName));
            
            #line default
            #line hidden
            this.Write("<T>)target;\r\n    }\r\n");
            
            #line 108 "D:\Projects\go2cs\src\go2cs\Templates\InterfaceTypeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(NamespaceFooter));
            
            #line default
            #line hidden
            this.Write("\r\n\r\nnamespace go\r\n{\r\n    public partial class NilType\r\n    {\r\n        // Enable c" +
                    "omparisons between nil and Abser interface\r\n        [MethodImpl(MethodImplOption" +
                    "s.AggressiveInlining)]\r\n        public static bool operator ==(");
            
            #line 116 "D:\Projects\go2cs\src\go2cs\Templates\InterfaceTypeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(NamespacePrefix));
            
            #line default
            #line hidden
            this.Write(".");
            
            #line 116 "D:\Projects\go2cs\src\go2cs\Templates\InterfaceTypeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(PackageName));
            
            #line default
            #line hidden
            this.Write("_package.");
            
            #line 116 "D:\Projects\go2cs\src\go2cs\Templates\InterfaceTypeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(InterfaceName));
            
            #line default
            #line hidden
            this.Write(" value, NilType nil) => (object)value == null || Activator.CreateInstance(value.G" +
                    "etType()).Equals(value);\r\n\r\n        [MethodImpl(MethodImplOptions.AggressiveInli" +
                    "ning)]\r\n        public static bool operator !=(");
            
            #line 119 "D:\Projects\go2cs\src\go2cs\Templates\InterfaceTypeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(NamespacePrefix));
            
            #line default
            #line hidden
            this.Write(".");
            
            #line 119 "D:\Projects\go2cs\src\go2cs\Templates\InterfaceTypeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(PackageName));
            
            #line default
            #line hidden
            this.Write("_package.");
            
            #line 119 "D:\Projects\go2cs\src\go2cs\Templates\InterfaceTypeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(InterfaceName));
            
            #line default
            #line hidden
            this.Write(" value, NilType nil) => !(value == nil);\r\n\r\n        [MethodImpl(MethodImplOptions" +
                    ".AggressiveInlining)]\r\n        public static bool operator ==(NilType nil, ");
            
            #line 122 "D:\Projects\go2cs\src\go2cs\Templates\InterfaceTypeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(NamespacePrefix));
            
            #line default
            #line hidden
            this.Write(".");
            
            #line 122 "D:\Projects\go2cs\src\go2cs\Templates\InterfaceTypeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(PackageName));
            
            #line default
            #line hidden
            this.Write("_package.");
            
            #line 122 "D:\Projects\go2cs\src\go2cs\Templates\InterfaceTypeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(InterfaceName));
            
            #line default
            #line hidden
            this.Write(" value) => value == nil;\r\n\r\n        [MethodImpl(MethodImplOptions.AggressiveInlin" +
                    "ing)]\r\n        public static bool operator !=(NilType nil, ");
            
            #line 125 "D:\Projects\go2cs\src\go2cs\Templates\InterfaceTypeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(NamespacePrefix));
            
            #line default
            #line hidden
            this.Write(".");
            
            #line 125 "D:\Projects\go2cs\src\go2cs\Templates\InterfaceTypeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(PackageName));
            
            #line default
            #line hidden
            this.Write("_package.");
            
            #line 125 "D:\Projects\go2cs\src\go2cs\Templates\InterfaceTypeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(InterfaceName));
            
            #line default
            #line hidden
            this.Write(" value) => value != nil;\r\n    }\r\n}");
            return this.GenerationEnvironment.ToString();
        }
        
        #line 127 "D:\Projects\go2cs\src\go2cs\Templates\InterfaceTypeTemplate.tt"

// Template Parameters
public string NamespacePrefix;
public string NamespaceHeader;
public string NamespaceFooter;
public string PackageName;
public string InterfaceName;
public string Scope;
public (string functionName, string parameterSignature, string namedParameters, string parameterTypes, string resultType)[] Functions;

        
        #line default
        #line hidden
    }
    
    #line default
    #line hidden
}
