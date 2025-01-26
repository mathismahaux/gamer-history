using System.ComponentModel.DataAnnotations;

namespace Application.UseCases.Game.Dtos;

public class DtoInputCreateGame
{
    [Required] public string Name { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Only positive numbers are allowed ")]
    public int MinutesForCompletion { get; set; }
    
    [Required] public int SupportId { get; set; }
}