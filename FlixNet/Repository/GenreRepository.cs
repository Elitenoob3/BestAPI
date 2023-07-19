using Project.DOTS;
using Project.DOTS.Movie;
using Project.Entities;
using Project.Mapping;
using Project.Persistance;

namespace Project.Repository;

public class GenreRepository
{
    public EGenre PostDb(EGenre genre)
    {
        ContextDb contextDb = new ContextDb();
        contextDb.Genres.Add(genre);
        contextDb.SaveChanges();
        return contextDb.Genres.OrderBy(x=>x.Id).Last();
    }
    
    public EGenre? GetIdDb(int id)
    {
        ContextDb contextDb = new ContextDb();
        return contextDb.Genres.Find(id);
    }
    
    public DPaginationList<EGenre> GetListDb(PaginationParams paginationParams)
    {
        ContextDb contextDb = new ContextDb();
        DPaginationList<EGenre> ret = new DPaginationList<EGenre>();

        ret.DPagination.Page = paginationParams.Page;
        ret.DPagination.PerPage = paginationParams.PerPage;
        ret.DPagination.TotalCount = contextDb.Genres.Count();

        ret.Items = contextDb.Genres.Where(x => x.Name.Contains(paginationParams.Term))
            .Skip(paginationParams.PerPage * (paginationParams.Page - 1)).Take(paginationParams.PerPage).ToList();

        return ret;
    }
    
    
    public EGenre? PutDb(EGenre genre, int id)
    {
        ContextDb contextDb = new ContextDb();
        var toUpdate = contextDb.Genres.Find(id);

        if (toUpdate != null)
        {
            toUpdate.Name = genre.Name;

            contextDb.SaveChanges();
        }
        
        return contextDb.Genres.Find(id);
    }
    
    
    public void DeleteDbEntry(int id)
    {
        ContextDb contextDb = new ContextDb();
        var toDelete = contextDb.Genres.Find(id);

        if (toDelete != null)
        {
            contextDb.Genres.Remove(toDelete);

            contextDb.SaveChanges();
        }
    }
}