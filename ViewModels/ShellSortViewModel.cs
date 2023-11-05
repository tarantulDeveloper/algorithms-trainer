using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beckjan.ViewModels;

public class ShellSortViewModel : SortViewModel
{
    public override void SortArray(int[] array)
    {
        int n = array.Length;
        int gap = n / 2;

        while (gap > 0)
        {
            for (int i = gap; i < n; i++)
            {
                int temp = array[i];
                int j = i;

                while (j >= gap && array[j - gap] > temp)
                {
                    array[j] = array[j - gap];
                    j -= gap;
                }

                array[j] = temp;

                // Добавление текущего состояния массива в историю сортировки
                SortHistory.Add(new SortHistoryViewModel { Step = SortHistory.Count + 1, Message = $"Inserted {temp} at index {j}" });
            }

            gap /= 2;
        }
    }
}
