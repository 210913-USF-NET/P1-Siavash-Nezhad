using System.Collections.Generic;

namespace Models
{
    public class StoreFront
    {
        public int StoreID { get; set; }
        public string Address { get; set; }

        // //might be unnecessary
        // public override string ToString()
        // {
        //     return $"Store Name: {this.Name} Address : {this.Address}";
        // }
    }
}