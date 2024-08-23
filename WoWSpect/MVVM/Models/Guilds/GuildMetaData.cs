namespace WoWSpect.MVVM.Models.Guilds;

public record GuildMetaData
{
    public Links _links { get; set; }
    public Guild guild { get; set; }
    public List<Member> members { get; set; }
}