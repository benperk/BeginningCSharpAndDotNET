using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace SerializeJSON
{
    public class Book
    {
        public string title { get; set; }
        public string author { get; set; }
        public string code { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Book> books = new List<Book>();
            Book book1 = new Book { 
                title = "Beginning C# and .NET", 
                author = "Benjamin Perkins and Jon Reid", 
                code = "978-1119795780" 
            };
            Book book2 = new Book { 
                title = "Beginning XML", 
                author = "Joe Fawcett et al", 
                code = "978-1118162132" 
            };
            Book book3 = new Book { 
                title = "Professional C# 7 and .NET Core", 
                author = "Christian Nagel", 
                code = "978-1119449270" 
            };

            books.Add(book1);
            books.Add(book2);
            books.Add(book3);

            string jsonString1 = JsonSerializer.Serialize(books, typeof(List<Book>));
            File.WriteAllText("Books.json", jsonString1);

            string jsonString2 = File.ReadAllText("Books.json");
            List<Book> books2 = JsonSerializer.Deserialize<List<Book>>(jsonString2);
            foreach (Book b in books2)
            {
                Console.WriteLine("code: {0} title: {1} author: {2}", b.code, b.title, b.author);
            }

            Console.ReadKey();
        }
    }
}
