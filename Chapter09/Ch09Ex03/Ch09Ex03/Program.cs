using System;

namespace Ch09Ex03
{
    class MyClass
    {
        public int val;
    }
    struct myStruct
    {
        public int val;
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyClass objectA = new MyClass();
            MyClass objectB = objectA;
            objectA.val = 10;
            objectB.val = 20;
            myStruct structA = new myStruct();
            myStruct structB = structA;
            structA.val = 30;
            structB.val = 40;
            Console.WriteLine($"objectA.val = {objectA.val}");
            Console.WriteLine($"objectB.val = {objectB.val}");
            Console.WriteLine($"structA.val = {structA.val}");
            Console.WriteLine($"structB.val = {structB.val}");
            Console.ReadKey();
        }
    }
}
