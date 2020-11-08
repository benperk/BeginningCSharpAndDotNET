using System;
using System.Collections;

namespace SimpleIterators
{
    class Program
    {
        public static IEnumerable SimpleList()
        {
            yield return "string 1";
            yield return "string 2";
            yield return "string 3";
        }
        static void Main(string[] args)
        {
            foreach (string item in SimpleList())
                Console.WriteLine(item);
            Console.ReadKey();
        }
    }
}
