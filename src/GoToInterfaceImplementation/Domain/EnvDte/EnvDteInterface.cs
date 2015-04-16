using System;

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


        public void RevealInCodeWindow()
        {
            throw new NotImplementedException();
        }

        public void RevealImplementationInCodeWindow()
        {
            var finder = new EnvDteInterfaceImplementationFinder();
            var derivedCodeClass = finder.Find(this);

            if (derivedCodeClass != null)
            {
                derivedCodeClass.RevealInCodeWindow();
            }
        }
    }
}
