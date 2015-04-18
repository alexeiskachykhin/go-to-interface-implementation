using System;
using System.Collections.Generic;
using System.Linq;

using EnvDTE;

using GoToInterfaceImplementation.Domain.Contracts;

namespace GoToInterfaceImplementation.Domain.EnvDte
{
    public class EnvDteClassMember : IClassMember
    {
        private readonly ICodeEditor _codeEditor;

        private readonly CodeFunction _codeFunction;


        public string FullName
        {
            get { return _codeFunction.FullName; }
        }

        public IEnumerable<IParameter> Parameters
        {
            get 
            {
                IEnumerable<IParameter> parameters =
                    from i in _codeFunction.Parameters.OfType<CodeParameter>()
                    select new EnvDteParameter(_codeEditor, i);

                return parameters;
            }
        }


        public EnvDteClassMember(ICodeEditor codeEditor, CodeFunction codeFunction)
        {
            _codeEditor = codeEditor;
            _codeFunction = codeFunction;
        }


        public void RevealInCodeEditor()
        {
            Window window = _codeFunction.ProjectItem.Open();
            window.Activate();

            TextSelection selection = (TextSelection)window.Selection;
            selection.MoveToPoint(_codeFunction.StartPoint);
        }
    }
}
