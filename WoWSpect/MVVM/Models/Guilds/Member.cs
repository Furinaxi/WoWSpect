namespace WoWSpect.MVVM.Models.Guilds;

public record Member
{
    public Character character { get; set; }
    public int rank { get; set; }
}