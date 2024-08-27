using System.Collections;
using System.Windows;
using System.Windows.Controls;
using WoWSpect.MVVM.Models.Guilds;

namespace WoWSpect.Components;

public partial class GuildInfo : UserControl
{
    public static readonly DependencyProperty GuildMemberListSourceProperty = DependencyProperty.Register(
        nameof(GuildMemberListSource), typeof(IEnumerable), typeof(GuildInfo), new PropertyMetadata(null));

    public static readonly DependencyProperty GuildMetaDataValueProperty = DependencyProperty.Register(
        nameof(GuildMetaDataValue), typeof(GuildMetaData), typeof(GuildInfo), new PropertyMetadata(null));

    public GuildMetaData GuildMetaDataValue
    {
        get { return (GuildMetaData)GetValue(GuildMetaDataValueProperty); }
        set { SetValue(GuildMetaDataValueProperty, value); }
    }
    
    public IEnumerable GuildMemberListSource
    {
        get { return (IEnumerable)GetValue(GuildMemberListSourceProperty); }
        set { SetValue(GuildMemberListSourceProperty, value); }
    }
    
    public GuildInfo()
    {
        InitializeComponent();
    }
}

