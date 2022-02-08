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
            AnimalList.Animals.Add(new Tiger() { Id = 1, Name = "Maurice", IsFeeded = false });
        }

    }
}
