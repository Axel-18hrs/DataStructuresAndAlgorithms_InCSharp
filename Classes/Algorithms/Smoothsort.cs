using DataStructuresAndAlgorithms_InCSharp.Interfaces.Algorithms;

namespace DataStructuresAndAlgorithms_InCSharp.Classes.Algorithms
{
    internal class Smoothsort : ImethodAlgorithms
    {
        private int[] heap;

        public Smoothsort() { }

        public void Sort(int[] arr)
        {
            heap = arr;
            int n = arr.Length;

            for (int i = 0; i < n; i++)
            {
                Heapify(i);
            }

            for (int i = n - 1; i > 0; i--)
            {
                Swap(0, i);
                SiftDown(0, i - 1);
            }
        }

        public void Sort(double[] arr)
        {

        }

        private void Heapify(int i)
        {
            int n = heap.Length;
            int k = 1;
            int j = i - 1;

            while (j >= 0 && heap[i] != heap[j])
            {
                if (heap[i] > heap[j])
                {
                    Swap(i, j);
                    SiftDown(k, i - 1);
                }

                i = j;
                j = RightChild(i, k);
                k++;
            }
        }

        private void SiftDown(int l, int r)
        {
            while (l <= r)
            {
                int k = 2;
                int i = r;
                int j = r - l;

                while (j >= 0 && heap[i] != heap[j])
                {
                    if (heap[i] > heap[j])
                    {
                        Swap(i, j);
                        SiftDown(k, i - 1);
                    }

                    i = j;
                    j = RightChild(i, k);
                    k++;
                }

                l--;
            }
        }

        private int RightChild(int i, int k)
        {
            return i - Fibonacci(k - 1) + Fibonacci(k - 2);
        }

        private int Fibonacci(int n)
        {
            if (n <= 1)
                return n;

            int a = 0, b = 1;

            for (int i = 2; i <= n; i++)
            {
                int temp = a + b;
                a = b;
                b = temp;
            }

            return b;
        }

        private void Swap(int i, int j)
        {
            int temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }
    }
}
