using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveExtraBlanksLibrary
{
    enum State
    {
        SpaceTab,
        Other
    };

    public class StringProcessor
    {
        private bool isWhitespace(char ch)
        {
            return ch == '\t' || ch == ' ';
        }

        public string RemoveExtraBlanks(string input)
        {
            string cleared = input.Trim(new char[] { ' ', '\t' });
            string line = "";
            State state = State.Other;
            for (int i = 0; i < cleared.Length; i++)
            {
                char ch = cleared[i];
                Console.WriteLine(ch);
                switch (state)
                {
                    case State.Other:
                        line += ch;
                        if (isWhitespace(ch))
                        {
                            state = State.SpaceTab;
                        }
                        break;
                    case State.SpaceTab:
                        if (!isWhitespace(ch))
                        {
                            line += ch;
                            state = State.Other;
                        }
                        break;
                }
            }
            return line;
        }
    }
}
