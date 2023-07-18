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
    public ActionResult<string> GetGenresListId(int id)
    {
        return Ok(id);
    }
    
    [HttpGet]
    public ActionResult<string> GetGenresList([FromQuery] PaginationParams paginationParams)
    {
        return Ok(paginationParams);
    }
    
    //Add Value
    [HttpPost]
    public ActionResult<string> Post([FromBody] DGenre genre)
    {
        return Ok(_genreService.Post(genre));
    }
    
    //Update
    [HttpPut("{id}")]
    public ActionResult<string> PutGenreId(int id)
    {
        return Ok();
    }
}