using Infrastructure.Ef.DbEntities;

namespace Infrastructure.Ef;

public class UserRepository : IUserRepository
{
    private readonly GamerHistoryDatabaseContext _context;

    public UserRepository(GamerHistoryDatabaseContext context)
    {
        _context = context;
    }

    public IEnumerable<DbUser> FetchAll()
    {
        return _context.Users.ToList();
    }

    public DbUser FetchById(int id)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == id);

        if (user == null) throw new KeyNotFoundException($"User with id {id} has not been found");

        return user;
    }

    public DbUser Create(string pseudo, string email, string password, string role)
    {
        var user = new DbUser { Pseudo = pseudo, Email = email, Password = password, Role = role };
        _context.Users.Add(user);
        _context.SaveChanges();
        return user;
    }
    
    public DbUser FetchByUsername(string pseudo)
    {
        var user = _context.Users.FirstOrDefault(u => u.Pseudo == pseudo);

        if (user == null) throw new KeyNotFoundException($"User with pseudo {pseudo} has not been found");

        return user;
    }
}