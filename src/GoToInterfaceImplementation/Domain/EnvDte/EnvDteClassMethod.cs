﻿using System;
using System.Collections.Generic;
using System.Linq;

using EnvDTE;

using GoToInterfaceImplementation.Domain.Contracts;

namespace GoToInterfaceImplementation.Domain.EnvDte
{
    public class EnvDteClassMethod : EnvDteCodeElement<CodeFunction>, IClassMethod
    {
        public IEnumerable<IParameter> Parameters
        {
            get 
            {
                IEnumerable<IParameter> parameters =
                    from i in CodeElement.Parameters.OfType<CodeParameter>()
                    select new EnvDteParameter(CodeEditor, i);

                return parameters;
            }
        }


        public EnvDteClassMethod(ICodeEditor codeEditor, CodeFunction codeFunction)
            : base(codeEditor, codeFunction)
        {
        }


        public bool IsMatch(IInterfaceMethod declaration)
        {
            IEnumerable<IParameter> classMemberParameters = this.Parameters;
            IEnumerable<IParameter> interfaceMemberParameters = declaration.Parameters;

            bool isMatch = classMemberParameters
                .Zip(interfaceMemberParameters, (p1, p2) => p1.FullName == p2.FullName)
                .All(p => p);

            return isMatch;
        }
    }
}