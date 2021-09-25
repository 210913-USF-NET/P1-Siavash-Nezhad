using System;
using System.Collections.Generic;

namespace Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public DateTime DateOrder { get; set; }
    }
}