using System;

namespace TodoApp
{
    class Program
    {
        static string dayToChoose;
        static Read read = new Read();
        static Add add = new Add();
        static Remove remove = new Remove();
        static Check check = new Check();
        static EasterEggs easteregg = new EasterEggs();

        static void Inform()
        {
            Console.WriteLine("Command Line Todo application\n=============================\n\nCommand line arguments:\n -l   Lists all the tasks\n -a   Adds a new task\n -r   Removes a task\n -c   Completes a task");
        }

        static void DayChoose()
        {
            Console.Write("Today: ");
            string input = Console.ReadLine();
            if (input == "Monday" || input == "monday")
            {
                dayToChoose = "monday.txt";
            }
            else if (input == "Tuesday" || input == "tuesday")
            {
                dayToChoose = "tuesday.txt";
            }
            else if (input == "Wednesday" || input == "wednesday")
            {
                dayToChoose = "wednesday.txt";
            }
            else if (input == "Thursday" || input == "thursday")
            {
                dayToChoose = "thursday.txt";
            }
            else if (input == "Friday" || input == "friday")
            {
                dayToChoose = "friday.txt";
            }
            else
            {
                Console.WriteLine("Not a valid weekday");
            }

        }

        static void Unsupported()
        {
            Console.WriteLine("Unsupported argument\nCommand line arguments:\n -l   Lists all the tasks\n -a   Adds a new task\n -r   Removes a task\n -c   Completes a task");
        }

        static void Main(string[] args)
        {
            Inform();
            string input;
            bool hasBeenDoneYet = false;

            DayChoose();
            while (dayToChoose == "invalid")
            {
                DayChoose();
            }

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
                            read.ReadText(dayToChoose);
                        }
                        else
                        {
                            Unsupported();
                        }
                    }
                    else if (input.Substring(0, 2) == "-a")
                    {
                        add.AddText(input, dayToChoose);
                    }
                    else if (input.Substring(0, 2) == "-r")
                    {
                        remove.RemoveText(input, dayToChoose);
                    }
                    else if (input.Substring(0, 2) == "-c")
                    {
                        check.CheckText(input, dayToChoose);
                    }
                    else if (dayToChoose != "friday.txt" || hasBeenDoneYet == true)
                    {
                        Unsupported();
                    }
                }

                hasBeenDoneYet = easteregg.EasterEggWednesday(input, dayToChoose, hasBeenDoneYet);
                hasBeenDoneYet = easteregg.EasterEggFriday(input, dayToChoose, hasBeenDoneYet);
            }
        }
    }
}
