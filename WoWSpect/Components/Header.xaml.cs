using System.Windows;
using System.Windows.Controls;

namespace WoWSpect.Components;

public partial class Header : UserControl
{
    public static readonly DependencyProperty HeaderHeightProperty = DependencyProperty.Register(
        nameof(HeaderHeight), typeof(double), typeof(Header), new PropertyMetadata(default(double)));

    public static readonly DependencyProperty HeaderWidthProperty = DependencyProperty.Register(
        nameof(HeaderWidth), typeof(double), typeof(Header), new PropertyMetadata(default(double)));

    public static readonly DependencyProperty HeaderContentProperty = DependencyProperty.Register(
        nameof(HeaderContent), typeof(string), typeof(Header), new PropertyMetadata(default(string)));

    public string HeaderContent
    {
        get { return (string)GetValue(HeaderContentProperty); }
        set { SetValue(HeaderContentProperty, value); }
    }
    
    public double HeaderWidth
    {
        get { return (double)GetValue(HeaderWidthProperty); }
        set { SetValue(HeaderWidthProperty, value); }
    }

    public double HeaderHeight
    {
        get { return (double)GetValue(HeaderHeightProperty); }
        set { SetValue(HeaderHeightProperty, value); }
    }
    
    public Header()
    {
        InitializeComponent();
    }
}

