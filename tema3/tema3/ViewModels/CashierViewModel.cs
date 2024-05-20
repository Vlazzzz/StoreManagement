using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using Supermarket.ViewModels.Commands;
using tema3.Models.BusinessLogicLayer;
using tema3.Models.Entities;

namespace tema3.ViewModels
{
    public class CashierViewModel : BaseViewModel
    {
        private string _searchQuery;
        private ObservableCollection<Product> _products;
        private ObservableCollection<Product> _filteredProducts;
        private Product _selectedProduct;
        private ProductBLL productBLL = new ProductBLL();

        public ICommand SearchProductsCommand { get; set; }
        public ICommand BackToLoginCommand { get; set; }

        public CashierViewModel()
        {
            SearchProductsCommand = new RelayCommand(SearchProducts);
            BackToLoginCommand = new RelayCommand<object>(BackToLogin);
            Products = productBLL.GetAllProducts();
            FilteredProducts = new ObservableCollection<Product>(Products);
        }

        private void BackToLogin(object obj)
        {
            var currPage = obj as Page;
            currPage.NavigationService.Navigate(new LoginPage());
        }

        private void SearchProducts()
        {
            //ia text din searchQuery si cauta in lista de produse dupa orice camp din entitatea produs(searchQuery poate contine orice camp din entitate, nu doar numele)

            if (string.IsNullOrEmpty(SearchQuery))
            {
                FilteredProducts = new ObservableCollection<Product>(Products);
            }
            else
            {
                FilteredProducts = new ObservableCollection<Product>(Products.Where(p => p.Name.ToLower().Contains(SearchQuery.ToLower())));
            }

            FilteredProducts.Clear();

            foreach (var product in Products)
            {
                if (_searchQuery == product.Name)
                {
                    FilteredProducts.Add(product);
                }
                else if (_searchQuery == product.Barcode)
                {
                    FilteredProducts.Add(product);
                }
                else if (_searchQuery == product.CategoryName)
                {
                    FilteredProducts.Add(product);
                }
                else if (_searchQuery == product.ProducerName)
                {
                    FilteredProducts.Add(product);
                }
            }
            OnPropertyChanged(nameof(FilteredProducts));
        }

        public string SearchQuery
        {
            get { return _searchQuery; }
            set
            {
                _searchQuery = value;
                OnPropertyChanged(nameof(SearchQuery));
            }
        }

        public ObservableCollection<Product> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                OnPropertyChanged(nameof(Products));
            }
        }

        public ObservableCollection<Product> FilteredProducts
        {
            get { return _filteredProducts; }
            set
            {
                _filteredProducts = value;
                OnPropertyChanged(nameof(FilteredProducts));
            }
        }

        public Product SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }

    }
}
