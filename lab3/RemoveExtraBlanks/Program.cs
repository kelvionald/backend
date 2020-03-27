using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RemoveExtraBlanksLibrary;

namespace RemoveExtraBlanks
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Incorrect number of arguments!");
                Console.WriteLine("Usage RemoveExtraBlanks.exe <inputFile> <outputFile>");
                return;
            }
            string inputFile = args[0];
            string outputFile = args[1];
            StringProcessor stringProcessor = new StringProcessor();
            using (StreamReader reader = new StreamReader(inputFile))
            using (StreamWriter writer = new StreamWriter(outputFile))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    line = stringProcessor.RemoveExtraBlanks(line);
                    writer.WriteLine(line);
                }
            }
        }
    }
}
