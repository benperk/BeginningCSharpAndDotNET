using System;
using System.IO;
using static System.Console;

namespace StreamRead
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            try
            {
                using (FileStream aFile = new FileStream("Log.txt", FileMode.Open))
                {
                    using (StreamReader sr = new StreamReader(aFile))
                    {
                        line = sr.ReadLine();
                        // Read data in line by line.
                        while (line != null)
                        {
                            WriteLine(line);
                            line = sr.ReadLine();
                        }
                    }
                }
            }
            catch (IOException e)
            {
                WriteLine("An IO exception has been thrown!");
                WriteLine(e.ToString());
                return;
            }
        }
    }
}
