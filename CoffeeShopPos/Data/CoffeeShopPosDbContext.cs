using Microsoft.EntityFrameworkCore;

namespace CoffeeShopPos.Data;

public class CoffeeShopPosDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Database=CoffeeShopPos;Username=postgres;Password=nada");
    }

}