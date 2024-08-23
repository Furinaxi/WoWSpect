namespace WoWSpect.MVVM.Models.Players.MythicSeason;

public record Realm
{
    public Key key { get; set; }
    public int id { get; set; }
    public string slug { get; set; }
    public string name { get; set; }
}