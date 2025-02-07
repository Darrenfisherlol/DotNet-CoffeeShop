using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApplication2.Data;
using WebApplication2.Models;
using System.Linq;
using System.Collections.Generic;



namespace WebApplication2.Controllers
{
    public class CoffeeController : Controller
    {
        private CoffeeContext _context = new CoffeeContext();

        // GET: Coffee/CoffeeHub
        public ActionResult CoffeeHub()
        {
            return View();
        }

        // GET: Coffee/Details
        public ActionResult Details()
        {
            return View(_context.Coffees.ToList());
        }
        
        //GET: Coffee/Create
        public ActionResult Create()
        {
            return View();
        }
        
        // POST: Coffee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, Name, Category, Temp, Description, Price")] Coffee coffeeInput)
        {

            using (var context = new CoffeeContext())
            {
                var cof = await context.Coffees.FindAsync(coffeeInput.Id);
                if (coffeeInput.Id == 0 || cof is not null)
                {
                    return View();
                }
            }
            
           
            if (ModelState.IsValid)
            {
                _context.Add(coffeeInput);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details));
            }

            // Return the view with validation errors if any
            return View(coffeeInput);
        }
        
        //GET: Coffee/Delete
        public ActionResult Delete()
        {
            return View();
        }

        // POST: Coffee/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var coffeeId = await _context.Coffees.FindAsync(id);

            if (coffeeId == null)
            {
                TempData["ErrorMessage"] = "The specified ID does not exist.";
                return RedirectToAction(nameof(Delete));
            }

            _context.Coffees.Remove(coffeeId);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(CoffeeHub));
        }

        
        //GET: Coffee/Edit
        public async Task<IActionResult>  Edit(int? Id)
        {
            Coffee coffee = null;

            if (Id != null)
            {
                coffee = await _context.Coffees.FindAsync(Id);
                
                if (coffee == null)
                {
                    TempData["ErrorMessage"] = "The specified ID does not exist.";
                    return RedirectToAction(nameof(Edit));
                }
            }
            
            
            return View(coffee);   
        }

        // POST: Coffee/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Coffee coffeeInput)
        {
            if (id != coffeeInput.Id || id.HasValue)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(coffeeInput);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details));
            }
            return View(coffeeInput);
        }
    }
}
