using System;
using System.Collections.Generic;
using System.Linq;

using EnvDTE;

using GoToInterfaceImplementation.Domain.Contracts;

namespace GoToInterfaceImplementation.Domain.EnvDte
{
    public class EnvDteClass : IClass
    {
        private readonly ICodeEditor _codeEditor;

        private readonly CodeClass _codeClass;


        public string FullName
        {
            get { return _codeClass.FullName; }
        }

        public IEnumerable<IClassMember> Members
        {
            get 
            {
                IEnumerable<IClassMember> classMembers =
                    from i in _codeClass.Children.OfType<CodeFunction>()
                    select new EnvDteClassMember(_codeEditor, i);

                return classMembers;
            }
        }

        public IEnumerable<IInterface> ImplementedInterfaces
        {
            get 
            {
                IEnumerable<IInterface> implementedInterfaces =
                    from i in _codeClass.ImplementedInterfaces.OfType<CodeInterface>()
                    select new EnvDteInterface(_codeEditor, i);

                return implementedInterfaces;
            }
        }


        public EnvDteClass(ICodeEditor codeEditor, CodeClass codeClass)
        {
            _codeEditor = codeEditor;
            _codeClass = codeClass;
        }


        public void RevealInCodeEditor()
        {
            Window window = _codeClass.ProjectItem.Open();
            window.Activate();

            TextSelection selection = (TextSelection)window.Selection;
            selection.MoveToPoint(_codeClass.StartPoint);
        }
    }
}
