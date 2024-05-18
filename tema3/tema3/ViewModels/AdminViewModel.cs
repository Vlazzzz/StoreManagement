using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using Supermarket.ViewModels.Commands;
using tema3.Models.BusinessLogicLayer;
using tema3.Models.DataAccessLayer;
using tema3.Models.Entities;
using tema3.Pages;

namespace tema3.ViewModels
{
    public class AdminViewModel : BaseViewModel
    {
        public ObservableCollection<User> Users { get; set; }
        public ObservableCollection<Product> Products { get; set; }
        public ObservableCollection<Category> Categories { get; set; }
        public ObservableCollection<Producer> Producers { get; set; }
        public ObservableCollection<Receipt> Receipts { get; set; }
        public ObservableCollection<Stock> Stocks { get; set; }

        private readonly UserBLL userBLL = new UserBLL();
        private readonly ProductBLL productBLL = new ProductBLL();
        private readonly CategoryBLL categoryBLL = new CategoryBLL();
        private readonly ProducerBLL producerBLL = new ProducerBLL();
        private readonly ReceiptBLL receiptBLL = new ReceiptBLL();
        private readonly StockBLL stockBLL = new StockBLL();
        private readonly UserDAL userDAL = new UserDAL();
        private readonly CategoryDAL categoryDAL = new CategoryDAL();
        private readonly ProducerDAL producerDAL = new ProducerDAL();
        private readonly ProductDAL productDAL = new ProductDAL();
        private readonly ReceiptDAL receiptDAL = new ReceiptDAL();
        private readonly StockDAL stockDAL = new StockDAL();

        public ICommand DeleteUserCommand { get; set; }
        public ICommand DeleteProductCommand { get; set; }
        public ICommand DeleteCategoryCommand { get; set; }
        public ICommand DeleteProducerCommand { get; set; }
        public ICommand DeleteReceiptCommand { get; set; }
        public ICommand DeleteStockCommand { get; set; }
        public ICommand AddUserCommand { get; set; }
        public ICommand EditUserCommand { get; set; }

        private User _selectedUser;
        public User SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                if (_selectedUser != value)
                {
                    _selectedUser = value;
                    OnPropertyChanged(nameof(SelectedUser));
                }
            }
        }

        private Category _selectedCategory;

        public Category SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                if (_selectedCategory != value)
                {
                    _selectedCategory = value;
                    OnPropertyChanged(nameof(SelectedCategory));
                }
            }
        }

        private Producer _selectedProducer;
        public Producer SelectedProducer
        {
            get { return _selectedProducer; }
            set
            {
                if (_selectedProducer != value)
                {
                    _selectedProducer = value;
                    OnPropertyChanged(nameof(SelectedProducer));
                }
            }
        }
        
        private Product _selectedProduct;

        public Product SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                if (_selectedProduct != value)
                {
                    _selectedProduct = value;
                    OnPropertyChanged(nameof(SelectedProduct));
                }
            }
        }

        private Receipt _selectedReceipt;

        public Receipt SelectedReceipt
        {
            get { return _selectedReceipt; }
            set
            {
                if (_selectedReceipt != value)
                {
                    _selectedReceipt = value;
                    OnPropertyChanged(nameof(SelectedReceipt));
                }
            }
        }
        
        private Stock _selectedStock;
        public Stock SelectedStock
        {
            get { return _selectedStock; }
            set
            {
                if (_selectedStock != value)
                {
                    _selectedStock = value;
                    OnPropertyChanged(nameof(SelectedStock));
                }
            }
        }

        public AdminViewModel()
        {
            Users = userBLL.GetAllUsers();
            Products = productBLL.GetAllProducts();
            Categories = categoryBLL.GetAllCategories();
            Producers = producerBLL.GetAllProducers();
            Receipts = receiptBLL.GetAllReceipts();
            Stocks = stockBLL.GetAllStocks();

            DeleteUserCommand = new RelayCommand(DeleteUser);
            DeleteCategoryCommand = new RelayCommand(DeleteCategory);
            DeleteProducerCommand = new RelayCommand(DeleteProducer);
            DeleteProductCommand = new RelayCommand(DeleteProduct);
            DeleteReceiptCommand = new RelayCommand(DeleteReceipt);
            DeleteStockCommand = new RelayCommand(DeleteStock);

            AddUserCommand = new RelayCommand<object>(AddUser);
            EditUserCommand = new RelayCommand<object>(EditUser);
        }

        private void EditUser(object obj)
        {
            if (SelectedUser != null)
            {
                var currPage = obj as Page;
                var editUserPage = new EditUserPage();
                editUserPage.DataContext = new EditUserViewModel(SelectedUser); // Transmiteți utilizatorul selectat către EditUserViewModel
                currPage.NavigationService.Navigate(editUserPage);
            }
        }


        private void AddUser(object obj)
        {
            var currPage = obj as Page;
            currPage.NavigationService.Navigate(new EditUserPage());
        }

        private void DeleteStock()
        {
            if (SelectedStock.IsActive)
            {
                stockDAL.DeleteStock(SelectedStock.StockId);
                Stocks = stockBLL.GetAllStocks();
                OnPropertyChanged(nameof(Stocks));
            }
        }

        private void DeleteReceipt()
        {
            if (SelectedReceipt.IsActive)
            {
                receiptDAL.DeleteReceipt(SelectedReceipt.ReceiptId);
                Receipts = receiptBLL.GetAllReceipts();
                OnPropertyChanged(nameof(Receipts));
            }
        }
        private void DeleteProduct()
        {
            if (SelectedProduct.IsActive)
            {
                productDAL.DeleteProduct(SelectedProduct.ProducerId);
                Products = productBLL.GetAllProducts();
                OnPropertyChanged(nameof(Products));
            }
        }

        private void DeleteProducer()
        {
            if (SelectedProducer.IsActive)
            {
                producerDAL.DeleteProducer(SelectedProducer.ProducerId);
                Producers = producerBLL.GetAllProducers();
                OnPropertyChanged(nameof(Producers));
            }
        }

        private void DeleteCategory()
        {
            if (SelectedCategory.IsActive)
            {
                categoryDAL.DeleteCategory(SelectedCategory.CategoryId);
                Categories = categoryBLL.GetAllCategories();
                OnPropertyChanged(nameof(Categories));
            }
        }

        private void DeleteUser()
        {
            if (SelectedUser.IsActive)
            {
                userDAL.DeleteUser(SelectedUser.UserId);
                Users = userBLL.GetAllUsers();
                OnPropertyChanged(nameof(Users));
            }
        }
    }
}
