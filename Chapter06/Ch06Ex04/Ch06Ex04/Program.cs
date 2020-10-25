using System;

namespace Ch06Ex04
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"{args.Length} command line arguments were specified:");
            foreach (string arg in args)
                Console.WriteLine(arg);
            Console.ReadKey();
        }
    }
}
