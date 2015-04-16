using System;
using System.Collections.Generic;
using System.Linq;

using EnvDTE;

using GoToInterfaceImplementation.Integration;
using GoToInterfaceImplementation.Domain.Contracts;

namespace GoToInterfaceImplementation.Domain.EnvDte
{
    public class EnvDteInterfaceImplementationFinder : IInterfaceImplementationFinder
    {
        private readonly DTE _dte;


        public EnvDteInterfaceImplementationFinder()
        {
            _dte = PackageServiceLocator.Current.GetService<DTE>();
        }


        public IClass Find(IInterface codeInterface)
        {
            IEnumerable<CodeClass> codeClasses = GetClassesInSolution(_dte.Solution);

            CodeClass derivedCodeClass =
                codeClasses.FirstOrDefault(c => c.ImplementedInterfaces.Cast<CodeElement>().Any(b => b.FullName == codeInterface.FullName));

            IClass codeElement = (derivedCodeClass != null) ?
                new EnvDteClass(derivedCodeClass) :
                null;

            return codeElement;
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
