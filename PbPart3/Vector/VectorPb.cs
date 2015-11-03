using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    public class VectorPb: IEnumerable, IEnumerator
    {
        private object Current 
        {
            get; 
        }

        private  bool MoveNext()
        {
            return true;
        }

        private void Reset()
        {
 
        }
        
    }
}
