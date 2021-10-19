using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToppingDetailsAPI.Models;
using ToppingDetailsAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToppingDetailsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToppingController : ControllerBase
    {
        private readonly ToppingService _service;

        public ToppingController(ToppingService service)
        {
            _service = service;
        }
        // GET: api/<ToppingController>
        [HttpGet]
        public IEnumerable<Topping> Get()
        {
            var toppings = _service.AllToppings();
            return toppings;
        }

        // GET api/<ToppingController>/5
        [HttpGet("{id}")]
        public Topping Get(int id)
        {
            var topping = _service.GetTopping(id);
            return topping;
        }

        
    }
}
