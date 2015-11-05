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
                
                return obj;
            }

            public object[] Remove(object element)
            {

                return obj;
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
