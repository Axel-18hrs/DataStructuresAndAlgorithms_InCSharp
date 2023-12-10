using DataStructuresAndAlgorithms_InCSharp.Interfaces.Algorithms;

namespace DataStructuresAndAlgorithms_InCSharp.Classes.Algorithms
{
    internal class Selectionsort : ImethodAlgorithms
    {
        private int swaps = 0;
        private int iterations = 0;

        public Selectionsort() { }

        public void Sort(int[] arr)
        {
            int n = arr.Length;

            for (int i = 0; i < n - 1; i++)
            {
                // Encontrar el índice del mínimo elemento en el subarreglo no ordenado
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[j] < arr[minIndex])
                    {
                        minIndex = j;
                    }
                }

                // Intercambiar el mínimo encontrado con el primer elemento del subarreglo no ordenado
                Swap(ref arr[i], ref arr[minIndex]);

                // Print the array at each iteration
                PrintArray(arr);
            }

            Console.WriteLine($"Number of swaps: {swaps}");
            Console.WriteLine($"Number of iterations: {iterations}");
        }

        public void Sort(double[] arr)
        {
            // Implementación para ordenar un array de doubles
        }

        private void PrintArray(int[] arr)
        {
            Console.WriteLine("[ " + string.Join(", ", arr) + " ]");
            iterations++;
        }

        private void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
            swaps++; // Incrementa el número de intercambios
        }
    }
}
