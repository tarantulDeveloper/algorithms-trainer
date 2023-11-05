using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;

namespace Beckjan.ViewModels;

public class PyromidSortViewModel : SortViewModel
{
    public override void SortArray(int[] array)
    {
        var n = array.Length;

        // Построение начальной пирамиды (max-heap)
        for (var i = n / 2 - 1; i >= 0; i--)
            Heapify(array, n, i);

        for (var i = n - 1; i > 0; i--)
        {
            // Обмен текущего элемента с корнем пирамиды
            (array[i], array[0]) = (array[0], array[i]);

            // Добавление текущего состояния массива в историю сортировки
            SortHistory.Add(new SortHistoryViewModel { Step = SortHistory.Count + 1, Message = $"Swapped {array[0]} and {array[i]}" });

            // Перестройка пирамиды после обмена
            Heapify(array, i, 0);
        }
    }

    private void Heapify(int[] array, int n, int i)
    {
        var largest = i;
        var left = 2 * i + 1;
        var right = 2 * i + 2;

        if (left < n && array[left] > array[largest])
            largest = left;

        if (right < n && array[right] > array[largest])
            largest = right;

        if (largest != i)
        {
            (array[largest], array[i]) = (array[i], array[largest]);
            SortHistory.Add(new SortHistoryViewModel { Step = SortHistory.Count + 1, Message = $"Swapped {array[i]} and {array[largest]}" });

            Heapify(array, n, largest);
        }
    }
}
