using Project.DOTS;
using Project.DOTS.Movie;
using Project.Entities;
using Project.Mapping;
using Project.Repository;

namespace Project.Services;

public class CastServices
{
    private readonly CastRepository _castRepository;

    public CastServices()
    {
        _castRepository = new CastRepository();
    }
    
    public DCast? Add(int movieId, DCast cast)
    {
        var eCast = ProjectMapper.Instance.Map<DCast, ECast>(cast);
        var ret = _castRepository.Add(movieId, eCast);
        if (ret != null)
            return ProjectMapper.Instance.Map<ECast, DCast>(ret);
        return null;
    }
    
    public DCast? Put(int movieId, DCast cast, int id)
    {
        var eCast = ProjectMapper.Instance.Map<DCast, ECast>(cast);
        var ret = _castRepository.Put(movieId, eCast, id);
        if (ret != null)
            return ProjectMapper.Instance.Map<ECast, DCast>(ret);
        return null;
    }
    
    public DCast? GetId(int movieId, int id)
    {
        var toConvert = _castRepository.GetId(movieId, id);
        if(toConvert != null)
            return ProjectMapper.Instance.Map<ECast, DCast>(toConvert);
        return null;
    }

    public DPaginationList<DCast>? GetList(int movieId, PaginationParams paginationParams)
    {
        var toConvert = _castRepository.GetList(movieId, paginationParams);
        if(toConvert != null)
            return ProjectMapper.Instance.Map<DPaginationList<ECast>, DPaginationList<DCast>>(toConvert);
        return null;
    }
    
    
}