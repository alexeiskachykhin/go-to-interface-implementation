using System;
using System.Collections.Generic;
using System.Linq;

using EnvDTE;

using GoToInterfaceImplementation.Domain.Contracts.Code;
using GoToInterfaceImplementation.Domain.Contracts.Editor;
using GoToInterfaceImplementation.Domain.EnvDte.Services;

namespace GoToInterfaceImplementation.Domain.EnvDte.Code
{
    public class ClassMethod : SemanticElement<CodeFunction>, IClassMethod
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

        public IClass ContainingType
        {
            get { return new Class(CodeEditor, (CodeClass)CodeElement.Parent); }
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


        public ClassMethod(ICodeEditor codeEditor, CodeFunction codeFunction)
            : base(codeEditor, codeFunction)
        {
        }


        public bool IsMatch(IInterfaceMethod declaration)
        {
            Signature classMethodSignature = new Signature()
            {
                Name = Name,
                Parameters = Parameters,
                ReturnTypeFullName = ReturnTypeFullName,
                AccessModifier = AccessModifier
            };

            Signature interfaceMethodSignature = new Signature()
            {
                Name = declaration.Name,
                Parameters = declaration.Parameters,
                ReturnTypeFullName = declaration.ReturnTypeFullName,
                AccessModifier = declaration.AccessModifier
            };

            return classMethodSignature.Equals(interfaceMethodSignature);
        }
    }
}
