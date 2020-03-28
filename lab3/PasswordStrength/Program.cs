using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordStrengthLibrary;

namespace PasswordStrength
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Incorrect number of arguments!");
                Console.WriteLine("Usage PasswordStrength.exe <password>");
                return;
            }
            PasswordStrengthLibrary.PasswordStrength passwordStrength = new PasswordStrengthLibrary.PasswordStrength();
            Console.WriteLine(passwordStrength.CalcSafety(args[0]));
        }
    }
}
