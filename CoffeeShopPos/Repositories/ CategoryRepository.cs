using CoffeeShopPos.Models;
using CoffeeShopPos.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeShopPos.Repositories
{
    public class CategoryRepository
    {
        private readonly CoffeeShopPosDbContext _context;


        public CategoryRepository(CoffeeShopPosDbContext context)
        {
            _context = context;
        }

        // Retrieve all categories
        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _context.Category.ToListAsync();
        }

        // Retrieve a category by ID
        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _context.Category.FindAsync(id);
        }

        // Add a new category
        public async Task AddCategoryAsync(Category category)
        {
            _context.Category.Add(category);
            await _context.SaveChangesAsync();
        }

        // Update an existing category
        public async Task UpdateCategoryAsync(Category category)
        {
            _context.Category.Update(category);
            await _context.SaveChangesAsync();
        }

        // Delete a category by ID
        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _context.Category.FindAsync(id);
            if (category != null)
            {
                _context.Category.Remove(category);
                await _context.SaveChangesAsync();
            }
        }
    }
}