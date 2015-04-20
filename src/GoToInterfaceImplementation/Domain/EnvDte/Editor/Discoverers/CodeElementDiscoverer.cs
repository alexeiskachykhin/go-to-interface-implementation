using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

using EnvDTE;
using EnvDTE80;

using GoToInterfaceImplementation.Domain.Contracts.Code;
using GoToInterfaceImplementation.Domain.Contracts.Editor;
using GoToInterfaceImplementation.Integration;

namespace GoToInterfaceImplementation.Domain.EnvDte.Editor.Discoverers
{
    internal abstract class CodeElementDiscoverer
    {
        private readonly DTE2 _dte;


        public ICodeEditor CodeEditor { get; private set; }

        public Type DomainType { get; private set; }

        public Type EnvDteType { get; private set; }

        public vsCMElement EnvDteKind { get; private set; }


        public CodeElementDiscoverer(ICodeEditor codeEditor, Type domainType, Type envDteType, vsCMElement envDteKind)
        {
            _dte = PackageServiceLocator.Current.GetService<DTE, DTE2>();

            CodeEditor = codeEditor;
            DomainType = domainType;
            EnvDteType = envDteType;
            EnvDteKind = envDteKind;
        }


        public ICodeElement Discover()
        {
            CodeElement codeElement = GetCodeElement();

            if (codeElement != null)
            {
                return CreateDomainModel(codeElement);
            }

            return null;
        }


        protected virtual ICodeElement CreateDomainModel(CodeElement codeElement)
        {
            ConstructorInfo constructor =
                    DomainType.GetConstructor(new[] { typeof(ICodeEditor), EnvDteType });

            return (ICodeElement)constructor.Invoke(new object[] { CodeEditor, codeElement });
        }

        protected virtual CodeElement GetCodeElement()
        {
            CodeElement codeElement = null;

            TextSelection selection = (TextSelection)_dte.ActiveWindow.Selection;
            TextPoint selectionPoint = selection.ActivePoint;

            try
            {
                codeElement = _dte.ActiveDocument.ProjectItem.FileCodeModel.CodeElementFromPoint(
                    selectionPoint, EnvDteKind);
            }
            catch (COMException)
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
