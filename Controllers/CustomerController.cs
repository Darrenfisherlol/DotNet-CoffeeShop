using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        
        public ActionResult Customers()
        {
            return View(_context.Customers.ToList());
        }
        
        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> CreateCustomerForm(Customer model)
        {
            _context.Customers.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Customers");
        }
        
        // // POST: CustomerController/Create
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Create([Bind("Id, FistName, LastName, Email, Phone")] Customer customerInput)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         _context.Add(customerInput);
        //         await _context.SaveChangesAsync();
        //         return RedirectToAction("CustomerHub");
        //     }
        //
        //     // Return the view with validation errors if any
        //     return View(customerInput);
        // }
        
        // MUST delete form Customer view -> always has an ID
        public IActionResult Delete(int id)
        {
            
            var customerId =  _context.Customers.SingleOrDefault(x => x.Id == id);

            _context.Customers.Remove(customerId);
            _context.SaveChangesAsync();

            return RedirectToAction("Customers");
        }

        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Edit(int? id, Customer customerInput)
        // {
        //     if (id != customerInput.Id || id.HasValue)
        //     {
        //         return NotFound();
        //     }
        //
        //     if (ModelState.IsValid)
        //     {
        //         _context.Update(customerInput);
        //         await _context.SaveChangesAsync();
        //         return RedirectToAction("Customers");
        //     }
        //     return View(customerInput);
        // }

        public IActionResult Edit(Customer model)
        {
        
            _context.Customers.Update(model);
            
            _context.SaveChanges();
            
            return RedirectToAction("Customers");
        }
    }
}
