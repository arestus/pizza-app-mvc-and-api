using Microsoft.AspNetCore.Mvc;
using OrderItemDetailsAPI.Models;
using OrderItemDetailsAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderItemDetailsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemDetailController : ControllerBase
    {
        private readonly OrderItemDetailService _service;

        public OrderItemDetailController(OrderItemDetailService service)
        {
            _service = service;
        }
        // GET: api/<OrderController>
        [HttpGet]
        public IEnumerable<OrderItemDetail> Get()
        {
            var orders = _service.GetAll();
            return orders;
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public OrderItemDetail Get(int id)
        {
            var order = _service.GetOrder(id);
            return order;
        }

        // POST api/<OrderController>
        [HttpPost]
        public void Post([FromBody] OrderItemDetail order)
        {
            _service.PostOrder(order);
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] OrderItemDetail order)
        {
            _service.PutOrder(id, order);
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.RemoveOrder(id);
        }
    }
}
