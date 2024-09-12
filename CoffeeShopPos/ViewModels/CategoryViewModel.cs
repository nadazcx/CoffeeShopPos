using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using CoffeeShopPos.Helpers;
using CoffeeShopPos.Models;
using CoffeeShopPos.Services;

namespace CoffeeShopPos.ViewModels
{
    public class CategoryViewModel : BaseViewModel
    {
        private readonly CategoryService _categoryService;
        private ObservableCollection<Category> _categories;
        private Category _selectedCategory;
        private bool _isLoading;

        public CategoryViewModel(CategoryService categoryService)
        {
            _categoryService = categoryService;
            _categories = new ObservableCollection<Category>();
            LoadCategoriesCommand = new RelayCommand(async () => await LoadCategoriesAsync());
            // Other commands can be added here if needed
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
        // Other commands can be added here if needed

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

        // Commands for adding, updating, or deleting categories can be implemented here if needed

        public event PropertyChangedEventHandler? PropertyChanged; // Allow null

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
