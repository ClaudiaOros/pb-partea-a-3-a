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
        private VectorPb vector;
        private int position = -1;

        public VectorEnum(VectorPb vector, int position)
        {
            this.position = position;
            this.vector = vector;
        }

       public  bool MoveNext()
        {
            position++;
           return (position < vector.count);
        }

       public void Reset()
       {
           position = -1;
       }

       public object Current
       {
           get { return vector.obj[position]; }
       }

    }
}
