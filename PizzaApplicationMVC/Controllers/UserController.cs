using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaApplicationMVC.Models;
using PizzaApplicationMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaApplicationMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _userService;

        public UserController(UserService service)
        {
            _userService = service;
        }
        // GET: UserController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Register()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserDTO userDto)
        {
            try
            {
                UserDTO user = _userService.Register(userDto);
                if (user != null)
                {
                    TempData["token"] = user.jwtToken;
                    return RedirectToAction("Login", "User");
                }
            }
            catch
            {
                return View();
            }
            ViewBag.Error = "Not Registered! User name already taken";
            return View();
        }

        // GET: UserController/Edit/5
        public ActionResult Login(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserDTO userDto)
        {
            try
            {
                UserDTO user = _userService.Login(userDto);
                if (user != null)
                {
                    TempData["token"] = user.jwtToken;
                    TempData["userEmail"] = user.id;
                    return RedirectToAction("Index", "Pizza");
                }
            }
            catch
            {
                return View();
            }
            ViewBag.Error = "Invalid username or password";
            return View();
        }


        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
