using System;
using System.Collections.Generic;
using System.Linq;

using EnvDTE;
using EnvDTE80;

using GoToInterfaceImplementation.Domain.Contracts.Code;
using GoToInterfaceImplementation.Domain.Contracts.Editor;
using GoToInterfaceImplementation.Domain.Contracts.Services;
using GoToInterfaceImplementation.Domain.EnvDte.Services;

namespace GoToInterfaceImplementation.Domain.EnvDte.Code
{
    public class InterfaceProperty : SemanticElement<CodeProperty2>, IInterfaceProperty
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

        public IInterface Interface
        {
            get { return new Interface(CodeEditor, (CodeInterface)CodeElement.Parent2); }
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


        public InterfaceProperty(ICodeEditor codeEditor, CodeProperty2 codeProperty)
            : base(codeEditor, codeProperty)
        {
        }


        public IEnumerable<IClassProperty> FindImplementations()
        {
            IImplementationFinder<IInterfaceProperty, IClassProperty> finder =
                new InterfacePropertyImplementationFinder();

            return finder.Find(this);
        }
    }
}
