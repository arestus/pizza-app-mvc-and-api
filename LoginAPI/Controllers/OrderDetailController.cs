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
    public class OrderDetailController : ControllerBase
    {
        private readonly OrderDetailService _service;

        public OrderDetailController(OrderDetailService service)
        {
            _service = service;
        }
        // GET: api/<ItemDetailController>
        [HttpGet]
        public IEnumerable<OrderDetailDTO> Get()
        {
            var orders = _service.AllOrder();
            return orders;
        }

        // GET api/<ItemDetailController>/5
        [HttpGet("{id}")]
        public OrderDetailDTO Get(int id)
        {
            var order = _service.GetOrder(id);
            return order;
        }

        // POST api/<ItemDetailController>
        [HttpPost]
        public OrderDetailDTO Post([FromBody] OrderDetailDTO orderDetailDTO)
        {
           var order =  _service.AddOrder(orderDetailDTO);
            return order;
        }

        // PUT api/<ItemDetailController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] OrderDetailDTO orderDetailDTO)
        {
            _service.EditOrder(id, orderDetailDTO);
        }

        // DELETE api/<ItemDetailController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
