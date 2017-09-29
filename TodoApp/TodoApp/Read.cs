using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TodoApp
{
    public class Read
    {
        public void ReadText()
        {
            string line;
            int i = 0;
            StreamReader file = new StreamReader("tasks.txt");

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
