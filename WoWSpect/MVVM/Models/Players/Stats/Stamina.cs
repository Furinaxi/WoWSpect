namespace WoWSpect.MVVM.Models.Players.Stats;

public record Stamina
{
    public int @base { get; set; }
    public int effective { get; set; }
}