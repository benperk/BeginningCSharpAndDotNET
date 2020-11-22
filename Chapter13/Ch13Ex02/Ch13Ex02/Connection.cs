using System;
using System.Timers;

namespace Ch13Ex02
{
    public delegate void MessageHandler(string messageText);
    public class Connection
    {
        public event MessageHandler MessageArrived;
        private Timer pollTimer;
        public Connection()
        {
            pollTimer = new Timer(100);
            pollTimer.Elapsed += new ElapsedEventHandler(CheckForMessage);
        }
        public void Connect() => pollTimer.Start();
        public void Disconnect() => pollTimer.Stop();
        private static Random random = new Random();
        private void CheckForMessage(object source, ElapsedEventArgs e)
        {
            Console.WriteLine("Checking for new messages.");
            if ((random.Next(9) == 0) && (MessageArrived != null))
            {
                MessageArrived("Hello Donna!");
            }
        }
    }
}
