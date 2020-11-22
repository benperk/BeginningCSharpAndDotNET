using System;
using System.Collections.Generic;
using System.Text;

namespace Ch13Ex04
{
    public class Chicken : Animal
    {
        public void LayEgg() => Console.WriteLine($"{name} has laid an egg.");
        //public Chicken(string newName) : base(newName) { }
        public override void MakeANoise()
        {
            Console.WriteLine($"{name} says 'cluck!';");
        }
    }
}
