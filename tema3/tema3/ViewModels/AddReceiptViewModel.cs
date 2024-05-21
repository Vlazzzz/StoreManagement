using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Supermarket.ViewModels.Commands;
using tema3.Models.BusinessLogicLayer;
using tema3.Models.DataAccessLayer;
using tema3.Models.Entities;
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
        private int _receiptCounter = 0;

        private int cashierId;
        private string cashierName;

        public ICommand AddProductOnReceiptCommand { get; set; }

        public AddReceiptViewModel()
        {
            Receipts = receiptBLL.GetAllReceipts();
            ReceiptProducts = receiptProductBLL.GetAllReceiptProducts();
            Stocks = stockBLL.GetAllStocks();
            Products = productBLL.GetAllProducts();
            InitializeProductsInStock();
            AddProductOnReceiptCommand = new RelayCommand(AddProductOnReceipt);
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
        
        private int idCurrentReceipt = -1;
        private decimal totalValue = 0;
        private void AddProductOnReceipt()
        {
            if (_receiptCounter == 0)
            {
                //creez un nou bon
                //Valoarea totala a bonului este 0, pentru ca nu am adaugat inca niciun produs, dar se va modifica pe parcurs
                receiptDAL.InsertReceipt(cashierId, DateTime.Now, 0);
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
                        _receiptCounter++;
                        //totodata aici trebuie sa dam update la valoarea totala a bonului cu id-ul idCurrentReceipt
                        totalValue += product.Price * Quantity;
                        //update la valoarea totala a bonului
                        receiptDAL.UpdateReceipt(idCurrentReceipt, cashierId, DateTime.Now, totalValue);
                        //adaugam produsul pe bon
                        receiptProductDAL.InsertReceiptProduct(idCurrentReceipt, ProductId, Quantity, Unit, product.Price * Quantity);
                        //adaugam produsul in lista de produse adaugate pe bon salvata local
                        AddedProductsOnReceipt.Add(Products.FirstOrDefault(p => p.ProductId == ProductId));
                        //scadem cantitatea din stoc
                        product.Quantity -= Quantity;
                        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                        // Update the stock in the database with the new quantity(daca cantitatea introdusa este mai mare decat unul din stocuri,
                        // il stergem pe cel mai mic si daca a mai ramas, mai stergem si din celalalt/celelelte care a/au ramas)
                        //??
                        //??
                        //??        DE IMPLEMENTAT 
                        //??
                        //??
                        //??
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
