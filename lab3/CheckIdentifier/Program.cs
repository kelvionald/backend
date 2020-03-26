using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckIdentifierLibrary;

namespace CheckIdentifier
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Incorrect number of arguments!");
                Console.WriteLine("Usage CheckIdentifier.exe <identifier>");
                return;
            }
            CheckIdentifierLibrary.CheckIdentifier checkIdentifier = new CheckIdentifierLibrary.CheckIdentifier();
            string identifier = args[0];
            if (checkIdentifier.IsIdentifier(identifier))
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
                if (checkIdentifier.IsEmpty())
                {
                    Console.WriteLine("Input is empty");
                }
                else
                {
                    int badIndex = checkIdentifier.GetBadIndex();
                    Console.WriteLine("Bad index " + badIndex + ", bad char '" + identifier[badIndex] + "'");
                }
            }
        }
    }
}
