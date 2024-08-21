using System.Windows;
using System.Windows.Controls;

namespace WoWSpect.HelperClasses;

public static class PasswordHelper
{
    public static readonly DependencyProperty PasswordProperty = DependencyProperty.RegisterAttached("Password",
        typeof(string), typeof(PasswordHelper), new FrameworkPropertyMetadata(string.Empty, OnPasswordPropertyChanged));
    
    public static readonly DependencyProperty AttachProperty = DependencyProperty.RegisterAttached("Attach",
        typeof(bool), typeof(PasswordHelper), new FrameworkPropertyMetadata(false, Attach));

    public static readonly DependencyProperty IsUpdatingProperty = DependencyProperty.RegisterAttached("IsUpdating",
        typeof(bool), typeof(PasswordHelper));

    public static void SetAttach(DependencyObject dp, bool value)
    {
        dp.SetValue(AttachProperty, value);
    }
    
    public static bool GetAttach(DependencyObject dp)
    {
        return (bool) dp.GetValue(AttachProperty);
    }

    public static void SetPassword(DependencyObject dp, string value)
    {
        dp.SetValue(PasswordProperty, value);
    }

    public static string GetPassword(DependencyObject dp)
    {
        return (string)dp.GetValue(PasswordProperty);
    }

    public static void SetIsUpdating(DependencyObject dp, bool value)
    {
        dp.SetValue(IsUpdatingProperty, value);
    }

    public static bool GetIsUpdating(DependencyObject dp)
    {
        return (bool) dp.GetValue(IsUpdatingProperty);
    }
    
    private static void OnPasswordPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
    {
        if(sender is not PasswordBox passwordBox) return;
        
        passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;
        
        if(!GetIsUpdating(passwordBox))
        {
            passwordBox.Password = (string) args.NewValue;
        }
        
        passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
    }

    private static void Attach(DependencyObject sender, DependencyPropertyChangedEventArgs args)
    {
        if(sender is not PasswordBox passwordBox) return;
        
        if((bool) args.OldValue)
        {
            passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;
        }
        
        if((bool) args.NewValue)
        {
            passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
        }
        
    }

    private static void PasswordBox_PasswordChanged(object sender, RoutedEventArgs args)
    {
        if(sender is not PasswordBox passwordBox) return;
        
        SetIsUpdating(passwordBox, true);
        
        SetPassword(passwordBox, passwordBox.Password);
        
        SetIsUpdating(passwordBox, false);
    }
}
