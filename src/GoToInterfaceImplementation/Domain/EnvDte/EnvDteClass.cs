using System;
using System.Collections.Generic;
using System.Linq;

using EnvDTE;
using EnvDTE80;

using GoToInterfaceImplementation.Domain.Contracts;

namespace GoToInterfaceImplementation.Domain.EnvDte
{
    public class EnvDteClass : EnvDteCodeElement<CodeClass>, IClass
    {
        public IEnumerable<IClassMethod> Methods
        {
            get 
            {
                IEnumerable<IClassMethod> classMethods =
                    from i in CodeElement.Children.OfType<CodeFunction>()
                    select new EnvDteClassMethod(CodeEditor, i);

                return classMethods;
            }
        }

        public IEnumerable<IClassProperty> Properties
        {
            get 
            {
                IEnumerable<IClassProperty> classProperties =
                    from i in CodeElement.Children.OfType<CodeProperty2>()
                    select new EnvDteClassProperty(CodeEditor, i);

                return classProperties;
            }
        }

        public IEnumerable<IClassEvent> Events
        {
            get 
            {
                IEnumerable<IClassEvent> classEvents =
                    from i in CodeElement.Children.OfType<CodeEvent>()
                    select new EnvDteClassEvent(CodeEditor, i);

                return classEvents;
            }
        }

        public IEnumerable<IInterface> ImplementedInterfaces
        {
            get 
            {
                IEnumerable<IInterface> implementedInterfaces =
                    from i in CodeElement.ImplementedInterfaces.OfType<CodeInterface>()
                    select new EnvDteInterface(CodeEditor, i);

                return implementedInterfaces;
            }
        }


        public EnvDteClass(ICodeEditor codeEditor, CodeClass codeElement)
            : base(codeEditor, codeElement)
        {
        }


        public bool IsMatch(IInterface declaration)
        {
            bool isMatch = ImplementedInterfaces.Any(
                c => declaration.FullName == c.FullName);

            return isMatch;
        }
    }
}
