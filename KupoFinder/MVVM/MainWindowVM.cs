using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KupoFinder.ConfigHandler;

namespace KupoFinder.MVVM;

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
