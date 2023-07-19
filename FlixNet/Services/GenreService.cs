using AutoMapper;
using Project.DOTS;
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

    public DGenre? GetId(int id)
    {
        var toConvert = _genreRepository.GetIdDb(id);
        if (toConvert != null)
        {
            return ProjectMapper.Instance.Map<EGenre, DGenre>(toConvert);
        }

        return null;
    }

    public DPaginationList<DGenre> GetList(PaginationParams paginationParams)
    {
        var toConvert = _genreRepository.GetListDb(paginationParams);
        return ProjectMapper.Instance.Map<DPaginationList<EGenre>, DPaginationList<DGenre>>(toConvert);
    }

    public DGenre? Put(DGenre genre, int id)
    {
        var eGenre = ProjectMapper.Instance.Map<DGenre, EGenre>(genre);
        var toCovert = _genreRepository.PutDb(eGenre, id);
        if (toCovert != null)
        {        
            return ProjectMapper.Instance.Map<EGenre, DGenre>(toCovert);
        }

        return null;
    }

    public void Delete(int id)
    {
        _genreRepository.DeleteDbEntry(id);
    }
}