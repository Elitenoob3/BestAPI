namespace Project.Entities;

public class EGenre : BaseEntity
{
    public string Name { get; set; }
    public List<EMovie> Movies { get; set; }
}