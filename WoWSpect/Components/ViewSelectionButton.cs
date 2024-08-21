using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WoWSpect.Components;

public class ViewSelectionButton : RadioButton
{
    public static readonly DependencyProperty ViewTypeProperty = DependencyProperty.Register(
        nameof(ViewType), typeof(Type), typeof(ViewSelectionButton), new PropertyMetadata(default(Type)));

    public static readonly DependencyProperty SwitchViewCommandProperty = DependencyProperty.Register(
        nameof(SwitchViewCommand), typeof(ICommand), typeof(ViewSelectionButton), new PropertyMetadata(default(ICommand)));

    public ICommand SwitchViewCommand
    {
        get { return (ICommand)GetValue(SwitchViewCommandProperty); }
        set { SetValue(SwitchViewCommandProperty, value); }
    }
    
    public Type ViewType
    {
        get { return (Type)GetValue(ViewTypeProperty); }
        set { SetValue(ViewTypeProperty, value); }
    }

    protected override void OnClick()
    {
        base.OnClick();
        
        SwitchViewCommand.Execute(ViewType);
    }
}
