using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using DemoBinding.Utils;
using DemonBinding.Models;
using Polly;

namespace DemoBinding.UserControls
{
    /// <summary>
    /// Logique d'interaction pour HomePage.xaml
    /// </summary>
    public partial class HomePage : UserControl, INotifyPropertyChanged
    {
        private readonly IDataManager<UserModel, UserDto> _userDataManager
            = ((App)Application.Current).UserDataManager;


        public INavigator Navigator { get; set; } = ((App)Application.Current).ServiceProvider.GetService<INavigator>();
        public UsersList UsersList { get; set; } = new UsersList();

        private string _textSearch;
        public string TextSearch
        {
            get
            {
                return _textSearch;
            }
            set
            {
                _textSearch = value;
                OnPropertyChanged();
                ((CollectionViewSource)Resources["UsersViewSource"]).View.Refresh();
            }
        }

        public Policy Policy { get; set; } = Policy.Handle<Exception>().WaitAndRetry(new[]
        {
            TimeSpan.FromSeconds(5),
            TimeSpan.FromSeconds(10),
            TimeSpan.FromSeconds(30)
        });

        public HomePage()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var newUser = new UserModel() { Name = TbUserName.Text };

            //UsersList.Users.Add(newUser);

            await _userDataManager.Add(newUser);

            UsersList.Users.Add(newUser);
          
            //UsersList.Users = new ObservableCollection<UserModel>();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            UsersList.IsVisible = !UsersList.IsVisible;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadUser();
        }

        public async void LoadUser()
        {
            /*await Policy.Execute(async () =>
            {*/
            var userModels = await _userDataManager.GetAll();
            UsersList.Users = new ObservableCollection<UserModel>(userModels);
            UsersList.Users.Add(new AdminModel());
            //});
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (Navigator.CanGoBack())
            {
                Navigator.Back();
            }
        }

        public void CollectionViewSource_OnFilter(object sender, FilterEventArgs e)
        {
            var user = e.Item as UserModel;

            if (string.IsNullOrWhiteSpace(TextSearch) && TextSearch.Length > 3)
            {
                e.Accepted = true; 
                return;
            }

            if (user != null && !string.IsNullOrWhiteSpace(user.Name) && user.Name.Contains(TextSearch))
            {
                e.Accepted = true;
                return;
            }

            e.Accepted = false;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
