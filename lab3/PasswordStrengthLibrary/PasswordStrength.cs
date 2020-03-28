using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordStrengthLibrary
{
    public class PasswordStrength
    {
        private bool IsUpperCase(char ch)
        {
            return 'A' <= ch && ch <= 'Z';
        }

        private bool IsLowerCase(char ch)
        {
            return 'a' <= ch && ch <= 'z';
        }

        public int GetSafetyByLength(string line)
        {
            return line.Length * 4;
        }

        public int GetSafetyByDigitsCount(string line)
        {
            return line.Count(char.IsDigit);
        }

        public int GetSafetyByUpperCaseChars(string line)
        {
            int countUpperCase = line.Count(IsUpperCase);
            if (countUpperCase != 0)
            {
                return (line.Length - countUpperCase) * 2;
            }
            return 0;
        }

        public int GetSafetyByLowerCaseChars(string line)
        {
            int countLowerCase = line.Count(IsLowerCase);
            if (countLowerCase != 0)
            {
                return (line.Length - countLowerCase) * 2;
            }
            return 0;
        }

        public int GetSafetyByContainsOnlyLetters(string line)
        {
            int lettersCount = line.Count(char.IsLetter);
            if (lettersCount == line.Length)
            {
                return -line.Length;
            }
            return 0;
        }

        public int GetSafetyByContainsOnlyDigits(string line)
        {
            int digitsCount = line.Count(char.IsDigit);
            if (digitsCount == line.Length)
            {
                return -line.Length;
            }
            return 0;
        }

        public int GetSafetyByRepeateChars(string line)
        {
            int safety = 0;
            Dictionary<char, int> frequency = new Dictionary<char, int>();
            foreach (char ch in line)
            {
                if (!frequency.ContainsKey(ch))
                {
                    frequency[ch] = 1;
                }
                else
                {
                    frequency[ch]++;
                }
            }
            foreach (var item in frequency)
            {
                if (item.Value > 1)
                {
                    safety -= item.Value;
                }
            }
            return safety;
        }

        public int CalcSafety(string password)
        {
            int safety = 0;
            safety += GetSafetyByLength(password);
            safety += GetSafetyByDigitsCount(password);
            safety += GetSafetyByUpperCaseChars(password);
            safety += GetSafetyByLowerCaseChars(password);
            safety += GetSafetyByContainsOnlyLetters(password);
            safety += GetSafetyByContainsOnlyDigits(password);
            safety += GetSafetyByRepeateChars(password);
            return safety;
        }
    }
}
