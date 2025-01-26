using System.Runtime.InteropServices.JavaScript;
using Infrastructure.Ef.DbEntities;

namespace Infrastructure.Ef;

public class SessionRepository : ISessionRepository
{
    private readonly GamerHistoryDatabaseContext _context;

    public SessionRepository(GamerHistoryDatabaseContext context)
    {
        _context = context;
    }
    
    public DbSession FetchById(int id)
    {
        var session = _context.Sessions.FirstOrDefault(s => s.Id == id);

        if (session == null) throw new KeyNotFoundException($"Session with id {id} has not been found");

        return session;
    }
    
    public DbSession? FetchByUserId(int userId)
    {
        return _context.Sessions.FirstOrDefault(s => s.UserId == userId);
    }

    public DbSession Create(int userId, DateTime startTime)
    {
        var session = new DbSession { UserId = userId, StartTime = startTime };
        _context.Sessions.Add(session);
        _context.SaveChanges();
        return session;
    }

    public bool Delete(int id)
    {
        var session = _context.Sessions.FirstOrDefault(s => s.Id == id);

        if (session == null)
        {
            return false;
        }
        
        _context.Sessions.Remove(session);
        _context.SaveChanges();
        return true;
    }
}