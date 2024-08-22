using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WoWSpect.Components;

public partial class PasswordBoxWithLabel : UserControl
{
    public static readonly DependencyProperty PasswordBoxLabelTextProperty = DependencyProperty.Register(
        nameof(PasswordBoxLabelText), typeof(string), typeof(PasswordBoxWithLabel), new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty PasswordBoxUserInputProperty = DependencyProperty.Register(
        nameof(PasswordBoxUserInput), typeof(string), typeof(PasswordBoxWithLabel), new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty PasswordBoxLabelColorProperty = DependencyProperty.Register(
        nameof(PasswordBoxLabelColor), typeof(Brush), typeof(PasswordBoxWithLabel), new PropertyMetadata(Brushes.White));

    public Brush PasswordBoxLabelColor
    {
        get { return (Brush)GetValue(PasswordBoxLabelColorProperty); }
        set { SetValue(PasswordBoxLabelColorProperty, value); }
    }

    public string PasswordBoxUserInput
    {
        get { return (string)GetValue(PasswordBoxUserInputProperty); }
        set { SetValue(PasswordBoxUserInputProperty, value); }
    }
    
    public string PasswordBoxLabelText
    {
        get { return (string)GetValue(PasswordBoxLabelTextProperty); }
        set { SetValue(PasswordBoxLabelTextProperty, value); }
    }
    
    public PasswordBoxWithLabel()
    {
        InitializeComponent();
    }
}

