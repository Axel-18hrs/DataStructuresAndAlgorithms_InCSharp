using DataStructuresAndAlgorithms_InCSharp.Interfaces.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms_InCSharp.Classes.Algorithms
{
    internal class Gnomesort : ImethodAlgorithms
    {
        private int iterations = 0;
        private int swaps = 0;

        public Gnomesort() { }

        public void Sort(int[] arr)
        {
            GnomeSort(arr);
            Console.WriteLine($"Number of iterations: {iterations}");
            Console.WriteLine($"Number of swaps: {swaps}");
        }

        public void Sort(double[] arr)
        {
            // Implementación para ordenar un array de doubles
        }

        private void GnomeSort(int[] arr)
        {
            int n = arr.Length;
            int index = 0;

            while (index < n)
            {
                if (index == 0)
                {
                    index++;
                }
                if (arr[index] >= arr[index - 1])
                {
                    index++;
                }
                else
                {
                    Swap(ref arr[index], ref arr[index - 1]);
                    index--;

                    // Print the array at each iteration
                    Console.WriteLine("[ " + string.Join(", ", arr) + " ]");
                    iterations++;
                }
            }
        }

        private void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
            swaps++;
        }
    }
}
