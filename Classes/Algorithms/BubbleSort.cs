using DataStructuresAndAlgorithms_InCSharp.Interfaces.Algorithms;

namespace DataStructuresAndAlgorithms_InCSharp.Classes.Algorithms
{
    internal class BubbleSort : ImethodAlgorithms
    {
        public BubbleSort() { }

        public void Sort(int[] arr) 
        {
            bubbleSort(arr);
        }

        public void Sort(double[] arr)
        {

        }

        public void bubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }
    }
}
