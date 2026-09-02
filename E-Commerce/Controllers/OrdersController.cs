using E_Commerce.DTO;
using E_Commerce.Models;
using E_Commerce.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hangfire;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderServices _orderServices;
        private readonly IBackgroundJobClient _backgroundJobClient;

        public OrdersController(IOrderServices orderServices, IBackgroundJobClient backgroundJobClient)
        {
            _orderServices = orderServices;
            _backgroundJobClient = backgroundJobClient;
        }

        // GET: api/<OrdersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrderByID(int id)
        {
            var order = await _orderServices.GetById(id);

            if (order == null)
                return NotFound($"Order with ID {id} not found.");
            return Ok(order);
        }

        // POST api/<OrdersController>
        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(OrdersDto dto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var neworder = new Order
            {
                
                CustomerEmail = dto.CustomerEmail,
                TotalAmount = dto.TotalAmount,
                Status ="Pending",
                CreatedAt = DateTime.UtcNow,
                OrderItems = dto.OrderItems.Select(item => new OrderItem
                {
                    ProductName = item.ProductName,
                    Quantity = item.Quantity,
                    Price = item.Price
                }).ToList()
            };

            await _orderServices.CreateOrder(neworder);
            _backgroundJobClient.Enqueue<OrderProcessingServices>(job => job.ProcessOrder(neworder.Id));

            

            return Ok(neworder);
        }

       

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
