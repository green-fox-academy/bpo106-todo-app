using System;
using System.IO;

namespace TodoApp
{
    public class Read
    {
        public void ReadText(string inputDay)
        {
            string line;
            int i = 0;
            StreamReader file = new StreamReader(inputDay);

            while ((line = file.ReadLine()) != null)
            {
                if (line.Length > 0)
                {
                    i++;
                    Console.WriteLine(i + " - " + line);
                }
            }
            if (i == 0)
            {
                Console.WriteLine("No todos for today! :)");
            }
            file.Close();
        }
    }
}
