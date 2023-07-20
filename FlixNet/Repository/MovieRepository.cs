using Microsoft.EntityFrameworkCore;
using Project.DOTS;
using Project.DOTS.Movie;
using Project.Entities;
using Project.Persistance;

namespace Project.Repository;

public class MovieRepository
{
    //Add or Post
    public EMovie PostDb(EMovie movie)
    {
        using (ContextDb contextDb = new ContextDb())
        {
            contextDb.Add(movie);
            movie.Genres.ForEach(x=> contextDb.Entry(x).State=EntityState.Unchanged);
            contextDb.SaveChanges();
        }

        using (ContextDb contextDb = new ContextDb())
        {
            var ret = contextDb.Movies.Include(x => x.Genres)
                .OrderBy(x => x.Id).Last();
            return ret;
        }
    }
    
    //Update or Put
    public EMovie? Put(EMovie movieUpdate, int id)
    {
        using (ContextDb contextDb = new ContextDb())
        {
            var toUpdate = contextDb.Movies.Include(x => x.Genres)
                .FirstOrDefault(x => x.Id == id);
            if (toUpdate != null)
            {
                toUpdate.Genres.Clear();
                contextDb.SaveChanges();
            }
            else
            {
                return null;
            }
        }

        using (ContextDb contextDb = new ContextDb())
        {
            var toUpdate = contextDb.Movies.Include(x => x.Genres)
                .FirstOrDefault(x => x.Id == id);

            foreach (var x in movieUpdate.Genres)
            {
                toUpdate.Genres.Add(x);
            }
            
            movieUpdate.Genres.ForEach(z =>
            {
                toUpdate.Genres.Add(z);
                contextDb.Entry(z).State = EntityState.Unchanged;
            });

            contextDb.SaveChanges();
        }

        using (ContextDb contextDb = new ContextDb())
        {
            var toUpdate = contextDb.Movies.Include(x => x.Genres)
                .FirstOrDefault(x => x.Id == id);
            if (toUpdate != null)
            {
                return toUpdate;
            }

            return null;
        }
    }
    
    
    //Get By search term
    public DPaginationList<EMovie> GetListDb(PaginationParams paginationParams)
    {
        ContextDb contextDb = new ContextDb();
        DPaginationList<EMovie> ret = new DPaginationList<EMovie>();

        ret.DPagination.Page = paginationParams.Page;
        ret.DPagination.PerPage = paginationParams.PerPage;
        ret.DPagination.TotalCount = contextDb.Genres.Count();

        if (paginationParams.Term == string.Empty)
        {
            ret.Items = contextDb.Movies.Include(x => x.Genres).ToList();
        }
        else
            ret.Items = contextDb.Movies.Include(x => x.Genres).Where(x => x.Title.Contains(paginationParams.Term))
            .Skip(paginationParams.PerPage * (paginationParams.Page - 1)).Take(paginationParams.PerPage).ToList();

        return ret;
    }
    
    //Get by Id
    public EMovie? GetIdDb(int id)
    {
        ContextDb contextDb = new ContextDb();
        var ret = contextDb.Movies.Include(x => x.Genres).FirstOrDefault(x => x.Id == id);

        if (ret != null)
        {
            return ret;
        }
        return null;
    }
    

    //Delete Movie
    public void DeleteDbEntry(int id)
    {
        using (ContextDb contextDb = new ContextDb())
        {
            var toUpdate = contextDb.Movies.Include(x => x.Genres)
                .FirstOrDefault(x => x.Id == id);
            if (toUpdate != null)
            {
                toUpdate.Genres.Clear();
                contextDb.SaveChanges();
            }
        }

        using (ContextDb contextDb = new ContextDb())
        {        var toDelete = contextDb.Movies.Find(id);

            if (toDelete != null)
            {
                contextDb.Movies.Remove(toDelete);
                contextDb.SaveChanges();
            }
        }
    }
    
}