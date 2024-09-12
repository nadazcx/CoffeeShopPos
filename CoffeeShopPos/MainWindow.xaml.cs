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
        public MainWindow()
        {
            InitializeComponent();

            // Set up the services and view models
            var connectionString = Helper.CnnVal("DefaultConnection");
            var optionsBuilder = new DbContextOptionsBuilder<CoffeeShopPosDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            var categoryDbContext = new CoffeeShopPosDbContext(optionsBuilder.Options);
            var productDbContext = new CoffeeShopPosDbContext(optionsBuilder.Options);
            var categoryRepository = new CategoryRepository(categoryDbContext);
            var categoryService = new CategoryService(categoryRepository);
            var productRepository = new ProductRepository(productDbContext);
            var productService = new ProductService(productRepository);

            var productViewModel = new ProductViewModel(productService);
            var categoryViewModel = new CategoryViewModel(categoryService, productViewModel);

            var mainViewModel = new MainViewModel(categoryViewModel, productViewModel);

            DataContext = mainViewModel;

            categoryViewModel.LoadCategoriesCommand.Execute(null);
        }
    }

}