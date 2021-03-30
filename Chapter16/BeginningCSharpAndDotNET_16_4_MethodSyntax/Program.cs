using System;
using System.Linq;
using static System.Console;

namespace BeginningCSharpAndDotNET_16_4_MethodSyntax
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "Alonso", "Zheng", "Smith", "Jones", "Smythe", "Small", "Rodriguez", "Hsieh", "Jorgenson", "Ilyich", "Singh", "Samba", "Fatimah" };

            var queryResults = names.Where(n => n.StartsWith("S"));

            WriteLine("Names beginning with S:");
            foreach (var item in queryResults)
            {
                WriteLine(item);
            }

            Write("Program finished, press Enter/Return to continue:");

        }
    }
}
