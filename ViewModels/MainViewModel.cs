using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using Splat;
using Beckjan.Pages;

namespace Beckjan.ViewModels;

public class MainViewModel : ReactiveObject, IScreen
{
    // The Router associated with this Screen.
    // Required by the IScreen interface.
    public RoutingState Router
    {
        get;
    }

    // The command that navigates a user to first view model.
    public ReactiveCommand<Unit, IRoutableViewModel> GoToPyromidSort
    {
        get;
    }

    public ReactiveCommand<Unit, IRoutableViewModel> GoToShellSort
    {
        get;
    }

    public ReactiveCommand<Unit, IRoutableViewModel> GoToGnomeSort
    {
        get;
    }

    public ReactiveCommand<Unit, IRoutableViewModel> GoToSettings
    {
        get;
    }

    // The command that navigates a user back.
    public ReactiveCommand<Unit, IRoutableViewModel> GoBack
    {
        get;
    }

    public MainViewModel()
    {
        // Initialize the Router.
        Router = new RoutingState();

        // Manage the routing state. Use the Router.Navigate.Execute
        // command to navigate to different view models. 
        //
        // Note, that the Navigate.Execute method accepts an instance 
        // of a view model, this allows you to pass parameters to 
        // your view models, or to reuse existing view models.
        //
        GoToPyromidSort = GoTo(() => new PyromidSortPage(), () => new PyromidSortViewModel());
        GoToShellSort = GoTo(() => new ShellSortPage(), () => new ShellSortViewModel());
        GoToGnomeSort = GoTo(() => new GnomeSortPage(), () => new GnomeSortViewModel());

        GoToSettings = GoTo(() => new SettingsPage(), () => new SettingsViewModel(this));

        // You can also ask the router to go back. One option is to 
        // execute the default Router.NavigateBack command. Another
        // option is to define your own command with custom
        // canExecute condition as such:
        var canGoBack = this
            .WhenAnyValue(x => x.Router.NavigationStack.Count)
            .Select(count => count > 0);
        GoBack = ReactiveCommand.CreateFromObservable(
            () => Router.NavigateBack.Execute(),
            canGoBack);
    }

    private ReactiveCommand<Unit, IRoutableViewModel> GoTo<TView, TVm>(Func<TView> viewFactory, Func<TVm> vmFactory) where TView : class, IViewFor<TVm> where TVm: class, IRoutableViewModel
    {
        Locator.CurrentMutable.Register(() => viewFactory(), typeof(IViewFor<TVm>));
        return ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(vmFactory()));
    }
}
