using System;

namespace OverflowCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = Convert.ToDouble("Number");

            byte destinationVar;
            short sourceVar = 281;
            destinationVar = checked((byte)sourceVar);
            //destinationVar = unchecked((byte)sourceVar);
            Console.WriteLine($"sourceVar val: {sourceVar}");
            Console.WriteLine($"destinationVar val: {destinationVar}");
        }
    }
}

