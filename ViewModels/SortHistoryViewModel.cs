using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Beckjan.ViewModels;
public class SortHistoryViewModel: ReactiveObject
{
    [Reactive]
    public int Step
    {
        get; set;
    }
    [Reactive]
    public string Message
    {
        get; set;
    }
}
