using System;
using System.Collections.Generic;

namespace CS03_Extended_OOP
{
    class ReverseAgeComparer : IComparer<Cat>
    {
        public int Compare(Cat x, Cat y)
        {
            return y.Age - x.Age;
        }
    }

}
