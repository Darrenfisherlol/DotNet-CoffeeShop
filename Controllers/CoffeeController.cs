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
        private ApplicationDbContext _context = new ApplicationDbContext();
        
        public ActionResult CoffeeHub()
        {
            return View();
        }

        public ActionResult Details()
        {
            return View(_context.Coffees.ToList());
        }
        
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, Name, Category, Temp, Description, Price")] Coffee coffeeInput)
        {

            using (var context = new ApplicationDbContext())
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

            return View(coffeeInput);
        }
        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coffee = await _context.Coffees.FindAsync(id);
            
            if (coffee == null)
            {
                return NotFound();
            }

            return View(coffee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var coffee = await _context.Coffees.FindAsync(id);
        
            if (coffee != null)
            {
                _context.Coffees.Remove(coffee);
                await _context.SaveChangesAsync();
            }
        
            return RedirectToAction(nameof(Details));
        }
        
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
