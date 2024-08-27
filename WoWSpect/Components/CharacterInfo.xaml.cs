using System.Collections;
using System.Windows;
using System.Windows.Controls;
using WoWSpect.MVVM.Models.Players;
using WoWSpect.MVVM.Models.Players.MythicSeason;
using WoWSpect.MVVM.Models.Players.Stats;

namespace WoWSpect.Components;

public partial class CharacterInfo : UserControl
{
    public static readonly DependencyProperty CharacterMetaDataValueProperty = DependencyProperty.Register(
        nameof(CharacterMetaDataValue), typeof(CharacterMetaData), typeof(CharacterInfo), new PropertyMetadata(null));

    public static readonly DependencyProperty CharacterStatusDataValueProperty = DependencyProperty.Register(
        nameof(CharacterStatusDataValue), typeof(CharacterStatusData), typeof(CharacterInfo), new PropertyMetadata(null));

    public static readonly DependencyProperty CharacterStatisticsDataValueProperty = DependencyProperty.Register(
        nameof(CharacterStatisticsDataValue), typeof(CharacterStatisticData), typeof(CharacterInfo), new PropertyMetadata(null));

    public static readonly DependencyProperty MythicSeasonPerformanceValueProperty = DependencyProperty.Register(
        nameof(MythicSeasonPerformanceValue), typeof(MythicSeasonPerformanceData), typeof(CharacterInfo), new PropertyMetadata(null));

    public static readonly DependencyProperty MythicRunsSourceProperty = DependencyProperty.Register(
        nameof(MythicRunsSource), typeof(IEnumerable), typeof(CharacterInfo), new PropertyMetadata(null));

    public IEnumerable MythicRunsSource
    {
        get { return (IEnumerable)GetValue(MythicRunsSourceProperty); }
        set { SetValue(MythicRunsSourceProperty, value); }
    }

    public MythicSeasonPerformanceData MythicSeasonPerformanceValue
    {
        get { return (MythicSeasonPerformanceData)GetValue(MythicSeasonPerformanceValueProperty); }
        set { SetValue(MythicSeasonPerformanceValueProperty, value); }
    }

    public CharacterStatisticData CharacterStatisticsDataValue
    {
        get { return (CharacterStatisticData)GetValue(CharacterStatisticsDataValueProperty); }
        set { SetValue(CharacterStatisticsDataValueProperty, value); }
    }

    public CharacterStatusData CharacterStatusDataValue
    {
        get { return (CharacterStatusData)GetValue(CharacterStatusDataValueProperty); }
        set { SetValue(CharacterStatusDataValueProperty, value); }
    }
        
    public CharacterMetaData CharacterMetaDataValue
    {
        get { return (CharacterMetaData)GetValue(CharacterMetaDataValueProperty); }
        set { SetValue(CharacterMetaDataValueProperty, value); }
    }
    
    public CharacterInfo()
    {
        InitializeComponent();
    }
}

