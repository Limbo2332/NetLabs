using LAB1_Linq_To_Objects.Classes;
using LAB1_Linq_To_Objects.Enums;
using LAB1_Linq_To_Objects.TempClasses;
using System.Diagnostics.CodeAnalysis;

namespace LAB1_Linq_To_Objects
{
    class CarCustomerEqualityComparer : IEqualityComparer<CarCustomer>
    {
        public bool Equals(CarCustomer? x, CarCustomer? y)
        {
            return x?.Customer?.Name!.CompareTo(y?.Customer?.Name) == 0;
        }

        public int GetHashCode(CarCustomer obj)
        {
            return obj.Customer!.Name!.GetHashCode();
        }
    }
}