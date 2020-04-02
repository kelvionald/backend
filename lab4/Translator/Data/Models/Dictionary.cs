using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Translator.Data.Models
{
    public class Dictionary
    {
        public string WordFrom { get; set; }
        public string WordTo { get; set; }
        public Dictionary(string WordFrom, string WordTo)
        {
            this.WordFrom = WordFrom;
            this.WordTo = WordTo;
        }
        public static Dictionary Find(string wordFrom)
        {
            wordFrom = wordFrom.ToLower();
            using (StreamReader sr = new StreamReader("dictionaries\\en-ru.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] parts = line.Split('|');
                    if (parts.Length != 2)
                    {
                        throw new Exception("Incorrect dictionary format.");
                    }
                    if (parts[0] == wordFrom)
                    {
                        Dictionary dictionary = new Dictionary(parts[0], parts[1]);
                        return dictionary;
                    }
                }
            }
            return null;
        }
    }
}
