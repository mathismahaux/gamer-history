using Application.UseCases.User.Dtos;
using Infrastructure.Ef;

namespace Application.UseCases.User;

public class UseCaseGetUserHistory
{
    private readonly IGameSessionRepository _repository;

    public UseCaseGetUserHistory(IGameSessionRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<DtoOutputUserHistory>> ExecuteAsync(int userId, int? gameId, int? supportId)
    {
        var gameSessions = await _repository.GetUserHistoryAsync(userId, gameId, supportId);

        return gameSessions.Select(gs => new DtoOutputUserHistory
        {
            GameName = gs.Game.Name,
            GameTimeMin = gs.GameTimeMin,
            SessionDateTime = gs.SessionDateTime,
            SupportName = gs.Game.Support.Name
        }).ToList();
    }
    
}