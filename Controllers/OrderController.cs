using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class OrderController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        
        // get request to show index page
        public IActionResult Index()
        {
            return View(_context.OrderDetails.ToList());
        }
    }
}
