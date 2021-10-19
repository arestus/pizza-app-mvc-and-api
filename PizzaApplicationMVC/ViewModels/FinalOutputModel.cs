using PizzaApplicationMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaApplicationMVC.ViewModels
{
    public class FinalOutputModel
    {
        public PizzaDTO Pizza { get; set; }
        public List<ToppingDTO> Toppings { get; set; }
    }
    public class OutputList
    {
        public List<FinalOutputModel> FinalListPizzas { get; set; }
    }
}
