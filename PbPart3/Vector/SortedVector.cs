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
            if (obj == null)
            {
                Array.Resize(ref obj, 1);
                obj[0] = element;
            }
            else

            for (int i = 0; i < obj.Length; i++)
                if (obj[i].CompareTo(element) < 0)
                {
                    Array.Resize(ref obj, obj.Length + 1);
                    obj = ShiftRight(i+1, element);
                }                        
        }

        public int Find(T element)
        {
            int index = Array.BinarySearch(obj, element);

            return index;
        }


    }
}
