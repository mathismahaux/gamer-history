using Infrastructure.Ef.DbEntities;

namespace Infrastructure.Ef;

public class SupportRepository : ISupportRepository
{
    private readonly GamerHistoryDatabaseContext _context;

    public SupportRepository(GamerHistoryDatabaseContext context)
    {
        _context = context;
    }

    public IEnumerable<DbSupport> FetchAll()
    {
        return _context.Supports.ToList();
    }
    
    public DbSupport FetchById(int id)
    {
        var support = _context.Supports.FirstOrDefault(s => s.Id == id);

        if (support == null) throw new KeyNotFoundException($"Support with id {id} has not been found");

        return support;
    }
}