namespace WoWSpect.MVVM.Models.Settings;

public record ClientCredentials
{
    public string access_token { get; set; }
    public string token_type { get; set; }
    public int expires_in { get; set; }
    public string sub { get; set; }
}
