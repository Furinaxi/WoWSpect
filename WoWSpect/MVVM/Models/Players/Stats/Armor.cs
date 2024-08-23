namespace WoWSpect.MVVM.Models.Players.Stats;

public record Armor
{
    public int @base { get; set; }
    public int effective { get; set; }
}