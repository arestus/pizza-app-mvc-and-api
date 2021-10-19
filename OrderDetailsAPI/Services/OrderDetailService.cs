using OrderDetailsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderDetailsAPI.Services
{
    public class OrderDetailService
    {
        private readonly CompanyContext _context;

        public OrderDetailService(CompanyContext context)
        {
            _context = context;
        }

        public List<OrderDetail> GetAll()
        {
            List<OrderDetail> order = _context.OrderDetails.ToList();
            return order;
        }
        public OrderDetail GetOrder(int id)
        {
            OrderDetail order = null;
            order = _context.OrderDetails.FirstOrDefault(p => p.ItemId == id);
            return order;
        }
        public OrderDetail PostOrder(OrderDetail order)
        {
            try
            {
                OrderDetail newOrder = new OrderDetail();
                newOrder.ItemId = order.ItemId;
                newOrder.OrderId = order.OrderId;
                newOrder.PizzaId = order.PizzaId;
                _context.OrderDetails.Add(newOrder);
                _context.SaveChanges();
                return newOrder;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }
        public OrderDetail PutOrder(int id, OrderDetail order)
        {
            try
            {
                var newOrder = _context.OrderDetails.FirstOrDefault(p => p.ItemId == id);
                newOrder.ItemId = order.ItemId;
                newOrder.OrderId = order.OrderId;
                newOrder.PizzaId = order.PizzaId;
                _context.OrderDetails.Update(newOrder);
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
                var newOrder = _context.OrderDetails.FirstOrDefault(p => p.ItemId == id);
                _context.OrderDetails.Remove(newOrder);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
