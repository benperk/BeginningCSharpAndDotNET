using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using static System.Console;

namespace BeginningCSharpAndDotNet_17_1_CodeFirstDatabase
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        [Key] public int Code { get; set; }
    }
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(LocalDB)\MSSQLLocalDB;Database=Books;Integrated Security=True");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BookContext())
            {
                Book book1 = new Book
                {
                    Title = "Beginning C# and .NET",
                    Author = "Perkins, Reid"
                };
                db.Books.Add(book1);
                Book book2 = new Book
                {
                    Title = "Beginning XML",
                    Author = "Fawcett, Quin, and Ayers"
                };
                db.Books.Add(book2);
                db.SaveChanges();
                var query = from b in db.Books
                            orderby b.Title
                            select b;
                WriteLine("All books in the database:");
                foreach (var b in query)
                {
                    WriteLine($"{b.Title} by {b.Author}, code={b.Code}");
                }
                WriteLine("Press a key to exit...");
                ReadKey();
            }
        }
    }
}
