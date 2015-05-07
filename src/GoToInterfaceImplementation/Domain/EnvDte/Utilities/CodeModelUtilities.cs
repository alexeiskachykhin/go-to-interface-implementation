using System;
using System.Collections.Generic;
using System.Linq;

using EnvDTE;
using EnvDTE80;

using GoToInterfaceImplementation.Integration;

namespace GoToInterfaceImplementation.Domain.EnvDte.Utilities
{
    public class CodeModelUtilities
    {
        private readonly DTE2 _dte;


        public CodeModelUtilities()
        {
            _dte = PackageServiceLocator.Current.GetService<DTE, DTE2>();
        }


        public IEnumerable<CodeClass> GetClassesInActiveSolution()
        {
            return GetClassesInSolution(_dte.Solution);
        }

        public CodeElement GetCodeElementUnderCursor(vsCMElement kind)
        {
            TextPoint cursorTextPoint = GetCursorTextPoint();

            CodeElement codeElement = GetCodeElementAtTextPoint(
                _dte.ActiveDocument.ProjectItem.FileCodeModel.CodeElements,
                cursorTextPoint,
                kind);

            return codeElement;
        }


        private IEnumerable<CodeClass> GetClassesInSolution(Solution solution)
        {
            foreach (Project project in solution.Projects)
            {
                foreach (CodeClass codeClass in GetClassesInProject(project))
                {
                    yield return codeClass;
                }
            }
        }

        private IEnumerable<CodeClass> GetClassesInProject(Project project)
        {
            if (project.CodeModel == null)
            {
                return Enumerable.Empty<CodeClass>();
            }

            return GetClasses(project.CodeModel.CodeElements);
        }

        private IEnumerable<CodeClass> GetClasses(CodeElements codeElements)
        {
            Stack<CodeElement> unvisitedCodeElements =
                new Stack<CodeElement>(codeElements.OfType<CodeElement>());

            while (unvisitedCodeElements.Count > 0)
            {
                CodeElement codeElement = unvisitedCodeElements.Pop();

                if (codeElement.Kind == vsCMElement.vsCMElementClass)
                {
                    if (codeElement.InfoLocation == vsCMInfoLocation.vsCMInfoLocationProject)
                    {
                        yield return (CodeClass)codeElement;
                    }
                }
                else if (codeElement.Kind == vsCMElement.vsCMElementNamespace)
                {
                    CodeNamespace namespaceElement = (CodeNamespace)codeElement;

                    foreach (CodeElement innerCodeElement in namespaceElement.Members)
                    {
                        unvisitedCodeElements.Push(innerCodeElement);
                    }
                }
            }
        }


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
