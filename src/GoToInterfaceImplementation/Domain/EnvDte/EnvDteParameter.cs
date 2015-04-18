using System;
using System.Collections.Generic;
using System.Linq;

using EnvDTE;

using GoToInterfaceImplementation.Domain.Contracts;

namespace GoToInterfaceImplementation.Domain.EnvDte
{
    public class EnvDteParameter : IParameter
    {
        private readonly ICodeEditor _codeEditor;

        private readonly CodeParameter _codeParameter;


        public string FullName
        {
            get { return _codeParameter.FullName; }
        }


        public EnvDteParameter(ICodeEditor codeEditor, CodeParameter codeParameter)
        {
            _codeEditor = codeEditor;
            _codeParameter = codeParameter;
        }


        public void RevealInCodeEditor()
        {
            throw new NotImplementedException();
        }
    }
}
