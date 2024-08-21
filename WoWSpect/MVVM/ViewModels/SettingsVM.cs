using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WoWSpect.HelperClasses;

namespace WoWSpect.MVVM.ViewModels;

public partial class SettingsVM : ObservableObject
{
    [ObservableProperty]
    private string _clientID;
    
    [ObservableProperty]
    private string _clientSecret;

    public SettingsVM()
    {
        LoadSettings();
    }
    
    public void LoadSettings()
    {
        string[] keys = [AppConfigHandler.ClientIdKey, AppConfigHandler.ClientSecretKey];
        
        if (AppConfigHandler.TryGetValues(keys, out IDictionary<string, string> values))
        {
            ClientID = values.TryGetValue(AppConfigHandler.ClientIdKey, out string clientId) ? clientId : string.Empty;
            ClientSecret = values.TryGetValue(AppConfigHandler.ClientSecretKey, out string clientSecret) ? clientSecret : string.Empty;
        }
        else
        {
            ClientID = string.Empty;
            ClientSecret = string.Empty;
        }
    }
    
    [RelayCommand]
    private void SaveSettings()
    {
        Dictionary<string, string> values = new Dictionary<string, string>
        {
            [AppConfigHandler.ClientIdKey] = ClientID,
            [AppConfigHandler.ClientSecretKey] = ClientSecret
        };
        
        AppConfigHandler.SetValues(values);
    }
}
