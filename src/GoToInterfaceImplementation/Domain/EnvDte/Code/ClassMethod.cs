using System;
using System.Collections.Generic;
using System.Linq;

using EnvDTE;

using GoToInterfaceImplementation.Domain.Contracts.Code;
using GoToInterfaceImplementation.Domain.Contracts.Editor;

namespace GoToInterfaceImplementation.Domain.EnvDte.Code
{
    public class ClassMethod : EnvDteCodeElement<CodeFunction>, IClassMethod
    {
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
                ReturnTypeFullName = ReturnTypeFullName
            };

            Signature interfaceMethodSignature = new Signature()
            {
                Name = declaration.Name,
                Parameters = declaration.Parameters,
                ReturnTypeFullName = declaration.ReturnTypeFullName
            };

            return classMethodSignature.Equals(interfaceMethodSignature);
        }
    }
}
