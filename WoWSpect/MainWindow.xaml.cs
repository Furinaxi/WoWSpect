using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using WoWSpect.MVVM.Views;

namespace WoWSpect;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly Dictionary<Type, UserControl> _viewDictionary = new();
    
    public ICommand SwitchViewCommand { get; set; }
    
    public MainWindow()
    {
        SwitchViewCommand = new RelayCommand<Type>(SwitchView);
        InitializeComponent();
        SwitchView(typeof(PlayersView));
    }

    private void SwitchView(Type? view)
    {
        if(view is null)
        {
            throw new NotSupportedException("View type cannot be null");
        }
        
        _viewDictionary.TryGetValue(view, out UserControl? uc);

        if (uc is null)
        {
            uc = Activator.CreateInstance(view) as UserControl;
            
            if (uc is null)
            {
                throw new NotSupportedException("UserControl Instance cannot be null");
            }
            
            _viewDictionary.Add(view, uc);
        }
        
        MainContent.Content = uc;
        
    }

    private void DragMoveEvent(object sender, MouseButtonEventArgs e)
    {
        DragMove();
    }
}
