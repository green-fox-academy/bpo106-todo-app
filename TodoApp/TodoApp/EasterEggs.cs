using System;
using System.IO;

namespace TodoApp
{
    class EasterEggs
    {
        public bool EasterEggWednesday(string input, string dayToChoose, bool hasBeenPissedOnYet)
        {
            if (dayToChoose == "wednesday.txt")
            {
                string line;
                bool enable = false;
                using (StreamReader file = new StreamReader(dayToChoose))
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        if (line.Length > 0)
                        {
                            if (line == "[X] Piss on Dad" && hasBeenPissedOnYet == false)
                            {
                                hasBeenPissedOnYet = true;
                                Console.WriteLine("The Rednecks captured you, stole your clothes and tried to make you their slave.\nNew task: pick up a new stock of clothes from the laundry.");
                                enable = true;
                            }
                        }
                    }
                }
                if (enable)
                {
                    using (StreamWriter file = File.AppendText(dayToChoose))
                    {
                        line = "\n[ ] Pick up laundry";
                        file.WriteLine(line);
                    }
                }
            }
            return hasBeenPissedOnYet;
        }

        public bool EasterEggFriday(string input, string dayToChoose, bool hasBeenPissedYet)
        {
            if (dayToChoose == "friday.txt")
            {
                if (hasBeenPissedYet == false)
                {
                    if (input == "-p")
                    {
                        Console.WriteLine("It seems you have some nasty STD. You'd better show it to someone.\nNew task: get cured ASAP.");
                        hasBeenPissedYet = true;
                        string line;
                        using (StreamWriter file = File.AppendText(dayToChoose))
                        {
                            line = "\n[ ] Get cured";
                            file.WriteLine(line);
                        }
                    }
                    else
                    {
                        Random random = new Random();
                        int num = random.Next(0, 2);
                        if (num == 0)
                        {
                            Console.WriteLine("Why don't you try -p?");
                        }
                    }
                }

            }
            return hasBeenPissedYet;
        }
    }
}
