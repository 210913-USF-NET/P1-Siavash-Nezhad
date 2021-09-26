namespace Models
{
    public class LineItem
    {
        public int LineItemID { get; set; }
        public int OrderID { get; set; }
        public int StoreID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
    }
}