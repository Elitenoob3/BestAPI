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
    
    /*
    public EGenre PutDb(EGenre genre)
    {

    }
    
    public EGenre DeleteDb(EGenre genre)
    {

    }
    
    public EGenre GetIdDb(EGenre genre)
    {

    }
    
    public EGenre GetListDb(EGenre genre)
    {
        
    }
    */
}