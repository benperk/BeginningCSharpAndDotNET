using System;

namespace Ch13Ex05
{
    class Program
    {
        static void Main(string[] args)
        {
            var animals = new[]
           {
              new {  Name = "Benjamin",  Age = 49,  Weight = 185 },
              new { Name  = "Benjamin",  Age = 49,  Weight = 185 },
              new { Name  = "Andrea",  Age = 48,  Weight = 109 }
           };
            Console.WriteLine(animals[0].ToString());
            Console.WriteLine(animals[0].GetHashCode());
            Console.WriteLine(animals[1].GetHashCode());
            Console.WriteLine(animals[2].GetHashCode());
            Console.WriteLine(animals[0].Equals(animals[1]));
            Console.WriteLine(animals[0].Equals(animals[2]));
            Console.WriteLine(animals[0] == animals[1]);
            Console.WriteLine(animals[0] == animals[2]);
            Console.ReadKey();

        }
    }
}
