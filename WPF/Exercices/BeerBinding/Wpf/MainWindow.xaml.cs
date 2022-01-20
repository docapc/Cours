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

/// <summary>
/// Binding : liens dynamique et directionelle entre deux propriété
/// </summary>
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

        public ObservableCollection<BeerModel> BeerObsCol { get; set; } = new ObservableCollection<BeerModel>();
        public MainWindow()
        {
            InitializeComponent();
            // Notes : ne pas oublier le .Map
            var beersModel = _mapper.Map<IEnumerable<BeerModel>>(_beerRepository.GetAllBeers());
            BeerObsCol = new ObservableCollection<BeerModel>(beersModel);

            var BeerList = new ObservableCollection<BeerModel>(beersModel).ToList<BeerModel>();
            //DataContext = beersModel;
            //DataContext = new ObservableCollection<BeerModel>(beersModel);
            DataContext = BeerObsCol;
//            BeerList = ObservableCollection<BeerModel>(BeerList);

        }

        public void Click_AddButton(object sender , RoutedEventArgs e)
        {
            var nameToAdd = TbName; // On récupère ce qu'il y a dans le textbox TbName
            var beer = new BeerModel() { Name = nameToAdd.Text };
            BeerObsCol.Add(beer);
        }

        public void Click_DelButton(object sender, RoutedEventArgs e)
        {
            //var beerToDel = ListId.SelectedItem as BeerModel;
            if (DetailedBeer.DataContext is BeerModel beerToDel) // équivalent à la ligne du dessous (au moin en terme de fonctionnalité)
            //if (ListId.SelectedItem is BeerModel beerToDel)
            {
                BeerObsCol.Remove(beerToDel);
            }
        }

        public void Click_UpdateButton(object sender, RoutedEventArgs e)
        {
            var nameToUpdate = DetailedTbName.Text; // On récupère ce qu'il y a dans le textbox TbName
            // Update par modification direct de l'objet
            if (ListId.SelectedItem is BeerModel oldBeer)
            //if (DetailedBeer.DataContext is BeerModel oldBeer)
            {
                //var deg = oldBeer.Degree.GetType();
                //typeof(oldBeer.Degree);
                //typeof();
                oldBeer.Name = DetailedTbName.Text;
                oldBeer.Degree = float.Parse(DetailedTbDegree.Text);
                oldBeer.Ibu = float.Parse(DetailedTbIbu.Text);
            }
        }

        public void Click_ReplaceButton(object sender, RoutedEventArgs e)
        {
            var nameToUpdate = DetailedTbName.Text; // On récupère ce qu'il y a dans le textbox TbName

            // Update par remplacement
            if (ListId.SelectedItem is BeerModel oldBeer)
            //if (DetailedBeer.DataContext is BeerModel oldBeer)
            {
                var updatedBeer = new BeerModel() { Name = nameToUpdate,
                    Degree = float.Parse(DetailedTbDegree.Text),
                    Ibu = float.Parse(DetailedTbIbu.Text)
                };
                int rindex = BeerObsCol.IndexOf(oldBeer);
                if (rindex >= 0) { BeerObsCol[rindex] = updatedBeer; }
                // refocus sur le nouvelle élément à l'emplacement de l'ancien
                ListId.SelectedItem = updatedBeer;
            }
        }
    }
}
