using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fashion.DAL.Models;

public class Product:BaseModel
{
    public string Imgurl { get; set; }
    public string Name { get; set; }
    public string ShortDescription { get; set; }
    public double Price     { get; set; }
}
