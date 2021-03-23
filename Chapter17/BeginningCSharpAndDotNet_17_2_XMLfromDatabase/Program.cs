using System;
using System.Linq;
using System.Xml.Linq;
using static System.Console;

namespace BeginningCSharpAndDotNet_17_2_XMLfromDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BooksContext())
            {
                var query = from store in db.Stores
                            orderby store.Name
                            select store;
                foreach (var s in query)
                {
                    XElement storeElement = new XElement("store",
                        new XAttribute("name", s.Name),
                        new XAttribute("address", s.Address),
                        from stock in s.Stocks
                        select new XElement("stock",
                              new XAttribute("StockID", stock.StockId),
                              new XAttribute("onHand",
                               stock.OnHand),
                              new XAttribute("onOrder",
                               stock.OnOrder),
                       new XElement("book",
                       new XAttribute("title",
                           stock.ItemCodeNavigation.Title),
                       new XAttribute("author",
                           stock.ItemCodeNavigation.Author)
                       )// end book
                     ) // end stock
                   ); // end store
                    WriteLine(storeElement);
                }
                Write("Program finished, press Enter/Return to continue:");
                ReadLine();
            }

        }
    }
}
