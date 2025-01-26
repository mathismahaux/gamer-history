namespace Application.UseCases.User.Dtos;

public class DtoOutputUserHistory
{
    public string GameName { get; set; }
    public int GameTimeMin { get; set; }
    public DateTime SessionDateTime { get; set; }
    public string SupportName { get; set; }
}