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
    }
}
