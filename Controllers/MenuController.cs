using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class MenuController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext(); 
        
        public ActionResult Index()
        {
            return View();
        }
    }
}
