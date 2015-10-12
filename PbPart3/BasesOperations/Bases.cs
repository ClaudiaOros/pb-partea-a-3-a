using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasesOperations
{
    public class Bases
    {
        public static byte[] ConvertADecimalNumberIntoAnotherBase(int decimalNumber, int baseNumber)
        {
            byte[] convertedNumber;
            int i = 0;

            while (decimalNumber > 0)
            {
                var modulo = decimalNumber % baseNumber;
                convertedNumber[i] = (byte)modulo;
                i++;
            }

            return convertedNumber;
        }
    }
}
