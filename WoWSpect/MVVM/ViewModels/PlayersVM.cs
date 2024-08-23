using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WoWSpect.HelperClasses;
using WoWSpect.MVVM.Models.Players;
using WoWSpect.MVVM.Models.Players.Stats;


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
    private bool _hasData = false;
    
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
                HasData = true;
            }
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
    
}
