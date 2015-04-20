using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

using EnvDTE;

using GoToInterfaceImplementation.Domain.Contracts;
using GoToInterfaceImplementation.Integration;

namespace GoToInterfaceImplementation.Domain.EnvDte.Editor.Discoverers
{
    public abstract class EnvDteCodeElementDiscoverer
    {
        private readonly DTE _dte;


        public ICodeEditor CodeEditor { get; private set; }

        public Type DomainType { get; private set; }

        public Type EnvDteType { get; private set; }

        public vsCMElement EnvDteKind { get; private set; }


        public EnvDteCodeElementDiscoverer(ICodeEditor codeEditor, Type domainType, Type envDteType, vsCMElement envDteKind)
        {
            _dte = PackageServiceLocator.Current.GetService<DTE>();

            CodeEditor = codeEditor;
            DomainType = domainType;
            EnvDteType = envDteType;
            EnvDteKind = envDteKind;
        }


        public ICodeElement Discover()
        {
            TextSelection selection = (TextSelection)_dte.ActiveWindow.Selection;
            TextPoint selectionPoint = selection.ActivePoint;

            try
            {
                CodeElement codeElement =
                    _dte.ActiveDocument.ProjectItem.FileCodeModel.CodeElementFromPoint(selectionPoint, EnvDteKind);

                if (!IsApplicable(codeElement))
                {
                    return null;
                }

                ConstructorInfo constructor =
                    DomainType.GetConstructor(new[] { typeof(ICodeEditor), EnvDteType });

                return (ICodeElement)constructor.Invoke(new object[] { CodeEditor, codeElement });
            }
            catch (COMException)
            {
                return null;
            }
        }

        protected abstract bool IsApplicable(CodeElement codeElement);
    }
}
