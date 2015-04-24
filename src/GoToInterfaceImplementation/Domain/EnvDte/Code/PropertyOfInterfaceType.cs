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
    public class PropertyOfInterfaceType : Property, IPropertyOfInterfaceType
    {
        public IInterface Interface
        {
            get { return new Interface(CodeEditor, (CodeInterface)CodeElement.Type.CodeType); }
        }


        public PropertyOfInterfaceType(ICodeEditor codeEditor, CodeProperty2 codeProperty)
            : base(codeEditor, codeProperty)
        {
        }


        public IEnumerable<IClass> FindImplementations()
        {
            IImplementationFinder<IPropertyOfInterfaceType, IClass> finder =
                new PropertyOfInterfaceTypeImplementationFinder();

            return finder.Find(this);
        }
    }
}
