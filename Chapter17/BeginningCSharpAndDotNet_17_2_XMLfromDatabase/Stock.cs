using System;
using System.Collections.Generic;

#nullable disable

namespace BeginningCSharpAndDotNet_17_2_XMLfromDatabase
{
    public partial class Stock
    {
        public int StockId { get; set; }
        public int OnHand { get; set; }
        public int OnOrder { get; set; }
        public int? ItemCode { get; set; }
        public int? StoreId { get; set; }

        public virtual Book ItemCodeNavigation { get; set; }
        public virtual Store Store { get; set; }
    }
}
