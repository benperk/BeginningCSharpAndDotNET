using System;

namespace LocalFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            int myNumber = 5;
            Console.WriteLine($"Main Function = {myNumber}");
            DoubleIt(myNumber);
            Console.ReadLine();

            void DoubleIt(int val)
            {
                val *= 2;
                Console.WriteLine($"Local Function - val = {val}");
            }
        }
    }
}
