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


        public ISemanticElement GetSelectedSemanticElement()
        {
            var semanticElementDiscoverers = new SemanticElementDiscoverer[] 
            {
                new ParameterOfInterfaceTypeDiscoverer(this),
                new PropertyOfInterfaceTypeDiscoverer(this),
                new FieldOfInterfaceTypeDiscoverer(this),
                new InterfaceMethodDiscoverer(this),
                new InterfacePropertyDiscoverer(this),
                new InterfaceEventDiscoverer(this),
                new InterfaceDiscoverer(this)
            };

            IEnumerable<ISemanticElement> possiblySelectedSemanticElements =
                from discoverer in semanticElementDiscoverers
                select discoverer.Discover();

            ISemanticElement selectedSemanticElement = possiblySelectedSemanticElements
                .FirstOrDefault(e => e != null);

            return selectedSemanticElement;
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
            Stack<CodeElement> unvisitedCodeElements = 
                new Stack<CodeElement>(codeElements.OfType<CodeElement>());

            while (unvisitedCodeElements.Count > 0)
            {
                CodeElement codeElement = unvisitedCodeElements.Pop();

                if (codeElement.Kind == vsCMElement.vsCMElementClass)
                {
                    yield return (CodeClass)codeElement;
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
