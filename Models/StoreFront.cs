using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class StoreFront
    {
        [Key]
        public int StoreID { get; set; }
        public string Address { get; set; }

        //might be unnecessary
        public override string ToString()
        {
            return $"StoreID: {this.StoreID} Address : {this.Address}";
        }
    }
}