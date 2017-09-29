using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TodoApp
{
    public class Check
    {
        public void CheckText(string input)
        {
            if (input.Length < 4)
            {
                Console.WriteLine("Unable to check: no index provided");
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
                            Console.WriteLine("Unable to check: index is not a number");
                        }
                    }
                    if (isNumber)
                    {
                        int num = Int32.Parse(input.Substring(3, input.Length - 3));

                        string line;
                        List<string> list = new List<string>();
                        int i = 0;
                        StreamReader file = new StreamReader("tasks.txt");
                        while ((line = file.ReadLine()) != null)
                        {
                            if (line.Length > 0)
                            {
                                i++;
                                if (num == i)
                                {
                                    if (line.Substring(0, 3) == "[X]")
                                    {
                                        Console.WriteLine("Unable to check: task is already done");
                                        file.Close();
                                        return;
                                    }
                                    else
                                    {
                                        line = "[X]" + line.Substring(3, line.Length - 3);
                                    }
                                }
                                list.Add(line);
                            }
                        }
                        file.Close();
                        if (i == 0)
                        {
                            Console.WriteLine("No checkable content");
                            file.Close();
                            return;
                        }
                        if (i < num)
                        {
                            Console.WriteLine("Unable to check: index is out of bound");
                            file.Close();
                            return;
                        }
                        StreamWriter fileOut = new StreamWriter("tasks.txt");
                        for (i = 0; i < list.Count; i++)
                        {
                            fileOut.WriteLine(list[i]);
                        }
                        fileOut.Close();
                    }
                }
                else
                {
                    Console.WriteLine("Unable to check: no index provided");
                }
            }
        }
    }
}
