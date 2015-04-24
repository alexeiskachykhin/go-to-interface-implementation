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
    internal abstract class SemanticElementDiscoverer
    {
        private readonly DTE2 _dte;


        public ICodeEditor CodeEditor { get; private set; }

        public Type DomainType { get; private set; }

        public Type EnvDteType { get; private set; }

        public vsCMElement EnvDteKind { get; private set; }


        public SemanticElementDiscoverer(ICodeEditor codeEditor, Type domainType, Type envDteType, vsCMElement envDteKind)
        {
            _dte = PackageServiceLocator.Current.GetService<DTE, DTE2>();

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
            TextPoint cursorTextPoint = GetCursorTextPoint();

            CodeElement codeElement = GetCodeElementAtTextPoint(
                _dte.ActiveDocument.ProjectItem.FileCodeModel.CodeElements,
                cursorTextPoint,
                EnvDteKind);

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


        private CodeElement GetCodeElementAtTextPoint(CodeElements codeElements, TextPoint textPoint, vsCMElement kind)
        {
            if (codeElements == null)
            {
                return null;
            }

            CodeElement foundCodeElement = null;

            foreach (CodeElement codeElement in codeElements)
            {
                if (codeElement.StartPoint.GreaterThan(textPoint) ||
                    codeElement.EndPoint.LessThan(textPoint))
                {
                    continue;
                }

                if (codeElement.Kind == kind)
                {
                    foundCodeElement = codeElement;
                }

                CodeElements innerCodeElements = GetCodeElementMembers(codeElement);

                foundCodeElement = GetCodeElementAtTextPoint(
                    innerCodeElements, textPoint, kind) ?? foundCodeElement;
            }

            return foundCodeElement;
        }

        private CodeElements GetCodeElementMembers(CodeElement codeElement)
        {
            CodeElements codeElements = null;

            if (codeElement is CodeNamespace)
            {
                codeElements = ((CodeNamespace)codeElement).Members;
            }
            else if (codeElement is CodeType)
            {
                codeElements = ((CodeType)codeElement).Members;
            }
            else if (codeElement is CodeFunction)
            {
                codeElements = ((CodeFunction)codeElement).Parameters;
            }

            return codeElements;
        }

        private TextPoint GetCursorTextPoint()
        {
            TextSelection selection = (TextSelection)_dte.ActiveWindow.Selection;
            TextPoint selectionPoint = selection.ActivePoint;

            return selectionPoint;
        }
    }
}
