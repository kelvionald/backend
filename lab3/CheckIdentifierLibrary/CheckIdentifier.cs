using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIdentifierLibrary
{
    public class CheckIdentifier
    {
        public static bool IsIdentifier(string value)
        {
            if (value.Length == 0 || !char.IsLetter(value[0]))
            {
                return false;
            }
            for (int i = 1; i < value.Length; i++)
            {
                if (!char.IsLetterOrDigit(value[i]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
