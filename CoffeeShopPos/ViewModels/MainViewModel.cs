namespace CoffeeShopPos.ViewModels;
public class MainViewModel : BaseViewModel
{
    public CategoryViewModel CategoriesViewModel { get; }
    public ProductViewModel ProductsViewModel { get; }

    public MainViewModel(CategoryViewModel categoriesViewModel, ProductViewModel productsViewModel)
    {
        CategoriesViewModel = categoriesViewModel;
        ProductsViewModel = productsViewModel;
    }
}
