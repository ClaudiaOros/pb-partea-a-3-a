using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion
{
    public class Recursion
    {
        public static string ReturnTheReverseString(string s)
        {

            if ((s.Length == 1) || (String.IsNullOrEmpty(s))) return s;
            else
                return s[s.Length - 1] + ReturnTheReverseString(s.Substring(0, s.Length - 1));
        }

        public static string ReplaceACharWithAString(int index, string a, string b)
        {
            if (String.IsNullOrEmpty(a) || (a.Length == 1 && index == 1))
                return b;
            else
                if (String.IsNullOrEmpty(b) || (b.Length == 1 && index == 1))
                    return a;

        }

    }
}
