using System;

namespace Ch05Ex05
{
    class Program
    {        
        static void Main(string[] args)
        {
            string[] friendNames = { "Todd Anthony", "Mary Chris",
                           "Autry Rual", null, "" };
            foreach (var friendName in friendNames)
            {
                switch (friendName)
                {
                    case string t when t.StartsWith("T"):
                        Console.WriteLine("This friends name starts with a 'T': " +
                          $"{friendName} and is {t.Length - 1} letters long ");
                        break;
                    case string e when e.Length == 0:
                        Console.WriteLine("There is a string in the array with no value");
                        break;
                    case null:
                        Console.WriteLine("There was a 'null' value in the array");
                        break;
                    case var x:
                        Console.WriteLine("This is the var pattern of type: " +
                                  $"{x.GetType().Name}");
                        break;
                    default:
                        break;
                }
            }

            int sum = 0, total = 0, counter = 0, intValue = 0;
            int?[] myIntArray = new int?[7] { 5, intValue, 9, 10, null, 2, 99 };
            foreach (var integer in myIntArray)
            {
                switch (integer)
                {
                    case 0:
                        Console.WriteLine($"Integer number '{ counter }' has a default value of 0");
                        counter++;
                        break;
                    case int value:
                        sum += value;
                        Console.WriteLine($"Integer number '{ counter }' has a value of {value}");
                        counter++;
                        break;
                    case null:
                        Console.WriteLine($"Integer number '{ counter }' is null");
                        counter++;
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine($"The sum of all {counter} is {sum}");
            Console.ReadLine();
        }
    }
}
