using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class CustomerController : Controller
    {
        
        private readonly ApplicationDbContext _context;

        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        // get request to show index page
        public IActionResult Index()
        {
            return View(_context.Customers.ToList());
        }
        
        // get request to show create page
        public IActionResult Create()
        {
            return View();
        }
        
        // post request to edit data
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCustomerForm(Customer model)
        {

            if (ModelState.IsValid)
            {
                _context.Customers.Add(model);
                await _context.SaveChangesAsync();

                TempData["Message"] = "Customer created successfully";

                return RedirectToAction("Index");
            }
            
            TempData["Message"] = "Customer was not created successfully";
            return View("Create", model);
        }

        // get request to showcase customer specific data
        public async Task<IActionResult> Detail(int? id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }
            
            return View(customer);
        }
        
        // get request to showcasce model data
        public async Task<IActionResult> Edit(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            
            if (customer == null)
            {
                return NotFound();
            }
            
            return View(customer);
        }
        
        // post request to push changes to db
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCustomer(Customer model)
        {
            _context.Customers.Update(model);
            await _context.SaveChangesAsync();
            
            return RedirectToAction("Index");
        }
        
        // get request to get to the delete page with model filled in
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }
            
            return View(customer);
        }
        
        // post request to push changes to db
        [HttpPost, ActionName("DeleteConfirm")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var customer =  await _context.Customers.FindAsync(id);
            
            if (customer == null)
            {
                return NotFound();
            }
            
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            TempData["Message"] = "Customer deleted successfully";
            
            return RedirectToAction("Index");
        }
    }
}
