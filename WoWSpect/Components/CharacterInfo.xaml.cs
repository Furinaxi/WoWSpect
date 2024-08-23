using System.Windows;
using System.Windows.Controls;

namespace WoWSpect.Components;

public partial class CharacterInfo : UserControl
{
    public static readonly DependencyProperty CharacterNameValueProperty = DependencyProperty.Register(
        nameof(CharacterNameValue), typeof(string), typeof(CharacterInfo), new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty FactionValueProperty = DependencyProperty.Register(
        nameof(FactionValue), typeof(string), typeof(CharacterInfo), new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty RaceValueProperty = DependencyProperty.Register(
        nameof(RaceValue), typeof(string), typeof(CharacterInfo), new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty ClassValueProperty = DependencyProperty.Register(
        nameof(ClassValue), typeof(string), typeof(CharacterInfo), new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty ActiveSpecValueProperty = DependencyProperty.Register(
        nameof(ActiveSpecValue), typeof(string), typeof(CharacterInfo), new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty RealmValueProperty = DependencyProperty.Register(
        nameof(RealmValue), typeof(string), typeof(CharacterInfo), new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty LevelValueProperty = DependencyProperty.Register(
        nameof(LevelValue), typeof(string), typeof(CharacterInfo), new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty ActiveTitleValueProperty = DependencyProperty.Register(
        nameof(ActiveTitleValue), typeof(string), typeof(CharacterInfo), new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty CurrentlySubscribedValueProperty = DependencyProperty.Register(
        nameof(CurrentlySubscribedValue), typeof(string), typeof(CharacterInfo), new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty StaminaValueProperty = DependencyProperty.Register(
        nameof(StaminaValue), typeof(string), typeof(CharacterInfo), new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty StrengthValueProperty = DependencyProperty.Register(
        nameof(StrengthValue), typeof(string), typeof(CharacterInfo), new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty AgilityValueProperty = DependencyProperty.Register(
        nameof(AgilityValue), typeof(string), typeof(CharacterInfo), new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty IntellectValueProperty = DependencyProperty.Register(
        nameof(IntellectValue), typeof(string), typeof(CharacterInfo), new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty CritValueProperty = DependencyProperty.Register(
        nameof(CritValue), typeof(string), typeof(CharacterInfo), new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty HasteValueProperty = DependencyProperty.Register(
        nameof(HasteValue), typeof(string), typeof(CharacterInfo), new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty MasteryValueProperty = DependencyProperty.Register(
        nameof(MasteryValue), typeof(string), typeof(CharacterInfo), new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty VersatilityValueProperty = DependencyProperty.Register(
        nameof(VersatilityValue), typeof(string), typeof(CharacterInfo), new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty AvoidanceValueProperty = DependencyProperty.Register(
        nameof(AvoidanceValue), typeof(string), typeof(CharacterInfo), new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty LeechValueProperty = DependencyProperty.Register(
        nameof(LeechValue), typeof(string), typeof(CharacterInfo), new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty SpeedValueProperty = DependencyProperty.Register(
        nameof(SpeedValue), typeof(string), typeof(CharacterInfo), new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty MythicRatingValueProperty = DependencyProperty.Register(
        nameof(MythicRatingValue), typeof(string), typeof(CharacterInfo), new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty AvgItemLevelValueProperty = DependencyProperty.Register(
        nameof(AvgItemLevelValue), typeof(string), typeof(CharacterInfo), new PropertyMetadata(default(string)));

    public string AvgItemLevelValue
    {
        get { return (string)GetValue(AvgItemLevelValueProperty); }
        set { SetValue(AvgItemLevelValueProperty, value); }
    }

    public string MythicRatingValue
    {
        get { return (string)GetValue(MythicRatingValueProperty); }
        set { SetValue(MythicRatingValueProperty, value); }
    }
    
    public string SpeedValue
    {
        get { return (string)GetValue(SpeedValueProperty); }
        set { SetValue(SpeedValueProperty, value); }
    }
    
    public string LeechValue
    {
        get { return (string)GetValue(LeechValueProperty); }
        set { SetValue(LeechValueProperty, value); }
    }
    
    public string AvoidanceValue
    {
        get { return (string)GetValue(AvoidanceValueProperty); }
        set { SetValue(AvoidanceValueProperty, value); }
    }
    
    public string VersatilityValue
    {
        get { return (string)GetValue(VersatilityValueProperty); }
        set { SetValue(VersatilityValueProperty, value); }
    }
    
    public string MasteryValue
    {
        get { return (string)GetValue(MasteryValueProperty); }
        set { SetValue(MasteryValueProperty, value); }
    }
    
    public string HasteValue
    {
        get { return (string)GetValue(HasteValueProperty); }
        set { SetValue(HasteValueProperty, value); }
    }
    
    public string CritValue
    {
        get { return (string)GetValue(CritValueProperty); }
        set { SetValue(CritValueProperty, value); }
    }
    
    public string IntellectValue
    {
        get { return (string)GetValue(IntellectValueProperty); }
        set { SetValue(IntellectValueProperty, value); }
    }
    
    public string AgilityValue
    {
        get { return (string)GetValue(AgilityValueProperty); }
        set { SetValue(AgilityValueProperty, value); }
    }
    
    public string StrengthValue
    {
        get { return (string)GetValue(StrengthValueProperty); }
        set { SetValue(StrengthValueProperty, value); }
    }
    
    public string StaminaValue
    {
        get { return (string)GetValue(StaminaValueProperty); }
        set { SetValue(StaminaValueProperty, value); }
    }
    
    public string CurrentlySubscribedValue
    {
        get { return (string)GetValue(CurrentlySubscribedValueProperty); }
        set { SetValue(CurrentlySubscribedValueProperty, value); }
    }
    
    public string ActiveTitleValue
    {
        get { return (string)GetValue(ActiveTitleValueProperty); }
        set { SetValue(ActiveTitleValueProperty, value); }
    }
    
    public string LevelValue
    {
        get { return (string)GetValue(LevelValueProperty); }
        set { SetValue(LevelValueProperty, value); }
    }
    
    public string RealmValue
    {
        get { return (string)GetValue(RealmValueProperty); }
        set { SetValue(RealmValueProperty, value); }
    }
    
    public string ActiveSpecValue
    {
        get { return (string)GetValue(ActiveSpecValueProperty); }
        set { SetValue(ActiveSpecValueProperty, value); }
    }
    
    public string ClassValue
    {
        get { return (string)GetValue(ClassValueProperty); }
        set { SetValue(ClassValueProperty, value); }
    }
    
    public string RaceValue
    {
        get { return (string)GetValue(RaceValueProperty); }
        set { SetValue(RaceValueProperty, value); }
    }
    
    public string FactionValue
    {
        get { return (string)GetValue(FactionValueProperty); }
        set { SetValue(FactionValueProperty, value); }
    }
    
    public string CharacterNameValue
    {
        get { return (string)GetValue(CharacterNameValueProperty); }
        set { SetValue(CharacterNameValueProperty, value); }
    }
    
    public CharacterInfo()
    {
        InitializeComponent();
    }
}

