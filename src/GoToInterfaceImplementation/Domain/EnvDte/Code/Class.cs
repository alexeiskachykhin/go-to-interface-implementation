﻿using System;
using System.Collections.Generic;
using System.Linq;

using EnvDTE;
using EnvDTE80;

using GoToInterfaceImplementation.Domain.Contracts.Code;
using GoToInterfaceImplementation.Domain.Contracts.Editor;
using GoToInterfaceImplementation.Domain.EnvDte.Services;

namespace GoToInterfaceImplementation.Domain.EnvDte.Code
{
    public class Class : SemanticElement<CodeClass>, IClass
    {
        public AccessModifier AccessModifier
        {
            get
            {
                ITypeConverter<vsCMAccess, AccessModifier> converter =
                    new VsCMAccessToAccessModifierConverter();

                return converter.Convert(CodeElement.Access);
            }
        }

        public IEnumerable<IClassMethod> Methods
        {
            get
            {
                IEnumerable<IClassMethod> methods =
                    from i in CodeElement.Members.OfType<CodeFunction>()
                    select new ClassMethod(CodeEditor, i);

                return methods;
            }
        }

        public IEnumerable<IClassProperty> Properties
        {
            get
            {
                IEnumerable<IClassProperty> properties =
                    from i in CodeElement.Members.OfType<CodeProperty2>()
                    select new ClassProperty(CodeEditor, i);

                return properties;
            }
        }

        public IEnumerable<IClassEvent> Events
        {
            get
            {
                IEnumerable<IClassEvent> events =
                    from i in CodeElement.Members.OfType<CodeEvent>()
                    select new ClassEvent(CodeEditor, i);

                return events;
            }
        }

        public IEnumerable<IInterface> ImplementedInterfaces
        {
            get
            {
                IEnumerable<IInterface> implementedInterfaces =
                    from i in CodeElement.ImplementedInterfaces.OfType<CodeInterface>()
                    select new Interface(CodeEditor, i);

                return implementedInterfaces;
            }
        }


        public Class(ICodeEditor codeEditor, CodeClass codeElement)
            : base(codeEditor, codeElement)
        {
        }


        public bool IsMatch(IInterface declaration)
        {
            bool isMatch = ImplementedInterfaces.Any(
                c => declaration.FullName == c.FullName);

            return isMatch;
        }
    }
}
