using System.Collections.ObjectModel;
using System.Windows;
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
    public class ProductStock
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }

    public class AddReceiptViewModel : BaseViewModel
    {
        public ObservableCollection<Receipt> Receipts { get; set; }
        public ObservableCollection<ProductStock> ProductsInStock { get; set; } // Use the custom class
        public ObservableCollection<ReceiptProduct> ReceiptProducts { get; set; }
        public ObservableCollection<Stock> Stocks { get; set; }
        public ObservableCollection<Product> Products { get; set; }
        public ObservableCollection<Product> AddedProductsOnReceipt { get; set; }


        private int _quantity;
        private string _unit;
        private int _productId;

        public int ProductId
        {
            get { return _productId; }
            set
            {
                _productId = value;
                OnPropertyChanged(nameof(ProductId));
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

        private ReceiptBLL receiptBLL = new ReceiptBLL();
        private ReceiptDAL receiptDAL = new ReceiptDAL();
        private ReceiptProductDAL receiptProductDAL = new ReceiptProductDAL();
        private ReceiptProductBLL receiptProductBLL = new ReceiptProductBLL();
        private StockDAL stockDAL = new StockDAL();
        private StockBLL stockBLL = new StockBLL();
        private ProductDAL productDAL = new ProductDAL();
        private ProductBLL productBLL = new ProductBLL();

        //ne luam un contor, pentru ca sa stim ca trebuie sa creem un nou bon atunci adaugam primul produs pe bon
        private int _receiptProductsCounter = 0;

        private int cashierId;
        private string cashierName;

        public ICommand AddProductOnReceiptCommand { get; set; }
        public ICommand ResetCommand { get; set; }
        public ICommand BackToCashierPageCommand { get; set; }

        public AddReceiptViewModel()
        {
            Receipts = receiptBLL.GetAllReceipts();
            ReceiptProducts = receiptProductBLL.GetAllReceiptProducts();
            Stocks = stockBLL.GetAllStocks();
            Products = productBLL.GetAllProducts();
            InitializeProductsInStock();
            AddProductOnReceiptCommand = new RelayCommand(AddProductOnReceipt);
            ResetCommand = new RelayCommand<object>(ResetPage);
            BackToCashierPageCommand = new RelayCommand<object>(BackToCashierPage);
            AddedProductsOnReceipt = new ObservableCollection<Product>();
            if (SessionService.Instance.CurrentUser != null)
            {
                // Puteți accesa ID-ul casierului așa:
                cashierId = SessionService.Instance.CurrentUser.UserId;
                // Sau numele:
                cashierName = SessionService.Instance.CurrentUser.Username;
                // Și utilizați aceste informații după cum aveți nevoie
            }
        }

        private void ResetPage(object obj)
        {
            MessageBox.Show("Receipt added successfully.");
            var currPage = obj as Page;
            currPage.NavigationService.Navigate(new AddReceiptPage());
        }

        private void BackToCashierPage(object obj)
        {
            var currPage = obj as Page;
            currPage.NavigationService.Navigate(new CashierPage());
        }

        private int idCurrentReceipt = -1;
        private decimal totalValue = 0;
        private void AddProductOnReceipt()
        {
            if (Unit == null || Unit == "")
            {
                MessageBox.Show("Please fill in all th fields!");
                return;
            }

            if (Quantity <= 0)
            {
                MessageBox.Show("Please fill in all th fields!");
                return;
            }

            if (_receiptProductsCounter == 0)
            {
                //creez un nou bon
                //Valoarea totala a bonului este 0, pentru ca nu am adaugat inca niciun produs, dar se va modifica pe parcurs
                receiptDAL.InsertReceipt(cashierId, DateTime.Now, 0);
                Receipts = receiptBLL.GetAllReceipts();
                foreach (Receipt receipt in Receipts)
                {
                    if (receipt.ReceiptId > idCurrentReceipt)
                    {
                        idCurrentReceipt = receipt.ReceiptId;
                    }
                }
            }

            //fac verificarea pentru existenta stocului necesar
            foreach (var product in ProductsInStock)
            {
                if (product.ProductId == ProductId)
                {
                    if (Quantity <= product.Quantity)
                    {
                        //adaugam produsul pe bon si scadem cantitatea din stoc
                        _receiptProductsCounter++; //counter pentru nr de produse adaugate pe bon
                        //totodata aici trebuie sa dam update la valoarea totala a bonului cu id-ul idCurrentReceipt
                        totalValue += product.Price * Quantity;
                        //update la valoarea totala a bonului
                        receiptDAL.UpdateReceipt(idCurrentReceipt, cashierId, DateTime.Now, totalValue);
                        Receipts = receiptBLL.GetAllReceipts();
                        //adaugam produsul pe bon
                        bool productIsAlreadyOnReceipt = false;
                        foreach (ReceiptProduct receiptProduct in ReceiptProducts)
                        {
                            if (receiptProduct.ReceiptId == idCurrentReceipt && receiptProduct.ProductId == ProductId)
                            {
                                //daca produsul exista deja pe bon, facem update la cantitate si subtotal
                                int newQuantity = receiptProduct.Quantity + Quantity;
                                receiptProductDAL.UpdateReceiptProduct(idCurrentReceipt, ProductId, newQuantity, Unit, product.Price * newQuantity);
                                ReceiptProducts = receiptProductBLL.GetAllReceiptProducts();
                                productIsAlreadyOnReceipt = true;
                                break;
                            }
                        }

                        if (!productIsAlreadyOnReceipt)
                        {
                            //daca produsul nu exista pe bon, il adaugam
                            receiptProductDAL.InsertReceiptProduct(idCurrentReceipt, ProductId, Quantity, Unit, product.Price * Quantity);
                            ReceiptProducts = receiptProductBLL.GetAllReceiptProducts();
                        }

                        //adaugam produsul in lista de produse adaugate pe bon salvata local
                        AddedProductsOnReceipt.Add(Products.FirstOrDefault(p => p.ProductId == ProductId));
                        //scadem cantitatea din stoc
                        product.Quantity -= Quantity;
                        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                        // Update the stock in the database with the new quantity(daca cantitatea introdusa este mai mare decat unul din stocuri,
                        bool StillIsQuantityToSubstract = true;
                        //sort the Stocks ascending by the expiry date

                        /////
                        ///
                        ///
                        Stocks = stockBLL.GetAllStocks();
                        List<Stock> stockList = new List<Stock>();
                        foreach (Stock stock in Stocks)
                        {
                            if (stock.ProductId == ProductId)
                            {
                                stockList.Add(stock);
                            }
                        }
                        stockList.Sort((x, y) => DateTime.Compare(x.ExpiryDate, y.ExpiryDate));

                        foreach (Stock stock in stockList)
                        {
                            if(StillIsQuantityToSubstract)
                            {
                                if (stock.ProductId == ProductId)
                                {
                                    if (stock.Quantity > Quantity)
                                    {
                                        stockDAL.UpdateStock(stock.StockId, stock.ProductId, stock.Quantity - Quantity,
                                            stock.Unit, stock.SupplyDate, stock.ExpiryDate, stock.PurchasePrice);
                                        break;
                                    }
                                    else
                                    {
                                        stockDAL.DeleteStock(stock.StockId);
                                        Quantity -= stock.Quantity;
                                    }
                                    Stocks = stockBLL.GetAllStocks();
                                }

                                if (Quantity == 0)
                                {
                                    StillIsQuantityToSubstract = false;
                                }
                            }
                        }
                        break;
                    }
                    else
                    {
                        // Show a message box with the error saying that the quantity is too big
                        MessageBox.Show("Not enough stock!");
                        return;
                    }
                }
            }

            ProductId = -1;
            Quantity = 0;
            Unit = "";
        }

        private void InitializeProductsInStock()
        {
            ProductsInStock = new ObservableCollection<ProductStock>();
            foreach (var stock in Stocks)
            {
                var product = Products.FirstOrDefault(p => p.ProductId == stock.ProductId);
                if (product != null)
                {
                    var productStock = ProductsInStock.FirstOrDefault(p => p.ProductId == product.ProductId);
                    if (productStock != null)
                    {
                        productStock.Quantity += stock.Quantity;
                    }
                    else
                    {
                        ProductsInStock.Add(new ProductStock { ProductId = product.ProductId, Name = product.Name, Quantity = stock.Quantity, Price = stock.PurchasePrice});
                    }
                }
            }
        }
    }
}
