﻿using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WoWSpect.HelperClasses;
using WoWSpect.MVVM.Models.Players;
using WoWSpect.MVVM.Models.Players.MythicProfile;
using WoWSpect.MVVM.Models.Players.MythicSeason;
using WoWSpect.MVVM.Models.Players.Stats;
using Season = WoWSpect.MVVM.Models.Players.MythicProfile.Season;


namespace WoWSpect.MVVM.ViewModels;

public partial class PlayersVM : ObservableObject
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

    private static readonly MythicSeasonPerformanceData EmptyMythicSeasonPerformance = new()
    {
        best_runs = new List<BestRun>()
    };
    
    private static readonly MythicProfileData EmptyMythicProfileData = new MythicProfileData()
    {
        current_mythic_rating = new CurrentMythicRating()
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
        
        if (!AppConfigHandler.TryGetValue(AppConfigHandler.AccessTokenKey, out string accessToken))
        {
            MessageBox.Show("No access token found. Please provide your client ID and client secret.", 
                "Error",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
            return;
        }
        
        Region = Region.ToLower();
        Realm = Realm.ToLower();
        CharacterName = CharacterName.ToLower();

        string characterMetaDataUrl = GetCharacterMetaDataUrl(accessToken);
        string characterStatusUrl = GetCharacterStatusUrl(accessToken);

        var characterMetaData = await APIHandler.Get<CharacterMetaData>(characterMetaDataUrl);
        var characterStatus = await APIHandler.Get<CharacterStatusData>(characterStatusUrl);

        if (characterMetaData is not null && characterStatus is not null)
        {
            Cmd = characterMetaData;
            Csd = characterStatus;
            
            Dictionary<string, string> queryParams = new()
            {
                {"namespace", "profile-" + Region},
                {"locale", "en_US"},
                {"access_token", accessToken}
            };
            
            var characterStats = await APIHandler.Get<CharacterStatisticData>(characterMetaData.statistics.href, queryParams);
            
            if (characterStats is not null)
            {
                CStats = characterStats;
                
            }
            
            var mythicProfile = await APIHandler.Get<MythicProfileData>(characterMetaData.mythic_keystone_profile.href, queryParams);
            
            if (mythicProfile is not null)
            {
                MythicProfile = mythicProfile;
                
                Season season = mythicProfile.seasons.MaxBy(s => s.id);
                
                var mythicSeasonPerformance = await APIHandler.Get<MythicSeasonPerformanceData>(season.key.href, queryParams);
                
                if (mythicSeasonPerformance is not null)
                {
                    MythicSeasonPerformance = mythicSeasonPerformance;
                }
            }
            else
            {
                MythicProfile = EmptyMythicProfileData;
                MythicSeasonPerformance = EmptyMythicSeasonPerformance;
            }
            
                            
            if (MythicSeasonPerformance.best_runs.Count > 0)
            {
                SortedBestRuns = InsertionSort(MythicSeasonPerformance.best_runs, (a, b) => a.keystone_level < b.keystone_level).ToList();
            }
            
            
            HasData = true;
        }
    }
    
    private string GetCharacterMetaDataUrl(string accessToken)
    {
        return $"https://{Region}.api.blizzard.com/profile/wow/character/{Realm}/{CharacterName}?namespace=profile-{Region}&locale=en_US&access_token={accessToken}";
    }
    
    private string GetCharacterStatusUrl(string accessToken)
    {
        return $"https://{Region}.api.blizzard.com/profile/wow/character/{Realm}/{CharacterName}/status?namespace=profile-{Region}&locale=en_US&access_token={accessToken}";
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
                j = j - 1;
            }
            list[j + 1] = key;
        }

        return list;
    }
    
}
