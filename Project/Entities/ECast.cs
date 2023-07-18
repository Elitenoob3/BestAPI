namespace Project.Entities;

public class ECast : BaseEntity
{
    public string Name { get; set; }
    public string Role { get; set; }
    public EMovie Movie { get; set;}
    public int movieId { get; set; }
}