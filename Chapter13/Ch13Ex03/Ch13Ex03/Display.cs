using System;
using System.Collections.Generic;
using System.Text;

namespace Ch13Ex03
{
    public class Display
    {
        public void DisplayMessage(object source, MessageArrivedEventArgs e)
        {
            Console.WriteLine($"Message arrived from: {((Connection)source).Name}");
            Console.WriteLine($"Message Text: {e.Message}");
        }
    }
}
