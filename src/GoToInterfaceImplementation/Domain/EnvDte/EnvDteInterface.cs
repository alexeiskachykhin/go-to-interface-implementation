using System;
using System.Collections.Generic;

using EnvDTE;

using GoToInterfaceImplementation.Domain.Contracts;

namespace GoToInterfaceImplementation.Domain.EnvDte
{
    public class EnvDteInterface : IInterface
    {
        private readonly ICodeEditor _codeEditor;

        private readonly CodeInterface _codeInterface;


        public string FullName
        {
            get { return _codeInterface.FullName; }
        }


        public EnvDteInterface(ICodeEditor codeEditor, CodeInterface codeInterface)
        {
            _codeEditor = codeEditor;
            _codeInterface = codeInterface;
        }


        public void RevealInCodeEditor()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IClass> FindImplementations()
        {
            IImplementationFinder<IInterface, IClass> finder = 
                new EnvDteInterfaceImplementationFinder(_codeEditor);

            return finder.Find(this);
        }
    }
}
