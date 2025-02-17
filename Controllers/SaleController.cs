using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class SaleController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        
        // get request to show index page
        public IActionResult Index()
        {
            return View(_context.Sales.ToList());
        }
        
        // get request to show create page
        public IActionResult Create()
        {
            return View();
        }
        
        // post request to edit data
        public async Task<IActionResult> CreateSaleForm(Sale model)
        {
            _context.Sales.Add(model);
            await _context.SaveChangesAsync();
            
            ViewBag.Message = "Sale created successfully";
            
            return RedirectToAction("Index");
        }

        // get request to showcase Sale specific data
        public async Task<IActionResult> Detail(int? id)
        {
            var sale = await _context.Sales.FindAsync(id);

            if (sale == null)
            {
                return NotFound();
            }
            
            return View(sale);
        }
        
        // get request to showcasce model data
        public async Task<IActionResult> Edit(int id)
        {
            var sale = await _context.Sales.FindAsync(id);
            
            return View(sale);
        }
        
        // post request to push changes to db
        public async Task<IActionResult> EditCustomer(Sale model)
        {
            _context.Sales.Update(model);
            await _context.SaveChangesAsync();
            
            return RedirectToAction("Index");
        }
        
        // get request to get to the delete page with model filled in
        public async Task<IActionResult> Delete(int id)
        {
            var sale = await _context.Sales.FindAsync(id);

            if (sale == null)
            {
                return NotFound();
            }
            
            return View(sale);
        }
        
        // post request to push changes to db
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var sale =  await _context.Sales.FindAsync(id);
            
            if (sale == null)
            {
                return NotFound();
            }
            
            _context.Sales.Remove(sale);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
