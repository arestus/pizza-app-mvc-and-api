using LoginAPI.Models;
using LoginAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoginAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _service;

        public OrderController(OrderService service)
        {
            _service = service;
        }
        // GET: api/<OrderController>
        [HttpGet]
        public IEnumerable<OrderDTO> Get()
        {
            var orders = _service.AllOrder();
            return orders ;
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public OrderDTO Get(int id)
        {
            var order = _service.GetOrder(id);
            return order;
        }

        // POST api/<OrderController>
        [HttpPost]
        public OrderDTO Post([FromBody] OrderDTO orderDTO)
        {
           var order =  _service.AddOrder(orderDTO);
            return order;
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public OrderDTO Put(int id, [FromBody] OrderDTO orderDTO)
        {
            var order = _service.EditOrder(id, orderDTO);
            return order;
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
