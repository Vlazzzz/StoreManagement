using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tema3.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private Object? _currentPage;

        public Object? CurrentPage
        {
            get => _currentPage;
            set
            {
                _currentPage = value;
                OnPropertyChanged(nameof(CurrentPage));
            }
        }

        public MainViewModel()
        {
            CurrentPage = new LoginPage();
        }
    }
}
