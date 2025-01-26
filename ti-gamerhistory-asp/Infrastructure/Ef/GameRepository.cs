using Infrastructure.Ef.DbEntities;

namespace Infrastructure.Ef;

public class GameRepository : IGameRepository
{
    private readonly GamerHistoryDatabaseContext _context;

    public GameRepository(GamerHistoryDatabaseContext context)
    {
        _context = context;
    }

    public IEnumerable<DbGame> FetchAll()
    {
        return _context.Games.ToList();
    }

    public DbGame FetchById(int id)
    {
        var game = _context.Games.FirstOrDefault(g => g.Id == id);
        
        if (game == null)
            throw new KeyNotFoundException($"Game with id {id} has not been found");

        return game;
    }
    
    public IEnumerable<DbGame> FetchGamesBySupport(int supportId)
    {
        return _context.Games
            .Where(g => g.SupportId == supportId)
            .Select(g => new DbGame
            {
                Id = g.Id,
                Name = g.Name,
                SupportId = g.SupportId
                
            })
            .ToList();
    }

    public DbGame Create(string name, int minutesForCompletion, int supportId)
    {
        var game = new DbGame
        {
            Name = name,
            MinutesForCompletion = minutesForCompletion,
            SupportId = supportId
        };
        _context.Games.Add(game);
        _context.SaveChanges();
        return game;
    }
}