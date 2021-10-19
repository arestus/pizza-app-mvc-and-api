using Microsoft.AspNetCore.Mvc;
using OrdersAPI.Models;
using OrdersAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrdersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _service;

        public OrderController(OrderService service)
        {
            _service = service;
        }
        // GET: api/<OrderController>
        [HttpGet]
        public IEnumerable<Order> Get()
        {
            var orders = _service.GetAll();
            return orders;
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public Order Get(int id)
        {
            var order = _service.GetOrder(id);
            return order;
        }

        // POST api/<OrderController>
        [HttpPost]
        public Order Post([FromBody] Order order)
        {
            var neworder = _service.PostOrder(order);
            return neworder;
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public Order Put(int id, [FromBody] Order order)
        {
            var neworder = _service.PutOrder(id, order);
            return neworder;
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.RemoveOrder(id);
        }
    }
}
