using DataStructuresAndAlgorithms_InCSharp.Interfaces.Algorithms;

namespace DataStructuresAndAlgorithms_InCSharp.Classes.Algorithms
{
    internal class Heapsort : ImethodAlgorithms
    {
        private int iterations = 0;
        private static int recursions = 0;
        private static int swaps = 0;

        public Heapsort() { }

        public void Sort(int[] arr)
        {
            HeapSort(arr);
            Console.WriteLine($"Number of iterations: {iterations}");
            Console.WriteLine($"Number of recursions: {recursions}");
            Console.WriteLine($"Number of swaps: {swaps}");
        }

        public void Sort(double[] arr)
        {
            // Implementación para ordenar un array de doubles
        }

        private void HeapSort(int[] arr)
        {
            int n = arr.Length;

            // Construir un heap (montículo) máximo
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(arr, n, i);
            }

            // Extraer elementos uno por uno del heap
            for (int i = n - 1; i > 0; i--)
            {
                // Mover la raíz actual al final
                Swap(ref arr[0], ref arr[i]);
                swaps++;
                // Llamar a heapify en el subárbol reducido
                Heapify(arr, i, 0);

                // Print the array at each iteration
                Console.WriteLine("[ " + string.Join(", ", arr) + " ]");
                iterations++;
            }
        }

        private static void Heapify(int[] arr, int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            // Comparar con el hijo izquierdo
            if (left < n && arr[left] > arr[largest])
            {
                largest = left;
            }

            // Comparar con el hijo derecho
            if (right < n && arr[right] > arr[largest])
            {
                largest = right;
            }

            // Si el mayor no es la raíz
            if (largest != i)
            {
                Swap(ref arr[i], ref arr[largest]);

                // Recursivamente heapify el subárbol afectado
                Heapify(arr, n, largest);
                recursions++;
                swaps++;
            }
        }

        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }


}
