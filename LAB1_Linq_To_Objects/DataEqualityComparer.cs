using LAB1_Linq_To_Objects.Classes;
using System.Diagnostics.CodeAnalysis;

namespace LAB1_Linq_To_Objects
{
    class DataEqualityComparer : IEqualityComparer<ICollection<Rental>>
    {
        public bool Equals(ICollection<Rental>? x, ICollection<Rental>? y)
        {
            bool result = true;
            foreach (var xElement in x)
            {
                result &= xElement.Equals(y.FirstOrDefault(el => el.Id == xElement.Id));
            }

            return result;
        }

        public int GetHashCode([DisallowNull] ICollection<Rental> obj)
        {
            unchecked
            {
                int hash = 19;
                foreach (var foo in obj)
                {
                    hash = hash * 31 + foo.Id.GetHashCode();
                }
                return hash;
            }
        }
    }
}