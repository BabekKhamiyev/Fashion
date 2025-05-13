using Microsoft.AspNetCore.Mvc;

namespace Fashion.MVC.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
