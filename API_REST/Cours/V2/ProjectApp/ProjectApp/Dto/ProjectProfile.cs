using AutoMapper;
using ProjectApp.Model;

namespace ProjectApp.Dto
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<ProjectDto, Project>().ReverseMap();

            // OU
            //CreateMap<ProjectDto, Project>().ForMember(
            //    dest => dest.Name,
            //    opt => opt.MapFrom(src => $"{src.Name}"));
            //CreateMap<Project,ProjectDto> ();

        }
    }
}
