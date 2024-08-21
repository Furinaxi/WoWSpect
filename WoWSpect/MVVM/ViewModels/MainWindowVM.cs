using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WoWSpect.ConfigHandler;

namespace WoWSpect.MVVM.ViewModels;

public partial class MainWindowVM : ObservableObject
{
    [ObservableProperty]
    private ObservableObject _currentViewModel = new PlayersVM();
    
    public MainWindowVM()
    {
        AppConfigHandler.CheckConfigFile();
    }
    
    [RelayCommand]
    private void CloseApp()
    {
        Environment.Exit(0);
    }
    
    [RelayCommand]
    private void ShowPlayers()
    {
        CurrentViewModel = new PlayersVM();
    }
    
    [RelayCommand]
    private void ShowSettings()
    {
        CurrentViewModel = new SettingsVM();
    }
    
    [RelayCommand]
    private void ShowItems()
    {
        CurrentViewModel = new ItemsVM();
    }
}
