using System;
using System.IO;

namespace TodoApp
{
    public class Add
    {
        public void AddText(string input, string inputDay)
        {
            if (input.Length < 5)
            {
                Console.WriteLine("Unable to add: no task provided");
            }
            else if (input.Length == 5)
            {
                Console.WriteLine("Empty task added");
            }
            else
            {
                if (input.Substring(2, 2) == " \"" && input.Substring(input.Length - 1, 1) == "\"")
                {
                    using (StreamWriter file = File.AppendText(inputDay))
                    {
                        string line = "[ ] " + input.Substring(4, input.Length - 5);
                        file.WriteLine(line);
                    }
                }
                else
                {
                    Console.WriteLine("Unable to add: no task provided");
                }
            }
        }
    }
}
