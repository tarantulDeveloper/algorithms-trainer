using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Beckjan.ViewModels;

public abstract class SortViewModel : PageViewModel
{
    public SortViewModel() : this(null!)
    {
    }

    public SortViewModel(IScreen hostScreen) : base(hostScreen)
    {
        Array = "0, 11, 3, 1, 2, 123, 51";
        SortCommand = ReactiveCommand.Create(() =>
        {
            var array = Array.Split(",", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
                             .Select(x => int.Parse(x))
                             .ToArray();
            SortHistory.Clear();
            SortArray(array);
            SortHistory.Add(new()
            {
                Step = SortHistory.Count + 1,
                Message = $"Final array {string.Join(",",array)}"
            });
        });
    }

    public ObservableCollection<SortHistoryViewModel> SortHistory
    {
        get;
    } = new();

    [Reactive]
    public string Array
    {
        get; set;
    } = string.Empty;

    public ICommand SortCommand
    {
        get;
    }

    public abstract void SortArray(int[] array);
}
