namespace E_Commerce.Models
{
    public class OrderItem
    {
        public int Id { set; get; }
        public required string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int OrderId { get; set; }
    }
}
