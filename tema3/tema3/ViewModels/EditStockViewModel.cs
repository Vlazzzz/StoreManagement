using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.VisualBasic.ApplicationServices;
using Supermarket.ViewModels.Commands;
using tema3.Models.BusinessLogicLayer;
using tema3.Models.DataAccessLayer;
using tema3.Models.Entities;
using tema3.Pages;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace tema3.ViewModels
{
    public class EditStockViewModel : BaseViewModel
    {
        public ObservableCollection<Stock> Stocks { get; set; }
        public ObservableCollection<Product> Products{ get; set; }
        private StockBLL stockBLL = new StockBLL();
        private StockDAL stockDAL = new StockDAL();
        private ProductDAL productDAL = new ProductDAL();
        private ProductBLL productBLL = new ProductBLL();
        private string _productName;
        private int _quantity;
        private string _unit;
        private DateTime _supplyDate = new DateTime(2024, 1, 1);
        private DateTime _expiryDate = new DateTime(2024, 1, 1);
        private decimal _purchasePrice;

        private Product _selectedProduct;
        public Product SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
                if (_selectedProduct != null)
                {
                    ProductName = _selectedProduct.Name;
                }
            }
        }

        public string ProductName
        {
            get { return _productName; }
            set
            {
                _productName = value;
                OnPropertyChanged(nameof(ProductName));
            }
        }

        public int Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }

        public string Unit
        {
            get { return _unit; }
            set
            {
                _unit = value;
                OnPropertyChanged(nameof(Unit));
            }
        }

        public DateTime SupplyDate
        {
            get { return _supplyDate; }
            set
            {
                _supplyDate = value;
                OnPropertyChanged(nameof(SupplyDate));
            }
        }
        public DateTime ExpiryDate
        {
            get { return _expiryDate; }
            set
            {
                _expiryDate = value;
                OnPropertyChanged(nameof(ExpiryDate));
            }
        }
        public decimal PurchasePrice
        {
            get { return _purchasePrice; }
            set
            {
                _purchasePrice = value;
                OnPropertyChanged(nameof(PurchasePrice));
            }
        }

        public ICommand AddStockInDatabaseCommand { get; set; }
        public ICommand UpdateStockInDatabaseCommand { get; set; }
        public ICommand ReturnCommand { get; set; }

        Stock _selectedStock;

        public EditStockViewModel()
        {
            AddStockInDatabaseCommand = new RelayCommand(AddStockInDatabase);
            ReturnCommand = new RelayCommand<object>(ReturnToMenuFunction);
            Stocks = stockBLL.GetAllStocks();
            Products = productBLL.GetAllProducts();
        }

        public EditStockViewModel(Stock selectedStock)
        {
            Stocks = stockBLL.GetAllStocks();
            Products = productBLL.GetAllProducts();
            _selectedStock = selectedStock;

            // Inițializați proprietățile cu valorile din produsul selectat
            if (_selectedStock != null)
            {
                SelectedProduct = Products.FirstOrDefault(p => p.ProductId == _selectedStock.ProductId);
                ProductName = _selectedStock.ProductName;
                Quantity = _selectedStock.Quantity;
                Unit = _selectedStock.Unit;
                SupplyDate = _selectedStock.SupplyDate;
                ExpiryDate = _selectedStock.ExpiryDate;
                PurchasePrice = _selectedStock.PurchasePrice;
            }

            AddStockInDatabaseCommand = new RelayCommand(AddStockInDatabase);
            UpdateStockInDatabaseCommand = new RelayCommand(UpdateStockInDatabase);
            ReturnCommand = new RelayCommand<object>(ReturnToMenuFunction);
        }

        private void AddStockInDatabase()
        {
            if (ProductName == null || Quantity == 0 || Unit == null || SupplyDate == null || ExpiryDate == null ||
                PurchasePrice == 0)
            {
                System.Windows.MessageBox.Show("Please fill in all the fields!");
                return;
            }

            int productId = -1;
            foreach (Product product in Products)
            {
                if (product.Name == ProductName)
                {
                    productId = product.ProductId;
                    break;
                }
            }

            stockDAL.InsertStock(productId, Quantity, Unit, SupplyDate, ExpiryDate, PurchasePrice);
            Stocks = stockBLL.GetAllStocks();
            OnPropertyChanged(nameof(Stocks));
            System.Windows.MessageBox.Show("Stock added successfully!");
        }

        private void UpdateStockInDatabase()
        {
            if (ProductName == null || Quantity == 0 || Unit == null || SupplyDate == null || ExpiryDate == null ||
                PurchasePrice == 0)
            {
                System.Windows.MessageBox.Show("Please fill in all the fields!");
                return;
            }

            stockDAL.UpdateStock(_selectedStock.StockId, _selectedStock.ProductId, Quantity, Unit, SupplyDate, ExpiryDate, PurchasePrice);
            Stocks = stockBLL.GetAllStocks();
            OnPropertyChanged(nameof(Stocks));
            System.Windows.MessageBox.Show("Stock updated successfully!");
        }

        private void ReturnToMenuFunction(object obj)
        {
            var currPage = obj as Page;
            currPage.NavigationService.Navigate(new AdminPage());
        }
    }
}
