using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

using EnvDTE;
using EnvDTE80;

using GoToInterfaceImplementation.Domain.Contracts.Code;
using GoToInterfaceImplementation.Domain.Contracts.Editor;
using GoToInterfaceImplementation.Domain.EnvDte.Utilities;
using GoToInterfaceImplementation.Integration;

namespace GoToInterfaceImplementation.Domain.EnvDte.Editor.Discoverers
{
    internal abstract class SemanticElementDiscoverer
    {
        private readonly CodeModelUtilities _codeModelUtilities;


        public ICodeEditor CodeEditor { get; private set; }

        public Type DomainType { get; private set; }

        public Type EnvDteType { get; private set; }

        public vsCMElement EnvDteKind { get; private set; }


        public SemanticElementDiscoverer(ICodeEditor codeEditor, Type domainType, Type envDteType, vsCMElement envDteKind)
        {
            _codeModelUtilities = new CodeModelUtilities();

            CodeEditor = codeEditor;
            DomainType = domainType;
            EnvDteType = envDteType;
            EnvDteKind = envDteKind;
        }


        public ISemanticElement Discover()
        {
            CodeElement codeElement = GetCodeElement();

            if (codeElement != null)
            {
                return CreateDomainModel(codeElement);
            }

            return null;
        }


        protected virtual ISemanticElement CreateDomainModel(CodeElement codeElement)
        {
            ConstructorInfo constructor =
                    DomainType.GetConstructor(new[] { typeof(ICodeEditor), EnvDteType });

            return (ISemanticElement)constructor.Invoke(new object[] { CodeEditor, codeElement });
        }

        protected virtual CodeElement GetCodeElement()
        {
            CodeElement codeElement = _codeModelUtilities.GetCodeElementUnderCursor(EnvDteKind);

            if (codeElement == null)
            {
                return null;
            }

            if (!IsApplicable(codeElement))
            {
                return null;
            }

            return codeElement;
        }

        protected abstract bool IsApplicable(CodeElement codeElement);
    }
}
