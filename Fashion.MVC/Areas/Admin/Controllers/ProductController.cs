using Fashion.BL.Services;
using Fashion.BL.ViewModels;
using Fashion.DAL.Models;
using Fashion.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Fashion.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        ProductService productService;
        public ProductController()
        {
            productService = new ProductService();
        }
        public IActionResult Index()
        {
            List<Product> products = productService.GetAllProducts();
            return View(products);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateaProductVM proVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("problemin var");
            }
            productService.Create(proVM);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Product product = productService.GetProductById(id);

            UpdateProductVM vm = new UpdateProductVM
            {
                Id = product.Id,
                Name = product.Name,
                ShortDescription = product.ShortDescription,
                Price = product.Price
            };
            return View(vm);
        }
        [HttpPost]
        public IActionResult Update(int id, UpdateProductVM product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("problemin var");
            }
            productService.Update(id, product);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            productService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Info(int id)
        {
            Product product=productService.GetProductById(id);
            return View(product);
        }
    }
}
