namespace Project.DOTS.Movie;

public class DMovie
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    
    public List<DGenre> Genres { get; set; }
    public List<DCast> Cast { get; set; }
    
    public string VideoSource { get; set; }
}