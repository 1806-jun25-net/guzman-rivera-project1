using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PizzaPalace.Data;
using PizzaPalace.Library;
using PizzaPalaceWeb.Models;

namespace PizzaPalaceWeb.Controllers
{
    public class OrdersController : Controller
    {
        private readonly PizzaPalacedbContext _context;
        public SelectListItem SelectedSize { get; set; }
        public UserRepository Repo { get; }
        public int Count = 0;
        public int Total = 0;
        public List<int> toppins = new List<int>();

        public OrdersController(PizzaPalacedbContext context, UserRepository repo)
        {
            _context = context;
            Repo = repo;
        }

        public IActionResult ShowOrder()
        {
            return View();
        }

        //Get: placeAnOrder
        public IActionResult OrderSubmit()
        {
            //PizzaM pizza = new PizzaM();
            //OrderM order = new OrderM();
            //OrdersPizzaModel orderPizza = new OrdersPizzaModel();

            return View();
        }

        // Post: PlaceAnOrder
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult OrderSubmit(IFormCollection VC, Users user)
        {

            int UseridTD = int.Parse(TempData.Peek("userid").ToString());
            int LocationTD = int.Parse(TempData.Peek("locationid").ToString());
            string NameTD = TempData.Peek("firstname").ToString();
            string LastnameTD = TempData.Peek("lastname").ToString();
            string PhoneTD = TempData.Peek("phone").ToString();

            if (Count == 12)
            {
                ViewData["msg"] = "You can't order more than 12 Pizzas :( ";
                return RedirectToAction(nameof(OrderSubmit));
            }

            string SelectedPizza = VC["SP"];
            int SelectedSize = int.Parse(VC["SS"]);
            //ModeloGeneral myModel = new ModeloGeneral();
            double cost;
            double ELTOTAL;
            //pizza.Pizza1 = myModel.SelectTopping.Value;
            //pizza.Size = myModel.SelectSize.Value;

            //// Sets the values
            //order.OrderId = user.Id;
            //order.LocationsIdfk = user.DefaultLocationFk;
            //pizza.Cost = Total;

            if (SelectedSize == 1)
            {
                cost = 6;

                ELTOTAL = int.Parse(TempData.Peek("order_total").ToString());
                ELTOTAL += 6;
                TempData["order_total"] = ELTOTAL;
            }
            else if (SelectedSize == 2)
            {
                cost = 12;
                ELTOTAL = int.Parse(TempData.Peek("order_total").ToString());
                ELTOTAL += 12;
                TempData["order_total"] = ELTOTAL;

            }
            else
            {
                cost = 17;
                ELTOTAL = int.Parse(TempData.Peek("order_total").ToString());
                ELTOTAL += 17;
                TempData["order_total"] = ELTOTAL;

            }


            //check availability of ingredients for each pizza
            bool availability = Repo.checkInv(LocationTD);
            
            if (availability == true)
            {
                // take out toppings from db

                //add pizza
                
                if (TempData.Peek("Count").ToString() == "1")
                {
                    Count = 1;

                }
                else
                {
                    Count = int.Parse(TempData.Peek("Count").ToString());
                }


                if (Count < 2)//only if the order is new is going to be created
                {
                    Repo.SubmitOrder(UseridTD, LocationTD);

                    /////////////////////////////////////////////////////////////////////////////Repo.SubmitOrder(UseridTD, LocationTD, Order_total);

                }
                int? OrderIDs = Repo.GetOrderByUserId(UseridTD);

                //increment counter to know next time, that this is not a new order.
                if (SelectedPizza == "Cheese")
                {
                    Repo.Cheesepizza(SelectedSize, LocationTD, cost, SelectedPizza, UseridTD);
                }
                if (SelectedPizza == "Pepperoni")
                {
                    Repo.Pepperoni(SelectedSize, LocationTD, cost, SelectedPizza, UseridTD);
                }
                if (SelectedPizza == "Allmeat")
                {
                    Repo.AllMeat(SelectedSize, LocationTD, cost, SelectedPizza, UseridTD);
                }
                if (SelectedPizza == "Chorizo")
                {
                    Repo.Chorizo(SelectedSize, LocationTD, cost, SelectedPizza, UseridTD);
                }
                if (SelectedPizza == "Bacon")
                {
                    Repo.Bacon(SelectedSize, LocationTD, cost, SelectedPizza, UseridTD);
                }
                Repo.SaveChanges();
                Count++;
                TempData["Count"] = Count;
                return RedirectToAction(nameof(OrderSubmit));
                
            }
            else
            {
                ViewData["msg"] = "Not enough reseources to complete your order, Please choose again...";
                return RedirectToAction(nameof(OrderSubmit));
            }


        }



        public ActionResult PizzaPalace(Orders order)
        {
            ////////////////////////////////////////////////////////////////////////////////////////
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            Console.WriteLine(configuration.GetConnectionString("PizzaPalacedb"));
            var optionsBuilder = new DbContextOptionsBuilder<PizzaPalacedbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("PizzaPalacedb"));
            ////////////////////////////////////////////////////////////////////////////////////////
            //var Loc = SelectedSize.Value;
            //var Location = Int32.Parse(Loc);

            var repo = new UserRepository(new PizzaPalacedbContext(optionsBuilder.Options));
            var LocationsSearch = Repo.GetLocation();// get all locat
            var location = LocationsSearch.FirstOrDefault(q => q.LocationsId == 1);// the location
            var won = Repo.GetOrdersTable(); // Get all Order
            var order2 = won.Where(q => q.LocationsIdfk == location.LocationsId); // order from loc


            //TempData["id"] = ELUSER.Id;
            //TempData["name"] = ELUSER.FirstName;
            //TempData["last"] = ELUSER.LastName;
            //TempData["phone"] = ELUSER.PhoneNumber;
            return View(order2);
        }




        public ActionResult Index(string sortOrder)
        {
            ViewBag.LocSortParm = String.IsNullOrEmpty(sortOrder) ? "Location_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "Date_desc" : "Date";
            //ViewBag.User = sortOrder == "User" ? "User" : "User_desc";
            var Oder = from s in Repo.GetOrdersTable()
                       select s;

            switch (sortOrder)
            {
                case "Date":
                    Oder = Oder.OrderBy(s => s.DateTimeOrder);
                    break;
                case "Date_desc":
                    Oder = Oder.OrderByDescending(s => s.DateTimeOrder);
                    break;
                //case "Location_desc":
                //    Oder = Oder.OrderByDescending(s => s.LocationsIdfk);
                //    break;
                //case "User":
                //    Oder = Oder.OrderBy(s => s.UserIdfk);
                //    break;
                //case "User_desc":
                //    Oder = Oder.OrderByDescending(s => s.UserIdfk);
                //    break;
                default:
                    Oder = Oder.OrderBy(s => s.LocationsIdfk);
                    break;

            }
            return View(Oder.ToList());

        }
        // GET: Orders
        //public async Task<IActionResult> Index()
        //{
        //    var pizzaPalacedbContext = _context.Orders.Include(o => o.LocationsIdfkNavigation).Include(o => o.UserIdfkNavigation);
        //    return View(await pizzaPalacedbContext.ToListAsync());
        //}

        //public IActionResult AngelitoOrder()
        //{
        //    return View();
        //}



        public ActionResult AngelitoOrder(Orders order)
        {
            ////////////////////////////////////////////////////////////////////////////////////////
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            Console.WriteLine(configuration.GetConnectionString("PizzaPalacedb"));
            var optionsBuilder = new DbContextOptionsBuilder<PizzaPalacedbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("PizzaPalacedb"));
            ////////////////////////////////////////////////////////////////////////////////////////
            //var Loc = SelectedSize.Value;
            //var Location = Int32.Parse(Loc);

            var repo = new UserRepository(new PizzaPalacedbContext(optionsBuilder.Options));
            var LocationsSearch = Repo.GetLocation();// get all locat
            var location = LocationsSearch.FirstOrDefault(q => q.LocationsId == 2);// the location
            var won = Repo.GetOrdersTable(); // Get all Order
            var order2 = won.Where(q => q.LocationsIdfk == location.LocationsId); // order from loc


            //TempData["id"] = ELUSER.Id;
            //TempData["name"] = ELUSER.FirstName;
            //TempData["last"] = ELUSER.LastName;
            //TempData["phone"] = ELUSER.PhoneNumber;
            return View(order2);
        }
        //public ActionResult OrderLocation(string sortOrder)
        //{

        //    //ViewBag.NameSortParm = String.IsNullOrEmpty(sort) ? "Price" : "Price_desc";
        //    ViewBag.PriceSortParm = sortOrder == "Order ID" ? "Price_desc" : "Price";
        //    ViewBag.DateSortParm = sortOrder == "Date" ? "Date_desc" : "Date";

        //    //var Oder = Repo.GetLocationOrders(Int32.Parse(sortOrder));


        //    switch (sortOrder)
        //    {
        //        case "Order ID":
        //            Oder = Oder.OrderBy(s => s.OrderId);
        //            break;
        //        case "Order ID_desc":
        //            Oder = Oder.OrderByDescending(s => s.OrderId);
        //            break;
        //        case "Date":
        //            Oder = Oder.OrderBy(s => s.DateTimeOrder);
        //            break;
        //        case "Date_desc":
        //            Oder = Oder.OrderByDescending(s => s.DateTimeOrder);
        //            break;
        //        default:
        //            Oder = Oder.OrderBy(s => s.OrderId);
        //            break;
        //    }
        //    return View(Oder.ToList());
        //}

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            int orderid = int.Parse(TempData.Peek("orderid").ToString());
            var orders = await _context.Orders
                .Include(o => o.LocationsIdfkNavigation)
                .Include(o => o.UserIdfkNavigation)
                .FirstOrDefaultAsync(m => m.OrderId == orderid);

            return View(orders);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["LocationsIdfk"] = new SelectList(_context.Locations, "LocationsId", "LocationsId");
            ViewData["UserIdfk"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,UserIdfk,LocationsIdfk,DateTimeOrder")] Orders orders)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orders);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocationsIdfk"] = new SelectList(_context.Locations, "LocationsId", "LocationsId", orders.LocationsIdfk);
            ViewData["UserIdfk"] = new SelectList(_context.Users, "Id", "Id", orders.UserIdfk);
            return View(orders);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders.FindAsync(id);
            if (orders == null)
            {
                return NotFound();
            }
            ViewData["LocationsIdfk"] = new SelectList(_context.Locations, "LocationsId", "LocationsId", orders.LocationsIdfk);
            ViewData["UserIdfk"] = new SelectList(_context.Users, "Id", "Id", orders.UserIdfk);
            return View(orders);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,UserIdfk,LocationsIdfk,DateTimeOrder")] Orders orders)
        {
            if (id != orders.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orders);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdersExists(orders.OrderId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocationsIdfk"] = new SelectList(_context.Locations, "LocationsId", "LocationsId", orders.LocationsIdfk);
            ViewData["UserIdfk"] = new SelectList(_context.Users, "Id", "Id", orders.UserIdfk);
            return View(orders);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders
                .Include(o => o.LocationsIdfkNavigation)
                .Include(o => o.UserIdfkNavigation)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (orders == null)
            {
                return NotFound();
            }

            return View(orders);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orders = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(orders);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdersExists(int id)
        {
            return _context.Orders.Any(e => e.OrderId == id);
        }
    }
}
