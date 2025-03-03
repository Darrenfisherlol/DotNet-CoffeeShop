
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class OrderController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        
        // get request to show index page
        // get request to show index page
        public IActionResult Index()
        {
            return View(_context.Orders.ToList());
        }
        
        // get request to show create page
        public IActionResult Create()
        {
            return View();
        }
        
        // post request to edit data
        public async Task<IActionResult> CreateOrderForm(Order model)
        {
            _context.Orders.Add(model);
            await _context.SaveChangesAsync();
            
            ViewBag.Message = "Order created successfully";
            
            return RedirectToAction("Index");
        }

        // get request to showcase Order specific data
        public async Task<IActionResult> Detail(int? id)
        {
            var order = await _context.Orders.FindAsync(id);

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
        public async Task<IActionResult> EditOrder(Order model)
        {
            _context.Orders.Update(model);
            await _context.SaveChangesAsync();
            
            return RedirectToAction("Index");
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
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var order =  await _context.Orders.FindAsync(id);
            
            if (order == null)
            {
                return NotFound();
            }
            
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
