using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TodoApp
{
    public class Remove
    {
        public void RemoveText(string input)
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
                            Console.WriteLine("Unable to remove: index is not a number");
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
                                if (num != i)
                                {
                                    list.Add(line);
                                }
                                else if (line.Substring(0, 3) == "[ ]")
                                {
                                    Console.WriteLine("Unable to remove: task is not done yet");
                                    file.Close();
                                    return;
                                }
                            }
                        }
                        file.Close();
                        if (i == 0)
                        {
                            Console.WriteLine("No removable content");
                            file.Close();
                            return;
                        }
                        if (i < num)
                        {
                            Console.WriteLine("Unable to remove: index is out of bound");
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
                    Console.WriteLine("Unable to remove: no index provided");
                }
            }
        }
    }
}
