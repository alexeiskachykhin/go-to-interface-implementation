using System;
using System.Collections.Generic;
using System.Linq;

using EnvDTE;

using GoToInterfaceImplementation.Domain.Contracts;

namespace GoToInterfaceImplementation.Domain.EnvDte
{
    public class EnvDteClassMethod : EnvDteCodeElement<CodeFunction>, IClassMethod
    {
        public IEnumerable<IParameter> Parameters
        {
            get 
            {
                IEnumerable<IParameter> parameters =
                    from i in CodeElement.Parameters.OfType<CodeParameter>()
                    select new EnvDteParameter(CodeEditor, i);

                return parameters;
            }
        }


        public EnvDteClassMethod(ICodeEditor codeEditor, CodeFunction codeFunction)
            : base(codeEditor, codeFunction)
        {
        }


        public bool IsMatch(IInterfaceMethod declaration)
        {
            Signature classMethodSignature = new Signature()
            {
                Name = Name,
                Parameters = Parameters
            };

            Signature interfaceMethodSignature = new Signature()
            {
                Name = declaration.Name,
                Parameters = declaration.Parameters
            };

            return classMethodSignature.Equals(interfaceMethodSignature);
        }
    }
}
