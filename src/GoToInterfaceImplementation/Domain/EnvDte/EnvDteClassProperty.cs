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
            IEnumerable<IParameter> classPropertyParameters = this.Parameters;
            IEnumerable<IParameter> interfacePropertyParameters = declaration.Parameters;

            bool isMatch = classPropertyParameters
                .Zip(interfacePropertyParameters, (p1, p2) => p1.FullName == p2.FullName)
                .All(p => p);

            return isMatch;
        }
    }
}
