namespace Infrastructure.Ef.DbEntities;

public class DbSupport
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<DbGame> Games { get; set; }

}