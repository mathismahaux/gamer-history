using Infrastructure.Ef.DbEntities;

namespace Infrastructure.Ef;

public interface IUserRepository
{
    IEnumerable<DbUser> FetchAll();
    DbUser FetchById(int id);
    DbUser Create(string pseudo, string email, string password, string role);
    DbUser FetchByUsername(string pseudo);
}