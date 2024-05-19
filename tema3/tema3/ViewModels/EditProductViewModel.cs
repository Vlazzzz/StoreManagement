using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.VisualBasic.ApplicationServices;
using Supermarket.ViewModels.Commands;
using tema3.Models.BusinessLogicLayer;
using tema3.Models.DataAccessLayer;
using tema3.Models.Entities;
using tema3.Pages;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace tema3.ViewModels
{
    public class EditProductViewModel : BaseViewModel
    {
        public ObservableCollection<Product> Products { get; set; }
        public ObservableCollection<Category> Categories { get; set; }
        public ObservableCollection<Producer> Producers { get; set; }
        private ProductBLL productBLL = new ProductBLL();
        private ProductDAL productDAL = new ProductDAL();
        private CategoryBLL categoryBLL = new CategoryBLL();
        private CategoryDAL categoryDAL = new CategoryDAL();
        private ProducerBLL producerBLL = new ProducerBLL();
        private ProducerDAL producerDAL = new ProducerDAL();


        private string _productName;
        private string _barcode;
        private Category _selectedCategory;
        private Producer _selectedProducer;

        public string ProductName
        {
            get { return _productName; }
            set
            {
                _productName = value;
                OnPropertyChanged(nameof(ProductName));
            }
        }

        public string Barcode
        {
            get { return _barcode; }
            set
            {
                _barcode = value;
                OnPropertyChanged(nameof(Barcode));
            }
        }

        public Category SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value;
                OnPropertyChanged(nameof(SelectedCategory));
            }
        }

        public Producer SelectedProducer
        {
            get { return _selectedProducer; }
            set
            {
                _selectedProducer = value;
                OnPropertyChanged(nameof(SelectedProducer));
            }
        }

        public ICommand AddProductInDatabaseCommand { get; set; }
        public ICommand UpdateProductInDatabaseCommand { get; set; }
        public ICommand ReturnCommand { get; set; }

        Product _selectedProduct;

        public EditProductViewModel()
        {
            AddProductInDatabaseCommand = new RelayCommand(AddProductInDatabase);
            ReturnCommand = new RelayCommand<object>(ReturnToMenuFunction);
            Products = productBLL.GetAllProducts();
            Categories = categoryBLL.GetAllCategories();
            Producers = producerBLL.GetAllProducers();
        }

        public EditProductViewModel(Product selectedProduct)
        {
            _selectedProduct = selectedProduct;
            Products = productBLL.GetAllProducts();
            Categories = categoryBLL.GetAllCategories();
            Producers = producerBLL.GetAllProducers();
            // Inițializați proprietățile entitatii cu valorile din utilizatorul selectat
            ProductName = selectedProduct.Name;
            Barcode = selectedProduct.Barcode;
            //find the category object and producer based on the id
            foreach (Category category in Categories)
            {
                if (category.CategoryId == selectedProduct.CategoryId)
                {
                    SelectedCategory = category;
                    break;
                }
            }

            foreach (Producer producer in Producers)
            {
                if (producer.ProducerId == selectedProduct.ProducerId)
                {
                    SelectedProducer = producer;
                    break;
                }
            }
            
            AddProductInDatabaseCommand = new RelayCommand(AddProductInDatabase);
            UpdateProductInDatabaseCommand = new RelayCommand(UpdateProductInDatabase);
            ReturnCommand = new RelayCommand<object>(ReturnToMenuFunction);
            Products = productBLL.GetAllProducts();
        }

        private void AddProductInDatabase()
        {
            if (ProductName == null || Barcode == null || SelectedCategory == null || SelectedProducer == null)
            {
                System.Windows.MessageBox.Show("Please fill in all the fields!");
                return;
            }

            // check if the product is already in the database
            foreach (Product product in Products)
            {
                if (product.Name == ProductName && product.Barcode == Barcode)
                {
                    System.Windows.MessageBox.Show("Product already exists!");
                    return;
                }
            }


            // Insert the product into the database
            productDAL.InsertProduct(ProductName, Barcode, SelectedCategory.CategoryId, SelectedProducer.ProducerId);

            // Refresh the product list
            Products = productBLL.GetAllProducts();
            OnPropertyChanged(nameof(Products));
        }


        private void UpdateProductInDatabase()
        {
            if (ProductName == null || Barcode == null || SelectedCategory == null || SelectedProducer == null)
            {
                System.Windows.MessageBox.Show("Please fill in all the fields!");
                return;
            }
            //check if the user is already in the database
            foreach (Product product in Products)
            {
                if (product.Name == ProductName && product.Barcode == Barcode)
                    return;
            }

            //get the id of the selected category and producer from their name (de adaugat procedura stocata)
            //int categoryId = productBLL.GetCategoryIdByName(SelectedCategory.Name);
            //int producerId = productBLL.GetProducerIdByName(SelectedProducer.Name);
            productDAL.UpdateProduct(_selectedProduct.ProductId, ProductName, Barcode, SelectedCategory.CategoryId, SelectedProducer.ProducerId);

            Products = productBLL.GetAllProducts();
            OnPropertyChanged(nameof(Products));
        }

        private void ReturnToMenuFunction(object obj)
        {
            var currPage = obj as Page;
            currPage.NavigationService.Navigate(new AdminPage());
        }
    }
}
