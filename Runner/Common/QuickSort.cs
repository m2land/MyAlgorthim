using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Common
{
    public class SortAlgorithm
    {
        public static void QuickSort(int[] list, int left, int right)
        {
            if (list.Length < 2 || left >=right)
            {
                return;
            }

            var pivot = Partition(list, left, right);
            QuickSort(list, left, pivot - 1);
            QuickSort(list, pivot + 1, right);

        }
        private static int Partition(int[] list, int left, int right)
        {
            var pivotValue = list[left];
            while (left < right)
            {
                while (list[right] >= pivotValue && left < right) right--;
                list[left] = list[right];

                while (list[left] <= pivotValue && left < right) left++;
                list[right] = list[left];
            }

            list[left] = pivotValue;
            return left;
        }


    }
}
