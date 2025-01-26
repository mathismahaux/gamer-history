using Application.UseCases.Support;
using Application.UseCases.Support.Dtos;
using Microsoft.AspNetCore.Mvc;
using DtoOutputGame = Application.UseCases.Game.Dtos.DtoOutputGame;

namespace GamerHistory.Controllers.Support;

[ApiController]
[Route("supports")]
public class SupportController : ControllerBase
{
    private readonly UseCaseFetchAllSupports _useCaseFetchAllSupports;
    private readonly UseCaseFetchGamesBySupport _useCaseFetchGamesBySupport;
    private readonly UseCaseFetchSupportById _useCaseFetchSupportById;

    public SupportController(UseCaseFetchGamesBySupport useCaseFetchGamesBySupport, UseCaseFetchAllSupports useCaseFetchAllSupports, UseCaseFetchSupportById useCaseFetchSupportById)
    {
        _useCaseFetchGamesBySupport = useCaseFetchGamesBySupport;
        _useCaseFetchAllSupports = useCaseFetchAllSupports;
        _useCaseFetchSupportById = useCaseFetchSupportById;
    }
    
    [HttpGet]
    public ActionResult<IEnumerable<DtoOutputSupport>> FetchAll()
    {
        return Ok(_useCaseFetchAllSupports.Execute());
    }
    
    [HttpGet]
    [Route("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<DtoOutputSupport> FetchById(int id)
    {
        try
        {
            return _useCaseFetchSupportById.Execute(id);
        }
        catch (KeyNotFoundException e)
        {
            return NotFound(new
            {
                e.Message
            });
        }
    }
    
    [HttpGet]
    [Route("{id}/games")]
    public ActionResult<IEnumerable<DtoOutputGame>> FetchGamesBySupport(int id)
    {
        try
        {
            var games = _useCaseFetchGamesBySupport.Execute(id);
            return Ok(games);
        }
        catch (KeyNotFoundException e)
        {
            return NotFound(new
            {
                e.Message
            });
        }
    }
}