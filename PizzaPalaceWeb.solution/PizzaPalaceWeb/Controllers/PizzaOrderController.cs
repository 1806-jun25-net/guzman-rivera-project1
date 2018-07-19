using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PizzaPalace.Data;
using PizzaPalace.Library;

namespace PizzaPalaceWeb.Controllers
{
    public class PizzaOrderController : Controller
    {
        public PizzaPalacedbContext _context { get; }
        public UserRepository Repo { get; }

      
        public PizzaOrderController(PizzaPalacedbContext context, UserRepository repo)
        {
            _context = context;
            Repo = repo;

        }
        public IActionResult Index()
        {
            ViewBag.Message = "PizzaOrderController";
            PizzaOrders OTPT = new PizzaOrders
            {
                OT = Repo.GetOrdersTable(),
                PT = Repo.GetPizza(),
                UT = Repo.GetUsertable()
            };

            return View(OTPT);
        }

        public IActionResult SearcU()
        {
            Users user = new Users();
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SearcU(Users user)
        {
            // var repo = new UserRepository(new PizzaPalacedbContext(optionsBuilder.Options));
            var users = Repo.GetUsertable(); // Get all user
            var userorder = users.Where(g => g.FirstName == user.FirstName); // searching user
            var userID = user.Id; // user ID
            var won = Repo.GetOrdersTable(); // Get all Order
            var order = won.Where(q => q.UserIdfk == userID); // All user order
            var pizzas = Repo.GetPizza(); // Get all Pizza
            var PizzasUser = pizzas.Where(q => q.OrdersIdfk == userID); // pizza of order

            if (userorder == null)
            {
                TempData["Error"] = "Error: User not found";
                return View();
            }
            else
            {
                PizzaOrders OTPT = new PizzaOrders
                {
                    OT = order,
                    PT = PizzasUser,
                    UT = userorder
                };
                return View(OTPT);
            }

        }

        public IActionResult SuggestedOrder(int ID, string FirstName, string LastName, string PhoneNumber, int? DefaultLocationFk)
        {
            Users user = new Users
            {
                Id = ID,
                FirstName = FirstName,
                LastName = LastName,
                PhoneNumber = PhoneNumber,
                DefaultLocationFk = DefaultLocationFk
            };
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuggestedOrder(Users user)
        {
            // var repo = new UserRepository(new PizzaPalacedbContext(optionsBuilder.Options));
            var users = Repo.GetUsertable(); // Get all user
            var userorder2 = users.FirstOrDefault(g => g.FirstName == user.FirstName && g.LastName == user.LastName && g.PhoneNumber == user.PhoneNumber); // select user
            if (userorder2 == null)
            {
                ModelState.AddModelError("", "Error: Order not found");
                return View();
            }
            else if(userorder2 != null)
            {
                var userorder = users.Where(g => g.FirstName == user.FirstName && g.LastName == user.LastName && g.PhoneNumber == user.PhoneNumber); // searching user
                var userID = userorder2.Id; // user ID
                var won = Repo.GetOrdersTable(); // Get all Order
                var order = won.Where(q => q.UserIdfk == userID); // All user order
                var pizzas = Repo.GetPizza(); // Get all Pizza
                var PizzasUser = pizzas.Where(q => q.OrdersIdfk == userID); // pizza of order
                var lastorder = won.LastOrDefault(q => q.UserIdfk == userID); // last order
                var lastPizzasUser = pizzas.LastOrDefault(q => q.OrdersIdfk == lastorder.OrderId); // last pizza of order
                
                PizzaOrders OTPT = new PizzaOrders
                {
                    OT = order,
                    PT = PizzasUser,
                    UT = userorder
                };

                ViewData["lastorder"] = lastorder;
                ViewData["lastPizzasUser"] = lastPizzasUser;
                return View();
            }
            return View();
        }
    }
}