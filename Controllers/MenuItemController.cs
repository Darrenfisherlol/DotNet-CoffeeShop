using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class MenuItemController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext(); 
        
        // get request to show index page
           public IActionResult Index()
        {
            return View(_context.MenuItems.ToList());
        }
        
        // get request to show create page
        public IActionResult Create()
        {
            return View();
        }
        
        // post request to edit data
        public async Task<IActionResult> CreateMenuItemForm(MenuItem model)
        {
            _context.MenuItems.Add(model);
            await _context.SaveChangesAsync();
            
            ViewBag.Message = "menuItem created successfully";
            
            return RedirectToAction("Index");
        }

        // get request to showcase menuItem specific data
        public async Task<IActionResult> Detail(int? id)
        {
            var menuItem = await _context.MenuItems.FindAsync(id);

            if (menuItem == null)
            {
                return NotFound();
            }
            
            return View(menuItem);
        }
        
        // get request to showcasce model data
        public async Task<IActionResult> Edit(int id)
        {
            var menuItem = await _context.MenuItems.FindAsync(id);
            
            if (menuItem == null)
            {
                return NotFound();
            }
            
            return View(menuItem);
        }
        
        // post request to push changes to db
        public async Task<IActionResult> EditOrder(MenuItem model)
        {
            _context.MenuItems.Update(model);
            await _context.SaveChangesAsync();
            
            return RedirectToAction("Index");
        }
        
        // get request to get to the delete page with model filled in
        public async Task<IActionResult> Delete(int id)
        {
            var menuItem = await _context.MenuItems.FindAsync(id);

            if (menuItem == null)
            {
                return NotFound();
            }
            
            return View(menuItem);
        }
        
        // post request to push changes to db
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var menuItem =  await _context.MenuItems.FindAsync(id);
            
            if (menuItem == null)
            {
                return NotFound();
            }
            
            _context.MenuItems.Remove(menuItem);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
