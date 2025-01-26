namespace Domain;

public class Game
{
    public int Id { get; set; }
    public string Name { get; set; }
    private int _minutesForCompletion;

    public int MinutesForCompletion
    {
        get => _minutesForCompletion;
        set
        {
            if (value < 1)
                throw new ArgumentException($"Minutes for completion must be greater or equal than 1!");

            _minutesForCompletion = value;
        }
    }
    
    public string Support { get; set; }
}