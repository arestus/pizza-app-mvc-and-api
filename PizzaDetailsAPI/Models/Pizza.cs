using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDetailsAPI.Models
{
    public class Pizza
    {
        [Key]
        public int PizzaID { get; set; }
        public string PizzaName { get; set; }

        public string PizzaType { get; set; }
        public int PizzaPrice { get; set; }
    }
}
