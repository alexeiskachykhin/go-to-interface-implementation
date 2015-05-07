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
using GoToInterfaceImplementation.Domain.EnvDte.Utilities;

namespace GoToInterfaceImplementation.Domain.EnvDte.Editor
{
    public class CodeEditor : ICodeEditor
    {
        private readonly CodeModelUtilities _codeModelUtilities;


        public CodeEditor()
        {
            _codeModelUtilities = new CodeModelUtilities();
        }


        public ISemanticElement GetSelectedSemanticElement()
        {
            var semanticElementDiscoverers = new SemanticElementDiscoverer[]
            {
                new ParameterOfInterfaceTypeDiscoverer(this),
                new InterfaceMethodDiscoverer(this),
                new InterfacePropertyDiscoverer(this),
                new InterfaceEventDiscoverer(this),
                new PropertyOfInterfaceTypeDiscoverer(this),
                new FieldOfInterfaceTypeDiscoverer(this),
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
                from c in _codeModelUtilities.GetClassesInActiveSolution()
                select new Class(this, c);

            return classes;
        }
    }
}
