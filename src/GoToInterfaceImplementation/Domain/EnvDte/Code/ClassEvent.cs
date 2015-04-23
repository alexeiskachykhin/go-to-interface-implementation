using System;
using System.Collections.Generic;
using System.Linq;

using EnvDTE;
using EnvDTE80;

using GoToInterfaceImplementation.Domain.Contracts.Code;
using GoToInterfaceImplementation.Domain.Contracts.Editor;
using GoToInterfaceImplementation.Domain.EnvDte.Services;

namespace GoToInterfaceImplementation.Domain.EnvDte.Code
{
    public class ClassEvent : SemanticElement<CodeEvent>, IClassEvent
    {
        public AccessModifier AccessModifier
        {
            get
            {
                ITypeConverter<vsCMAccess, AccessModifier> converter =
                    new VsCMAccessToAccessModifierConverter();

                return converter.Convert(CodeElement.Access);
            }
        }


        public ClassEvent(ICodeEditor codeEditor, CodeEvent codeEvent)
            : base(codeEditor, codeEvent)
        {
        }


        public bool IsMatch(IInterfaceEvent declaration)
        {
            Signature classEventSignature = new Signature()
            {
                Name = Name,
                AccessModifier = AccessModifier
            };

            Signature interfaceEventSignature = new Signature()
            {
                Name = declaration.Name,
                AccessModifier = declaration.AccessModifier
            };

            return classEventSignature.Equals(interfaceEventSignature);
        }
    }
}
