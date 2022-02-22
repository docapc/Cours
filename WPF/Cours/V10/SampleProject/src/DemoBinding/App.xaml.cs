using System.Globalization;
using AutoMapper;
using DemoBinding.ApiData;
using DemoBinding.Dtos;
using DemoBinding.Entities;
using DemoBinding.Persistance;
using DemonBinding.Models;
using System.Net.Http;
using System.Windows;
using System.Windows.Navigation;
using DemoBinding.UserControls;
using DemoBinding.Utils;

namespace DemoBinding
{
    /// <summary>
    /// Interaction logic for App.xamlreé
    /// </summary>
    public partial class App : Application
    {
        private const string SERVER_URL = "https://localhost:7167"; 

        public HttpClient HttpClient { get; } = new HttpClient();

        public IDataManager<UserModel,UserDto> UserDataManager { get; } 

        public IMapper Mapper { get; }
        
        public IServiceProvider ServiceProvider { get; set; } = new ServiceProvider();

        public App()
        {
            //CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
            //CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en-US");
            var configuration = new MapperConfiguration(cfg => cfg.AddMaps(typeof(App)));
            Mapper = new Mapper(configuration);
            UserDataManager = new UserDataManager(HttpClient, Mapper, SERVER_URL);
            ServiceProvider.RegisterService<INavigator>(new Navigator());
        }

        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            var navigator = ServiceProvider.GetService<INavigator>();
            navigator.RegisterView(new LoginPage());
            navigator.RegisterView(new HomePage());
        }
    }
}
