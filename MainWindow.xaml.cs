using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Beckjan.ViewModels;
using ReactiveUI;

namespace Beckjan;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : ReactiveWindow<MainViewModel>
{
    public MainWindow()
    {
        ViewModel = new MainViewModel();
        InitializeComponent();
        this.WhenActivated(disposables =>
        {
            // Bind the view model router to RoutedViewHost.Router property.
            this.OneWayBind(ViewModel, x => x.Router, x => x.RoutedViewHost.Router)
                .DisposeWith(disposables);
            this.BindCommand(ViewModel, x => x.GoToPyromidSort, x => x.pyromidSortButton)
                .DisposeWith(disposables);
            this.BindCommand(ViewModel, x => x.GoToSettings, x => x.settingsButton)
                .DisposeWith(disposables)
                ;this.BindCommand(ViewModel, x => x.GoBack, x => x.backButton)
                .DisposeWith(disposables);
        });
    }

    protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
    {
        if (e.Property.Name == nameof(ViewModel))
        {
            DataContext = ViewModel;
        }
        base.OnPropertyChanged(e);
    }
}
