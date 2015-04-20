using System;
using System.Collections.Generic;
using System.Linq;

using EnvDTE;

using GoToInterfaceImplementation.Domain.Contracts.Editor;
using GoToInterfaceImplementation.Domain.Contracts.Code;

namespace GoToInterfaceImplementation.Domain.EnvDte.Code
{
    public abstract class EnvDteCodeElement<T> : ICodeElement
    {
        private ICodeEditor _codeEditor;

        private T _codeElement;


        public string Name
        {
            get { return ((CodeElement)_codeElement).Name; }
        }

        public string FullName
        {
            get { return ((CodeElement)_codeElement).FullName; }
        }

        public ICodeEditor CodeEditor
        {
            get { return _codeEditor; }
        }

        protected T CodeElement
        {
            get { return _codeElement; }
        }


        public EnvDteCodeElement(ICodeEditor codeEditor, T codeElement)
        {
            _codeEditor = codeEditor;
            _codeElement = codeElement;
        }


        public void RevealInCodeEditor()
        {
            CodeElement codeElement = (CodeElement)_codeElement;

            Window window = codeElement.ProjectItem.Open();
            window.Activate();

            TextSelection selection = (TextSelection)window.Selection;
            selection.MoveToPoint(codeElement.StartPoint);
        }
    }
}
