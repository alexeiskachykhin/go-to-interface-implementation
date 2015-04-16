using System;

namespace GoToInterfaceImplementation.Integration
{
    public static class PackageIdentifiers
    {
        public const string GoToInterfaceImplementationPackageString = "5525ea2c-572b-4742-975b-8ba3262b48dc";

        public const string GoToInterfaceImplementationCommandSetString = "80e60a93-5c13-4c22-a468-2997f09cd108";
        
        public const uint GoToInterfaceImplementationCommand = 0x100;


        public static readonly Guid GoToInterfaceImplementationCommandSet = new Guid(GoToInterfaceImplementationCommandSetString);
    }
}
