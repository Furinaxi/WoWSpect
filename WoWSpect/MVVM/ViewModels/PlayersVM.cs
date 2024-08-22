using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

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
    private bool _hasData = false;
    
    public PlayersVM()
    {
        
    }
    
    [RelayCommand]
    private void SearchCharacter()
    {
        if(Region == string.Empty || Realm == string.Empty || CharacterName == string.Empty) return;
        
        
    }
}
