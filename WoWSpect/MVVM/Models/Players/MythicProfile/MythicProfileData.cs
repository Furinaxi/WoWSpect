namespace WoWSpect.MVVM.Models.Players.MythicProfile;

public record MythicProfileData
{
    public Links _links { get; set; }
    public CurrentPeriod current_period { get; set; }
    public List<Season> seasons { get; set; }
    public Character character { get; set; }
    public CurrentMythicRating current_mythic_rating { get; set; }
}