using DataStructuresAndAlgorithms_InCSharp.Interfaces.Algorithms;

namespace DataStructuresAndAlgorithms_InCSharp.Classes.Algorithms
{
    public class SmoothSort : ImethodAlgorithms
    {
        private int[] heap;

        public SmoothSort() { }

        public void Sort(int[] arr)
        {
            heap = arr;
            int n = arr.Length;

            for (int i = (n - 1) / 2; i >= 0; i--)
            {
                SiftDown(i, n - 1);
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

        private void SiftDown(int root, int end)
        {
            int leftChild = 2 * root + 1;
            while (leftChild <= end)
            {
                int rightChild = leftChild + 1;
                int swapIndex = root;

                if (heap[swapIndex] < heap[leftChild])
                {
                    swapIndex = leftChild;
                }

                if (rightChild <= end && heap[swapIndex] < heap[rightChild])
                {
                    swapIndex = rightChild;
                }

                if (swapIndex == root)
                {
                    return;
                }
                else
                {
                    Swap(root, swapIndex);
                    root = swapIndex;
                    leftChild = 2 * root + 1;
                }
            }
        }

        private void Swap(int i, int j)
        {
            int temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }
    }
}
