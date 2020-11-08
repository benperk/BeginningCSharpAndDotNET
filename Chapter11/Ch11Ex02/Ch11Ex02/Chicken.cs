using System;
using System.Collections.Generic;
using System.Text;

namespace Ch11Ex02
{
    public class Chicken : Animal
    {
        public void LayEgg() => Console.WriteLine($"{name} has laid an egg.");
        public Chicken(string newName) : base(newName) { }
    }
}
