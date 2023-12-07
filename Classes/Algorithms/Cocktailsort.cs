using DataStructuresAndAlgorithms_InCSharp.Interfaces.Algorithms;
using System.Collections.Generic;

namespace DataStructuresAndAlgorithms_InCSharp.Classes.Algorithms
{
    internal class Cocktailsort : ImethodAlgorithms
    {
        public Cocktailsort() { }

        public void Sort(int[] arr)
        {
            cocktailSort(arr);
        }

        public void Sort(double[] arr)
        {

        }

        public void cocktailSort(int[] arr)
        {
            int n = arr.Length;
            bool swapped = true;
            int start = 0;
            int end = n - 1;
            while (swapped)
            {
                // Move from left to right
                swapped = false;
                for (int i = start; i < end; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        Swap(arr, i, i + 1);
                        swapped = true;
                    }
                }
                if (!swapped)
                {
                    break;
                }
                end--;
                // Move from right to left
                swapped = false;
                for (int i = end - 1; i >= start; i--)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        Swap(arr, i, i + 1);
                        swapped = true;
                    }
                }
                start++;
            }
        }

        private void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
