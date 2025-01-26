using Infrastructure.Ef.DbEntities;

namespace Infrastructure.Ef;

public interface IGameSessionRepository
{
    IEnumerable<DbGameSession> FetchAll();
    Task<List<DbGameSession>> GetUserHistoryAsync(int userId, int? gameId, int? supportId);

}