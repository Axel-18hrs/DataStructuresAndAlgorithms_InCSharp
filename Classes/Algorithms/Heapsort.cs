using DataStructuresAndAlgorithms_InCSharp.Interfaces.Algorithms;

namespace DataStructuresAndAlgorithms_InCSharp.Classes.Algorithms
{
    internal class Heapsort : ImethodAlgorithms
    {
        public Heapsort() { }

        public void Sort(int[] arr)
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

                // Llamar a heapify en el subárbol reducido
                Heapify(arr, i, 0);
            }
        }

        public void Sort(double[] arr)
        {

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
