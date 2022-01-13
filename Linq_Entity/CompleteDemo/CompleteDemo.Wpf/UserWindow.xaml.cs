using CompleteDemo.Persistance;
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
using System.Windows.Shapes;

namespace CompleteDemo.Wpf
{
    /// <summary>
    /// Logique d'interaction pour UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public IUserManager UserManager { get; }


        public UserWindow()
        {
            InitializeComponent();
            if (Application.Current is App app)
            {
                UserManager = app.UserManager;
            }
        }
    }
}
