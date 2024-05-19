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
    public class EditCategoryViewModel : BaseViewModel
    {
        public ObservableCollection<Category> Categories { get; set; }
        private CategoryDAL categoryDAL = new CategoryDAL();
        private CategoryBLL categoryBLL = new CategoryBLL();
        private string _category;

        public ICommand AddCategoryInDatabaseCommand { get; set; }
        public ICommand UpdateCategoryInDatabaseCommand { get; set; }
        public ICommand ReturnCommand { get; set; }

        Category _selectedCategory;
        public string Category
        {
            get { return _category; }
            set
            {
                _category = value;
                OnPropertyChanged(nameof(Category));
            }
        }
        public EditCategoryViewModel()
        {
            ReturnCommand = new RelayCommand<object>(ReturnToMenuFunction);
            Categories = categoryBLL.GetAllCategories();
        }

        public EditCategoryViewModel(Category selectedCategory)
        {
            _selectedCategory = selectedCategory;
            // Inițializați proprietatea CategoryName cu valorile din utilizatorul selectat
            Category = selectedCategory.Name;

            AddCategoryInDatabaseCommand = new RelayCommand(AddCategoryInDatabase);
            UpdateCategoryInDatabaseCommand = new RelayCommand(UpdateCategoryInDatabase);
            ReturnCommand = new RelayCommand<object>(ReturnToMenuFunction);
            Categories = categoryBLL.GetAllCategories();
        }

        private void AddCategoryInDatabase()
        {
            if (Category == "")
                return;
            foreach(Category cat in Categories)
            {
                if (cat.Name == Category)
                    return;
            }

            categoryDAL.InsertCategory(Category);
            Categories = categoryBLL.GetAllCategories();
            OnPropertyChanged(nameof(Categories));
        }

        private void UpdateCategoryInDatabase()
        {
            if(Category == "")
                return;
            foreach (Category cat in Categories)
            {
                if (cat.Name == Category)
                    return;
            }
            categoryDAL.UpdateCategory(_selectedCategory.CategoryId, Category);
            Categories = categoryBLL.GetAllCategories();
            OnPropertyChanged(nameof(Categories));
        }

        private void ReturnToMenuFunction(object obj)
        {
            var currPage = obj as Page;
            currPage.NavigationService.Navigate(new AdminPage());
        }

        
    }
}
