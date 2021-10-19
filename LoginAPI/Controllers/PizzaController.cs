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
    public class PizzaController : ControllerBase
    {
        private readonly PizzaService _service;

        public PizzaController(PizzaService service)
        {
            _service = service;
        }
        // GET: api/<PizzaController>
        [HttpGet]
        public IEnumerable<PizzaDTO> Get()
        {
            var pizzas = _service.AllPizzas();
            return pizzas;
        }

        // GET api/<PizzaController>/5
        [HttpGet("{id}")]
        public PizzaDTO Get(int id)
        {
            var pizza = _service.PizzaDetail(id);
            return pizza;
        }

       
      
    }
}
