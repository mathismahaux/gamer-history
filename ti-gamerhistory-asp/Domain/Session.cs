namespace Domain;

public class Session
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public DateTime StartTime { get; set; } = DateTime.UtcNow;
}