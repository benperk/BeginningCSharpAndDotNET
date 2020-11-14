using System;
using System.Collections.Generic;
using System.Text;

namespace Ch12Ex02
{
    public class Cow : Animal
    {
        public void Milk() => Console.WriteLine($"{name} has been milked.");
        public Cow(string newName) : base(newName) { }
    }
}
