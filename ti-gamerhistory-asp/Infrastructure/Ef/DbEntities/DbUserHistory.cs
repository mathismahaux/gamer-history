namespace Infrastructure.Ef.DbEntities;

public class DbUserHistory
{
    public int SessionId { get; set; }
    public string GameName { get; set; }
    public int GametimeMin { get; set; }
    public DateTime SessionDatetime { get; set; }
    public string SupportName { get; set; }
}