using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

using EnvDTE;

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

            CodeInterface selectedCodeInterface = null;

            try
            {
                selectedCodeInterface = (CodeInterface)_dte.ActiveDocument.ProjectItem.FileCodeModel.CodeElementFromPoint(
                    selectionPoint,
                    vsCMElement.vsCMElementInterface);
            }
            catch (COMException)
            {
            }

            ICodeElement codeElement = (selectedCodeInterface != null) ? 
                new EnvDteInterface(selectedCodeInterface) : 
                null;

            return codeElement;
        }

        public IEnumerable<IClass> GetClassesInSolution()
        {
            IEnumerable<IClass> classes =
                from c in GetClassesInSolution(_dte.Solution)
                select new EnvDteClass(c);

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
