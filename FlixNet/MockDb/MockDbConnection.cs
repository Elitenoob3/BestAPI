using Project.DOTS.Movie;
using System.IO;
using Newtonsoft.Json;
using Project.DOTS;

namespace Project.MockDb;

public class MockDbConnection
{
    private List<DMovie> movies;

    public MockDbConnection ()
    {
        string raw = File.ReadAllText("C:/Users/brain/Git/BestAPI/FlixNet/MockDb/movies_database.json");
        movies = JsonConvert.DeserializeObject<List<DMovie>>(raw);
    }

    public DMovie GetMovieId(int id)
    {
        return movies[id - 1];
    }

    public DPaginationList<DMovie> GetMovieQuery(PaginationParams pagParams)
    {
        //Initialize
        DPaginationList<DMovie> ret = new DPaginationList<DMovie>
        {
            Items = new List<DMovie>(),
            DPagination = new DPagination()
        };
        
        //Search
        var data = movies.Where(x=>x.Title.Contains(pagParams.Term)).ToList();
        
        //PageData
        DPagination pag = new DPagination
        {
            Page = pagParams.Page,
            PerPage = pagParams.PerPage,
            TotalCount = data.Count
        };
        
        for (int i = (pagParams.Page-1)*pagParams.PerPage; i < data.Count; i++)
        {
            if(ret.Items.Count < pagParams.PerPage)
                ret.Items.Add(data[i]);
            else break;
        }
        ret.DPagination = pag;
        
        return ret;
    }
}