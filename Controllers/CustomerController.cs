using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class CustomerController : Controller
    {
        private CustomerContext _context = new CustomerContext();

        
        // GET: Customer/CustomerHub
        public ActionResult CustomerHub()
        {
            return View();
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.User = _context.Customers.FirstOrDefault();
            return View(_context.Customers.ToList());
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, FirstName, LastName, Email, Phone")] Customer customerInput)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customerInput);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details));
            }

            // Return the view with validation errors if any
            return View(customerInput);
        }

        // GET: CustomerController/Edit
        public ActionResult Delete()
        {
            return View();
        }

        // POST: Coffee/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var customerId = await _context.Customers.FindAsync(id);

            if (customerId == null)
            {
                TempData["ErrorMessage"] = "The specified ID does not exist.";
                return RedirectToAction(nameof(Delete));
            }

            _context.Customers.Remove(customerId);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(CustomerHub));
        }
        //GET: Customer/Edit
        public async Task<IActionResult>  Edit(int? Id)
        {
            Customer customer = null;

            if (Id != null)
            {
                customer = await _context.Customers.FindAsync(Id);
                
                if (customer == null)
                {
                    TempData["ErrorMessage"] = "The specified ID does not exist.";
                    return RedirectToAction(nameof(Edit));
                }
            }
            
            
            return View(customer);   
        }
        
        // POST: Coffee/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Customer customerInput)
        {
            if (id != customerInput.Id || id.HasValue)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(customerInput);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details));
            }
            return View(customerInput);
        }
    
    }
}
