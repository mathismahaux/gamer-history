namespace Infrastructure.Ef.DbEntities;

public class DbGame
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int MinutesForCompletion { get; set; }
    public int SupportId { get; set; }
    public DbSupport Support { get; set; }
}