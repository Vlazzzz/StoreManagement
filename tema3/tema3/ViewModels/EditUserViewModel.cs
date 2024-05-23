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
    public class EditUserViewModel : BaseViewModel
    {
        public ObservableCollection<User> Users { get; set; }
        private UserBLL userBLL = new UserBLL();
        private UserDAL userDAL = new UserDAL();
        private string _username;
        private string _password;

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        private string _selectedCategory;
        public string SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value;
                OnPropertyChanged(nameof(SelectedCategory));
            }
        }

        public ICommand AddUserInDatabaseCommand { get; set; }
        public ICommand UpdateUserInDatabaseCommand { get; set; }
        public ICommand ReturnCommand { get; set; }

        User _selectedUser;
        public EditUserViewModel()
        {
            AddUserInDatabaseCommand = new RelayCommand(AddUserInDatabase);
            ReturnCommand = new RelayCommand<object>(ReturnToMenuFunction);
            Users = userBLL.GetAllUsers();
        }

        public EditUserViewModel(User selectedUser)
        {
            Users = userBLL.GetAllUsers();
            _selectedUser = selectedUser;
            // Inițializați proprietățile Username și SelectedCategory cu valorile din utilizatorul selectat
            Username = selectedUser.Username;
            Password = selectedUser.Password;
            
            if (selectedUser.UserType)
                SelectedCategory = "Admin";
            else
                SelectedCategory = "Cashier";
            
            AddUserInDatabaseCommand = new RelayCommand(AddUserInDatabase);
            UpdateUserInDatabaseCommand = new RelayCommand(UpdateUserInDatabase);
            ReturnCommand = new RelayCommand<object>(ReturnToMenuFunction);
        }

        private void UpdateUserInDatabase()
        {
            bool isAdmin;
            if (SelectedCategory == "System.Windows.Controls.ComboBoxItem: Admin" || SelectedCategory == "Admin")
                isAdmin = true;
            else
                isAdmin = false;

            if (Username == null || Password == null)
            {
                System.Windows.MessageBox.Show("Please fill in all the fields!");
                return;
            }

            //check if the user is already in the database
            foreach (User user in Users)
            {
                if (user.Username == Username && user.UserId != _selectedUser.UserId)
                {
                    System.Windows.MessageBox.Show("User already exists!");
                    return;
                }
            }

            userDAL.UpdateUser(_selectedUser.UserId, Username, Password, isAdmin);
            Users = userBLL.GetAllUsers();
            OnPropertyChanged(nameof(Users));
            System.Windows.MessageBox.Show("User updated successfully!");
        }

        private void ReturnToMenuFunction(object obj)
        {
            var currPage = obj as Page;
            currPage.NavigationService.Navigate(new AdminPage());
        }

        private void AddUserInDatabase()
        {
            bool isAdmin;
            Console.WriteLine(SelectedCategory);
            if (SelectedCategory == "Admin")
                isAdmin = true;
            else
                isAdmin = false;
            if (Username == null || Password == null)
            {
                System.Windows.MessageBox.Show("Please fill in all the fields!");
                return;
            }

            //check if the user is already in the database
            foreach (User user in Users)
            {
                if (user.Username == Username)
                {
                    System.Windows.MessageBox.Show("User already exists!");
                    return;
                }
            }

            userDAL.InsertUser(Username, Password, isAdmin);
            Users = userBLL.GetAllUsers();
            OnPropertyChanged(nameof(Users));
            System.Windows.MessageBox.Show("User added successfully!");
        }
    }
}
