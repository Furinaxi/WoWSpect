namespace WoWSpect.MVVM.Models.Players;

public record CharacterStatusData
{
    public Links _links { get; set; }
    public int id { get; set; }
    public bool is_valid { get; set; }
}
