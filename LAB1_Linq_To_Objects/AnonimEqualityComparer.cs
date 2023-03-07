using LAB1_Linq_To_Objects.Classes;
using LAB1_Linq_To_Objects.Enums;
using System.Diagnostics.CodeAnalysis;

namespace LAB1_Linq_To_Objects
{
    class AnonimEqualityComparer : IEqualityComparer<TempClassForOwners>
    {
        public bool Equals(TempClassForOwners? x, TempClassForOwners? y)
        {
            return x?.Name!.CompareTo(y?.Name) == 0;
        }

        public int GetHashCode(TempClassForOwners obj)
        {
            return obj.Name!.GetHashCode();
        }
    }
}