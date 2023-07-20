using AutoMapper;
using Project.DOTS;
using Project.DOTS.Movie;
using Project.Entities;

namespace Project.Mapping;

public class ProjectMapper
{
    public static IMapper Instance { get; set; } = Configure();

    private static IMapper Configure()
    {
        return new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<DMovie, EMovie>().ReverseMap();
            cfg.CreateMap<DGenre, EGenre>().ReverseMap();
            cfg.CreateMap<DCast, ECast>().ReverseMap();

            cfg.CreateMap<DMovieUpdate, EMovie>()
                .ForMember(
                    dest => dest.Genres,
                    opt => 
                        opt.MapFrom(src =>
                        src.GenreIds.Select(id => new EGenre { Id = id }).ToList()
                    )
                );
                    
            
            cfg.CreateMap(typeof(DPaginationList<>), typeof(DPaginationList<>));
            cfg.CreateMap<DPagination, DPagination>();
            
            

        }).CreateMapper();
    }
}