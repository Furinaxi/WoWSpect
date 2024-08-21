using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WoWSpect.Components;

public partial class PasswordBoxWithLabel : UserControl
{
    public static readonly DependencyProperty LabelTextProperty = DependencyProperty.Register(
        nameof(LabelText), typeof(string), typeof(PasswordBoxWithLabel), new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty UserInputProperty = DependencyProperty.Register(
        nameof(UserInput), typeof(string), typeof(PasswordBoxWithLabel), new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty LabelColorProperty = DependencyProperty.Register(
        nameof(LabelColor), typeof(Brush), typeof(PasswordBoxWithLabel), new PropertyMetadata(Brushes.White));

    public Brush LabelColor
    {
        get { return (Brush)GetValue(LabelColorProperty); }
        set { SetValue(LabelColorProperty, value); }
    }

    public string UserInput
    {
        get { return (string)GetValue(UserInputProperty); }
        set { SetValue(UserInputProperty, value); }
    }
    
    public string LabelText
    {
        get { return (string)GetValue(LabelTextProperty); }
        set { SetValue(LabelTextProperty, value); }
    }
    
    public PasswordBoxWithLabel()
    {
        InitializeComponent();
        UserInput = "blub";
    }
    
    private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
    {
        //Password = inputBox.Password;
    }
}

