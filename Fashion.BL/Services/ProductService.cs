﻿using Fashion.BL.Exceptions;
using Fashion.BL.ViewModels;
using Fashion.DAL.Contexts;
using Fashion.DAL.Models;
using Fashion.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Fashion.BL.Services;

public class ProductService
{
    private readonly AppDbContext _context;
    public ProductService()
    {
        _context = new AppDbContext();
    }




    #region Create

    public void Create(CreateaProductVM pro)
    {
        Product product =new Product();
        product.Name = pro.Name;
        product.Price = pro.Price;
        product.ShortDescription = pro.ShortDescription;


        string fileName = Path.GetFileNameWithoutExtension(pro.ImgFile.FileName);
        string extension = Path.GetExtension(pro.ImgFile.FileName);
        string resultName = fileName + Guid.NewGuid().ToString() + extension;

        string uploadedPath = $"C:\\Users\\User\\Desktop\\Fashion\\Fashion.MVC\\wwwroot\\assets\\UploadedImages";

        uploadedPath = Path.Combine(uploadedPath, resultName);
        using FileStream stream = new FileStream(uploadedPath, FileMode.Create);
        pro.ImgFile.CopyTo(stream);
        product.Imgurl = resultName;



        _context.Products.Add(product);
        _context.SaveChanges();

    }
    #endregion




    #region Read

    public Product GetProductById(int id)
    {
        Product? pro = _context.Products.Find(id);
        if (pro is null)
        {
            throw new ProductException($"database de {id} idli data yoxdu");

        }
        return pro;
    }






    public List<Product> GetAllProducts()
    {
        List<Product> products = _context.Products.ToList();
        return products;
    }
    #endregion



    #region Update

    public void Update(int id, UpdateProductVM pro)
    {
       
        Product? basepro = _context.Products.Find(id);
        if (basepro is null)
        {
            throw new ProductException($"database de {id} idli data yoxdu");
        }
        basepro.ShortDescription = pro.ShortDescription;
        basepro.Price = pro.Price;
        basepro.Name = pro.Name;

        if (pro.ImgFile != null)
        {
            string fileName = Path.GetFileNameWithoutExtension(pro.ImgFile.FileName);
            string extension = Path.GetExtension(pro.ImgFile.FileName);
            string resultName = fileName + Guid.NewGuid().ToString() + extension;

            string uploadedPath = $"C:\\Users\\User\\Desktop\\Fashion\\Fashion.MVC\\wwwroot\\assets\\UploadedImages";

            uploadedPath = Path.Combine(uploadedPath, resultName);
            using FileStream stream = new FileStream(uploadedPath, FileMode.Create);
            pro.ImgFile.CopyTo(stream);
            basepro.Imgurl = resultName;
        }
        _context.SaveChanges();
    }
    #endregion

    #region Delete
    public void Delete(int id)
    {
        Product? pro = _context.Products.Find(id);
        if (pro is null)
        {
            throw new ProductException($"database de {id} idli data yoxdu");
        }
        _context.Products.Remove(pro);
        _context.SaveChanges();
    }

    #endregion

}
