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
    public class OrderItemDetailController : ControllerBase
    {
        private readonly OrderItemDetailService _service;

        public OrderItemDetailController(OrderItemDetailService service)
        {
            _service = service;
        }
        // GET: api/<ItemDetailController>
        [HttpGet]
        public IEnumerable<OrderItemDetailDTO> Get()
        {
            return _service.AllOrder();
        }

        // GET api/<ItemDetailController>/5
        [HttpGet("{id}")]
        public OrderItemDetailDTO Get(int id)
        {
            return _service.GetOrder(id);
        }

        // POST api/<ItemDetailController>
        [HttpPost]
        public void Post([FromBody] OrderItemDetailDTO orderDetailDTO)
        {
            _service.AddOrder(orderDetailDTO);
        }

        // PUT api/<ItemDetailController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] OrderItemDetailDTO orderDetailDTO)
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
