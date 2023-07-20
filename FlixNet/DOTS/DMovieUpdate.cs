namespace Project.DOTS;

public class DMovieUpdate
{
    public string Title { get; set; }
    public string Description { get; set; }
    
    public List<int> GenreIds { get; set; }
    
    public string VideoSourceUrl { get; set; }
    public string ImageUrl { get; set; }
}
