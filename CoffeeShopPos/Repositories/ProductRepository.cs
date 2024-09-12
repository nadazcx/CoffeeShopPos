using CoffeeShopPos.Models;
using CoffeeShopPos.Data;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShopPos.Repositories;

public class ProductRepository
{
    private readonly CoffeeShopPosDbContext _context;
    public ProductRepository(CoffeeShopPosDbContext context)
    {
        _context = context;
    }
    // Retieve all products
    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        return await _context.Product.ToListAsync();
    }
    // Retrieve a product by ID
    public async Task<Product> GetProductByIdAsync(int id)
    {
        return await _context.Product.FindAsync(id);
    }
    // Get Product by Category
    public async Task<IEnumerable<Product>> GetProductByCategoryAsync(int categoryId)
    {
        return await _context.Product.Where(p => p.CategoryId == categoryId).ToListAsync();
    }
    // Add a new product
    public async Task AddProductAsync(Product product)
    {
        _context.Product.Add(product);
        await _context.SaveChangesAsync();
    }
    // Update an existing product
    public async Task UpdateProductAsync(Product product)
    {
        _context.Product.Update(product);
        await _context.SaveChangesAsync();
    }
    // Delete a product by ID
    public async Task DeleteProductAsync(int id)
    {
        var product = await _context.Product.FindAsync(id);
        if (product != null)
        {
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
        }
    }


}