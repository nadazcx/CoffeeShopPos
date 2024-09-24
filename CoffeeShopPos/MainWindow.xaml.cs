using System.Windows;
using CoffeeShopPos.Data;
using CoffeeShopPos.Helpers;
using CoffeeShopPos.Models;
using CoffeeShopPos.Repositories;
using CoffeeShopPos.Services;
using CoffeeShopPos.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShopPos
{
    public partial class MainWindow : Window
    {
        private MainViewModel _mainViewModel;

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

            _mainViewModel = new MainViewModel(categoryViewModel, productViewModel);

            DataContext = _mainViewModel;

            categoryViewModel.LoadCategoriesCommand.Execute(null);
            productViewModel.LoadProductsCommand.Execute(null);
        }

        private void ListView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
        }

        private void ListView_SelectionChanged_1(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}
