using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationsOnBases
{
    public class OperationsOnBases
    {
        public static byte[] ConvertADecimalNumberIntoAnotherBase(int decimalNumber, int baseNumber)
        {
            byte[] convertedNumber = new byte[Byte.MaxValue];
            int i = 0;

            while (decimalNumber > 0)
            {
                var modulo = decimalNumber % baseNumber;
                convertedNumber[i++] = (byte)modulo;
                decimalNumber = decimalNumber / baseNumber;
            }

            Array.Resize(ref convertedNumber, i);
            Array.Reverse(convertedNumber);

            return convertedNumber;
        }

        public static byte[] OperatorNot(byte[] binaryNumber)
        {
            for (int i = 0; i < binaryNumber.Length; i++)
            {
                  if ( binaryNumber[i] == 1 )
                      binaryNumber[i] = 0;
                  else
                      binaryNumber[i] = 1;

            }

            return binaryNumber;
        }

        public static byte[] OperatorAnd(byte[] firstBinaryNumber, byte[] secondBinaryNumber)
        {

            var resultedBinary= new byte[firstBinaryNumber.Length];

            for (int i = 0; i < firstBinaryNumber.Length; i++)
            {
                if ((firstBinaryNumber[i] == 1) & (secondBinaryNumber[i] == 1))
                    resultedBinary[i] = 1;
                else
                 //   if (((firstBinaryNumber[i] == 0) & (secondBinaryNumber[i] == 0)) || ((firstBinaryNumber[i]) != (secondBinaryNumber[i])))
                        resultedBinary[i] = 0;
            }

            return resultedBinary;
        }

        public static byte[] OperatorOR(byte[] firstBinaryNumber, byte[] secondBinaryNumber)
        {

            var resultedBinary = new byte[firstBinaryNumber.Length];

            for (int i = 0; i < firstBinaryNumber.Length; i++)
            {
                if ((firstBinaryNumber[i] == 0) & (secondBinaryNumber[i] == 0))
                    resultedBinary[i] = 0;
                else
                //    if (((firstBinaryNumber[i] == 1) & (secondBinaryNumber[i] == 1)) || ((firstBinaryNumber[i]) != (secondBinaryNumber[i])))
                        resultedBinary[i] = 1;
            }

            return resultedBinary;
        }

        public static byte[] OperatorXOR(byte[] firstBinaryNumber, byte[] secondBinaryNumber)
        {

            var resultedBinary = new byte[firstBinaryNumber.Length];

            for (int i = 0; i < firstBinaryNumber.Length; i++)
            {
                if (((firstBinaryNumber[i] == 0) & (secondBinaryNumber[i] == 0)) || ((firstBinaryNumber[i] == 1) & (secondBinaryNumber[i] == 1)))
                    resultedBinary[i] = 0;
                else
               //     if ((firstBinaryNumber[i]) != (secondBinaryNumber[i]))
                        resultedBinary[i] = 1;
            }

            return resultedBinary;
        }

        public static byte[] OperatorRightHandShift(byte[] binaryNumber, int value)
        {
            var resultedBinaryNumber = new byte[binaryNumber.Length];

            for (int i = value; i < binaryNumber.Length; i++)
            {
                resultedBinaryNumber[i] = binaryNumber[i-value];
            }

                return resultedBinaryNumber;
        }

        public static byte[] OperatorLeftHandShift(byte[] binaryNumber, int value)
        {
            var resultedBinaryNumber = new byte[binaryNumber.Length];

            for (int i = 0; i < binaryNumber.Length-value; i++)
            {
                resultedBinaryNumber[i] = binaryNumber[value+i];
            }

            return resultedBinaryNumber;
        }
    }
}
