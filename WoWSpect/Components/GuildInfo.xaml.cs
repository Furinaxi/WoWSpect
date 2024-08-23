using System.Collections;
using System.Windows;
using System.Windows.Controls;

namespace WoWSpect.Components;

public partial class GuildInfo : UserControl
{
    public static readonly DependencyProperty GuildNameValueProperty = DependencyProperty.Register(
        nameof(GuildNameValue), typeof(string), typeof(GuildInfo), new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty GuildFactionValueProperty = DependencyProperty.Register(
        nameof(GuildFactionValue), typeof(string), typeof(GuildInfo), new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty GuildRealmValueProperty = DependencyProperty.Register(
        nameof(GuildRealmValue), typeof(string), typeof(GuildInfo), new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty GuildMemberListSourceProperty = DependencyProperty.Register(
        nameof(GuildMemberListSource), typeof(IEnumerable), typeof(GuildInfo), new PropertyMetadata(null));

    public IEnumerable GuildMemberListSource
    {
        get { return (IEnumerable)GetValue(GuildMemberListSourceProperty); }
        set { SetValue(GuildMemberListSourceProperty, value); }
    }

    public string GuildRealmValue
    {
        get { return (string)GetValue(GuildRealmValueProperty); }
        set { SetValue(GuildRealmValueProperty, value); }
    }
    
    public string GuildFactionValue
    {
        get { return (string)GetValue(GuildFactionValueProperty); }
        set { SetValue(GuildFactionValueProperty, value); }
    }
    
    public string GuildNameValue
    {
        get { return (string)GetValue(GuildNameValueProperty); }
        set { SetValue(GuildNameValueProperty, value); }
    }
    
    public GuildInfo()
    {
        InitializeComponent();
    }
}

