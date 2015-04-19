using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

using EnvDTE;
using EnvDTE80;

using GoToInterfaceImplementation.Integration;
using GoToInterfaceImplementation.Domain.Contracts;

namespace GoToInterfaceImplementation.Domain.EnvDte
{
    public class EnvDteCodeEditor : ICodeEditor
    {
        private readonly DTE _dte;


        public EnvDteCodeEditor()
        {
            _dte = PackageServiceLocator.Current.GetService<DTE>();
        }


        public ICodeElement GetSelectedCodeElement()
        {
            TextSelection selection = (TextSelection)_dte.ActiveWindow.Selection;
            TextPoint selectionPoint = selection.ActivePoint;

            var elementTypes = new[] 
            {
                new { DomainType = typeof(EnvDteInterfaceMethod), EnvDteType = typeof(CodeFunction), EnvDteKind = vsCMElement.vsCMElementFunction },
                new { DomainType = typeof(EnvDteInterfaceProperty), EnvDteType = typeof(CodeProperty2), EnvDteKind = vsCMElement.vsCMElementProperty },
                new { DomainType = typeof(EnvDteInterfaceEvent), EnvDteType = typeof(CodeEvent), EnvDteKind = vsCMElement.vsCMElementEvent },
                new { DomainType = typeof(EnvDteInterface), EnvDteType = typeof(CodeInterface), EnvDteKind = vsCMElement.vsCMElementInterface }
            };

            IEnumerable<ICodeElement> possiblySelectedCodeElements = elementTypes.Select(x =>
            {
                try
                {
                    CodeElement codeElement =
                        _dte.ActiveDocument.ProjectItem.FileCodeModel.CodeElementFromPoint(selectionPoint, x.EnvDteKind);

                    ConstructorInfo constructor =
                        x.DomainType.GetConstructor(new[] { typeof(ICodeEditor), x.EnvDteType });

                    return (ICodeElement)constructor.Invoke(new object[] { this, codeElement });
                }
                catch (COMException)
                {
                    return null;
                }
            });

            ICodeElement selectedCodeElement = possiblySelectedCodeElements
                .FirstOrDefault(e => e != null);

            return selectedCodeElement;
        }

        public IEnumerable<IClass> GetClassesInSolution()
        {
            IEnumerable<IClass> classes =
                from c in GetClassesInSolution(_dte.Solution)
                select new EnvDteClass(this, c);

            return classes;
        }


        private IEnumerable<CodeClass> GetClasses(CodeElements codeElements)
        {
            foreach (CodeElement codeElement in codeElements)
            {
                if (codeElement.Kind == vsCMElement.vsCMElementClass)
                {
                    yield return (CodeClass)codeElement;
                }
                else if (codeElement.Kind == vsCMElement.vsCMElementNamespace)
                {
                    var namespaceElement = (CodeNamespace)codeElement;

                    foreach (CodeClass codeClass in GetClasses(namespaceElement.Members))
                    {
                        yield return codeClass;
                    }
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
    }
}
