using Application.UseCases.Game;
using Application.UseCases.Game.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GamerHistory.Controllers.Game;

[ApiController]
[Route("games")]
public class GameController : ControllerBase
{
    private readonly UseCaseFetchAllGames _useCaseFetchAllGames;
    private readonly UseCaseCreateGame _useCaseCreateGame;

    public GameController(UseCaseFetchAllGames useCaseFetchAllGames, UseCaseCreateGame useCaseCreateGame)
    {
        _useCaseFetchAllGames = useCaseFetchAllGames;
        _useCaseCreateGame = useCaseCreateGame;
    }

    [HttpGet]
    public ActionResult<IEnumerable<DtoOutputGame>> FetchAll()
    {
        return Ok(_useCaseFetchAllGames.Execute());
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public ActionResult<DtoOutputGame> Create(DtoInputCreateGame dto)
    {
        return Ok(_useCaseCreateGame.Execute(dto));
    }
}