using AutoMapper;
using Project.DOTS.Movie;
using Project.Entities;
using Project.Mapping;
using Project.Repository;


namespace Project.Services;

public class GenreService
{
    private readonly GenreRepository _genreRepository;

    public GenreService()
    {
        _genreRepository = new GenreRepository();
    }
    
    public DGenre Post(DGenre genre)
    {
        var eGenre =  ProjectMapper.Instance.Map<DGenre, EGenre>(genre); 
        var toConvert = _genreRepository.PostDb(eGenre);
        return ProjectMapper.Instance.Map<EGenre, DGenre>(toConvert);
    }
}