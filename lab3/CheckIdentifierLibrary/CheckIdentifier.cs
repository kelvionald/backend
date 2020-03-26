using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIdentifierLibrary
{
    public class CheckIdentifier
    {
        private const int GOOD_INDEX = -1;
        private int badIndex = GOOD_INDEX;
        private bool isEmpty = false;

        private void resetState()
        {
            badIndex = GOOD_INDEX;
            isEmpty = false;
        }

        public bool IsEmpty()
        {
            return isEmpty;
        }

        public int GetBadIndex()
        {
            return badIndex;
        }

        public bool IsIdentifier(string value)
        {
            resetState();
            if (value.Length == 0)
            {
                isEmpty = true;
                return false;
            }
            if (!char.IsLetter(value[0]))
            {
                badIndex = 0;
                return false;
            }
            for (int i = 1; i < value.Length; i++)
            {
                if (!char.IsLetterOrDigit(value[i]))
                {
                    badIndex = i;
                    return false;
                }
            }
            return true;
        }
    }
}
