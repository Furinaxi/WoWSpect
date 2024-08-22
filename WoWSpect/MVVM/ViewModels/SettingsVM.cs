﻿using CommunityToolkit.Mvvm.ComponentModel;
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
        }
    }
}
