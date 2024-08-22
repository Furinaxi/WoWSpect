using System.Windows;
using System.Windows.Controls;

namespace WoWSpect.Components;

public partial class StatDisplay : UserControl
{
    public static readonly DependencyProperty FirstStatNameProperty = DependencyProperty.Register(
        nameof(FirstStatName), typeof(string), typeof(StatDisplay), new PropertyMetadata(string.Empty));
    
    public static readonly DependencyProperty SecondStatNameProperty = DependencyProperty.Register(
        nameof(SecondStatName), typeof(string), typeof(StatDisplay), new PropertyMetadata(string.Empty));
    
    public static readonly DependencyProperty ThirdStatNameProperty = DependencyProperty.Register(
        nameof(ThirdStatName), typeof(string), typeof(StatDisplay), new PropertyMetadata(string.Empty));
    
    public static readonly DependencyProperty FourthStatNameProperty = DependencyProperty.Register(
        nameof(FourthStatName), typeof(string), typeof(StatDisplay), new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty StatHeaderContentProperty = DependencyProperty.Register(
        nameof(StatHeaderContent), typeof(string), typeof(StatDisplay), new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty FirstStatValueProperty = DependencyProperty.Register(
        nameof(FirstStatValue), typeof(string), typeof(StatDisplay), new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty SecondStatValueProperty = DependencyProperty.Register(
        nameof(SecondStatValue), typeof(string), typeof(StatDisplay), new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty ThirdStatValueProperty = DependencyProperty.Register(
        nameof(ThirdStatValue), typeof(string), typeof(StatDisplay), new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty FourthStatValueProperty = DependencyProperty.Register(
        nameof(FourthStatValue), typeof(string), typeof(StatDisplay), new PropertyMetadata(string.Empty));

    public string FourthStatValue
    {
        get { return (string)GetValue(FourthStatValueProperty); }
        set { SetValue(FourthStatValueProperty, value); }
    }
    
    public string ThirdStatValue
    {
        get { return (string)GetValue(ThirdStatValueProperty); }
        set { SetValue(ThirdStatValueProperty, value); }
    }
    
    public string SecondStatValue
    {
        get { return (string)GetValue(SecondStatValueProperty); }
        set { SetValue(SecondStatValueProperty, value); }
    }

    public string FirstStatValue
    {
        get { return (string)GetValue(FirstStatValueProperty); }
        set { SetValue(FirstStatValueProperty, value); }
    }

    public string StatHeaderContent
    {
        get { return (string)GetValue(StatHeaderContentProperty); }
        set { SetValue(StatHeaderContentProperty, value); }
    }

    public string FourthStatName
    {
        get { return (string)GetValue(FourthStatNameProperty); }
        set { SetValue(FourthStatNameProperty, value); }
    }

    public string ThirdStatName
    {
        get { return (string)GetValue(ThirdStatNameProperty); }
        set { SetValue(ThirdStatNameProperty, value); }
    }

    public string SecondStatName
    {
        get { return (string)GetValue(SecondStatNameProperty); }
        set { SetValue(SecondStatNameProperty, value); }
    }

    public string FirstStatName
    {
        get { return (string)GetValue(FirstStatNameProperty); }
        set { SetValue(FirstStatNameProperty, value); }
    }
    
    public StatDisplay()
    {
        InitializeComponent();
    }
}

