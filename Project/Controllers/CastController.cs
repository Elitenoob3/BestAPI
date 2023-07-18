using Microsoft.AspNetCore.Mvc;
using Project.DOTS;
using Project.DOTS.Movie;

namespace Project.Controllers;

[Route("api/v1/movies/{movieId}/[controller]")]
[ApiController]
public class CastController : Controller
{
    [HttpGet("{id}")]
    public ActionResult<string> GetMovieCastListId([FromRoute] int movieId, int id)
    {
        return Ok($"{movieId}, {id}");
    }
    
    [HttpGet]
    public ActionResult<string> GetMovieCastList([FromRoute] int movieId, [FromQuery] PaginationParams paginationParams)
    {
        return Ok(paginationParams);
    }
    
    //Add Value
    [HttpPost]
    public ActionResult<string> Post([FromBody] DCast cast)
    {
        return Ok();
    }
    
    //Update
    [HttpPut("{id}")]
    public ActionResult<string> PutCastId(int id)
    {
        return Ok();
    }
}