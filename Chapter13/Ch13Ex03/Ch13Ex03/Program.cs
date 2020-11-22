using System;

namespace Ch13Ex03
{
    class Program
    {
        static void Main(string[] args)
        {
            Connection myConnection1 = new Connection();
            myConnection1.Name = "First connection.";
            Connection myConnection2 = new Connection();
            myConnection2.Name = "Second connection.";
            Display myDisplay = new Display();
            myConnection1.MessageArrived += myDisplay.DisplayMessage;
            myConnection2.MessageArrived += myDisplay.DisplayMessage;
            myConnection1.Connect();
            myConnection2.Connect();
            System.Threading.Thread.Sleep(200);
            Console.ReadKey();
        }
    }
}
