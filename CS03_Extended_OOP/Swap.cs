using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CS03_Extended_OOP
{
    public class Swap<T>
    {
        public static void SwapNow(ref T original, ref T target)
        {
            T holder = original;
            original = target;
            target = holder;
        }
    }
}
