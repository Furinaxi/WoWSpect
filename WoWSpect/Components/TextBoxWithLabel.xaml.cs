using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WoWSpect.Components;

public partial class TextBoxWithLabel : UserControl
{
    public static readonly DependencyProperty TextBoxLabelText = DependencyProperty.Register(
        nameof(TextLabelText), typeof(string), typeof(TextBoxWithLabel), new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty TextBoxUserInputProperty = DependencyProperty.Register(
        nameof(TextBoxUserInput), typeof(string), typeof(TextBoxWithLabel), new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty TextBoxLabelColorProperty = DependencyProperty.Register(
        nameof(TextBoxLabelColor), typeof(Brush), typeof(TextBoxWithLabel), new PropertyMetadata(Brushes.White));

    public static readonly DependencyProperty TextBoxMaxUserInputLength = DependencyProperty.Register(
        nameof(UserInputMaxLength), typeof(int), typeof(TextBoxWithLabel), new PropertyMetadata(default(int)));

    public static readonly DependencyProperty TextBoxLabelFontSizeProperty = DependencyProperty.Register(
        nameof(TextBoxLabelFontSize), typeof(double), typeof(TextBoxWithLabel), new PropertyMetadata(default(double)));

    public double TextBoxLabelFontSize
    {
        get { return (double)GetValue(TextBoxLabelFontSizeProperty); }
        set { SetValue(TextBoxLabelFontSizeProperty, value); }
    }
    
    public int UserInputMaxLength
    {
        get { return (int)GetValue(TextBoxMaxUserInputLength); }
        set { SetValue(TextBoxMaxUserInputLength, value); }
    }

    public Brush TextBoxLabelColor
    {
        get { return (Brush)GetValue(TextBoxLabelColorProperty); }
        set { SetValue(TextBoxLabelColorProperty, value); }
    }

    public string TextBoxUserInput
    {
        get { return (string)GetValue(TextBoxUserInputProperty); }
        set { SetValue(TextBoxUserInputProperty, value); }
    }
    
    public string TextLabelText
    {
        get { return (string)GetValue(TextBoxLabelText); }
        set { SetValue(TextBoxLabelText, value); }
    }
    
    public TextBoxWithLabel()
    {
        InitializeComponent();
    }
}

