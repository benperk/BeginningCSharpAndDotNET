using System;

namespace Ch13Ex04
{
    class Program
    {
        static void Main(string[] args)
        {
            Farm<Animal> farm = new Farm<Animal>
           {
              new Cow { Name="Lea" },
              new Chicken { Name="Noa" },
              new Chicken(),
              new SuperCow { Name="Andrea" }
           };
            farm.MakeNoises();
            Console.ReadKey();
        }
    }
}
