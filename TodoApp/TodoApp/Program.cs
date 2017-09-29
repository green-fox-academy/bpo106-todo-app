using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp
{
    class Program
    {
        static void Inform()
        {
            Console.WriteLine("Command Line Todo application\n=============================\n\nCommand line arguments:\n -l   Lists all the tasks\n -a   Adds a new task\n -r   Removes a task\n -c   Completes a task");
        }

        static void Unsupported()
        {
            Console.WriteLine("Unsupported argument\nCommand line arguments:\n -l   Lists all the tasks\n -a   Adds a new task\n -r   Removes a task\n -c   Completes a task");
        }

        static void Main(string[] args)
        {
            Inform();
            string input;
            Read read = new Read();
            Add add = new Add();
            Remove remove = new Remove();
            Check check = new Check();
            while (true)
            {
                input = Console.ReadLine();

                if (input.Length == 0)
                {
                    Console.ReadLine();
                }
                else if (input.Length == 1)
                {
                    Unsupported();
                }
                else
                {
                    if (input.Substring(0, 2) == "-l")
                    {
                        if (input.Length == 2)
                        {
                            read.ReadText();
                        }
                        else
                        {
                            Unsupported();
                        }
                    }
                    else if (input.Substring(0, 2) == "-a")
                    {
                        add.AddText(input);
                    }
                    else if (input.Substring(0, 2) == "-r")
                    {
                        remove.RemoveText(input);
                    }
                    else if (input.Substring(0, 2) == "-c")
                    {
                        check.CheckText(input);
                    }
                    else
                    {
                        Unsupported();
                    }
                }
            }
        }
    }
}
