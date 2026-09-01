using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace E_Commerce.Models
{
    public class Order
    {
       
        public required int Id;
        public required string CustomerEmail;
        public decimal TotalAmount;
        public required string Status;
        public DateTime CreatedAt;

        public List<OrderItem> OrderItems { get; set; }
    }
}
