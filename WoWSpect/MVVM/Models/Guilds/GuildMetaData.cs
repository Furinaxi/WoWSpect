namespace WoWSpect.MVVM.Models.Guilds;

public record Character
{
    public Key key { get; set; }
    public string name { get; set; }
    public int id { get; set; }
    public Realm realm { get; set; }
    public int level { get; set; }
    public PlayableClass playable_class { get; set; }
    public PlayableRace playable_race { get; set; }
}

public record Faction
{
    public string type { get; set; }
    public string name { get; set; }
}

public record Guild
{
    public Key key { get; set; }
    public string name { get; set; }
    public int id { get; set; }
    public Realm realm { get; set; }
    public Faction faction { get; set; }
}

public record Key
{
    public string href { get; set; }
}

public record Links
{
    public Self self { get; set; }
}

public record Member
{
    public Character character { get; set; }
    public int rank { get; set; }
}

public record PlayableClass
{
    public Key key { get; set; }
    public int id { get; set; }
}

public record PlayableRace
{
    public Key key { get; set; }
    public int id { get; set; }
}

public record Realm
{
    public Key key { get; set; }
    public string name { get; set; }
    public int id { get; set; }
    public string slug { get; set; }
}

public record GuildMetaData
{
    public Links _links { get; set; }
    public Guild guild { get; set; }
    public List<Member> members { get; set; }
}

public record Self
{
    public string href { get; set; }
}


