using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Supermarket.ViewModels.Commands;
using tema3.Models.BusinessLogicLayer;
using tema3.Models.DataAccessLayer;

namespace tema3.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private UserBLL userBLL = new UserBLL();
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
        public ICommand LoginCommand { get; private set; }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand<object>(Login);
        }

        private void Login(object t)
        {
            var currPage = t as Page;

            if (!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password))
            {
                if (userBLL.CheckUserCredentials(Username, Password))
                {
                    bool isAdmin;
                    if (userBLL.CheckUserType(Username, Password, out isAdmin))
                    {
                        // Navigate to the admin page if the user is an admin
                        if (isAdmin)
                            currPage.NavigationService.Navigate(new AdminPage());
                        else
                            currPage.NavigationService.Navigate(new CashierPage());
                    }
                    else
                    {
                        // Show a message box if the user type cannot be determined
                        MessageBox.Show("Unable to determine user type");
                    }
                }
                else
                {
                    // Show a message box if credentials are invalid
                    MessageBox.Show("Invalid username or password");
                }
            }
            else
            {
                // Show a message box if either username or password is empty
                MessageBox.Show("Please enter both username and password");
            }
        }
    }
}
