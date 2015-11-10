using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    public class SortedVector<T> : VectorPb<T> where T : IComparable
    {
        public override void Add(T element)
        {
            for (int i = 0; i < obj.Length; i++)
                if (obj[i].CompareTo(element) < 0)
                {
                    Insert(i, element);
                }                        
        }

        public int Find(T element)
        {
            int index = Array.BinarySearch(obj, element);

            return index;
        }


    }
}
