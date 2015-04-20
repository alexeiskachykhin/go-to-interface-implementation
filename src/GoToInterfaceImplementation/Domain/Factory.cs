﻿using System;

using GoToInterfaceImplementation.Domain.EnvDte;
using GoToInterfaceImplementation.Domain.Contracts.Editor;
using GoToInterfaceImplementation.Domain.Contracts.Services;

namespace GoToInterfaceImplementation.Domain
{
    public abstract class Factory
    {
        public abstract ICodeEditor CreateCodeEditor();

        public abstract IImplementationSelector CreateImplementationSelector();


        private static Factory _current;


        public static Factory Current
        {
            get 
            {
                if (_current == null)
                {
                    _current = new EnvDteFactory();
                }

                return _current;
            }
        }
    }
}
