using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PbPart3
{
    public class Loto
    {
        public static long CalculateOdds(long numbersToBeGuessed, long totalNumbers)
        {
            long numarator = CalculateNumerator(totalNumbers, numbersToBeGuessed);

            long odds = numarator / CalculatePermutations(numbersToBeGuessed);

            return odds;
        }

        public static long CalculatePermutations(long n)
        {
            long permutation = 1;
            for (long i = 1; i <= n; i++)
            {
                permutation = permutation * i;
            }
            return permutation;
        }

        public static long CalculateNumerator(long n, long k)
        {
            long numarator=1;
            
            for ( long i = k - 1 ; i >=0 ; i--)
            {
                numarator = numarator * (n - i);
            }

            return numarator;
        }

    }
}
