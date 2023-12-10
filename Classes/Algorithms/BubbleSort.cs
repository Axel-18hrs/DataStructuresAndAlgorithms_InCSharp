using DataStructuresAndAlgorithms_InCSharp.Interfaces.Algorithms;

namespace DataStructuresAndAlgorithms_InCSharp.Classes.Algorithms
{
    public class BubbleSort : ImethodAlgorithms
    {
        private int swaps = 0;
        private int iterations = 0;

        public BubbleSort() { }

        public void Sort(int[] arr)
        {
            bubbleSort(arr);
            Console.WriteLine($"Number of swaps: {swaps}");
            Console.WriteLine($"Number of iterations: {iterations}");
        }

        public void Sort(double[] array)
        {
            // Implementación para ordenar un array de doubles y mostrar pasos
        }

        private void bubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    iterations++; // Incrementa el número de iteraciones
                    if (array[j] > array[j + 1])
                    {
                        swaps++; // Incrementa el número de intercambios
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;

                        Console.WriteLine("[ " + string.Join(", ", array) + " ]");
                    }
                }
            }
        }
    }
}
