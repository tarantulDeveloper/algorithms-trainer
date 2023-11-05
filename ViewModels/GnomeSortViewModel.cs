using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beckjan.ViewModels;

public class GnomeSortViewModel : SortViewModel
{
    public override void SortArray(int[] array)
    {
        var n = array.Length;
        var index = 0;

        while (index < n)
        {
            if (index == 0)
                index++;

            if (array[index] >= array[index - 1])
            {
                index++;
            }
            else
            {
                // Обмен текущего элемента с предыдущим
                (array[index - 1], array[index]) = (array[index], array[index - 1]);

                // Добавление текущего состояния массива в историю сортировки
                SortHistory.Add(new SortHistoryViewModel { Step = SortHistory.Count + 1, Message = $"Swapped {array[index]} and {array[index - 1]}" });

                index--;
            }
        }
    }
}
