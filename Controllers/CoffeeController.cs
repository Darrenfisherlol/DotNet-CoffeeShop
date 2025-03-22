using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class CoffeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CoffeeController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        // get request to show index page
        public IActionResult Index()
        {
            return View(_context.Coffees.ToList());
        }
        
        // get request to show create page
        public IActionResult Create()
        {
            return View();
        }
        
        // post request to push new coffee to db
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCoffeeForm(Coffee coffee)
        {

            if (ModelState.IsValid)
            {
                _context.Coffees.Add(coffee);
                await _context.SaveChangesAsync();

                TempData["Message"] = "Coffee created successfully";

                return RedirectToAction("Index");
            }
            
            TempData["Message"] = "Coffee was not created successfully";
            return View("Create", coffee);
        }
        
        // get request to get coffee detail
        public async Task<ActionResult> Detail(int? id)
        {
            var coffee = await _context.Coffees.FindAsync(id);

            if (coffee == null)
            {
                return NotFound();
            }
            
            return View(coffee);
        }
        
        // get request to retrieve data to edit page
        public async Task<ActionResult> Edit(int? id)
        {
            var coffee = await _context.Coffees.FindAsync(id);

            if (coffee == null)
            {
                return NotFound();
            }
            
            return View(coffee);
        }
        
        // post request to push changes to db
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditCoffee(Coffee coffee)
        {
            _context.Coffees.Update(coffee);
            await _context.SaveChangesAsync();
            
            return RedirectToAction("Index");
        }
        
        // get request to populate delete page
        public async Task<ActionResult> Delete(int? id)
        {
            var coffee = await _context.Coffees.FindAsync(id);
            
            if (coffee == null)
            {
                return NotFound();
            }
            
            return View(coffee);
        }
        
        // post request to edit db to remove coffee
        [HttpPost, ActionName("DeleteConfirm")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var coffee =  await _context.Coffees.FindAsync(id);
            
            if (coffee == null)
            {
                return NotFound();
            }
            
            _context.Coffees.Remove(coffee);
            await _context.SaveChangesAsync();
            TempData["Message"] = "Coffee deleted successfully";

            return RedirectToAction("Index");
        }
    }
}
