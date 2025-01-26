namespace Application.UseCases.User.Dtos;

public class DtoOutputUser
{
    public int Id { get; set; }
    public string Pseudo { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
}