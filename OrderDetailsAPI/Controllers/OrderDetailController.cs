using Microsoft.AspNetCore.Mvc;
using OrderDetailsAPI.Models;
using OrderDetailsAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderDetailsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly OrderDetailService _service;

        public OrderDetailController(OrderDetailService service)
        {
            _service = service;
        }
        // GET: api/<OrderController>
        [HttpGet]
        public IEnumerable<OrderDetail> Get()
        {
            var orders = _service.GetAll();
            return orders;
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public OrderDetail Get(int id)
        {
            var order = _service.GetOrder(id);
            return order;
        }

        // POST api/<OrderController>
        [HttpPost]
        public OrderDetail Post([FromBody] OrderDetail order)
        {
            var neworder = _service.PostOrder(order);
            return neworder;
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] OrderDetail order)
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
