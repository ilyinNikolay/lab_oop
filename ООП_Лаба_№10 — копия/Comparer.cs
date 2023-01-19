using System.Collections;
using System;

namespace OOP__lab10
{
    public class SortByWeight : IComparer
    {
        public int Compare(object? obj1, object? obj2)
        {
            if (obj1 is Animal other1 && obj2 is Animal other2)
                return other1.Weight.CompareTo(other2.Weight);
            else
                throw new ArgumentException("Object is not an Animal");
        }
    }
}