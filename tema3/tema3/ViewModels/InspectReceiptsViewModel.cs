using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using Supermarket.ViewModels.Commands;
using tema3.Models.BusinessLogicLayer;
using tema3.Models.DataAccessLayer;
using tema3.Models.Entities;
using tema3.Pages;
using tema3.Services;

namespace tema3.ViewModels
{
    public class InspectReceiptsViewModel : BaseViewModel
    {
        public decimal TVA = 12;
        public ObservableCollection<Receipt> Receipts { get; set; }
        public ObservableCollection<ReceiptProduct> ReceiptProducts { get; set; }
        public ObservableCollection<ReceiptProduct> FilteredProducts { get; set; }
        ReceiptBLL receiptBLL = new ReceiptBLL();
        ReceiptDAL receiptDAL = new ReceiptDAL();
        ReceiptProductDAL receiptProductDAL = new ReceiptProductDAL();
        ReceiptProductBLL receiptProductBLL = new ReceiptProductBLL();
        private int _selectedReceiptId;
        private string _receiptDetails;

        public int SelectedReceiptId
        {
            get { return _selectedReceiptId; }
            set
            {
                _selectedReceiptId = value;
                OnPropertyChanged(nameof(SelectedReceiptId));
                ShowReceipt();//////////
            }
        }

        public string ReceiptDetails
        {
            get { return _receiptDetails; }
            set
            {
                _receiptDetails = value;
                OnPropertyChanged(nameof(ReceiptDetails));
            }
        }

        public ICommand ShowReceiptCommand { get; set; }
        public ICommand BackToCashierPageCommand { get; set; }
        
        public int cashierId;
        public string cashierName;

        public InspectReceiptsViewModel()
        {
            // Exemplu de inițializare a listei de Receipt Id-uri. În practică, aceasta poate fi încărcată dintr-o sursă de date.
            Receipts = receiptBLL.GetAllReceipts();
            ReceiptProducts = receiptProductBLL.GetAllReceiptProducts();
            ShowReceiptCommand = new RelayCommand(ShowReceipt);
            BackToCashierPageCommand = new RelayCommand<object>(BackToCashierPage);
            FilteredProducts = new ObservableCollection<ReceiptProduct>();
            if (SessionService.Instance.CurrentUser != null)
            {
                // Puteți accesa ID-ul casierului așa:
                cashierId = SessionService.Instance.CurrentUser.UserId;
                // Sau numele:
                cashierName = SessionService.Instance.CurrentUser.Username;
                // Și utilizați aceste informații după cum aveți nevoie
            }
        }

        private void BackToCashierPage(object obj)
        {
            var currPage = obj as Page;
            currPage.NavigationService.Navigate(new CashierPage());
        }

        private void InitializeProductListForReceipt()
        {
            foreach (ReceiptProduct receiptProduct in ReceiptProducts)
            {
                if (receiptProduct.ReceiptId == SelectedReceiptId)
                {
                    FilteredProducts.Add(receiptProduct);
                }
            }
        }

        private void ShowReceipt()
        {
            FilteredProducts.Clear();
            Console.WriteLine(SelectedReceiptId);
            InitializeProductListForReceipt();
            DateTime issueDate = new DateTime();
            Decimal totalPrice = 0;
            string cashierUsername = "";
            foreach (Receipt receipt in Receipts)
            {
                if (receipt.ReceiptId == SelectedReceiptId)
                {
                    issueDate = receipt.IssueDate;
                    totalPrice = receipt.AmountReceived;
                    cashierUsername = receipt.UserName;
                }
            }
            //de adaugat numele produselor in ReceiptDetails(am facut procedura stocata in ReceiptProduct BLL)


            // Inițializați proprietatea ReceiptDetails cu detaliile bonului selectat
            ReceiptDetails = @"
        ___    __   _  __    ____ ____ __   __    _   __    
       | __ )/  _  \| \|  |   |   __|_ _/ __|/ __|  /_\ |  |   
       | _   \  (_)  |  .`  |   | __| _| |\__ \ (__ / _  \|  |_
       |___/ \___/|_|\_ |   |_|  |___|___/\__/_/ \_ \___|
                " + "\n" +
                             "════════════════════════════════════════════\n";

            //pt fiecare produs din lista de produse filtrate, adăugați un rând în ReceiptDetails
            foreach (ReceiptProduct receiptProduct in FilteredProducts)
            {
                ReceiptDetails += "    Produs: " + receiptProduct.ProductName + " x " + receiptProduct.Quantity + "\n" +
                                  "                      -> Subtotal: " + receiptProduct.Subtotal.ToString("F2") + " RON\n" +
                                  "                      -> TVA (" + TVA + "%): " + (receiptProduct.Subtotal * TVA / 100).ToString("F2") + " RON\n";
            }

            decimal totalPriceTVA = totalPrice + (totalPrice * TVA / 100);

            ReceiptDetails = ReceiptDetails +
                             "════════════════════════════════════════════\n" +
                             "    Total: " + totalPrice.ToString("F2") + " RON\n" +
                             "    Total TVA (" + TVA + "%): " + (totalPrice * TVA / 100).ToString("F2") + " RON\n" +
                             "    Pret Final: " + totalPriceTVA.ToString("F2") + " RON\n" +
                             "════════════════════════════════════════════\n" +
                             "    Data: " + issueDate.ToString("d") + "\n" +
                             "    Nume Casier: " + cashierUsername + "\n" +
                             "════════════════════════════════════════════\n" +
                             "                   Mulțumim pentru vizită!\n";
        }
    }
}