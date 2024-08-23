using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WoWSpect.Components;

public partial class TextDisplay : UserControl
{
    public static readonly DependencyProperty TextDisplayInfoProperty = DependencyProperty.Register(
        nameof(TextDisplayInfo), typeof(string), typeof(TextDisplay), new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty TextDisplayInfoColorProperty = DependencyProperty.Register(
        nameof(TextDisplayInfoColor), typeof(Brush), typeof(TextDisplay), new PropertyMetadata(Brushes.White));

    public static readonly DependencyProperty TextDisplayShowProperty = DependencyProperty.Register(
        nameof(TextDisplayShow), typeof(string), typeof(TextDisplay), new PropertyMetadata(default(string)));

    public static readonly DependencyProperty TextDisplayShowColorProperty = DependencyProperty.Register(
        nameof(TextDisplayShowColor), typeof(Brush), typeof(TextDisplay), new PropertyMetadata(Brushes.White));

    public static readonly DependencyProperty LabelDistanceValueProperty = DependencyProperty.Register(
        nameof(LabelDistanceValue), typeof(GridLength), typeof(TextDisplay), new PropertyMetadata(new GridLength(100)));

    public GridLength LabelDistanceValue
    {
        get { return (GridLength)GetValue(LabelDistanceValueProperty); }
        set { SetValue(LabelDistanceValueProperty, value); }
    }

    public Brush TextDisplayShowColor
    {
        get { return (Brush)GetValue(TextDisplayShowColorProperty); }
        set { SetValue(TextDisplayShowColorProperty, value); }
    }
    
    public string TextDisplayShow
    {
        get { return (string)GetValue(TextDisplayShowProperty); }
        set { SetValue(TextDisplayShowProperty, value); }
    }

    public Brush TextDisplayInfoColor
    {
        get { return (Brush)GetValue(TextDisplayInfoColorProperty); }
        set { SetValue(TextDisplayInfoColorProperty, value); }
    }
    
    public string TextDisplayInfo
    {
        get { return (string)GetValue(TextDisplayInfoProperty); }
        set { SetValue(TextDisplayInfoProperty, value); }
    }
    
    public TextDisplay()
    {
        InitializeComponent();
    }
}

