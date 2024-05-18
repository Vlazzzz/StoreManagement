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
        public ObservableCollection<tema3.Models.Entities.User> Users { get; set; }   
        public ObservableCollection<Product> Products { get; set; }
        public ObservableCollection<Category> Categories { get; set; }
        public ObservableCollection<Producer> Producers { get; set; }
        public ObservableCollection<Receipt> Receipts { get; set; }
        public ObservableCollection<Stock> Stocks { get; set; }

        private UserBLL userBLL = new UserBLL();
        private ProductBLL productBLL = new ProductBLL();
        private CategoryBLL categoryBLL = new CategoryBLL();
        private ProducerBLL producerBLL = new ProducerBLL();
        private ReceiptBLL receiptBLL = new ReceiptBLL();
        private StockBLL stockBLL = new StockBLL();
        
        public AdminViewModel()
        {
            Users = userBLL.GetAllUsers();
            Products = productBLL.GetAllProducts();
            Categories = categoryBLL.GetAllCategories();
            Producers = producerBLL.GetAllProducers();
            Receipts = receiptBLL.GetAllReceipts();
            Stocks = stockBLL.GetAllStocks();
        }
    }

    
}
