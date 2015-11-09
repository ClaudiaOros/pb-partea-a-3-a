using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    public class VectorEnum <T> : IEnumerator
    {
        private VectorPb<T> vectorEnum;
        private int position = -1;

        public VectorEnum(VectorPb<T> vector)
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
