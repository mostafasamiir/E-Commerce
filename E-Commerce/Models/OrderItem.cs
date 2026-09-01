namespace E_Commerce.Models
{
    public class OrderItem
    {
        public int Id;
        public required string ProductName;
        public int Quantity;
        public decimal Price;
        public int OrderId;
    }
}
