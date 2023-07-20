using Project.DOTS;
using Project.DOTS.Movie;
using Project.Entities;
using Project.Mapping;
using Project.Repository;

namespace Project.Services;

public class MovieService
{
    private readonly MovieRepository _movieRepository;

    public MovieService()
    {
        _movieRepository = new MovieRepository();
    }
    
    // Post or Add
    public DMovie Post(DMovieUpdate movieUpdate)
    {
        var eMovie = ProjectMapper.Instance.Map<DMovieUpdate, EMovie>(movieUpdate);
        var toConvert = _movieRepository.PostDb(eMovie);
        return ProjectMapper.Instance.Map<EMovie, DMovie>(toConvert);
    }
    
    //Update or Put
    public DMovie? Put(DMovieUpdate movieUpdate, int id)
    {
        var eMovie = ProjectMapper.Instance.Map<DMovieUpdate, EMovie>(movieUpdate);
        var ret = _movieRepository.Put(eMovie, id);
        if (ret != null)
        {
            return ProjectMapper.Instance.Map<EMovie, DMovie>(ret);
        }
        return null;
    }

    //Get By ID
    public DMovie? GetId(int id)
    {
        var toConvert = _movieRepository.GetIdDb(id);
        if (toConvert != null)
        {
            return ProjectMapper.Instance.Map<EMovie, DMovie>(toConvert);
        }
        return null;
    }

    //Get Movies by search term
    public DPaginationList<DMovie> GetList(PaginationParams paginationParams)
    {
        var toConvert = _movieRepository.GetListDb(paginationParams);
        return ProjectMapper.Instance.Map<DPaginationList<EMovie>, DPaginationList<DMovie>>(toConvert);
    }

    
    //Remove or Delete
    public void Delete(int id)
    {
        _movieRepository.DeleteDbEntry(id);
    }
    
}