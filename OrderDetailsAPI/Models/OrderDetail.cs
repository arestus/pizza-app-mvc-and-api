using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderDetailsAPI.Models
{
    public class OrderDetail
    {
        [Key]
        public int ItemId { get; set; }
        public int OrderId { get; set; }
        public int PizzaId { get; set; }
    }
}
