using OrderItemDetailsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderItemDetailsAPI.Services
{
    public class OrderItemDetailService
    {
        private readonly OrderItemDetailsAPIContext _context;

        public OrderItemDetailService(OrderItemDetailsAPIContext context)
        {
            _context = context;
        }

        public List<OrderItemDetail> GetAll()
        {
            List<OrderItemDetail> order = _context.OrderItemDetails.ToList();
            return order;
        }
        public OrderItemDetail GetOrder(int id)
        {
            OrderItemDetail order = null;
            order = _context.OrderItemDetails.FirstOrDefault(p => p.ItemId == id);
            return order;
        }
        public OrderItemDetail PostOrder(OrderItemDetail order)
        {
            try
            {
                OrderItemDetail newOrder = new OrderItemDetail();
                newOrder.ItemId = order.ItemId;
                newOrder.ToppingId = order.ToppingId;
                _context.OrderItemDetails.Add(newOrder);
                _context.SaveChanges();
                return newOrder;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }
        public OrderItemDetail PutOrder(int id, OrderItemDetail order)
        {
            try
            {
                var newOrder = _context.OrderItemDetails.FirstOrDefault(p => p.ItemId == id);
                newOrder.ItemId = order.ItemId;
                newOrder.ToppingId = order.ToppingId;
                _context.OrderItemDetails.Update(newOrder);
                _context.SaveChanges();
                return newOrder;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }
        public void RemoveOrder(int id)
        {

            try
            {
                var newOrder = _context.OrderItemDetails.FirstOrDefault(p => p.ItemId == id);
                _context.OrderItemDetails.Remove(newOrder);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
