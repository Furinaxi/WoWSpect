using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WoWSpect.HelperClasses;
using WoWSpect.MVVM.Models.Guilds;

namespace WoWSpect.MVVM.ViewModels;

public partial class GuildsVM : TokenAccessor
{
    [ObservableProperty]
    private string _region;
    
    [ObservableProperty]
    private string _realm;
    
    [ObservableProperty]
    private string _guildName;
    
    [ObservableProperty]
    private GuildMetaData _gmd;
    
    [ObservableProperty]
    private bool _hasData = false;
    
    [ObservableProperty]
    private List<Member> _sortedMembersList;

    [ObservableProperty]
    private string _infoLabelText = StandardText;
    
    private const string StandardText = "Enter guild information to search.\n\nMultiple words should be separated by a hyphen (-), e.g. Argent Dawn => Argent-Dawn.";
    
    public GuildsVM()
    {
        
    }

    [RelayCommand]
    private async Task SearchGuild()
    {
        if(Region == string.Empty || Realm == string.Empty || GuildName == string.Empty) return;
        
        HasData = false;
        InfoLabelText = "Searching for guild...";

        if (!AccessTokenExists(out string accessToken))
        {
            InfoLabelText = StandardText;
            return;
        }
        
        Region = Region.ToLower();
        Realm = Realm.ToLower();
        GuildName = GuildName.ToLower();
        
        Dictionary<string, string> queryParams = new()
        {
            {"namespace", "profile-" + Region},
            {"locale", "en_US"},
            {"access_token", accessToken}
        };
        
        string guildMetaDataUrl = $"https://{Region}.api.blizzard.com/data/wow/guild/{Realm}/{GuildName}/roster";
        
        var guildMetaData = await APIHandler.Get<GuildMetaData>(guildMetaDataUrl, queryParams);

        if (guildMetaData is not null)
        {
            Gmd = guildMetaData;
            SortedMembersList = Gmd.members.OrderBy(m => m.character.name).ToList();
            HasData = true;
            return;
        }
        
        InfoLabelText = "No guild found. Please check your input.\n\nMultiple words should be separated by a hyphen (-), e.g. Argent Dawn => Argent-Dawn.";
    }
}
