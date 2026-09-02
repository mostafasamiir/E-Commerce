using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace E_Commerce.Models
{
    public class Order
    {
       
        public  int Id { get; set; }
        public required string CustomerEmail { get; set; }
        public decimal TotalAmount { get; set; }
        public required string Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public List<OrderItem> OrderItems { get; set; }
    }
}
