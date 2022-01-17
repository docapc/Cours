using AutoMapper;
using Dtos;
using Models;
using Perstistance;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IBeerRepository<BeerDto> _beerRepository = 
            ((App)Application.Current).BeerRepository;

        private IMapper _mapper =
            ((App)Application.Current).Mapper;

        public MainWindow()
        {
            InitializeComponent();
            // Notes : ne pas oublier le .Map
            var beersModel = _mapper.Map<IEnumerable<BeerModel>>(_beerRepository.GetAllBeers());
            DataContext = beersModel;
            //DataContext = new ObservableCollection<BeerModel>(beersModel);
        }
    }
}
