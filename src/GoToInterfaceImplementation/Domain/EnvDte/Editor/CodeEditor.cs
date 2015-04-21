using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

using EnvDTE;
using EnvDTE80;

using GoToInterfaceImplementation.Integration;
using GoToInterfaceImplementation.Domain.Contracts.Code;
using GoToInterfaceImplementation.Domain.Contracts.Editor;
using GoToInterfaceImplementation.Domain.EnvDte.Code;
using GoToInterfaceImplementation.Domain.EnvDte.Editor.Discoverers;

namespace GoToInterfaceImplementation.Domain.EnvDte.Editor
{
    public class CodeEditor : ICodeEditor
    {
        private readonly DTE2 _dte;


        public CodeEditor()
        {
            _dte = PackageServiceLocator.Current.GetService<DTE, DTE2>();
        }


        public ICodeElement GetSelectedCodeElement()
        {
            var elementDiscoverers = new CodeElementDiscoverer[] 
            {
                new ParameterOfInterfaceTypeDiscoverer(this),
                new InterfaceMethodDiscoverer(this),
                new InterfacePropertyDiscoverer(this),
                new InterfaceEventDiscoverer(this),
                new InterfaceDiscoverer(this)
            };

            IEnumerable<ICodeElement> possiblySelectedCodeElements =
                from discoverer in elementDiscoverers
                select discoverer.Discover();

            ICodeElement selectedCodeElement = possiblySelectedCodeElements
                .FirstOrDefault(e => e != null);

            return selectedCodeElement;
        }

        public IEnumerable<IClass> GetClassesInSolution()
        {
            IEnumerable<IClass> classes =
                from c in GetClassesInSolution(_dte.Solution)
                select new Class(this, c);

            return classes;
        }


        private IEnumerable<CodeClass> GetClasses(CodeElements codeElements)
        {
            Stack<CodeElement> unvisitedElements = 
                new Stack<CodeElement>(codeElements.OfType<CodeElement>());

            while (unvisitedElements.Count > 0)
            {
                CodeElement codeElement = unvisitedElements.Pop();

                if (codeElement.Kind == vsCMElement.vsCMElementClass)
                {
                    yield return (CodeClass)codeElement;
                }
                else if (codeElement.Kind == vsCMElement.vsCMElementNamespace)
                {
                    CodeNamespace namespaceElement = (CodeNamespace)codeElement;

                    foreach (CodeElement innerCodeElement in namespaceElement.Members)
                    {
                        unvisitedElements.Push(innerCodeElement);
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
