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
    public class PizzaController : Controller
    {
        private readonly PizzaService _pizzaService;
        private readonly ToppingService _toppingService;
        private readonly OrderService _orderService;
        private readonly OrderDetailService _orderDetailService;
        private readonly OrderItemDetailService _orderItemDetailService;

        public PizzaController(PizzaService pizzaService,ToppingService toppingService,OrderService orderService,OrderDetailService orderDetailService,OrderItemDetailService orderItemDetailService)
        {
            _pizzaService = pizzaService;
            _toppingService = toppingService;
            _orderService = orderService;
            _orderDetailService = orderDetailService;
            _orderItemDetailService = orderItemDetailService;
        }
        // GET: PizzaController
        public ActionResult Index()
        {
            List<PizzaDTO> pizzas = null;
            string token = (string)TempData.Peek("token");
            if (token != null)
            {
                try
                {
                    pizzas = _pizzaService.AllPizzas(token);
                }
                catch (Exception)
                {
                    return View();
                }
            }
            return View(pizzas);
        }

        // GET: PizzaController/Details/5
        public ActionResult Details(int id)
        {
            PizzaDTO pizza = null;
            List<ToppingCheck> toppingCheck = new();
            ToppingList objBind = new ToppingList();
            string token = (string)TempData.Peek("token");
            if (token != null)
            {
                try
                {
                    pizza = _pizzaService.GetPizza(id,token);
                    List<ToppingDTO> toppingList = _toppingService.AllToppings(token);
                    foreach (var item in toppingList)
                    {
                        ToppingCheck toppingcheck = new() { ToppingID = item.ToppingID, ToppingName = item.ToppingName, ToppingPrice = item.ToppingPrice, IsChecked = false };
                        toppingCheck.Add(toppingcheck);
                    }
                    objBind.Toppings = toppingCheck;
                    ViewBag.thePizza = pizza;
                }
                catch (Exception)
                {
                    return View();
                }
            }
            return View(objBind);
        }

       

        // POST: PizzaController/Details
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Details(ToppingList toppingList)
        {
            OrderDTO newOrder,order;
            int Price = Convert.ToInt32(TempData.Peek("pizzaPrice"));
            string token = (string)TempData.Peek("token");
            //TempData["orderId"] = null;
            if (TempData.Peek("orderId") == null)
            {
                newOrder = new() { Username = Convert.ToString(TempData.Peek("userEmail")), OrderTotal = 0, DeliveryCharge = 0, Status = "pending" };
                order = _orderService.AddOrder(newOrder,token);
                TempData["orderId"] = order.OrderID;
                newOrder = _orderService.GetOrder(Convert.ToInt32(TempData.Peek("orderId")), token);
            }
            else
            {
                newOrder = _orderService.GetOrder(Convert.ToInt32(TempData.Peek("orderId")),token);
            }
            OrderDetailDTO neworderdetail;
            OrderDetailDTO orderDetail = new()
            {
                OrderId = Convert.ToInt32(TempData.Peek("orderId")),
                PizzaId = Convert.ToInt32(TempData.Peek("pizzaChoise"))
            };
            neworderdetail = _orderDetailService.AddOrder(orderDetail,token);
            TempData["itemId"] = neworderdetail.ItemId;
            foreach (var item in toppingList.Toppings)
            {
                if (item.IsChecked)
                {
                    OrderItemDetailDTO itemOrder = new() { ItemId = Convert.ToInt32(TempData.Peek("itemId")), ToppingId = item.ToppingID };
                    Price += (int)_toppingService.GetTopping(item.ToppingID,token).ToppingPrice;
                    _orderItemDetailService.AddOrder(itemOrder,token);
                }
            }
            //changeOrder = _orderService.GetOrder(Convert.ToInt32(TempData.Peek("orderId")), token);
            newOrder.OrderTotal += Price;
            _orderService.EditOrder(Convert.ToInt32(TempData.Peek("orderId")),newOrder,token);
            return RedirectToAction("Index", "Pizza");
        }

       
    }
}
