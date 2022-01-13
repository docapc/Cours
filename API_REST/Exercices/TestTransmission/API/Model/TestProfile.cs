using AutoMapper;
using Dtos;
using Entities;

namespace API.Model
{
    public class TestProfile : Profile
    { 
        public TestProfile()
        {
            // Map de entity (Entré/Sortie BDD via EF) à Dbo (Entrée/Sortie de l'API)
            CreateMap<TestDto, TestEntity>().ReverseMap();

            // OU

            //CreateMap<ProjectDto, Project>().ForMember(
            //    dest => dest.Surname,
            //    opt => opt.MapFrom(src => $"{src.Name}"));
            //CreateMap<Project, ProjectDto>();
        }
    }
    
}
