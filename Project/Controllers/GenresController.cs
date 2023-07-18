using Microsoft.AspNetCore.Mvc;
using Project.DOTS;
using Project.DOTS.Movie;

namespace Project.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class GenresController : Controller
{
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
        return Ok();
    }
    
    //Update
    [HttpPut("{id}")]
    public ActionResult<string> PutGenreId(int id)
    {
        return Ok();
    }
}