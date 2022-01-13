using AutoMapper;

namespace ProjectWebApi.Dtos
{
    /// <summary>
    /// Profile de mappage pour le automappeur
    /// </summary>
    public class ProjectProfile : Profile // c'est grace à cet héritage qu'automappeur retrouve le profile seul
    {
        public ProjectProfile()
        {
            // c'est ici que l'on définit les map que l'on va utiliser
            CreateMap<ProjectDto, Project>().ReverseMap();   // le reverse map permet d'aller dans les deux sens

            // Si les noms entre les deux sont identique on a pas besoin de spécifier quoi que ce soit mais sinon il faut utiliser ForMember
            // ProjectDto est la source, Project est la destination
            CreateMap<ProjectDto, Project>().ForMember(
                dest => dest.Surname,
                opt => opt.MapFrom(src => $"{src.Name}")
                );
        }
    }
}
