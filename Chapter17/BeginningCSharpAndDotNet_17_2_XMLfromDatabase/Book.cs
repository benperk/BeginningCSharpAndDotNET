using System;
using System.Collections.Generic;

#nullable disable

namespace BeginningCSharpAndDotNet_17_2_XMLfromDatabase
{
    public partial class Book
    {
        public Book()
        {
            Stocks = new HashSet<Stock>();
        }

        public int Code { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }

        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
