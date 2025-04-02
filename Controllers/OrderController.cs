
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        // get request to show index page
        public async Task<IActionResult> Index()
        {
            var orders = await _context.Orders.ToListAsync();
            return View(orders);
        }
        
        // get request to show create page
        public IActionResult Create()
        {
            ViewBag.Customers = new SelectList(_context.Customers
                .OrderBy(x=> x.JoinDate)
                .Take(10)
                .Select(c => new 
            {
                c.CustomerId,
                FullName = c.FirstName + " " + c.LastName
            }), "CustomerId", "FullName");
            
            return View();
        }
        
        // post request to edit data
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrderForm([Bind("CustomerId,OrderDate")] Order model)
        {
           
            if (ModelState.IsValid)
            {
                model.OrderDate = model.OrderDate.ToUniversalTime();
                
                _context.Orders.Add(model);
                await _context.SaveChangesAsync();

                TempData["Message"] = "Order created successfully";
               
                return RedirectToAction("Index");
            }
            
            TempData["Message"] = "Order was not created successfully";
            return View("Create", model);
        }
        
        
        
        // -------------------
        
        // get request to showcase Order specific data
        public async Task<IActionResult> Detail(int? id)
        {
            var order = await _context.Orders
                .Include(o => o.Customer)
                .FirstOrDefaultAsync(o => o.OrderId == id);

            if (order == null)
            {
                return NotFound();
            }
            
            return View(order);
        }
        
        // get request to showcasce model data
        public async Task<IActionResult> Edit(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            
            if (order == null)
            {
                return NotFound();
            }
            
            return View(order);
        }
        
        // post request to push changes to db
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditOrder(Order model)
        {
            if (ModelState.IsValid)
            {
                _context.Orders.Update(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            
            TempData["Message"] = "Error updating model";
            return RedirectToAction("Edit");
        }
        
        // get request to get to the delete page with model filled in
        public async Task<IActionResult> Delete(int id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }
            
            return View(order);
        }
        
        // post request to push changes to db
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var order =  await _context.Orders.FindAsync(id);
            
            if (order == null)
            {
                return NotFound();
            }
            
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            TempData["Message"] = "Order deleted successfully";
            
            return RedirectToAction("Index");
        }
    }
}
