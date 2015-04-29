using System;
using System.Collections.Generic;
using System.Linq;

using EnvDTE;
using EnvDTE80;

using GoToInterfaceImplementation.Domain.Contracts.Editor;
using GoToInterfaceImplementation.Domain.EnvDte.Code;

namespace GoToInterfaceImplementation.Domain.EnvDte.Editor.Discoverers
{
    internal class PropertyOfInterfaceTypeDiscoverer : SemanticElementDiscoverer
    {
        public PropertyOfInterfaceTypeDiscoverer(ICodeEditor codeEditor)
            : base(
            codeEditor,
            typeof(PropertyOfInterfaceType),
            typeof(CodeProperty2),
            vsCMElement.vsCMElementProperty)
        {
        }


        protected override bool IsApplicable(CodeElement codeElement)
        {
            CodeProperty2 codeProperty = codeElement as CodeProperty2;
            return (codeProperty.Type.CodeType is CodeInterface);
        }
    }
}
