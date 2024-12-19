using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.CodeAnalysis.Razor;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class CoffeeController : Controller
    {
        private CoffeeContext _context = new CoffeeContext();

        public ActionResult Index()
        {
            return View();
        }

        // GET: CoffeeController/Details/5
        public ActionResult Details()
        {
            return View(_context.Coffees.ToList());
        }
        
       //GET: CoffeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CoffeeOrder/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, Name, Category, Temp, Description, Price")] Coffee coffeeInput)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coffeeInput);  
                await _context.SaveChangesAsync();  
                return RedirectToAction(nameof(Details)); 
            }
            // Return the view with validation errors if any
            return View(coffeeInput);  
        }
        
        
        
        
        //
        // // GET: Coffee/Edit/{id}
        // public ActionResult Edit(int? id)
        // {
        //     // Retrieve the product by ID
        //     var coffee = _context.Find(id);
        //     if (coffee == null)
        //     {
        //         return NotFound(new { message="no id found"}); 
        //     }
        //
        //     return View(coffee); // Return the product to the view for editing
        // }
        //
        // // POST: Product/Edit/{id}
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public ActionResult Edit(Coffee model)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         // Update the product in the database
        //         _context.Update(model);
        //         return RedirectToAction("Details"); // Redirect to another page, like Index or a details page
        //     }
        //
        //     // If model is not valid, return the same view with validation messages
        //     return View(model);
        // }
        //
        //
        
        
        
        
        
        
        
        
        
        
        

        // GET: CoffeeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CoffeeController/Delete/5
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
