using System;

namespace Ch05Ex04
{
    class Program
    {        
        static void Main(string[] args)
        {
            string[] friendNames = { "Todd Anthony", "Mary Chris",
                                     "Autry Rual" };
            int i;
            Console.WriteLine($"Here are {friendNames.Length} of my friends:");
            for (i = 0; i < friendNames.Length; i++)
            {
                Console.WriteLine(friendNames[i]);
            }
            Console.ReadKey();
        }
    }
}
