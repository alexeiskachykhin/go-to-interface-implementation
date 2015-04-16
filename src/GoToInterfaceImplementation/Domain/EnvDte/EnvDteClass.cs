using System;

using EnvDTE;

using GoToInterfaceImplementation.Domain.Contracts;

namespace GoToInterfaceImplementation.Domain.EnvDte
{
    public class EnvDteClass : IClass
    {
        private readonly CodeClass _codeClass;


        public string FullName
        {
            get { return _codeClass.FullName; }
        }


        public EnvDteClass(CodeClass codeClass)
        {
            _codeClass = codeClass;
        }


        public void RevealInCodeWindow()
        {
            Window window = _codeClass.ProjectItem.Open();
            window.Activate();

            TextSelection selection = (TextSelection)window.Selection;
            selection.MoveToPoint(_codeClass.StartPoint);
        }
    }
}
