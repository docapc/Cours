using Models;
using Models.Animals;
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
/// Un peu de doc sur le filtrage 
/// https://www.codeproject.com/Articles/170095/WPF-Custom-Control-FilterControl-for-ListBox-ListV
/// https://docs.microsoft.com/en-us/windows/apps/design/controls/listview-filtering
/// https://brandewinder.com/2010/09/28/Auto-complete-quick-search-WPF-ListBox/
/// https://docs.microsoft.com/fr-fr/dotnet/desktop/wpf/data/how-to-sort-and-group-data-using-a-view-in-xaml?view=netframeworkdesktop-4.8
/// https://docs.microsoft.com/en-us/answers/questions/181413/how-to-filter-listbox-in-wpf.html
/// Sur du grouping 
/// https://docs.microsoft.com/en-us/dotnet/desktop/wpf/data/how-to-sort-and-group-data-using-a-view-in-xaml?view=netframeworkdesktop-4.8
/// https://stackoverflow.com/questions/30754922/individual-observable-collections-vs-filtered-observable-collection-performance
/// </summary>
namespace WinApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //public ObservableCollection<Animal> Animals { get; set; } = new ObservableCollection<Animal> (); 
        public AnimalList AnimalList { get; set; } = new AnimalList();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnWindowLoaded(object sender, RoutedEventArgs e)
        {
            LoadAnimals();
            DataContext = AnimalList;
        }

        private void LoadAnimals()
        {
            AnimalList.Animals = new ObservableCollection<Animal>();
            AnimalList.Animals.Add(new Owl() { Id = 1, Name = "Roger", IsFeeded = true });
            AnimalList.Animals.Add(new Tiger() { Id = 2, Name = "Maurice", IsFeeded = false });
        }

    }
}
