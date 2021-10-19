using Microsoft.AspNetCore.Mvc;
using PizzaDetailsAPI.Models;
using PizzaDetailsAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PizzaDetailsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly PizzaService _service;

        public PizzaController(PizzaService service)
        {
            _service = service;
        }
        [HttpGet]
        public IEnumerable<Pizza> Get()
        {
            var pizzas = _service.AllPizzas();
            return pizzas;
        }

        // GET api/<PizzaController>/5
        [HttpGet("{id}")]
        public Pizza Get(int id)
        {
            var pizza = _service.GetPizza(id);
            return pizza;
        }

       
    }
}
