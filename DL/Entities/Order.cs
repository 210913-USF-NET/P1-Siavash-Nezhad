using System;
using System.Collections.Generic;

#nullable disable

namespace DL.Entities
{
    public partial class Order
    {
        public Order()
        {
            LineItems = new HashSet<LineItem>();
        }

        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime DateOrder { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<LineItem> LineItems { get; set; }
    }
}
