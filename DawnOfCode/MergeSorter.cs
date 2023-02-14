using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DawnOfCode
{
    internal class MergeSorter
    {
        public static void MergeSort(int[] arr,int start, int end)
        {
            if(start< end)
            {
                int m = start + (end - start) / 2;
                MergeSort(arr, start, m);
                MergeSort(arr, m+1, end);
                int[] fa = new int[m - start + 1];
                int[] sa = new int[end - m];
                for (int i = start; i <= m; i++) fa[i - start] = arr[i];
                for (int j = m + 1; j <= end; j++) sa[j - m - 1] = arr[j];
                int f = 0, s = 0;
                for(int i=start; i <= end; i++)
                {
                    if (s >= sa.Length || (f < fa.Length && fa[f] < sa[s])) arr[i] = fa[f++];
                    else arr[i] = sa[s++];
                }
            }
        }
        public static void Main()
        {
            int[] arr = { 6, 5, 4, 9, 7, 3, 2, 1 };
            MergeSort(arr,0,arr.Length-1);
            for(int i=0;i<arr.Length;i++) Console.WriteLine(arr[i]);
        }
    }
}
