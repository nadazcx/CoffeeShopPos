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
    public class CategoryViewModel : BaseViewModel
    {
        private readonly CategoryService _categoryService;
        private readonly ProductViewModel _productsViewModel;
        private ObservableCollection<Category> _categories;
        private Category _selectedCategory;
        private bool _isLoading;

        public CategoryViewModel(CategoryService categoryService, ProductViewModel productsViewModel)
        {
            _categoryService = categoryService;
            _productsViewModel = productsViewModel;
            _categories = new ObservableCollection<Category>();
            LoadCategoriesCommand = new RelayCommand(async () => await LoadCategoriesAsync());
            SelectCategoryCommand = new RelayCommand<Category>(async category => await SelectCategoryAsync(category));
        }

        public ObservableCollection<Category> Categories
        {
            get => _categories;
            set
            {
                _categories = value;
                OnPropertyChanged(nameof(Categories));
            }
        }

        public Category SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                _selectedCategory = value;
                OnPropertyChanged(nameof(SelectedCategory));
            }
        }

        public ICommand LoadCategoriesCommand { get; }
        public ICommand SelectCategoryCommand { get; }

        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }

        private async Task LoadCategoriesAsync()
        {
            IsLoading = true;
            var categories = await _categoryService.GetCategoriesAsync();
            Categories.Clear();
            foreach (var category in categories)
            {
                Categories.Add(category);
            }
            IsLoading = false;
        }

        private async Task SelectCategoryAsync(Category category)
        {
            if (category == null) return;
            SelectedCategory = category;
            await _productsViewModel.LoadProductsByCategoryAsync(category.Id);
        }
    }

}

