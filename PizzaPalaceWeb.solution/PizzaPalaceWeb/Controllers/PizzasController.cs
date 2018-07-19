using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PizzaPalace.Data;
using PizzaPalace.Library;

namespace PizzaPalaceWeb.Controllers
{
    public class PizzasController : Controller
    {
        private readonly PizzaPalacedbContext _context;
        public UserRepository Repo { get; }

        public PizzasController(PizzaPalacedbContext context, UserRepository repo)
        {
            _context = context;
            Repo = repo;
        }

        public ActionResult Index(string sortOrder)
        {
            //ViewBag.LocSortParm = String.IsNullOrEmpty(sortOrder) ? "Location_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Cost" ? "Cost_desc" : "Cost";
            ViewBag.Pizzas = sortOrder == "Pizza" ? "Pizza_desc" : "Pizza";
            var Oder = from s in Repo.GetPizza()
                       select s;

            switch (sortOrder)
            {
                case "Cost":
                    Oder = Oder.OrderBy(s => s.Cost);
                    break;
                case "Cost_desc":
                    Oder = Oder.OrderByDescending(s => s.Cost);
                    break;
                case "Pizza":
                    Oder = Oder.OrderBy(s => s.Pizza1);
                    break;
                case "Pizza_desc":
                    Oder = Oder.OrderByDescending(s => s.Pizza1);
                    break;
                default:
                    Oder = Oder.OrderBy(s => s.Cost);
                    break;

            }
            return View(Oder.ToList());

        }


        // GET: Pizzas
        //public async Task<IActionResult> Index()
        //{
        //    var pizzaPalacedbContext = _context.Pizza.Include(p => p.OrdersIdfkNavigation);
        //    return View(await pizzaPalacedbContext.ToListAsync());
        //}

        // GET: Pizzas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pizza = await _context.Pizza
                .Include(p => p.OrdersIdfkNavigation)
                .FirstOrDefaultAsync(m => m.PizzaId == id);
            if (pizza == null)
            {
                return NotFound();
            }

            return View(pizza);
        }

        // GET: Pizzas/Create
        public IActionResult Create()
        {
            ViewData["OrdersIdfk"] = new SelectList(_context.Orders, "OrderId", "OrderId");
            return View();
        }

        // POST: Pizzas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PizzaId,Pizza1,Size,Cost,OrdersIdfk,Doug,Cheese,Pepperoni,Sausage,Bacon,Onion,Chiken,Sauce,Chorizo")] Pizza pizza)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pizza);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrdersIdfk"] = new SelectList(_context.Orders, "OrderId", "OrderId", pizza.OrdersIdfk);
            return View(pizza);
        }

        // GET: Pizzas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pizza = await _context.Pizza.FindAsync(id);
            if (pizza == null)
            {
                return NotFound();
            }
            ViewData["OrdersIdfk"] = new SelectList(_context.Orders, "OrderId", "OrderId", pizza.OrdersIdfk);
            return View(pizza);
        }

        // POST: Pizzas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PizzaId,Pizza1,Size,Cost,OrdersIdfk,Doug,Cheese,Pepperoni,Sausage,Bacon,Onion,Chiken,Sauce,Chorizo")] Pizza pizza)
        {
            if (id != pizza.PizzaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pizza);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PizzaExists(pizza.PizzaId))
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
            ViewData["OrdersIdfk"] = new SelectList(_context.Orders, "OrderId", "OrderId", pizza.OrdersIdfk);
            return View(pizza);
        }

        // GET: Pizzas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pizza = await _context.Pizza
                .Include(p => p.OrdersIdfkNavigation)
                .FirstOrDefaultAsync(m => m.PizzaId == id);
            if (pizza == null)
            {
                return NotFound();
            }

            return View(pizza);
        }

        // POST: Pizzas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pizza = await _context.Pizza.FindAsync(id);
            _context.Pizza.Remove(pizza);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PizzaExists(int id)
        {
            return _context.Pizza.Any(e => e.PizzaId == id);
        }
    }
}
