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
    public class ToppingController : ControllerBase
    {
        private readonly ToppingService _service;

        public ToppingController(ToppingService service)
        {
            _service = service;
        }
        // GET: api/<PizzaController>
        [HttpGet]
        public IEnumerable<ToppingDTO> Get()
        {
            var toppings = _service.AllToppings();
            return toppings;
        }

        // GET api/<PizzaController>/5
        [HttpGet("{id}")]
        public ToppingDTO Get(int id)
        {
            var topping = _service.GetTopping(id);
            return topping;
        }

    }
}
