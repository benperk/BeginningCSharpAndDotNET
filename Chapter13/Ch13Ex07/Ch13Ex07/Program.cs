using System;
using System.Collections.Generic;

namespace Ch13Ex07
{
    class Program
    {
        static void Main(string[] args)
        {
            string sentence = "his gaze against the sweeping bars has grown so weary";
            List<string> words;
            words = WordProcessor.GetWords(sentence);
            Console.WriteLine("Original sentence:");
            foreach (string word in words)
            {
                Console.Write(word);
                Console.Write(' ');
            }
            Console.WriteLine('\n');
            words = WordProcessor.GetWords(
               sentence,
               reverseWords: true,
               capitalizeWords: true);
            Console.WriteLine("Capitalized sentence with reversed words:");
            foreach (string word in words)
            {
                Console.Write(word);
                Console.Write(' ');
            }
            Console.ReadKey();
        }
    }
}
