namespace WoWSpect.MVVM.Models.Players.MythicSeason;

public record BestRun
{
    public object completed_timestamp { get; set; }
    public int duration { get; set; }
    public int keystone_level { get; set; }
    public List<KeystoneAffix> keystone_affixes { get; set; }
    public List<Member> members { get; set; }
    public Dungeon dungeon { get; set; }
    public bool is_completed_within_time { get; set; }
    public MythicRating mythic_rating { get; set; }
    public MapRating map_rating { get; set; }
}