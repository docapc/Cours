using Models.Animals;
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

namespace WinApp.UserControls
{
    /// <summary>
    /// Logique d'interaction pour AnimalDetail.xaml
    /// </summary>
    public partial class AnimalDetail : UserControl
    {
        private static readonly DependencyProperty AnimalProperty =
            DependencyProperty.Register("CurrentAnimal", typeof(Animal), typeof(AnimalDetail));

        public Animal CurrentAnimal
        {
            get { return GetValue(AnimalProperty) as Animal; }
            set
            {
                if (CurrentAnimal != value)
                {
                    SetValue(AnimalProperty, value);
                }
            }
        }

        public AnimalDetail()
        {
            InitializeComponent();
        }
    }
}
