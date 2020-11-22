using System;
using Microsoft.CSharp.RuntimeBinder;

namespace Ch13Ex06
{
    class MyClass1
    {
        public int Add(int var1, int var2) => var1 + var2;
    }
    class MyClass2 { }
    class Program
    {
        static int callCount = 0;
        static dynamic GetValue()
        {
            if (callCount++ == 0)
            {
                return new MyClass1();
            }
            return new MyClass2();
        }
        static void Main(string[] args)
        {
            try
            {
                dynamic firstResult = GetValue();
                dynamic secondResult = GetValue();
                Console.WriteLine($"firstResult is: {firstResult.ToString()}");
                Console.WriteLine($"secondResult is: {secondResult.ToString()}");
                Console.WriteLine($"firstResult call: {firstResult.Add(2, 3)}");
                Console.WriteLine($"secondResult call: {secondResult.Add(2, 3)}");
            }
            catch (RuntimeBinderException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }

}
