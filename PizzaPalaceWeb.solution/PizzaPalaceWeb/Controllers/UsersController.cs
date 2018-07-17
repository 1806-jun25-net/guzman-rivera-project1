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
    public class UsersController : Controller
    {
        public PizzaPalacedbContext _context { get; }
        public UserRepository Repo { get; }
        public SelectListItem SelectedSize { get; set; }
        public string sort;


        public UsersController(PizzaPalacedbContext context, UserRepository repo)
        {
            _context = context;
            Repo = repo;
           
        }


        public IActionResult AddNewUser()
        {
            Users user = new Users();
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddNewUser(Users user)
        {
            bool foundUser = false;
            var allUsers = Repo.GetUsertable();

            foreach (var aUser in allUsers)
            {
                if (aUser.FirstName == user.FirstName && aUser.PhoneNumber == user.PhoneNumber)
                {
                    user.Id = aUser.Id;
                    foundUser = true;
                    goto aNewUser;
                }
            }
            aNewUser:
            if (foundUser == true)
            {
                var aUser = new Users
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    PhoneNumber = user.PhoneNumber
                };
            }
            else if (foundUser == false)
            {
                //create new user
                Repo.AddUser(user.FirstName, user.LastName, user.PhoneNumber,1);
                Repo.SaveChanges();
            }

            return RedirectToAction("ChooseALocation", "Locations", user);
            // return View(user);
        }


















        public IActionResult Home()
        {
            return View();
        }

        public IActionResult AngelitoOrder()
        {
            Orders hi = new Orders();
            return View(hi);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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
            var Loc = SelectedSize.Value;
            var Location = Int32.Parse(Loc);

            var repo = new UserRepository(new PizzaPalacedbContext(optionsBuilder.Options));
            var LocationsSearch = Repo.GetLocation();// get all locat
            var location = LocationsSearch.FirstOrDefault(q => q.LocationsId == Location);// the location
            var won = Repo.GetOrdersTable(); // Get all Order
            var order2 = won.Where(q => q.LocationsIdfk == location.LocationsId); // order from loc

            List<Object> newObj = new List<Object>();
            
            return View(newObj);
        }

        /// SearcUser
        public IActionResult SearcUser()
        {
            Users user = new Users();
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SearcUser(Users user)
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

            //var repo = new UserRepository(new PizzaPalacedbContext(optionsBuilder.Options));
            var use = Repo.GetUsertable();
            var ELUSER = use.FirstOrDefault(e => e.FirstName == user.FirstName);
            if(ELUSER == null)
            {
                TempData["Error"] = "Error: User not found";
            }
            else
            {
                TempData["id"] = ELUSER.Id;
                TempData["name"] = ELUSER.FirstName;
                TempData["last"] = ELUSER.LastName;
                TempData["phone"] = ELUSER.PhoneNumber;
                if (ELUSER.DefaultLocationFk == 1)
                {
                    TempData["loc"] = "Pizza Palace!";
                }
                else if (ELUSER.DefaultLocationFk == 2)
                {
                    TempData["loc"] = "Angelito's Pizza!";
                }
                else if (ELUSER.DefaultLocationFk == 3)
                {
                    TempData["loc"] = "Belito's pizza!";
                }
            }
            return View();
        }

        public IActionResult UserOrder()
        {
            Users user = new Users();
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserOrder(Users user)
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


            var repo = new UserRepository(new PizzaPalacedbContext(optionsBuilder.Options));
            var users = Repo.GetUsertable(); // Get all user
            var userorder = users.FirstOrDefault(g => g.FirstName == user.FirstName); // searching user
            var userID = user.Id; // user ID
            var won = Repo.GetOrdersTable(); // Get all Order
            var order = won.Where(q => q.UserIdfk == userID); // All user order
            var pizzas = Repo.GetPizza(); // Get all Pizza
            var PizzasUser = pizzas.Where(q => q.OrdersIdfk == userID); // pizza of order





            //TempData["id"] = ELUSER.Id;
            //TempData["name"] = ELUSER.FirstName;
            //TempData["last"] = ELUSER.LastName;
            //TempData["phone"] = ELUSER.PhoneNumber;
            return View();
        }

        public IActionResult LogIN()
        {
            Users user = new Users();
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIN(Users user)
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

            
            var repo = new UserRepository(new PizzaPalacedbContext(optionsBuilder.Options));
            var use = repo.GetUsertable();
            var ELUSER = use.FirstOrDefault(e => e.FirstName == user.FirstName && e.PhoneNumber == user.PhoneNumber);
            if(ELUSER == null)
            {
                TempData["Error"] = "User not found.";
                ///////redirecting//////////////////////////////////////////////////////////ergergergergerg3w4gt345hyw4ethw345hetrg3e5g35rg3e
            }
            Users TheUserFound = new Users
            {
                Id = ELUSER.Id,
                FirstName = ELUSER.FirstName,
                LastName = ELUSER.LastName,
                PhoneNumber = ELUSER.PhoneNumber,
                DefaultLocationFk = ELUSER.DefaultLocationFk
            };
            return View();
           

            //TempData["id"] = ELUSER.Id;
            //TempData["name"] = ELUSER.FirstName;
            //TempData["last"] = ELUSER.LastName;
            //TempData["phone"] = ELUSER.PhoneNumber;
            //return RedirectToAction(nameof(controllerquequieroir))
        }
        














        // GET: Users
        public async Task<IActionResult> Index()
        {
            var pizzaPalacedbContext = _context.Users.Include(u => u.DefaultLocationFkNavigation);
            return View(await pizzaPalacedbContext.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.Users
                .Include(u => u.DefaultLocationFkNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (users == null)
            {
                return NotFound();
            }

            return View(users);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            ViewData["DefaultLocationFk"] = new SelectList(_context.Locations, "LocationsId", "LocationsId");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,PhoneNumber,DefaultLocationFk")] Users users)
        {
            if (ModelState.IsValid)
            {
                _context.Add(users);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DefaultLocationFk"] = new SelectList(_context.Locations, "LocationsId", "LocationsId", users.DefaultLocationFk);
            return View(users);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.Users.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }
            ViewData["DefaultLocationFk"] = new SelectList(_context.Locations, "LocationsId", "LocationsId", users.DefaultLocationFk);
            return View(users);
        }



        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,PhoneNumber,DefaultLocationFk")] Users users)
        {
            if (id != users.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(users);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsersExists(users.Id))
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
            ViewData["DefaultLocationFk"] = new SelectList(_context.Locations, "LocationsId", "LocationsId", users.DefaultLocationFk);
            return View(users);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.Users
                .Include(u => u.DefaultLocationFkNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (users == null)
            {
                return NotFound();
            }

            return View(users);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var users = await _context.Users.FindAsync(id);
            _context.Users.Remove(users);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsersExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
