using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{  

    public class VectorPb  //: IEnumerable, IEnumerator
    {

        public int count;
        public object[] obj;

        public VectorPb (object[] obj, int count)
        {
            this.count = count;
            this.obj = obj;
        }

            public object[] Add(object element)
            {
                if (count % 8 == 0)
                {
                    var obj2 = new object[count*2];
                    
                    for (int i = 0 ; i< count; i++)
                    {
                        obj2[i] = obj[i];
                    }
                    obj2[count] = element;
                    return obj2;
                }
                else 
                {              
                    obj[count] = element;
                    return obj;
                }                
            }

            public object[] Insert(int position, object element)
            {

                if (obj[position] == null)
                {
                    obj[position] = element;
                    return obj;
                }
                else
                {
                    if (count % 8 == 0)
                    {
                        return ResizeArrayAndInsertAnElement(position, element);
                    }
                    else
                    {
                        for (int i = count - 1; i >= position; i--)
                        {
                            obj[i + 1] = obj[i];
                        }

                        obj[position] = element;
                        return obj;
                    }
                }
            }

            private object[] ResizeArrayAndInsertAnElement(int position, object element)
            {
                var obj2 = new object[count * 2];

                CopyElementsUntillPosition(position, obj2);

                obj2[position] = element;

                CopyElementsFromPosition(position, obj2);

                return obj2;
            }

            private void CopyElementsFromPosition(int position, object[] obj2)
            {
                for (int i = position + 1; i <= count; i++)
                {
                    obj2[i] = obj[i - 1];
                }
            }

            private void CopyElementsFromPosition2(int position, object[] obj2)
            {
                for (int i = position; i < count-1; i++)
                {
                    obj2[i] = obj[i+1];
                }
            }

            private void CopyElementsUntillPosition(int position, object[] obj2)
            {
                for (int i = 0; i < position; i++)
                {
                    obj2[i] = obj[i];
                }
            }      

            public object[] Remove(object element)
            {           
                int position=0;

                position = FindElementChangeValueAndReturnPosition(element, position);

                if (count % 8 == 1)
                {
                    var obj2 = new object[count-1];

                    CopyElementsUntillPosition(position, obj2);

                    CopyElementsFromPosition2(position, obj2);

                    return obj2;
                }
                else
                {                 
                    MoveElementsToRightOneStepStartingWithAPosition(position);

                    return obj;
                }
            }

            private int FindElementChangeValueAndReturnPosition(object element, int position)
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

            public object[] Remove(int index)
            {
                return obj;
            }

            private bool MoveNext()
            {
                return true;
            }

            private void Reset()
            {

            }
        
    }
}
