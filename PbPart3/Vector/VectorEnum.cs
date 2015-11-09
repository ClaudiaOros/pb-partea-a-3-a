using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    public class VectorEnum: IEnumerator
    {
        private VectorPb vectorEnum;
        private int position = -1;

        public VectorEnum(VectorPb vector)
        {
            this.vectorEnum = vector;
        }

       public  bool MoveNext()
        {
            position++;
           return (position < vectorEnum.count);
        }

       public void Reset()
       {
           position = -1;
       }

       public object Current
       {
           get { return vectorEnum.obj[position]; }
       }

    }
}
