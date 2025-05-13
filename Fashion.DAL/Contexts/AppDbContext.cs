using Fashion.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fashion.DAL.Contexts;

public class AppDbContext:DbContext
{
    private readonly string _connectionString= @"Server=DESKTOP-GTVND9D\SQLEXPRESS;Database=FashionDb;Trusted_Connection=True;TrustServerCertificate=True";


    public DbSet<Product> Products { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString);
        base.OnConfiguring(optionsBuilder);
    }

}
