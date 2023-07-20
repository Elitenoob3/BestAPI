using Microsoft.AspNetCore.Mvc;
using Project.DOTS;
using Project.DOTS.Movie;
using Project.Repository;
using Project.Services;

namespace Project.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class GenresController : Controller
{
    private readonly GenreService _genreService;

    public GenresController()
    {
        _genreService = new GenreService();
    }

    [HttpGet("{id}")]
    public ActionResult<string> GetGenreId(int id)
    {
        var data = _genreService.GetId(id);
        if (data != null)
            return Ok(data);
        else
            return NotFound("Entry Id does not exist");
    }
    
    //Search by term
    [HttpGet]
    public ActionResult<string> GetGenresList([FromQuery] PaginationParams paginationParams)
    {
        return Ok(_genreService.GetList(paginationParams));
    }
    
    //Add Value or Post
    [HttpPost]
    public ActionResult<string> Post([FromBody] DGenre genre)
    {
        return Ok(_genreService.Post(genre));
    }
    
    //Update OR Put
    [HttpPut("{id}")]
    public ActionResult<string> PutGenreId([FromBody] string genre, int id)
    {
        //PatchFix
        DGenre enter = new DGenre()
        {
            Id = id,
            Name = genre,
        };
        
        var data = _genreService.Put(enter, id);
        if (data != null)
            return Ok(data);
        else
            return NotFound("Entry Id does not exist");
    }
    
    [HttpDelete("{id}")]
    public ActionResult<string> DeleteGenre(int id)
    {
        _genreService.Delete(id);
        return Ok("Entry deleted");
    }
}