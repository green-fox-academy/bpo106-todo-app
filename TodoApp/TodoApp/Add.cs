using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TodoApp
{
    public class Add
    {
        public void AddText(string input)
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
                    StreamWriter file = File.AppendText("tasks.txt");
                    string line = "[ ] " + input.Substring(4, input.Length - 5);
                    file.WriteLine(line);
                    file.Close();
                }
                else
                {
                    Console.WriteLine("Unable to add: no task provided");
                }
            }
        }
    }
}
