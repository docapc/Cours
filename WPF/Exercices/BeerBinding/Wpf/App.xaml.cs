using AutoMapper;
using Dtos;
using Extensions;
using Perstistance;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        internal IBeerRepository<BeerDto> BeerRepository { get; }
        internal IMapper Mapper { get; }

        public App()
        {
            BeerRepository = new FakeBeerRepository<BeerDto>();

            // Configuration du Mapper (à partir du profile)
            var configuration = new MapperConfiguration(cfg => cfg.AddMaps(typeof(ModelDtoProfile))); // récupère tt les profiles dans l'assembly

            // Instance du Mappeur en lui même.            
            Mapper = new Mapper(configuration);

        }

    }
}
