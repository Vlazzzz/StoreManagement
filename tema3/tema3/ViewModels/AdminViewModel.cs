using System.Collections.ObjectModel;
using System.Windows.Input;
using Supermarket.ViewModels.Commands;
using tema3.Models.BusinessLogicLayer;
using tema3.Models.DataAccessLayer;
using tema3.Models.Entities;

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

        public ICommand DeleteUserCommand { get; set; }

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

        public AdminViewModel()
        {
            Users = userBLL.GetAllUsers();
            Products = productBLL.GetAllProducts();
            Categories = categoryBLL.GetAllCategories();
            Producers = producerBLL.GetAllProducers();
            Receipts = receiptBLL.GetAllReceipts();
            Stocks = stockBLL.GetAllStocks();

            DeleteUserCommand = new RelayCommand(DeleteUser);
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
