using Infrastructure.Ef.DbEntities;

namespace Infrastructure.Ef;

public interface ISessionRepository
{
    DbSession FetchById(int id);
    DbSession? FetchByUserId(int id);

    DbSession Create(int userId, DateTime startTime);
    public bool Delete(int id);
}