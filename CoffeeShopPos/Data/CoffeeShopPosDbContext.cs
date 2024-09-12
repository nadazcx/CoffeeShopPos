using CoffeeShopPos.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShopPos.Data;

public class CoffeeShopPosDbContext : DbContext
{

    public CoffeeShopPosDbContext(DbContextOptions<CoffeeShopPosDbContext> options)
        : base(options)
    {
    }

    public DbSet<Category> Category { get; set; }
    public DbSet<Product> Product { get; set; }
}