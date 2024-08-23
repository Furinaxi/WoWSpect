namespace WoWSpect.MVVM.Models.Guilds;

public record Guild
{
    public Key key { get; set; }
    public string name { get; set; }
    public int id { get; set; }
    public Realm realm { get; set; }
    public Faction faction { get; set; }
}