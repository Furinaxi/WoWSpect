namespace WoWSpect.MVVM.Models.Players;

public record ActiveTitle
{
    public Key key { get; set; }
    public string name { get; set; }
    public int id { get; set; }
    public string display_string { get; set; }
}