using DataStructuresAndAlgorithms_InCSharp.Interfaces.Algorithms;
using System;

namespace DataStructuresAndAlgorithms_InCSharp.Classes.Algorithms
{
    internal class Insertionsort : ImethodAlgorithms
    {
        public Insertionsort() { }

        public void Sort(int[] arr)
        {
            InsertionSortAlgorithm(arr);
        }

        public void Sort(double[] arr)
        {

        }

        public void InsertionSortAlgorithm(int[] arr)
        {
            int n = arr.Length;
            for (int i = 1; i < n; ++i)
            {
                int key = arr[i];
                int j = i - 1;

                // Mover los elementos del subarreglo arr[0..i-1] que son mayores que key
                // a una posición adelante de su posición actual
                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }
                arr[j + 1] = key;
            }
        }
    }
}
