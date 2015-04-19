using System;
using System.Collections.Generic;
using System.Linq;

using EnvDTE;
using EnvDTE80;

using GoToInterfaceImplementation.Domain.Contracts;

namespace GoToInterfaceImplementation.Domain.EnvDte
{
    public class EnvDteClassProperty : EnvDteCodeElement<CodeProperty2>, IClassProperty
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


        public EnvDteClassProperty(ICodeEditor codeEditor, CodeProperty2 codeProperty)
            : base(codeEditor, codeProperty)
        {
        }


        public bool IsMatch(IInterfaceProperty declaration)
        {
            Signature classPropertySignature = new Signature()
            {
                Name = Name,
                Parameters = Parameters
            };

            Signature interfacePropertySignature = new Signature()
            {
                Name = declaration.Name,
                Parameters = declaration.Parameters
            };

            return classPropertySignature.Equals(interfacePropertySignature);
        }
    }
}
