using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using CoffeeShopPos.Helpers;
using CoffeeShopPos.Helpers.Generic;
using CoffeeShopPos.Models;
using CoffeeShopPos.Services;

namespace CoffeeShopPos.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        private int _quantity;
        private ObservableCollection<OrderItem> _orderItems;
        private readonly ProductService _productService;
        private Product _selectedProduct;
        private ObservableCollection<Product> _products;
        private bool _isLoading;
        public ICommand LoadProductsCommand { get; }
        public ICommand LoadProductsByCategoryCommand { get; }
        public ICommand AddProductToOrderCommand { get; }
        public ICommand IncrementQuantityCommand { get; }
        public ICommand DecrementQuantityCommand { get; }


        public ProductViewModel(ProductService productService)
        {
            _productService = productService;
            _products = new ObservableCollection<Product>();
            _orderItems = new ObservableCollection<OrderItem>();

            LoadProductsCommand = new RelayCommand(async () => await LoadProductsAsync());
            LoadProductsByCategoryCommand = new RelayCommand<int>(async categoryId => await LoadProductsByCategoryAsync(categoryId));
      
        }

        public ProductViewModel()
        {
        }

        public ObservableCollection<Product> Products
        {
            get => _products;
            set
            {
                _products = value;
                OnPropertyChanged(nameof(Products));
            }
        }

        public ObservableCollection<OrderItem> OrderItems
        {
            get => _orderItems;
            set
            {
                _orderItems = value;
                OnPropertyChanged(nameof(OrderItems));
            }
        }

        public int Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }

        public Product SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }

     
        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }

        private async Task LoadProductsAsync()
        {
            IsLoading = true;
            try
            {
                var products = await _productService.GetProductsAsync();
                Products.Clear();
                foreach (var product in products)
                {
                    Products.Add(product);
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                IsLoading = false;
            }
        }

        public async Task LoadProductsByCategoryAsync(int categoryId)
        {
            IsLoading = true;
            var products = await _productService.GetProductByCategoryAsync(categoryId);
            Products.Clear();
            foreach (var product in products)
            {
                Products.Add(product);
            }
            IsLoading = false;
        }




        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
