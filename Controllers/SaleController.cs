using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class SaleController : Controller
    {
        private SaleContext _context = new SaleContext();

        
        // GET: Sale/CustomerHub
        public ActionResult CustomerHub()
        {
            return View();
        }

        // GET: Sale/Details
        public ActionResult Details(int id)
        {
            ViewBag.User = _context.Sale.FirstOrDefault();
            return View(_context.Sale.ToList());
        }

        // GET: Sale/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sale/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, UserId, CoffeeId, Quantity, OrderDateTime")] Sale saleInput)
        {
            if (ModelState.IsValid)
            {
                _context.Add(saleInput);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details));
            }

            // Return the view with validation errors if any
            return View(saleInput);
        }

        // GET: Sale/Edit
        public ActionResult Delete()
        {
            return View();
        }

        // POST: Sale/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var saleId = await _context.Sale.FindAsync(id);

            if (saleId == null)
            {
                TempData["ErrorMessage"] = "The specified ID does not exist.";
                return RedirectToAction(nameof(Delete));
            }

            _context.Sale.Remove(saleId);
            await _context.SaveChangesAsync();
            
            
            return RedirectToAction(nameof(Details));
        }
        //GET: Sale/Edit
        public async Task<IActionResult>  Edit(int? Id)
        {
            Sale sale = null;

            if (Id != null)
            {
                sale = await _context.Sale.FindAsync(Id);
                
                if (sale == null)
                {
                    TempData["ErrorMessage"] = "The specified ID does not exist.";
                    return RedirectToAction(nameof(Edit));
                }
            }
            
            
            return View(sale);   
        }
        
        // POST: Sale/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Sale saleInput)
        {
            if (id != saleInput.Id || id.HasValue)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(saleInput);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details));
            }
            return View(saleInput);
        }
    
    }
}
