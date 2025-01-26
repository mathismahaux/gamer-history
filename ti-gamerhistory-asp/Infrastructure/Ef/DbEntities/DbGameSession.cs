namespace Infrastructure.Ef.DbEntities;

public class DbGameSession
{
    public int Id { get; set; }
    public int GameTimeMin { get; set; }
    public int UserId { get; set; }
    public int GameId { get; set; }
    public DateTime SessionDateTime { get; set; }
    public DbGame Game { get; set; }
}