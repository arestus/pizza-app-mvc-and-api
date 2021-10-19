using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaApplicationMVC.Models
{
    public class ToppingDTO
    {
        public int ToppingID { get; set; }
        public string ToppingName { get; set; }
        public int? ToppingPrice { get; set; }
    }
}
