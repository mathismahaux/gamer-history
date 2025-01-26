using System.ComponentModel.DataAnnotations;

namespace Application.UseCases.User.Dtos;

public class DtoInputCreateUser
{
    [Required] public string Pseudo { get; set; }
    [Required] public string Email { get; set; }
    [Required] public string Password { get; set; }
    [Required] public string Role { get; set; }
}