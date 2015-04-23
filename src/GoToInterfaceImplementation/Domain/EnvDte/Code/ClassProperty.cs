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
    public class ClassProperty : SemanticElement<CodeProperty2>, IClassProperty
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

        public string ReturnTypeFullName
        {
            get { return CodeElement.Type.AsFullName; }
        }
        
        public IEnumerable<IParameter> Parameters
        {
            get 
            {
                IEnumerable<IParameter> parameters =
                    from i in CodeElement.Parameters.OfType<CodeParameter>()
                    select new Parameter(CodeEditor, i);

                return parameters;
            }
        }


        public ClassProperty(ICodeEditor codeEditor, CodeProperty2 codeProperty)
            : base(codeEditor, codeProperty)
        {
        }


        public bool IsMatch(IInterfaceProperty declaration)
        {
            Signature classPropertySignature = new Signature()
            {
                Name = Name,
                ReturnTypeFullName = ReturnTypeFullName,
                Parameters = Parameters,
                AccessModifier = AccessModifier
            };

            Signature interfacePropertySignature = new Signature()
            {
                Name = declaration.Name,
                ReturnTypeFullName = declaration.ReturnTypeFullName,
                Parameters = declaration.Parameters,
                AccessModifier = declaration.AccessModifier
            };

            return classPropertySignature.Equals(interfacePropertySignature);
        }
    }
}
