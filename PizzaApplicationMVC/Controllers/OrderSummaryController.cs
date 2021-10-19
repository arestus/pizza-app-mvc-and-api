using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaApplicationMVC.Models;
using PizzaApplicationMVC.Services;
using PizzaApplicationMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaApplicationMVC.Controllers
{
    public class OrderSummaryController : Controller
    {
        private readonly PizzaService _pizzaService;
        private readonly ToppingService _toppingService;
        private readonly OrderService _orderService;
        private readonly OrderDetailService _orderDetailService;
        private readonly OrderItemDetailService _orderItemDetailService;

        public OrderSummaryController(PizzaService pizzaService, ToppingService toppingService, OrderService orderService, OrderDetailService orderDetailService, OrderItemDetailService orderItemDetailService)
        {
            _pizzaService = pizzaService;
            _toppingService = toppingService;
            _orderService = orderService;
            _orderDetailService = orderDetailService;
            _orderItemDetailService = orderItemDetailService;
        }
        public IActionResult Index()
        {
            string token = (string)TempData.Peek("token");
            int OrderID = Convert.ToInt32(TempData.Peek("orderId"));
            List<OrderDetailDTO> orderdetails = _orderDetailService.AllOrder(token);
            List<OrderDetailDTO> orders = new();
            foreach (var item in orderdetails)
            {
                if(item.OrderId == OrderID)
                {
                    orders.Add(item);
                }
            }
            ViewBag.ItemDetails = orders;
            // IList<PizzaDetail> pizzas = null;
            List<OrderItemDetailDTO> items = null;
            List<FinalOutputModel> obj = new();
            foreach (var item in ViewBag.ItemDetails)
            {
                FinalOutputModel output = new();
                output.Pizza = _pizzaService.GetPizza(item.PizzaId,token);
                output.Toppings = new();
                int pizzanumber = item.PizzaId;
                List<OrderItemDetailDTO> orderItemdetails = _orderItemDetailService.AllOrder(token);
                List<OrderItemDetailDTO> orderItems = new();
                foreach (var orderitem in orderItemdetails)
                {
                    if (orderitem.ItemId == item.ItemId)
                    {
                        orderItems.Add(orderitem);
                    }
                }
                items = orderItems;
                foreach (var itemtopping in items)
                {

                    ToppingDTO topping = _toppingService.GetTopping(itemtopping.ToppingId,token);
                    output.Toppings.Add(topping);
                    int orderId = Convert.ToInt32(TempData.Peek("orderId"));
                    OrderDTO order = _orderService.GetOrder(orderId,token);
                    if (order.OrderTotal < 50)
                    {
                        order.OrderTotal += 5;
                        ViewBag.deliveryPrice = 5;
                    }
                    else
                    {
                        ViewBag.deliveryPrice = 0;
                    }
                    ViewBag.theOrder = order;

                }
                obj.Add(output);
            }
            // ViewBag.PizzaDetails = pizzas;
            OutputList objBind = new();
            objBind.FinalListPizzas = obj;
            return View(objBind);
        }
        public IActionResult Confirm()
        {
            return View();
        }
    }
}
