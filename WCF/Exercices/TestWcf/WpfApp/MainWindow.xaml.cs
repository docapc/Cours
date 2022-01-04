using ServiceReference1;
using System;
using System.Collections.Generic;
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

namespace MyExercice.Test.WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TestServiceClient client = new TestServiceClient();
        public MainWindow()
        {
            InitializeComponent();
            //var client = new TestServiceClient();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            var response = client.GetData(60);
            //var response = client.GetDataAsync(60);
            bouton1.Content = response;
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            var response = client.GetUselessData();
            //var response = client.GetDataAsync(60);
            bouton2.Content = response;
        }
    }
}
