﻿using System;

using EnvDTE;

using GoToInterfaceImplementation.Domain.Contracts;

namespace GoToInterfaceImplementation.Domain.EnvDte
{
    public class EnvDteInterface : IInterface
    {
        private readonly CodeInterface _codeInterface;


        public string FullName
        {
            get { return _codeInterface.FullName; }
        }


        public EnvDteInterface(CodeInterface codeInterface)
        {
            _codeInterface = codeInterface;
        }


        public void RevealInCodeEditor()
        {
            throw new NotImplementedException();
        }

        public void RevealImplementationInCodeEditor(ICodeEditor codeEditor)
        {
            var finder = new EnvDteInterfaceImplementationFinder(codeEditor);
            var derivedCodeClass = finder.Find(this);

            if (derivedCodeClass != null)
            {
                derivedCodeClass.RevealInCodeEditor();
            }
        }
    }
}
