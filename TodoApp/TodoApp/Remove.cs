using System;
using System.Collections.Generic;
using System.IO;

namespace TodoApp
{
    public class Remove
    {
        public void RemoveText(string input, string inputDay)
        {
            if (input.Length < 4)
            {
                Console.WriteLine("Unable to remove: no index provided");
            }
            else
            {
                if (input.Substring(2, 1) == " " && input.Length > 3)
                {
                    bool isNumber = true;
                    for (int i = 3; i < input.Length; i++)
                    {
                        if (input.ToCharArray()[i] > 57 || input.ToCharArray()[i] < 48)
                        {
                            isNumber = false;
                            Console.WriteLine("Unable to remove: index is not an unsigned number");
                        }
                    }
                    if (isNumber)
                    {
                        int num = Int32.Parse(input.Substring(3, input.Length - 3));
                        string line;
                        List<string> list = new List<string>();
                        int i = 0;

                        using (StreamReader file = new StreamReader(inputDay))
                        {
                            while ((line = file.ReadLine()) != null)
                            {
                                if (line.Length > 0)
                                {
                                    i++;
                                    if (num != i)
                                    {
                                        list.Add(line);
                                    }
                                    else if (line.Substring(0, 3) == "[ ]")
                                    {
                                        Console.WriteLine("Unable to remove: task is not done yet");
                                        return;
                                    }
                                }
                            }
                            if (i == 0)
                            {
                                Console.WriteLine("No removable content");
                                return;
                            }
                            if (i < num)
                            {
                                Console.WriteLine("Unable to remove: index is out of bound");
                                return;
                            }
                        }

                        using (StreamWriter fileOut = new StreamWriter(inputDay))
                        {
                            for (i = 0; i < list.Count; i++)
                            {
                                fileOut.WriteLine(list[i]);
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Unable to remove: no index provided");
                }
            }
        }
    }
}
