using System;
using System.Collections.Generic;

namespace Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public List<LineItem> LineItems { get; set; }
        public List<Product> Products { get; set; }
        public decimal Total { get; set; }
        public DateTime Date { get; set; }
    }
}