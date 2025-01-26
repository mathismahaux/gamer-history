using Application.UseCases.GameSession;
using Application.UseCases.GameSession.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace GamerHistory.Controllers.GameSession;

[ApiController]
[Route("gameSessions")]
public class GameSessionController : ControllerBase
{
    private readonly UseCaseFetchAllGameSessions _useCaseFetchAllGameSessions;

    public GameSessionController(UseCaseFetchAllGameSessions useCaseFetchAllGameSessions)
    {
        _useCaseFetchAllGameSessions = useCaseFetchAllGameSessions;
    }
    
    [HttpGet]
    public ActionResult<IEnumerable<DtoOutputGameSession>> FetchAll()
    {
        return Ok(_useCaseFetchAllGameSessions.Execute());
    }
}