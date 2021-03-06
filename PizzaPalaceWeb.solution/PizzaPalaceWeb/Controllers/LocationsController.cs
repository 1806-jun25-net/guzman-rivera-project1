﻿using System;
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
    public class LocationsController : Controller
    {
        private readonly PizzaPalacedbContext _context;

        public LocationsController(PizzaPalacedbContext context)
        {
            _context = context;
        }

        // GET
        public ActionResult TheLocation(Users user)
        {
            LocationM location = new LocationM();
            return View(location);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public ActionResult TheLocation(LocationM location, Users user, IFormCollection loc)
        {
            var selected = location.LocationsId;
            // var selected = loc["LocationId"];
            location.LocationsId = int.Parse(loc["SL"]);
            TempData["locationid"] = location.LocationsId;

            //user.DefaultLocationFk = location.LocationsId;
            //TempData["msg"] = "user id " + user.UsersId + "name " + user.FirstName;
            // TempData["name"] = "user name " + user.FirstName + "last name " + user.FirstName;


            return RedirectToAction("OrderSubmit", "Orders", user);


        }




        // GET: Locations
        public async Task<IActionResult> Index()
        {
            return View(await _context.Locations.ToListAsync());
        }

        // GET: Locations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locations = await _context.Locations
                .FirstOrDefaultAsync(m => m.LocationsId == id);
            if (locations == null)
            {
                return NotFound();
            }

            return View(locations);
        }

        // GET: Locations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Locations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LocationsId,Locations1,Doug,Cheese,Pepperoni,Sausage,Bacon,Onion,Chiken,Sauce,Chorizo")] Locations locations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(locations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(locations);
        }

        // GET: Locations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locations = await _context.Locations.FindAsync(id);
            if (locations == null)
            {
                return NotFound();
            }
            return View(locations);
        }

        // POST: Locations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LocationsId,Locations1,Doug,Cheese,Pepperoni,Sausage,Bacon,Onion,Chiken,Sauce,Chorizo")] Locations locations)
        {
            if (id != locations.LocationsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(locations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocationsExists(locations.LocationsId))
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
            return View(locations);
        }

        // GET: Locations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locations = await _context.Locations
                .FirstOrDefaultAsync(m => m.LocationsId == id);
            if (locations == null)
            {
                return NotFound();
            }

            return View(locations);
        }

        // POST: Locations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var locations = await _context.Locations.FindAsync(id);
            _context.Locations.Remove(locations);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocationsExists(int id)
        {
            return _context.Locations.Any(e => e.LocationsId == id);
        }
    }
}
