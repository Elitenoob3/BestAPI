using Microsoft.AspNetCore.Mvc;
using Project.DOTS;
using Project.DOTS.Movie;
using Project.MockDb;

namespace Project.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class MoviesController : Controller
{
    [HttpGet("{id}")]
    public ActionResult<string> GetMovieId(int id)
    {
        MockDbConnection mockDb = new MockDbConnection();
        return Ok(mockDb.GetMovieId(id));
    }

    [HttpGet]
    public ActionResult<string> GetMoviesList([FromQuery] PaginationParams paginationParams)
    {
        MockDbConnection mockDb = new MockDbConnection();
        return Ok(mockDb.GetMovieQuery(paginationParams));
    }

    //Add Value
    [HttpPost]
    public ActionResult<string> Post([FromBody] DMovie movie)
    {
        return Ok();
    }
    
    //Update
    [HttpPut("{id}")]
    public ActionResult<string> PutMovieId(int id)
    {
        return Ok();
    }
}