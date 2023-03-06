using LAB1_Linq_To_Objects.Classes;
using LAB1_Linq_To_Objects.Enums;
using System.Diagnostics.CodeAnalysis;

namespace LAB1_Linq_To_Objects
{
    class AnonimEqualityComparer<T> : IEqualityComparer<T>
    {
        private readonly Func<T, T, bool> _comparerFunc;
        public AnonimEqualityComparer(Func<T, T, bool> comparerFunc)
        {
            _comparerFunc = comparerFunc;
        }

        public bool Equals(T x, T y)
        {
            return _comparerFunc(x, y);
        }

        public int GetHashCode(T obj)
        {
            return obj.GetHashCode();
        }
    }
}