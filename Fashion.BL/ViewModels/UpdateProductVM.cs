using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Fashion.BL.ViewModels;

public class UpdateProductVM
{
    public IFormFile? ImgFile { get; set; }

    public int Id { get; set; }

    public string Name { get; set; }
    public string ShortDescription { get; set; }
    public double Price { get; set; }
}
