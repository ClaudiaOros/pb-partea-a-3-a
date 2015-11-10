using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{

    public class VectorPb<T> : IEnumerable
    {
        public int count;
        public T[] obj;

        public VectorPb()
        {
 
        }

        public VectorPb(T[] obj, int count)
        {
            this.count = count;
            this.obj = obj;
        }

        public virtual void Add(T element)
        {
            if (count % 8 == 0)
            {
                var obj2 = new T[count * 2];
                Copy(obj2);
                obj2[count] = element;

            }
            else
                obj[count] = element;
        }

        private void Copy(T[] obj2)
        {
            for (int i = 0; i < count; i++)
            {
                obj2[i] = obj[i];
            }
        }

        public T[] Insert(int position, T element)
        {
            if (obj[position] == null)
            {
                obj[position] = element;
                return obj;
            }

            if (count % 8 == 0)
            {
                return ResizeArrayAndInsertAnElement(position, element);
            }

            return ShiftLeft(position, element);
        }

        private T[] ShiftLeft(int position, T element)
        {
            for (int i = count - 1; i >= position; i--)
            {
                obj[i + 1] = obj[i];
            }

            obj[position] = element;
            return obj;
        }

        private T[] ResizeArrayAndInsertAnElement(int position, T element)
        {
            var obj2 = new T[count * 2];

            CopyElementsUntillPosition(position, obj2);

            obj2[position] = element;

            CopyElementsFromPosition(position, obj2);

            return obj2;
        }

        private void CopyElementsFromPosition(int position, T[] obj2)
        {
            for (int i = position + 1; i <= count; i++)
            {
                obj2[i] = obj[i - 1];
            }
        }

        private void CopyElementsFromPosition2(int position, T[] obj2)
        {
            for (int i = position; i < count - 1; i++)
            {
                obj2[i] = obj[i + 1];
            }
        }

        private void CopyElementsUntillPosition(int position, T[] obj2)
        {
            for (int i = 0; i < position; i++)
            {
                obj2[i] = obj[i];
            }
        }

        public T[] Remove(T element)
        {
            int position = 0;

            position = FindElementChangeValueAndReturnPosition(element, position);

            if (count % 8 == 1)
            {
                var obj2 = new T[count - 1];

                CopyElementsUntillPosition(position, obj2);

                CopyElementsFromPosition2(position, obj2);

                return obj2;
            }

            MoveElementsToRightOneStepStartingWithAPosition(position);

            return obj;

        }

        private int FindElementChangeValueAndReturnPosition(T element, int position)
        {
            for (int i = 0; i < count; i++)
            {
                if (obj[i].Equals(element))
                {
                    obj[i] = obj[i + 1];
                    position = i + 1;
                    break;
                }
            }
            return position;
        }

        private void MoveElementsToRightOneStepStartingWithAPosition(int position)
        {
            for (int j = position; j < count; j++)
            {
                obj[j] = obj[j + 1];
            }
        }

        public T[] Remove(int index)
        {
            if (count % 8 == 1)
            {
                var obj2 = new T[count - 1];

                CopyElementsUntillPosition(index, obj2);

                CopyElementsFromPosition2(index, obj2);

                return obj2;
            }

            MoveElementsToRightOneStepStartingWithAPosition(index);
            return obj;

        }

        public int GetCount()
        {
            return count;
        }

        public T[] GetData()
        {
            return obj;
        }

        public IEnumerator GetEnumerator()
        {
            return new VectorEnum<T>(this);
        }



    }
}
