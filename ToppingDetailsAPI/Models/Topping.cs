using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToppingDetailsAPI.Models
{
    public class Topping
    {
        [Key]
        public int ToppingID { get; set; }
        public string ToppingName { get; set; }

        public int ToppingPrice { get; set; }
    }
}
