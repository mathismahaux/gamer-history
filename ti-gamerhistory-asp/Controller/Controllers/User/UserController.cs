using Application.UseCases.User;
using Application.UseCases.User.Dtos;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GamerHistory.Controllers.User;

[ApiController]
[Route("users")]
public class UserController : ControllerBase
{
    private readonly UseCaseFetchAllUsers _useCaseFetchAllUsers;
    private readonly UseCaseFetchUserById _useCaseFetchUserById;
    private readonly UseCaseCreateUser _useCaseCreateUser;
    private readonly UseCaseGetUserHistory _useCaseGetUserHistory;


    public UserController(UseCaseFetchAllUsers useCaseFetchAllUsers, UseCaseFetchUserById useCaseFetchUserById, UseCaseCreateUser useCaseCreateUser, UseCaseGetUserHistory useCaseGetUserHistory)
    {
        _useCaseFetchAllUsers = useCaseFetchAllUsers;
        _useCaseFetchUserById = useCaseFetchUserById;
        _useCaseCreateUser = useCaseCreateUser;
        _useCaseGetUserHistory = useCaseGetUserHistory;
    }
    
    [HttpGet]
    public ActionResult<IEnumerable<DtoOutputUser>> FetchAll()
    {
        return Ok(_useCaseFetchAllUsers.Execute());
    }
    
    [HttpGet]
    [Route("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<DtoOutputUser> FetchById(int id)
    {
        try
        {
            return _useCaseFetchUserById.Execute(id);
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
    [Route("{id}/history")]
    public async Task<IActionResult> GetUserGameSessionHistory(
        [FromRoute] int id, 
        [FromQuery] int? idGame, 
        [FromQuery] int? idSupport)
    {
        var result = await _useCaseGetUserHistory.ExecuteAsync(id, idGame, idSupport);
        return Ok(result);
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public ActionResult<DtoOutputUser> Create(DtoInputCreateUser dto)
    {
        var output = _useCaseCreateUser.Execute(dto);
        return CreatedAtAction(
            nameof(FetchById),
            new { id = output.Id },
            output
        );
    }
}