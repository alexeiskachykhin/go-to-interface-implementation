using System;
using System.Collections.Generic;
using System.Linq;

using GoToInterfaceImplementation.Domain.Contracts.Code;

namespace GoToInterfaceImplementation.Domain.EnvDte.Code
{
    internal class Signature : IEquatable<Signature>
    {
        private IEnumerable<IParameter> _parameters;


        public string Name { get; set; }

        public string FullName { get; set; }

        public string ReturnTypeFullName { get; set; }

        public IEnumerable<IParameter> Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }


        public Signature()
        {
            _parameters = Enumerable.Empty<IParameter>();
        }


        public bool Equals(Signature other)
        {
            if (other == null)
            {
                return false;
            }

            bool isMatch =
                NamesEquals(this, other) &&
                ParametersEquals(this, other);

            return isMatch;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (GetType() != obj.GetType())
            {
                return false;
            }

            return Equals((Signature)obj);
        }

        public override int GetHashCode()
        {
            return (Name.GetHashCode() ^ FullName.GetHashCode());
        }


        private bool NamesEquals(Signature a, Signature b)
        {
            bool isEquals =
                (a.Name == b.Name) &&
                (a.FullName == b.FullName) &&
                (a.ReturnTypeFullName == b.ReturnTypeFullName);

            return isEquals;
        }

        private bool ParametersEquals(Signature a, Signature b)
        {
            bool isParametersCountEquals = (a.Parameters.Count() == b.Parameters.Count());

            bool isParametersNamesEquals = a.Parameters
                .Zip(b.Parameters, (p1, p2) => ParameterEquals(p1, p2))
                .All(p => p);

            bool isEquals = (isParametersCountEquals && isParametersNamesEquals);

            return isEquals;
        }

        private bool ParameterEquals(IParameter a, IParameter b)
        {
            bool isEquals =
                (a.FullName == b.FullName) &&
                (a.TypeFullName == b.TypeFullName);

            return isEquals;
        }
    }
}
