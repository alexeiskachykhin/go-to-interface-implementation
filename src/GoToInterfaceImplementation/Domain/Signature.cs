using System;
using System.Collections.Generic;
using System.Linq;

using GoToInterfaceImplementation.Domain.Contracts;

namespace GoToInterfaceImplementation.Domain
{
    public class Signature : IEquatable<Signature>
    {
        private IEnumerable<IParameter> _parameters;


        public string Name { get; set; }

        public string FullName { get; set; }

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
                (a.FullName == b.FullName);

            return isEquals;
        }

        private bool ParametersEquals(Signature a, Signature b)
        {
            bool isParametersCountEquals = (a.Parameters.Count() == b.Parameters.Count());

            bool isParametersNamesEquals = a.Parameters
                .Zip(b.Parameters, (p1, p2) => p1.FullName == p2.FullName)
                .All(p => p);

            bool isEquals = (isParametersCountEquals && isParametersNamesEquals);

            return isEquals;
        }
    }
}
