using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
using DemoBinding.Annotations;
using DemoBinding.ApiData;
using DemoBinding.Dtos;
using DemoBinding.Persistance;
using DemonBinding.Models;
using Microsoft.Win32;
using Path = System.IO.Path;

namespace DemoBinding.UserControls
{
    /// <summary>
    /// Logique d'interaction pour UserDetailUC.xaml
    /// </summary>
    public partial class UserDetailUC : UserControl
    {

        public IDataManager<UserModel,UserDto> DataManager => ((App) Application.Current).UserDataManager; 

        private static readonly DependencyProperty CurrentUserProperty = 
            DependencyProperty.Register("CurrentUser",typeof(UserModel),typeof(UserDetailUC));

        private UserModel currentUser;
        public UserModel CurrentUser
        {
            get { return GetValue(CurrentUserProperty) as UserModel; }
            set
            {
                if (currentUser != value)
                {
                   SetValue(CurrentUserProperty , value);
                }
            }
        }


        public UserDetailUC()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var fileDialog = new OpenFileDialog();
                fileDialog.Filter = "Images | *.jpg";
                fileDialog.ShowDialog();
                var file = fileDialog.OpenFile() as FileStream;
                //if(file != null)
                //{
                //    using var fileStream = File.OpenWrite(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                //        "Images", Path.GetFileName(file.Name)));
                //    file.CopyTo(fileStream);
                //}

                var userImage = File.ReadAllBytes(file.Name);
                CurrentUser.Image = userImage;
                DataManager.Add(CurrentUser);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
