using Microsoft.AspNetCore.Mvc;
using Project.DOTS;
using Project.DOTS.Movie;
using Project.Services;

namespace Project.Controllers;

[Route("api/v1/movies/{movieId}/[controller]")]
[ApiController]
public class CastController : Controller
{
    private readonly CastServices _castServices;

    public CastController()
    {
        _castServices = new CastServices();
    }


    //Get id
    [HttpGet("{id}")]
    public ActionResult<string> GetMovieCastListId([FromRoute] int movieId, int id)
    {
        var ret = _castServices.GetId(movieId, id);
        if(ret != null) 
            return Ok(ret);
        return NotFound("Movie or cast Id not found");
    }
    
    //get by term
    [HttpGet]
    public ActionResult<string> GetMovieCastList([FromRoute] int movieId, [FromQuery] PaginationParams paginationParams)
    {
        var ret = _castServices.GetList(movieId, paginationParams);
        if(ret != null) 
            return Ok(ret);
        return NotFound("Movie Id not found");
    }
    
    
    //Add or Post
    [HttpPost]
    public ActionResult<string> Post([FromRoute] int movieId, [FromBody] DCast cast)
    {
        var ret = _castServices.Add(movieId, cast);
        if(ret != null) 
            return Ok(ret);
        return NotFound("Movie Id not found");
    }
    
    //Update or Put
    [HttpPut("{id}")]
    public ActionResult<string> PutCastId([FromRoute] int movieId, int id, [FromBody] DCast cast)
    {
        var ret = _castServices.Put(movieId, cast, id);
        if (ret != null)
            return Ok(ret);
        return NotFound("Movie or cast Id invalid");
    }
}