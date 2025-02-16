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
        
        public IActionResult Delete(int id)
        {
            var customerId =  _context.Customers.SingleOrDefault(x => x.Id == id);
            
            // if customer ID does not exist, send pop up saying does not exist
            if (customerId == null)
            {
                return NotFound();
            }
            
            _context.Customers.Remove(customerId);
            _context.SaveChangesAsync();

            return RedirectToAction("Customers");
        }

        public IActionResult Edit(Customer model)
        {
        
            _context.Customers.Update(model);
            
            _context.SaveChanges();
            
            return RedirectToAction("Customers");
        }
    }
}
