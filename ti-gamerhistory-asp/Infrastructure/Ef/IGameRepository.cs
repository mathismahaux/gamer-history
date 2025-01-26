using Infrastructure.Ef.DbEntities;

namespace Infrastructure.Ef;

public interface IGameRepository
{
    IEnumerable<DbGame> FetchAll();
    DbGame FetchById(int id);
    DbGame Create(string name, int minutesForCompletion, int supportId);
    IEnumerable<DbGame> FetchGamesBySupport(int supportId);

}