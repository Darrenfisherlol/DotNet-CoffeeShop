using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class OrderDetailController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext(); 
        
        public IActionResult Index()
        {
            return View(_context.OrderDetails.ToList());
        }
        
        // get request to show create page
        public IActionResult Create()
        {
            return View();
        }
        
        // post request to edit data
        public async Task<IActionResult> CreateOrderForm(OrderDetail model)
        {
            _context.OrderDetails.Add(model);
            await _context.SaveChangesAsync();
            
            ViewBag.Message = "OrderDetail created successfully";
            
            return RedirectToAction("Index");
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
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var orderDetail =  await _context.OrderDetails.FindAsync(id);
            
            if (orderDetail == null)
            {
                return NotFound();
            }
            
            _context.OrderDetails.Remove(orderDetail);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
