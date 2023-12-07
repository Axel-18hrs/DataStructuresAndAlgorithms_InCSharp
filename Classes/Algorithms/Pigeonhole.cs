﻿using DataStructuresAndAlgorithms_InCSharp.Interfaces.Algorithms;
using System;

namespace DataStructuresAndAlgorithms_InCSharp.Classes.Algorithms
{
    internal class Pigeonhole : ImethodAlgorithms
    {
        public Pigeonhole() { }

        public void Sort(int[] arr)
        {
            PigeonholeSort(arr);
            Console.WriteLine("[ " + string.Join(", ", arr) + " ]");
        }
        
        public void Sort(double[] arr)
        {

        }

        public void PigeonholeSort(int[] arr)
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
                    arr[index++] = j + min;
        }

        public void PrintArray(int[] arr)
        {
            foreach (int num in arr)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }
    }
}
