using Project.DOTS.Movie;

namespace Project.DOTS;

public class DPaginationList<T>
{
    public List<T> Items { get; set; }
    public DPagination DPagination { get; set; }
}