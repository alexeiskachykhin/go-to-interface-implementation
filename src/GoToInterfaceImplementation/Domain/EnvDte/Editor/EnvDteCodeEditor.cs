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
    public class EnvDteCodeEditor : ICodeEditor
    {
        private readonly DTE2 _dte;


        public EnvDteCodeEditor()
        {
            _dte = PackageServiceLocator.Current.GetService<DTE, DTE2>();
        }


        public ICodeElement GetSelectedCodeElement()
        {
            var elementDiscoverers = new EnvDteCodeElementDiscoverer[] 
            {
                new EnvDteParameterOfInterfaceTypeDiscoverer(this),
                new EnvDteInterfaceMethodDiscoverer(this),
                new EnvDteInterfacePropertyDiscoverer(this),
                new EnvDteInterfaceEventDiscoverer(this),
                new EnvDteInterfaceDiscoverer(this)
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
