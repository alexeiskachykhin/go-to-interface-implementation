using System;
using System.Runtime.InteropServices;

using EnvDTE;

using GoToInterfaceImplementation.Integration;
using GoToInterfaceImplementation.Domain.Contracts;

namespace GoToInterfaceImplementation.Domain.EnvDte
{
    public class EnvDteCodeEditor : ICodeEditor
    {
        private readonly DTE _dte;


        public EnvDteCodeEditor()
        {
            _dte = PackageServiceLocator.Current.GetService<DTE>();
        }


        public ICodeElement GetSelectedCodeElement()
        {
            TextSelection selection = (TextSelection)_dte.ActiveWindow.Selection;
            TextPoint selectionPoint = selection.ActivePoint;

            CodeInterface selectedCodeInterface = null;

            try
            {
                selectedCodeInterface = (CodeInterface)_dte.ActiveDocument.ProjectItem.FileCodeModel.CodeElementFromPoint(
                    selectionPoint,
                    vsCMElement.vsCMElementInterface);
            }
            catch (COMException)
            {
            }

            ICodeElement codeElement = (selectedCodeInterface != null) ? 
                new EnvDteInterface(selectedCodeInterface) : 
                null;

            return codeElement;
        }
    }
}
