using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tema3.Models.BusinessLogicLayer;
using tema3.Models.Entities;
using User = Microsoft.VisualBasic.ApplicationServices.User;

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

        UserBLL userBLL = new UserBLL();
        ProductBLL productBLL = new ProductBLL();
        
        public AdminViewModel()
        {
            //Users = userBLL.GetAllUsers(); ??????????????????? 
        }
    }

    
}
