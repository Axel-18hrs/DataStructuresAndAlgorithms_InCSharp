using DataStructuresAndAlgorithms_InCSharp.Interfaces.Algorithms;
using System;

namespace DataStructuresAndAlgorithms_InCSharp.Classes.Algorithms
{
    internal class Pigeonhole : ImethodAlgorithms
    {
        private int swaps = 0;
        private int iterations = 0;

        public Pigeonhole() { }

        public void Sort(int[] arr)
        {
            PigeonholeSort(arr);
            Console.WriteLine($"Number of swaps: {swaps}");
            Console.WriteLine($"Number of iterations: {iterations}");
        }

        public void Sort(double[] arr)
        {
            // Implementación para ordenar un array de doubles
        }

        private void PigeonholeSort(int[] arr)
        {
            int min = arr[0];
            int max = arr[0];
            int range, i, j, index;

            for (int a = 1; a < arr.Length; a++)
            {
                if (arr[a] > max)
                    max = arr[a];
                if (arr[a] < min)
                    min = arr[a];
            }

            range = max - min + 1;
            int[] pigeonholes = new int[range];

            for (i = 0; i < arr.Length; i++)
                pigeonholes[i] = 0;

            for (i = 0; i < arr.Length; i++)
                pigeonholes[arr[i] - min]++;

            index = 0;

            for (j = 0; j < range; j++)
                while (pigeonholes[j]-- > 0)
                {
                    arr[index++] = j + min;
                    swaps++; // Incrementa el número de intercambios
                    iterations++; // Incrementa el número de iteraciones
                    Console.WriteLine("[ " + string.Join(", ", arr) + " ]");
                }
        }
    }
}
