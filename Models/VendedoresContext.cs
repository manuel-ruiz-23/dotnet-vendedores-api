using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Vendedores.Models
{
 public class VendedoresContext : DbContext
 {
     public DbSet<Vendedor> Vendedores { get; set; }
     public DbSet<Producto> Productos { get; set; }

     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
     {
         optionsBuilder.UseSqlite("Data Source=vendedores.db");
     }
 }   
}