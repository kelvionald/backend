using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Translator.Data.Models
{
    public class Dictionary
    {
        public string path { get; set; }
        public Dictionary(string path)
        {
            this.path = path;
        }
        public string Find(string wordFrom)
        {
            wordFrom = wordFrom.ToLower();
            using (StreamReader sr = new StreamReader(path))
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
                        return parts[1];
                    }
                }
            }
            return null;
        }
    }
}
