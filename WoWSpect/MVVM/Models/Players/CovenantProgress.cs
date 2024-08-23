namespace WoWSpect.MVVM.Models.Players;

public record CovenantProgress
{
    public ChosenCovenant chosen_covenant { get; set; }
    public int renown_level { get; set; }
    public Soulbinds soulbinds { get; set; }
}