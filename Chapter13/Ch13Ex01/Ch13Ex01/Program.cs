using System;
using System.Timers;

namespace Ch13Ex01
{
    class Program
    {
        static int counter = 0;

        static string displayString =
                             "This string will appear one letter at a time. ";
        static void Main(string[] args)
        {
            Timer myTimer = new Timer(100);
            myTimer.Elapsed += new ElapsedEventHandler(WriteChar);
            myTimer.Start();
            System.Threading.Thread.Sleep(200);
            Console.ReadKey();
        }
        static void WriteChar(object source, ElapsedEventArgs e)
        {
            Console.Write(displayString[counter++ % displayString.Length]);
        }
    }
}
