using System;
using System.Collections.Generic;
using System.Linq;

using EnvDTE;
using EnvDTE80;

using GoToInterfaceImplementation.Domain.Contracts.Editor;
using GoToInterfaceImplementation.Domain.EnvDte.Code;

namespace GoToInterfaceImplementation.Domain.EnvDte.Editor.Discoverers
{
    internal class FieldOfInterfaceTypeDiscoverer : SemanticElementDiscoverer
    {
        public FieldOfInterfaceTypeDiscoverer(ICodeEditor codeEditor)
            : base(
            codeEditor,
            typeof(FieldOfInterfaceType),
            typeof(CodeVariable2),
            vsCMElement.vsCMElementVariable)
        {
        }


        protected override bool IsApplicable(CodeElement codeElement)
        {
            CodeVariable2 codeVariable = codeElement as CodeVariable2;
            return (codeVariable.Type.CodeType is CodeInterface);
        }
    }
}
