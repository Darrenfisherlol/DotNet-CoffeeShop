using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class OrderDetailController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderDetailController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.OrderDetails.ToList());
        }
        
        // get request to show create page
        public IActionResult Create()
        {
            ViewBag.Order = new SelectList(_context.Orders
                .OrderBy(x => x.OrderDate)
                .Take(10)
                .Select(x => new 
            {
                x.OrderId
            }), "OrderId", "OrderId");
            
            ViewBag.MenuItem = new SelectList(_context.MenuItems.Select(x => new 
            {
                x.MenuItemId,
                x.Name,
            }), "MenuItemId", "Name");
            
            return View();
        }
        
        // post request to edit data
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrderDetailForm(OrderDetail model)
        {

            if (ModelState.IsValid)
            {
                
                _context.OrderDetails.Add(model);
                await _context.SaveChangesAsync();

                TempData["Message"] = "OrderDetail created successfully";

                return RedirectToAction("Index");
            }
            
            TempData["Message"] = "OrderDetail was not created successfully";
            return View("Create", model);
        }

        // get request to showcase OrderDetail specific data
        public async Task<IActionResult> Detail(int? id)
        {
            var orderDetail = await _context.OrderDetails.FindAsync(id);

            if (orderDetail == null)
            {
                return NotFound();
            }
            
            return View(orderDetail);
        }
        
        // get request to showcasce model data
        public async Task<IActionResult> Edit(int id)
        {
            var orderDetail = await _context.OrderDetails.FindAsync(id);
            
            if (orderDetail == null)
            {
                return NotFound();
            }
            
            return View(orderDetail);
        }
        
        // post request to push changes to db
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditOrder(OrderDetail model)
        {
            _context.OrderDetails.Update(model);
            await _context.SaveChangesAsync();
            
            return RedirectToAction("Index");
        }
        
        // get request to get to the delete page with model filled in
        public async Task<IActionResult> Delete(int id)
        {
            var orderDetail = await _context.OrderDetails.FindAsync(id);

            if (orderDetail == null)
            {
                return NotFound();
            }
            
            return View(orderDetail);
        }
        
        // post request to push changes to db
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var orderDetail =  await _context.OrderDetails.FindAsync(id);
            
            if (orderDetail == null)
            {
                return NotFound();
            }
            
            _context.OrderDetails.Remove(orderDetail);
            await _context.SaveChangesAsync();
            TempData["Message"] = "OrderDetail deleted successfully";

            return RedirectToAction("Index");
        }
    }
}
