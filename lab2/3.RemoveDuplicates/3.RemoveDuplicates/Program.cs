using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.RemoveDuplicates
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Incorrect number of arguments!");
                Console.WriteLine("Usage 3.RemoveDuplicates.exe <input string>");
                return;
            }
            Dictionary<char, bool> exitingChars = new Dictionary<char, bool>();
            string line = args[0];
            foreach (char ch in line)
            {
                if (!exitingChars.ContainsKey(ch))
                {
                    exitingChars[ch] = true;
                    Console.Write(ch);
                }
            }
        }
    }
}
