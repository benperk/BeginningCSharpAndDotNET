using System;

namespace Ch12Ex04
{
    class Program
    {
        static void Main(string[] args)
        {
            Farm<Animal> farm = new Farm<Animal>();
            farm.Animals.Add(new Cow("Lea"));
            farm.Animals.Add(new Chicken("Donna"));
            farm.Animals.Add(new Chicken("Mary"));
            farm.Animals.Add(new SuperCow("Noa"));
            farm.MakeNoises();
            Farm<Cow> dairyFarm = farm.GetCows();
            dairyFarm.FeedTheAnimals();
            foreach (Cow cow in dairyFarm)
            {
                if (cow is SuperCow)
                {
                    (cow as SuperCow).Fly();
                }
            }
            Console.ReadKey();
        }
    }
}
