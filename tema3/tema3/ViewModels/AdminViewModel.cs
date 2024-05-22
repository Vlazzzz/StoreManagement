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

        public ICommand AddUserCommand { get; set; }
        public ICommand EditUserCommand { get; set; }
        public ICommand DeleteUserCommand { get; set; }
        
        public ICommand AddCategoryCommand { get; set; }
        public ICommand EditCategoryCommand { get; set; }
        public ICommand DeleteCategoryCommand { get; set; }

        public ICommand AddProductCommand { get; set; }
        public ICommand EditProductCommand { get; set; }
        public ICommand DeleteProductCommand { get; set; }
        
        public ICommand AddProducerCommand { get; set; }
        public ICommand EditProducerCommand { get; set; }
        public ICommand DeleteProducerCommand { get; set; }

        public ICommand AddStockCommand { get; set; }
        public ICommand EditStockCommand { get; set; }
        public ICommand DeleteStockCommand { get; set; }

        public ICommand AddReceiptCommand { get; set; }
        public ICommand EditReceiptCommand { get; set; }
        public ICommand DeleteReceiptCommand { get; set; }


        public ICommand BackToLoginCommand { get; set; }
        

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

            AddUserCommand = new RelayCommand<object>(AddUser);
            EditUserCommand = new RelayCommand<object>(EditUser);
            DeleteUserCommand = new RelayCommand(DeleteUser);
            
            AddCategoryCommand = new RelayCommand<object>(AddCategory);
            EditCategoryCommand = new RelayCommand<object>(EditCategory);
            DeleteCategoryCommand = new RelayCommand(DeleteCategory);

            AddProductCommand = new RelayCommand<object>(AddProduct);
            EditProductCommand = new RelayCommand<object>(EditProduct);
            DeleteProductCommand = new RelayCommand(DeleteProduct);

            AddProducerCommand = new RelayCommand<object>(AddProducer);
            EditProducerCommand = new RelayCommand<object>(EditProducer);
            DeleteProducerCommand = new RelayCommand(DeleteProducer);

            AddStockCommand = new RelayCommand<object>(AddStock);
            EditStockCommand = new RelayCommand<object>(EditStock);
            DeleteStockCommand = new RelayCommand(DeleteStock);

            AddReceiptCommand = new RelayCommand<object>(AddReceipt);
            EditReceiptCommand = new RelayCommand<object>(EditReceipt);
            DeleteReceiptCommand = new RelayCommand(DeleteReceipt);

            BackToLoginCommand = new RelayCommand<object>(BackToLogin);
        }

        private void BackToLogin(object obj)
        {
            var currPage = obj as Page;
            currPage.NavigationService.Navigate(new LoginPage());
        }

        //USER OPERATIONS
        private void AddUser(object obj)
        {
            var currPage = obj as Page;
            currPage.NavigationService.Navigate(new EditUserPage());
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
        private void DeleteUser()
        {
            if (SelectedUser != null)
            {
                userDAL.DeleteUser(SelectedUser.UserId);
                Users = userBLL.GetAllUsers();
                OnPropertyChanged(nameof(Users));
                System.Windows.MessageBox.Show("User deleted successfully!");
            }
        }

        //DELETE OPERATIONS
        private void AddCategory(object obj)
        {
            var currPage = obj as Page;
            currPage.NavigationService.Navigate(new EditCategoryPage());
        }
        private void EditCategory(object obj)
        {
            if (SelectedCategory != null)
            {
                var currPage = obj as Page;
                var editCategoryPage = new EditCategoryPage();
                editCategoryPage.DataContext = new EditCategoryViewModel(SelectedCategory); // Transmiteți utilizatorul selectat către EditCategoryViewModel
                currPage.NavigationService.Navigate(editCategoryPage);
            }
        }
        private void DeleteCategory()
        {
            if (SelectedCategory != null)
            {
                categoryDAL.DeleteCategory(SelectedCategory.CategoryId);
                Categories = categoryBLL.GetAllCategories();
                OnPropertyChanged(nameof(Categories));
                System.Windows.MessageBox.Show("Category deleted successfully!");
            }
        }
        //PRODUCT OPERATIONS
        private void AddProduct(object obj)
        {
            var currPage = obj as Page;
            currPage.NavigationService.Navigate(new EditProductPage());
        }
        private void EditProduct(object obj)
        {
            if (SelectedProduct != null)
            {
                var currPage = obj as Page;
                var editProductPage = new EditProductPage();
                editProductPage.DataContext = new EditProductViewModel(SelectedProduct); // Transmiteți utilizatorul selectat către EditProductViewModel
                currPage.NavigationService.Navigate(editProductPage);
            }
        }
        private void DeleteProduct()
        {
            if (SelectedProduct != null)
            {
                productDAL.DeleteProduct(SelectedProduct.ProductId);
                Products = productBLL.GetAllProducts();
                OnPropertyChanged(nameof(Products));
                System.Windows.MessageBox.Show("Product deleted successfully!");
            }
        }

        //PRODUCER OPERATIONS
        private void AddProducer(object obj)
        {
            var currPage = obj as Page;
            currPage.NavigationService.Navigate(new EditProducerPage());
        }
        private void EditProducer(object obj)
        {
            if (SelectedProducer != null)
            {
                var currPage = obj as Page;
                var editProducerPage = new EditProducerPage();
                editProducerPage.DataContext = new EditProducerViewModel(SelectedProducer); // Transmiteți utilizatorul selectat către EditProductViewModel
                currPage.NavigationService.Navigate(editProducerPage);
            }
        }
        private void DeleteProducer()
        {
            if (SelectedProducer != null)
            {
                producerDAL.DeleteProducer(SelectedProducer.ProducerId);
                Producers = producerBLL.GetAllProducers();
                OnPropertyChanged(nameof(Producers));
                System.Windows.MessageBox.Show("Producer deleted successfully!");
            }
        }

        //STOCK OPERATIONS
        private void AddStock(object obj)
        {
            var currPage = obj as Page;
            currPage.NavigationService.Navigate(new EditStockPage());
        }
        private void EditStock(object obj)
        {
            if (SelectedStock != null)
            {
                var currPage = obj as Page;
                var editStockPage = new EditStockPage();
                editStockPage.DataContext = new EditStockViewModel(SelectedStock); // Transmiteți utilizatorul selectat către EditProductViewModel
                currPage.NavigationService.Navigate(editStockPage);
            }
        }
        private void DeleteStock()
        {
            if (SelectedStock != null)
            {
                stockDAL.DeleteStock(SelectedStock.StockId);
                Stocks = stockBLL.GetAllStocks();
                OnPropertyChanged(nameof(Stocks));
                System.Windows.MessageBox.Show("Stock deleted successfully!");
            }
        }
        //RECEIPT OPERATIONS
        private void AddReceipt(object obj)
        {
            var currPage = obj as Page;
            currPage.NavigationService.Navigate(new EditReceiptPage());
        }
        private void EditReceipt(object obj)
        {
            throw new NotImplementedException();
        }
        private void DeleteReceipt()
        {
            if (SelectedReceipt != null)
            {
                receiptDAL.DeleteReceipt(SelectedReceipt.ReceiptId);
                Receipts = receiptBLL.GetAllReceipts();
                OnPropertyChanged(nameof(Receipts));
                System.Windows.MessageBox.Show("Receipt deleted successfully!");
            }
        }
    }
}
