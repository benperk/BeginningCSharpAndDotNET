using System;
using System.Collections.Generic;

namespace VarianceDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Cow myCow = new Cow("Noa");

            IMethaneProducer<Cow> cowMethaneProducer = myCow;
            IMethaneProducer<Animal> animalMethaneProducer = cowMethaneProducer;

            IGrassMuncher<Cow> cowGrassMuncher = myCow;
            IGrassMuncher<SuperCow> superCowGrassMuncher = cowGrassMuncher;

            List<Cow> cows = new List<Cow>();
            cows.Add(myCow);
            cows.Add(new SuperCow("Lea"));
            cows.Add(new Cow("Donna"));
            cows.Add(new Cow("Mary"));

            cows.Sort(new AnimalNameLengthComparer());

            ListAnimals(cows);

            Console.ReadKey();
        }

        static void ListAnimals(IEnumerable<Animal> animals)
        {
            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal.Name);
            }
        }
    }
}
