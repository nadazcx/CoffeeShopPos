using CoffeeShopPos.Models;
using CoffeeShopPos.Repositories;

namespace CoffeeShopPos.Services;

public class ProductService
{
    private readonly ProductRepository _productRepository;
    public ProductService(ProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        return await _productRepository.GetAllProductsAsync();
    }
    public async Task<Product> GetProductByIdAsync(int id)
    {
        return await _productRepository.GetProductByIdAsync(id);
    }

    public async Task<IEnumerable<Product>> GetProductByCategoryAsync(int categoryId)
    {
        return await _productRepository.GetProductByCategoryAsync(categoryId);
    }
    public async Task AddProductAsync(Product product)
    {
        // Business logic or validation can be added here
        await _productRepository.AddProductAsync(product);
    }
    public async Task UpdateProductAsync(Product product)
    {
        // Business logic or validation can be added here
        await _productRepository.UpdateProductAsync(product);
    }
    public async Task DeleteProductAsync(int id)
    {
        // Business logic or validation can be added here
        await _productRepository.DeleteProductAsync(id);
    }

}