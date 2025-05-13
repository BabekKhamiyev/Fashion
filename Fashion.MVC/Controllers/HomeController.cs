using Fashion.DAL.Contexts;
using Fashion.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fashion.MVC.Controllers
{
	public class HomeController : Controller
	{
		private readonly AppDbContext _context;
        public HomeController()
        {
            _context = new AppDbContext();
        }
        public IActionResult Index()
		{
			List<Product> product= _context.Products.ToList();
			return View(product);
		}
	}
}
