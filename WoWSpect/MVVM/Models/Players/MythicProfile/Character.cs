namespace WoWSpect.MVVM.Models.Players.MythicProfile;

public record Character
{
    public Key key { get; set; }
    public string name { get; set; }
    public int id { get; set; }
    public Realm realm { get; set; }
}