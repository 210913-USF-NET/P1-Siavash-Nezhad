using System;
using System.Collections.Generic;

#nullable disable

namespace DL.Entities
{
    public partial class Order
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public DateTime DateOrder { get; set; }

        public virtual User User { get; set; }
    }
}
