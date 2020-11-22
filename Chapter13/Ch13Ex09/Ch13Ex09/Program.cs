using System;
using System.Linq;

namespace Ch13Ex09
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] people = { "Donna", "Mary", "Lea" };
            Console.WriteLine(people.Aggregate(
               (a, b) => a + " " + b));
            Console.WriteLine(people.Aggregate<string, int>(
               0,
               (a, b) => a + b.Length));
            Console.WriteLine(people.Aggregate<string, string, string>(
               "Some people:",
               (a, b) => a + " " + b,
               a => a));
            Console.WriteLine(people.Aggregate<string, string, int>(
               "Some people:",
               (a, b) => a + " " + b,
               a => a.Length));
            Console.ReadKey();
        }
    }
}
