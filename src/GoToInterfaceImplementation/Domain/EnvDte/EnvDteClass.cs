using System;
using System.Collections.Generic;
using System.Linq;

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

        public IEnumerable<IInterface> ImplementedInterfaces
        {
            get 
            {
                IEnumerable<IInterface> implementedInterfaces =
                    from i in _codeClass.ImplementedInterfaces.OfType<CodeInterface>()
                    select new EnvDteInterface(i);

                return implementedInterfaces;
            }
        }


        public EnvDteClass(CodeClass codeClass)
        {
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
