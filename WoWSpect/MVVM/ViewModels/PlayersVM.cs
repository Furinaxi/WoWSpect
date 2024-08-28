using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WoWSpect.HelperClasses;
using WoWSpect.MVVM.Models.Players;
using WoWSpect.MVVM.Models.Players.MythicProfile;
using WoWSpect.MVVM.Models.Players.MythicSeason;
using WoWSpect.MVVM.Models.Players.Stats;
using Season = WoWSpect.MVVM.Models.Players.MythicProfile.Season;


namespace WoWSpect.MVVM.ViewModels;

public partial class PlayersVM : TokenAccessor
{
    [ObservableProperty]
    private string _region;
    
    [ObservableProperty]
    private string _realm;
    
    [ObservableProperty]
    private string _characterName;
    
    [ObservableProperty]
    private CharacterMetaData _cmd;
    
    [ObservableProperty]
    private CharacterStatusData _csd;
    
    [ObservableProperty]
    private CharacterStatisticData _cStats;
    
    [ObservableProperty]
    private MythicProfileData _mythicProfile;
    
    [ObservableProperty]
    private MythicSeasonPerformanceData _mythicSeasonPerformance;
    
    [ObservableProperty]
    private List<BestRun> _sortedBestRuns;
    
    [ObservableProperty]
    private bool _hasData = false;

    [ObservableProperty]
    private string _infoLabelText = StandardText;
    
    private const string StandardText = "Enter character information to search.\n\nMultiple words should be separated by a hyphen (-), e.g. Argent Dawn => Argent-Dawn.";

    private static readonly MythicSeasonPerformanceData EmptyMythicSeasonPerformance = new()
    {
        best_runs = new List<BestRun>(),
        season = new ()
        {
            id = 0
        },
        mythic_rating = new ()
        {
            rating = 0
        }
    };
    

    public PlayersVM()
    {
        
    }
    
    [RelayCommand]
    private async Task SearchCharacter()
    {
        if(Region == string.Empty || Realm == string.Empty || CharacterName == string.Empty) return;

        HasData = false;
        InfoLabelText = "Loading...";

        if (!AccessTokenExists(out string accessToken))
        {
            InfoLabelText = StandardText;
            return;
        }
        
        Region = Region.ToLower();
        Realm = Realm.ToLower().Replace(" ", "-");
        CharacterName = CharacterName.ToLower();
        
        Dictionary<string, string> queryParams = new()
        {
            {"namespace", "profile-" + Region},
            {"locale", "en_US"},
            {"access_token", accessToken}
        };

        string characterMetaDataUrl = $"https://{Region}.api.blizzard.com/profile/wow/character/{Realm}/{CharacterName}";
        string characterStatusUrl = $"https://{Region}.api.blizzard.com/profile/wow/character/{Realm}/{CharacterName}/status";

        var characterMetaData = await APIHandler.Get<CharacterMetaData>(characterMetaDataUrl, queryParams);
        var characterStatus = await APIHandler.Get<CharacterStatusData>(characterStatusUrl, queryParams);

        if (characterMetaData is not null && characterStatus is not null)
        {
            Cmd = characterMetaData;
            Csd = characterStatus;
            
            var characterStats = await APIHandler.Get<CharacterStatisticData>(characterMetaData.statistics.href, queryParams);
            
            if (characterStats is not null)
            {
                CStats = characterStats;
            }
            
            var mythicProfile = await APIHandler.Get<MythicProfileData>(characterMetaData.mythic_keystone_profile.href, queryParams);
            
            if (mythicProfile is not null)
            {
                MythicProfile = mythicProfile;
                
                if(MythicProfile.seasons is null)
                {
                    MythicSeasonPerformance = EmptyMythicSeasonPerformance;
                    HasData = true;
                    return;
                }
                
                Season season = MythicProfile.seasons.MaxBy(s => s.id);
                
                var mythicSeasonPerformance = await APIHandler.Get<MythicSeasonPerformanceData>(season.key.href, queryParams);
                
                MythicSeasonPerformance = mythicSeasonPerformance ?? EmptyMythicSeasonPerformance;
            }
            else
            {
                MythicSeasonPerformance = EmptyMythicSeasonPerformance;
            }
            
                            
            if (MythicSeasonPerformance.best_runs.Count > 0)
            {
                SortedBestRuns = InsertionSort(MythicSeasonPerformance.best_runs, (a, b) => a.keystone_level < b.keystone_level).ToList();
            }
            else
            {
                SortedBestRuns = new List<BestRun>();
            }
            
            
            HasData = true;
            return;
        }
        
        InfoLabelText = "Character not found. Please check the region, realm, and character name and try again. \n\nMultiple words should be separated by a hyphen (-), e.g. Argent Dawn => Argent-Dawn.";
    }
    
    private IList<T> InsertionSort<T>(IList<T> list, Func<T, T, bool> comparison)
    {
        for (int i = 1; i < list.Count; i++)
        {
            T key = list[i];
            int j = i - 1;
            while (j >= 0 && comparison(list[j], key))
            {
                list[j + 1] = list[j];
                j -= 1;
            }
            list[j + 1] = key;
        }

        return list;
    }
    
}
