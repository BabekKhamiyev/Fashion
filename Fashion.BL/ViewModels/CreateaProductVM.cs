using Microsoft.AspNetCore.Http;

namespace Fashion.MVC.ViewModels
{
    public class CreateaProductVM
    {
        public IFormFile? ImgFile { get; set; }

        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public double Price { get; set; }

    }
}
