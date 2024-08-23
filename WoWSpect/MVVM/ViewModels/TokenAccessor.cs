using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using WoWSpect.HelperClasses;

namespace WoWSpect.MVVM.ViewModels;

public partial class TokenAccessor : ObservableObject
{
    protected bool AccessTokenExists(out string accessToken)
    {
        if (!AppConfigHandler.TryGetValue(AppConfigHandler.AccessTokenKey, out accessToken))
        {
            MessageBox.Show("No access token found. Please provide your client ID and client secret in the settings.", 
                "Error",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
            return false;
        }
        
        return true;
    }
}
