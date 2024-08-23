namespace WoWSpect.MVVM.Models.Players.MythicSeason;

public record Member
{
    public Character character { get; set; }
    public Specialization specialization { get; set; }
    public Race race { get; set; }
    public int equipped_item_level { get; set; }
}