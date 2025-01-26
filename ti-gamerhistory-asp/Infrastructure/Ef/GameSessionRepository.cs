using Infrastructure.Ef.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Ef;

public class GameSessionRepository: IGameSessionRepository
{
    private readonly GamerHistoryDatabaseContext _context;

    public GameSessionRepository(GamerHistoryDatabaseContext context)
    {
        _context = context;
    }

    public IEnumerable<DbGameSession> FetchAll()
    {
        return _context.GameSessions.ToList();
    }
    
    public async Task<List<DbGameSession>> GetUserHistoryAsync(int userId, int? gameId, int? supportId)
    {
        var query = _context.GameSessions
            .Include(gs => gs.Game)
            .ThenInclude(g => g.Support) 
            .Where(gs => gs.UserId == userId);

        if (gameId.HasValue)
        {
            query = query.Where(gs => gs.GameId == gameId.Value);
        }

        if (supportId.HasValue)
        {
            query = query.Where(gs => gs.Game.SupportId == supportId.Value);
        }

        return await query.ToListAsync();
    }
}