using System;

namespace Ch04Ex05
{
    class Program
    {
        static void Main(string[] args)
        {
            double balance, interestRate, targetBalance;
            Console.WriteLine("What is your current balance?");
            balance = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("What is your current annual interest rate (in %)?");
            interestRate = 1 + Convert.ToDouble(Console.ReadLine()) / 100.0;
            Console.WriteLine("What balance would you like to have?");
            //targetBalance = Convert.ToDouble(Console.ReadLine());
            int totalYears = 0;
            do
            {
                targetBalance = Convert.ToDouble(Console.ReadLine());
                if (targetBalance <= balance)
                    Console.WriteLine("You must enter an amount greater than " +
                              "your current balance!\nPlease enter another value.");
            }
            while (targetBalance <= balance);
            while (balance < targetBalance)
            {
                balance *= interestRate;
                ++totalYears;
            }
            Console.WriteLine($"In {totalYears} year{(totalYears == 1 ? "" : "s")} " +
                      $"you'll have a balance of {balance}.");
            if (totalYears == 0)
                Console.WriteLine(
                   "To be honest, you really didn't need to use this calculator.");
            Console.ReadKey();
        }
    }
}
