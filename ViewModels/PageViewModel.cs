using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;

namespace Beckjan.ViewModels;

public class PageViewModel : ReactiveObject, IRoutableViewModel
{
    public PageViewModel(IScreen hostScreen)
    {
        HostScreen = hostScreen;
        UrlPathSegment = $"/{this.GetType().Name}";
    }

    public string? UrlPathSegment
    {
        get;
    }

    public IScreen HostScreen
    {
        get;
    }


}
