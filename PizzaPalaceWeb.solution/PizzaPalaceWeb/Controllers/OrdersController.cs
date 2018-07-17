using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
        public IActionResult PlaceAnOrder()
        {
            PizzaM pizza = new PizzaM();
            OrderM order = new OrderM();
            //OrdersPizzaModel orderPizza = new OrdersPizzaModel();

            return ViewBag(pizza, order);
        }

        // Post: PlaceAnOrder
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PlaceAnOrder(PizzaM pizza, OrderM order, Users user)
        {
            ModeloGeneral myModel = new ModeloGeneral();

            pizza.Pizza1 = myModel.SelectTopping.Value;
            pizza.Size = myModel.SelectSize.Value;

            // Sets the values
            order.OrderId = user.Id;
            order.LocationsIdfk = user.DefaultLocationFk;
            pizza.Cost = Total;


            if (Count <= 12)
            {


                // Calculates the total
                if (pizza.Size == "small")
                {
                    pizza.Cost = 5;
                    Total = Total += 5;
                }
                else if (pizza.Size == "medium")
                {
                    pizza.Cost = 10;
                    Total = Total += 10;
                }
                else if (pizza.Size == "large")
                {
                    pizza.Cost = 16;
                    Total = Total += 16;
                }

                int price = int.Parse(pizza.Cost.ToString());
                toppins.Clear();
                toppins.Add(1);
                toppins.Add(1);
                toppins.Add(0);
                toppins.Add(0);
                toppins.Add(0);
                toppins.Add(0);
                toppins.Add(0);
                toppins.Add(1);
                toppins.Add(0);
                // Checks if there are enough resourses
                bool checkInventory = Repo.InventorySubStract(1, toppins); // toppins



                if (checkInventory == true)
                {

                    // Add new pizza
                    Repo.Addpizza(pizza.Pizza1, pizza.Size, toppins);// toppins

                    // For creating just an order for every pizza
                    if (Count < 1)
                    {
                        // Add New Order
                        Repo.SubmitOrder(user.FirstName, user.LastName, user.PhoneNumber, 1);

                    }
                    Count++;



                    // Search for the pizza and order Id


                    return RedirectToAction("PlaceAnOrder");
                }
                // if there are no more toppings for the pizza's
                else
                {
                    ViewData["message"] = "Not Enough resourses to create a pizza, please try again later.";
                    return RedirectToAction("PlaceAnOrder");
                }
            }
            // If the user wants to order more than 12 pizza's 
            else
            {
                ViewData["message"] = "You exceded order limit, you can only order 12 pizzas max. Place your order and try again.";
                return RedirectToAction("PlaceAnOrder");
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
            //ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Price" : "Price_desc";
            ViewBag.PriceSortParm = sortOrder == "LocationsIdfk" ? "LocationsIdfk_desc" : "LocationsIdfk";
            ViewBag.DateSortParm = sortOrder == "Date" ? "Date_desc" : "Date";
            var Oder = from s in Repo.GetOrdersTable()
                       select s;
            switch (sortOrder)
            {
                case "LocationsIdfk":
                    Oder = Oder.OrderBy(s => s.LocationsIdfk);
                    break;
                case "LocationsIdfk_desc":
                    Oder = Oder.OrderByDescending(s => s.LocationsIdfk);
                    break;
                case "Date":
                    Oder = Oder.OrderBy(s => s.DateTimeOrder);
                    break;
                case "Date_desc":
                    Oder = Oder.OrderByDescending(s => s.DateTimeOrder);
                    break;
                default:
                    Oder = Oder.OrderBy(s => s.DateTimeOrder);
                    break;
            }
            return View(Oder.ToList());
        }


        //// GET: Orders
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
