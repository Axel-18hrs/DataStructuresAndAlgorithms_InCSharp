using DataStructuresAndAlgorithms_InCSharp.Interfaces.Algorithms;
using System;

namespace DataStructuresAndAlgorithms_InCSharp.Classes.Algorithms
{
    internal class Mergesort : ImethodAlgorithms
    {
        private int swaps = 0;
        private int iterations = 0;
        private int recursions = 0;

        public Mergesort() { }

        public void Sort(int[] arr)
        {
            MergeSort(arr);
            Console.WriteLine($"Number of swaps: {swaps}");
            Console.WriteLine($"Number of iterations: {iterations}");
            Console.WriteLine($"Number of recursions: {recursions}");
        }

        public void Sort(double[] arr)
        {
            // Implementación para ordenar un array de doubles
        }

        private void MergeSort(int[] arr)
        {
            if (arr.Length < 2)
                return;

            int mid = arr.Length / 2;
            int[] left = new int[mid];
            int[] right = new int[arr.Length - mid];

            Array.Copy(arr, 0, left, 0, mid);
            Array.Copy(arr, mid, right, 0, arr.Length - mid);

            MergeSort(left);
            MergeSort(right);
            Merge(arr, left, right);
            recursions++; // Incrementa el número de recursiones
        }

        private void Merge(int[] arr, int[] left, int[] right)
        {
            int i = 0, j = 0, k = 0;

            while (i < left.Length && j < right.Length)
            {
                if (left[i] <= right[j])
                {
                    arr[k] = left[i];
                    i++;
                }
                else
                {
                    arr[k] = right[j];
                    j++;
                }
                k++;
                swaps++; // Incrementa el número de intercambios
                iterations++; // Incrementa el número de iteraciones
                Console.WriteLine("[ " + string.Join(", ", arr) + " ]");
            }

            while (i < left.Length)
            {
                arr[k] = left[i];
                i++;
                k++;
                swaps++; // Incrementa el número de intercambios
                iterations++; // Incrementa el número de iteraciones
                Console.WriteLine("[ " + string.Join(", ", arr) + " ]");
            }

            while (j < right.Length)
            {
                arr[k] = right[j];
                j++;
                k++;
                swaps++; // Incrementa el número de intercambios
                iterations++; // Incrementa el número de iteraciones
                Console.WriteLine("[ " + string.Join(", ", arr) + " ]");
            }
        }
    }
}
