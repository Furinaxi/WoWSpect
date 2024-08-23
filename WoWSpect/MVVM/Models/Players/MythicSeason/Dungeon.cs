namespace WoWSpect.MVVM.Models.Players.MythicSeason;

public record Dungeon
{
    public Key key { get; set; }
    public string name { get; set; }
    public int id { get; set; }
}