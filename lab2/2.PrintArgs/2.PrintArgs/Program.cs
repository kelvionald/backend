using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.PrintArgs
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("No parameters were specified!");
            }
            else
            {
                Console.WriteLine("Number of arguments: {0}", args.Length);
                Console.Write("Arguments: {0}", String.Join(" ", args));
            }
        }
    }
}
