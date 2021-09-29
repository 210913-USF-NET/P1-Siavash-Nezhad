namespace Models
{
    public class Inventory
    {
        public int InventoryID { get; set;}
        public int StoreID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }

        public Product Product {get; set;}

        public override string ToString()
        {
            return $"Inventory ID: {this.InventoryID}, Product ID: {this.ProductID}, Quantity: {this.Quantity}";
            
        }
    }

}