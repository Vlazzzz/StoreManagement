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
    public class EditProducerViewModel : BaseViewModel
    {
        public ObservableCollection<Producer> Producers { get; set; }
        private ProducerBLL producerBLL = new ProducerBLL();
        private ProducerDAL producerDAL = new ProducerDAL();
        private string _producerName;
        private string _originCountry;

        public string ProducerName
        {
            get { return _producerName; }
            set
            {
                _producerName = value;
                OnPropertyChanged(nameof(ProducerName));
            }
        }

        public string OriginCountry
        {
            get { return _originCountry; }
            set
            {
                _originCountry = value;
                OnPropertyChanged(nameof(OriginCountry));
            }
        }
        public ICommand AddProducerInDatabaseCommand { get; set; }
        public ICommand UpdateProducerInDatabaseCommand { get; set; }
        public ICommand ReturnCommand { get; set; }

        Producer _selectedProducer;
        public EditProducerViewModel()
        {
            AddProducerInDatabaseCommand = new RelayCommand(AddProducerInDatabase);
            ReturnCommand = new RelayCommand<object>(ReturnToMenuFunction);
            Producers = producerBLL.GetAllProducers();
        }

        public EditProducerViewModel(Producer selectedProducer)
        {
            Producers = producerBLL.GetAllProducers();
            _selectedProducer = selectedProducer;
            // Inițializați proprietatea ProducerName și OriginCountry cu valorile din producătorul selectat
            ProducerName = selectedProducer.Name;
            OriginCountry = selectedProducer.OriginCountry;

            AddProducerInDatabaseCommand = new RelayCommand(AddProducerInDatabase);
            UpdateProducerInDatabaseCommand = new RelayCommand(UpdateProducerInDatabase);
            ReturnCommand = new RelayCommand<object>(ReturnToMenuFunction);
            Producers = producerBLL.GetAllProducers();
        }

        private void AddProducerInDatabase()
        {
            if (ProducerName == null || OriginCountry == null)
                return;
            //check if the user is already in the database
            foreach (Producer producer in Producers)
            {
                if(producer.Name == ProducerName)
                    return;
            }

            producerDAL.InsertProducer(ProducerName, OriginCountry);
            Producers = producerBLL.GetAllProducers();
            OnPropertyChanged(nameof(Producers));
        }

        private void UpdateProducerInDatabase()
        {
            producerDAL.UpdateProducer(_selectedProducer.ProducerId, ProducerName, OriginCountry);
            Producers = producerBLL.GetAllProducers();
            OnPropertyChanged(nameof(Producers));
        }

        private void ReturnToMenuFunction(object obj)
        {
            var currPage = obj as Page;
            currPage.NavigationService.Navigate(new AdminPage());
        }
    }
}
