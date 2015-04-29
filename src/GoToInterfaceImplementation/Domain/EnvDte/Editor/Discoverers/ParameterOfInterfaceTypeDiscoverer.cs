using System;
using System.Collections.Generic;
using System.Linq;

using EnvDTE;

using GoToInterfaceImplementation.Domain.Contracts.Editor;
using GoToInterfaceImplementation.Domain.EnvDte.Code;

namespace GoToInterfaceImplementation.Domain.EnvDte.Editor.Discoverers
{
    internal class ParameterOfInterfaceTypeDiscoverer : SemanticElementDiscoverer
    {
        public ParameterOfInterfaceTypeDiscoverer(ICodeEditor codeEditor)
            : base(
            codeEditor,
            typeof(ParameterOfInterfaceType),
            typeof(CodeParameter),
            vsCMElement.vsCMElementParameter)
        {
        }


        protected override bool IsApplicable(CodeElement codeElement)
        {
            CodeParameter codeParameter = codeElement as CodeParameter;
            return (codeParameter.Type.CodeType is CodeInterface);
        }
    }
}
