using Infrastructure.Ef.DbEntities;

namespace Infrastructure.Ef;

public interface ISupportRepository
{
    IEnumerable<DbSupport> FetchAll();
    DbSupport FetchById(int id);
}