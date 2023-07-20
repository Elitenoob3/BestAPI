using Microsoft.EntityFrameworkCore;
using Project.DOTS;
using Project.Entities;
using Project.Persistance;

namespace Project.Repository;

public class CastRepository
{
    public ECast? Add(int movieId, ECast cast)
    {
        using (ContextDb contextDb = new ContextDb())
        {
            var movie = contextDb.Movies.Find(movieId);
            if (movie != null)
            {            
                contextDb.Casts.Add(cast);
                cast.movieId = movieId;
                cast.Movie = movie;
                contextDb.Movies.Entry(cast.Movie).State = EntityState.Unchanged;
                contextDb.SaveChanges();

                return contextDb.Casts.OrderBy(x=>x.Id).Last();
            }

            return null;
        }
    }
    
    public ECast? Put(int movieId, ECast cast, int id)
    {
        using (ContextDb contextDb = new ContextDb())
        {
            var movie = contextDb.Movies.Find(movieId);
            var oldCast = contextDb.Casts.Where(x=>(x.movieId == movieId && x.Id == id)).ToList();
            if (movie != null && oldCast.Count > 0)
            {
                oldCast[0].Name = cast.Name;
                oldCast[0].Role = cast.Role;
                
                contextDb.SaveChanges();

                return contextDb.Casts.OrderBy(x=>x.Id).Last();
            }

            return null;
        }
    }
    
    public ECast? GetId(int movieId, int id)
    {
        using (ContextDb contextDb = new ContextDb())
        {
            var cast = contextDb.Casts.Where(x=>(x.movieId == movieId && x.Id == id)).ToList();
            if (cast.Count > 0) return cast[0];
            return null;
        }
    }
    
    public DPaginationList<ECast>? GetList(int movieId, PaginationParams paginationParams)
    {
        ContextDb contextDb = new ContextDb();
        DPaginationList<ECast> ret = new DPaginationList<ECast>();
        
        var res = contextDb.Casts.Where(x=>(x.movieId == movieId)).ToList();
        if (res.Count == 0) return null;

        ret.DPagination.Page = paginationParams.Page;
        ret.DPagination.PerPage = paginationParams.PerPage;
        ret.DPagination.TotalCount = contextDb.Genres.Count();

        if (paginationParams.Term == null)
        {
            ret.Items = contextDb.Casts.Where(x=>x.movieId == movieId).ToList();;
        }
        else
            ret.Items = contextDb.Casts.Where(x => x.Name.Contains(paginationParams.Term) && x.movieId == movieId)
                .Skip(paginationParams.PerPage * (paginationParams.Page - 1)).Take(paginationParams.PerPage).ToList();

        return ret;
    }
    
}