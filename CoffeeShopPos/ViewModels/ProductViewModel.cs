using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using CoffeeShopPos.Helpers;
using CoffeeShopPos.Models;
using CoffeeShopPos.Services;

namespace CoffeeShopPos.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        private readonly ProductService _productService;
        private Product _selectedProduct;
        private ObservableCollection<Product> _products;
        private bool _isLoading;

        public ProductViewModel(ProductService productService)
        {
            _productService = productService;
            _products = new ObservableCollection<Product>();
            LoadProductsCommand = new RelayCommand(async () => await LoadProductsAsync());
            AddProductCommand = new RelayCommand(async () => await AddProductAsync());
            UpdateProductCommand = new RelayCommand(async () => await UpdateProductAsync());
            DeleteProductCommand = new RelayCommand(async () => await DeleteProductAsync());
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

        public Product SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }

        public ICommand LoadProductsCommand { get; }
        public ICommand AddProductCommand { get; }
        public ICommand UpdateProductCommand { get; }
        public ICommand DeleteProductCommand { get; }

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
            var products = await _productService.GetProductsAsync();
            Products.Clear();
            foreach (var product in products)
            {
                Products.Add(product);
            }
            IsLoading = false;
        }

        private async Task AddProductAsync()
        {
            if (SelectedProduct != null)
            {
                await _productService.AddProductAsync(SelectedProduct);
                await LoadProductsAsync();
            }
        }

        private async Task UpdateProductAsync()
        {
            if (SelectedProduct != null)
            {
                await _productService.UpdateProductAsync(SelectedProduct);
                await LoadProductsAsync();
            }
        }

        private async Task DeleteProductAsync()
        {
            if (SelectedProduct != null)
            {
                await _productService.DeleteProductAsync(SelectedProduct.Id);
                await LoadProductsAsync();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged; // Allow null

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
