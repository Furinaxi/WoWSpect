using System.Windows.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WoWSpect.HelperClasses;
using WoWSpect.MVVM.Views;

namespace WoWSpect.MVVM.ViewModels;

public partial class MainWindowVM : ObservableObject
{
    [ObservableProperty]
    private UserControl _currentView;
    
    public MainWindowVM()
    {
        AppConfigHandler.CheckConfigFile();
        ShowPlayers();
    }
    
    [RelayCommand]
    private void CloseApp()
    {
        Environment.Exit(0);
    }
    
    [RelayCommand]
    private void ShowPlayers()
    {
        CurrentView = new PlayersView();
    }
    
    [RelayCommand]
    private void ShowSettings()
    {
        CurrentView = new SettingsView();
    }
    
    [RelayCommand]
    private void ShowItems()
    {
        CurrentView = new ItemsView();
    }
}
