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

                switch (input.Length)
                {
                    case 0:
                        Console.ReadLine();
                        break;
                    case 1:
                        Unsupported();
                        break;
                    default:
                        switch (input.Substring(0, 2))
                        {
                            case "-l":
                                if (input.Length == 2)
                                {
                                    read.ReadText();
                                }
                                else
                                {
                                    Unsupported();
                                }
                                break;
                            case "-a":
                                add.AddText(input);
                                break;
                            case "-r":
                                remove.RemoveText(input);
                                break;
                            case "-c":
                                check.CheckText(input);
                                break;
                            default:
                                Unsupported();
                                break;
                        }
                        break;
                }
            }
        }
    }
}
