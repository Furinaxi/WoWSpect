using System.Diagnostics;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WoWSpect.HelperClasses;
using WoWSpect.MVVM.Models.Settings;

namespace WoWSpect.MVVM.ViewModels;

public partial class SettingsVM : ObservableObject
{
    [ObservableProperty]
    private string _clientID;
    
    [ObservableProperty]
    private string _clientSecret;
    
    private static readonly ProcessStartInfo ProcessStartInfo = new()
    {
        FileName = "https://develop.battle.net/access/clients",
        UseShellExecute = true,
    };

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
    private void HandleLinkClick()
    {
        Process.Start(ProcessStartInfo);
    }
    
    [RelayCommand]
    private async Task SaveSettings()
    {
        string url = "https://oauth.battle.net/token";
        var postBody = new { grant_type = "client_credentials" };
        
        var credentials = await APIHandler.Receive<ClientCredentials>(url, ClientID, ClientSecret, postBody);
        
        
        if (credentials is not null)
        {
            Dictionary<string, string> values = new Dictionary<string, string>
            {
                [AppConfigHandler.ClientIdKey] = ClientID,
                [AppConfigHandler.ClientSecretKey] = ClientSecret,
                [AppConfigHandler.AccessTokenKey] = credentials.access_token,
            };
        
            AppConfigHandler.SetValues(values);

            MessageBox.Show("Settings saved successfully!", 
                "Success", 
                MessageBoxButton.OK, 
                MessageBoxImage.Information);
        }
        else
        {
            MessageBox.Show("Settings could not be saved. Please check your client ID and client secret.", 
                "Error", 
                MessageBoxButton.OK, 
                MessageBoxImage.Error);
        }
    }
}
