using System.Windows;
using CoffeeShopPos.Data;
using CoffeeShopPos.Helpers;
using CoffeeShopPos.Repositories;
using CoffeeShopPos.Services;
using CoffeeShopPos.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShopPos
{
    public partial class MainWindow : Window
    {
        private readonly ProductViewModel _productViewModel;
        private readonly CategoryViewModel _categoryViewModel;

        public MainWindow()
        {
            InitializeComponent();

            // Set up the ProductViewModel
            var connectionString = Helper.CnnVal("DefaultConnection");
            var optionsBuilder = new DbContextOptionsBuilder<CoffeeShopPosDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            // Create separate DbContext instances
            var categoryDbContext = new CoffeeShopPosDbContext(optionsBuilder.Options);

            var productDbContext = new CoffeeShopPosDbContext(optionsBuilder.Options);
            var categoryRepository = new CategoryRepository(categoryDbContext);
            var categoryService = new CategoryService(categoryRepository);

            var productRepository = new ProductRepository(productDbContext);
            var productService = new ProductService(productRepository);

            _categoryViewModel = new CategoryViewModel(categoryService);

            _productViewModel = new ProductViewModel(productService);

            // Set DataContext for the window
            DataContext = new
            {
                CategoriesViewModel = _categoryViewModel,

                ProductsViewModel = _productViewModel
            };

            // Load data
            _categoryViewModel.LoadCategoriesCommand.Execute(null);

            _productViewModel.LoadProductsCommand.Execute(null);
        }
    }

}