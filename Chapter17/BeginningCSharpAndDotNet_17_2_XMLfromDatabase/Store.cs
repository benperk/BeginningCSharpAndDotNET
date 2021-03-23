using System;
using System.Collections.Generic;

#nullable disable

namespace BeginningCSharpAndDotNet_17_2_XMLfromDatabase
{
    public partial class Store
    {
        public Store()
        {
            Stocks = new HashSet<Stock>();
        }

        public int StoreId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
