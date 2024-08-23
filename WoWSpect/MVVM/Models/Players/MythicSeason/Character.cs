namespace WoWSpect.MVVM.Models.Players.MythicSeason;

public record Character
{
    public string name { get; set; }
    public int id { get; set; }
    public Realm realm { get; set; }
    public Key key { get; set; }
}