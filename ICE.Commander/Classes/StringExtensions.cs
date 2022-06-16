using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICE.Commander
{
    public static class StringExtensions
    {
        public static string ToLowerFirst(this string str)
        {
            if (string.IsNullOrEmpty(str) || char.IsLower(str[0]))
                return str;

            return char.ToLower(str[0]) + str.Substring(1);
        }
        public static string ToUpperFirst(this string str)
        {
            if (string.IsNullOrEmpty(str) || char.IsUpper(str[0]))
                return str;

            return char.ToUpper(str[0]) + str.Substring(1);
        }
        public static string FirstUpper(this string st)
        {
            if (!string.IsNullOrEmpty(st) && st.Length > 2)
            {
                var temp = st.Substring(0, 1).ToUpper();
                return temp + st.Substring(1);
            }
            else
                return st;
        }
    }
}
