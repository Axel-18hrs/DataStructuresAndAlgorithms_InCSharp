using DataStructuresAndAlgorithms_InCSharp.Interfaces.Algorithms;
using System.Collections.Generic;

namespace DataStructuresAndAlgorithms_InCSharp.Classes.Algorithms
{
    internal class CocktailSort : ImethodAlgorithms
    {
        public CocktailSort() { }

        public void Sort(int[] arr)
        {
            CocktailSortAlgorithm(arr);
        }

        public void Sort(double[] arr)
        {
            // Implementación para ordenar un array de doubles
        }

        private void CocktailSortAlgorithm(int[] arr)
        {
            int n = arr.Length;
            bool swapped = true;
            int start = 0;
            int end = n - 1;

            while (swapped)
            {
                // Mover de izquierda a derecha
                swapped = false;
                for (int i = start; i < end; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        Swap(arr, i, i + 1);
                        swapped = true;
                        Console.WriteLine("[ " + string.Join(", ", arr) + " ]");
                    }
                }

                if (!swapped)
                {
                    break;
                }

                end--;

                // Mover de derecha a izquierda
                swapped = false;
                for (int i = end - 1; i >= start; i--)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        Swap(arr, i, i + 1);
                        swapped = true;
                        Console.WriteLine("[ " + string.Join(", ", arr) + " ]");
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
