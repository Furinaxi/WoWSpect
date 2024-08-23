using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace WoWSpect.MVVM.ViewModels;

public partial class GuildsVM : ObservableObject
{
    [ObservableProperty]
    private string _region;
    
    [ObservableProperty]
    private string _realm;
    
    [ObservableProperty]
    private string _guildName;
    
    [ObservableProperty]
    private bool _hasData = false;
    
    public GuildsVM()
    {
        
    }

    [RelayCommand]
    private void SearchGuild()
    {
        HasData = !HasData;
    }
}
