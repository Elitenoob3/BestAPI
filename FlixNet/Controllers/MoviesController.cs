using Microsoft.AspNetCore.Mvc;
using Project.DOTS;
using Project.DOTS.Movie;
using Project.Services;

namespace Project.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class MoviesController : Controller
{
    private readonly MovieService _movieServices;

    public MoviesController()
    {
        _movieServices = new MovieService();
    }

    [HttpGet("{id}")]
    public ActionResult<string> GetMovieId(int id)
    {
        var ret = _movieServices.GetId(id);
        if (ret != null)
            return Ok(_movieServices.GetId(id));
        else
            return NotFound("Movie not found by ID");
    }

    [HttpGet]
    public ActionResult<string> GetMoviesList([FromQuery] PaginationParams paginationParams)
    {
        return Ok(_movieServices.GetList(paginationParams));
    }

    //Add Value or Post
    [HttpPost]
    public ActionResult<string> Post([FromBody] DMovieUpdate movie)
    {
        return Ok(_movieServices.Post(movie));
    }
    
    //Update or Put
    [HttpPut("{id}")]
    public ActionResult<string> PutMovieId([FromBody] DMovieUpdate dMovieUpdate, int id)
    {
        return Ok(_movieServices.Put(dMovieUpdate, id));
    }
    
    //Not intended
    [HttpDelete]
    public void Delete(int id)
    {
    }
    
}