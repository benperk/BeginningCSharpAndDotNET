using System;

namespace Ch12Ex01
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector v1 = GetVector("vector1");
            Vector v2 = GetVector("vector2");
            Console.WriteLine($"{v1} + {v2} = {v1 + v2}");
            Console.WriteLine($"{v1} - { v2} = {v1 - v2}");
            Console.ReadKey();
        }
        static Vector GetVector(string name)
        {
            Console.WriteLine($"Input {name} magnitude:");
            double? r = GetNullableDouble();
            Console.WriteLine($"Input {name} angle (in degrees):");
            double? theta = GetNullableDouble();
            return new Vector(r, theta);
        }
        static double? GetNullableDouble()
        {
            double? result;
            string userInput = Console.ReadLine();
            try
            {
                result = double.Parse(userInput);
            }
            catch
            {
                result = null;
            }
            return result;
        }
    }
}
