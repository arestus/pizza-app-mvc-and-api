using OrdersAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersAPI.Services
{
    public class OrderService
    {
        private readonly CompanyContext _context;

        public OrderService(CompanyContext context)
        {
            _context = context;
        }

        public List<Order> GetAll()
        {
            List<Order> order = _context.Orders.ToList();
            return order;
        }
        public Order GetOrder(int id)
        {
            Order order = null;
            order = _context.Orders.FirstOrDefault(p => p.OrderID == id);
            return order;
        }
        public Order PostOrder(Order order)
        {
            try
            {
                Order newOrder = new Order();
                newOrder.OrderID = order.OrderID;
                newOrder.Username = order.Username;
                newOrder.OrderTotal = order.OrderTotal;
                newOrder.DeliveryCharge  = order.DeliveryCharge;
                newOrder.Status  = order.Status;
                _context.Orders.Add(newOrder);
                _context.SaveChanges();
                return newOrder;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }
        public Order PutOrder(int id,Order order)
        {
            try
            {
                var newOrder = _context.Orders.FirstOrDefault(p => p.OrderID == id);
                newOrder.OrderID = order.OrderID;
                newOrder.Username = order.Username;
                newOrder.OrderTotal = order.OrderTotal;
                newOrder.DeliveryCharge = order.DeliveryCharge;
                newOrder.Status = order.Status;
                _context.Orders.Update(newOrder);
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
                var newOrder = _context.Orders.FirstOrDefault(p => p.OrderID == id);
                _context.Orders.Remove(newOrder);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
