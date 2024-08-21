using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WoWSpect.HelperClasses;

namespace WoWSpect.MVVM.ViewModels;

public partial class MainWindowVM : ObservableObject
{
    public MainWindowVM()
    {
        AppConfigHandler.CheckConfigFile();
    }
    
    [RelayCommand]
    private void CloseApp()
    {
        Environment.Exit(0);
    }

}
