using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using CoffeeShopPos.Helpers.Generic;
using CoffeeShopPos.Models;
using CoffeeShopPos.Services;

namespace CoffeeShopPos.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly ProductViewModel _productsViewModel;
        private readonly CategoryViewModel _categoriesViewModel;
        private string _selectedCategoryTitle;

        public CategoryViewModel CategoriesViewModel => _categoriesViewModel;
        public ProductViewModel ProductsViewModel => _productsViewModel;

        private ObservableCollection<OrderItem> _orderItems;
        public ObservableCollection<OrderItem> OrderItems
        {
            get => _orderItems;
            set
            {
                _orderItems = value;
                OnPropertyChanged(nameof(OrderItems));
            }
        }

        public ICommand AddProductToOrderCommand { get; }
        public ICommand RemoveProductFromOrderCommand { get; }
        public ICommand IncrementQuantityCommand { get; }
        public ICommand DecrementQuantityCommand { get; }
        public ICommand DeleteProductFromOrderCommand { get; }

        // Parameterless constructor for design-time data
        public MainViewModel() : this(new CategoryViewModel(), new ProductViewModel())
        {
            LoadFakeData();
        }

        public MainViewModel(CategoryViewModel categoryViewModel, ProductViewModel productViewModel)
        {
            _categoriesViewModel = categoryViewModel;
            _productsViewModel = productViewModel;

            OrderItems = new ObservableCollection<OrderItem>();

            AddProductToOrderCommand = new RelayCommand<Product>(AddProductToOrder);
            RemoveProductFromOrderCommand = new RelayCommand<Product>(RemoveProductFromOrder);
            IncrementQuantityCommand = new RelayCommand<OrderItem>(IncrementQuantity);
            DecrementQuantityCommand = new RelayCommand<OrderItem>(DecrementQuantity);
            DeleteProductFromOrderCommand = new RelayCommand<OrderItem>(item => OrderItems.Remove(item));

            // Subscribe to the CategorySelected event
            _categoriesViewModel.CategorySelected += OnCategorySelected;
        }

        public string SelectedCategoryTitle
        {
            get => _selectedCategoryTitle;
            set
            {
                _selectedCategoryTitle = value;
                OnPropertyChanged(nameof(SelectedCategoryTitle));
            }
        }

        private void OnCategorySelected(Category category)
        {
            SelectedCategoryTitle = category.Name; // Assuming Category has a Name property
        }

        private void LoadFakeData()
        {
            // Example of fake products
            _productsViewModel.Products = new ObservableCollection<Product>
            {
                new Product { Id = 1, Name = "Espresso", Price = 300 },
                new Product { Id = 2, Name = "Latte", Price = 450 },
                new Product { Id = 3, Name = "Cappuccino", Price = 400 },
                new Product { Id = 5, Name = "Coffee", Price = 400 }
            };

            // Example of fake categories
            _categoriesViewModel.Categories = new ObservableCollection<Category>
            {
                new Category { Id = 1, Name = "Coffee" },
                new Category { Id = 2, Name = "Tea" }
            };
        }

        private void AddProductToOrder(Product product)
        {
            var existingItem = OrderItems.FirstOrDefault(i => i.Product.Id == product.Id);
            if (existingItem != null)
            {
                existingItem.Quantity += 1;
            }
            else
            {
                var newItem = new OrderItem
                {
                    Product = product,
                    Quantity = 1,
                };
                OrderItems.Add(newItem);
            }

            OnPropertyChanged(nameof(OrderItems));
        }

        private void RemoveProductFromOrder(Product product)
        {
            var existingItem = OrderItems.FirstOrDefault(i => i.Product.Id == product.Id);
            if (existingItem != null)
            {
                if (existingItem.Quantity > 1)
                {
                    existingItem.Quantity -= 1;
                }
                else
                {
                    OrderItems.Remove(existingItem);
                }
            }

            OnPropertyChanged(nameof(OrderItems));
        }

        private void IncrementQuantity(OrderItem item)
        {
            var existingItem = OrderItems.FirstOrDefault(i => i.Product.Id == item.Product.Id);
            if (existingItem != null)
            {
                existingItem.Quantity += 1;
            }
        }

        private void DecrementQuantity(OrderItem item)
        {
            var existingItem = OrderItems.FirstOrDefault(i => i.Product.Id == item.Product.Id);
            if (existingItem != null)
            {
                if (existingItem.Quantity > 1)
                {
                    existingItem.Quantity -= 1; // This will automatically trigger TotalPrice update
                }
                else
                {
                    OrderItems.Remove(existingItem);
                }
            }
        }

        public int GetProductQuantity(Product product)
        {
            var existingItem = OrderItems.FirstOrDefault(i => i.Product.Id == product.Id);
            return existingItem != null ? existingItem.Quantity : 0;
        }
    }
}
