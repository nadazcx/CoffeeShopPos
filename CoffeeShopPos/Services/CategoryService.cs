using CoffeeShopPos.Models;
using CoffeeShopPos.Repositories;
using global::CoffeeShopPos.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeShopPos.Services
{
    public class CategoryService
    {
        private readonly CategoryRepository _categoryRepository;

        public CategoryService(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _categoryRepository.GetAllCategoriesAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _categoryRepository.GetCategoryByIdAsync(id);
        }

        public async Task AddCategoryAsync(Category category)
        {
            // Business logic or validation can be added here
            await _categoryRepository.AddCategoryAsync(category);
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            // Business logic or validation can be added here
            await _categoryRepository.UpdateCategoryAsync(category);
        }

        public async Task DeleteCategoryAsync(int id)
        {
            // Business logic or validation can be added here
            await _categoryRepository.DeleteCategoryAsync(id);
        }
    }
}
