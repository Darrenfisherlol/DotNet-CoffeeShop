using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class OrderController : Controller
    {
        private CoffeeContext _context = new CoffeeContext();

        // GET: Order/Index
        public ActionResult Index()
        {
            return View();
        }

       
    }
}
