using System;
using System.Collections.Generic;

#nullable disable

namespace OrderItemDetailsAPI.Models
{
    public partial class OrderDetail
    {
        public OrderDetail()
        {
            OrderItemDetails = new HashSet<OrderItemDetail>();
        }

        public int ItemId { get; set; }
        public int? OrderId { get; set; }
        public int? PizzaId { get; set; }

        public virtual ICollection<OrderItemDetail> OrderItemDetails { get; set; }
    }
}
