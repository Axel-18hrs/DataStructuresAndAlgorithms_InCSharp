using DataStructuresAndAlgorithms_InCSharp.Interfaces.Algorithms;
using System;
using System.Collections.Generic;

namespace DataStructuresAndAlgorithms_InCSharp.Classes.Algorithms
{
    internal class BucketSort : ImethodAlgorithms
    {

        public BucketSort() { }

        public void Sort(int[] arr) 
        {
            
        }

        public void Sort(double[] arr) 
        {
            BucketSort_Double(arr);
        }

        static void PrintBucketState(List<double>[] buckets)
        {
            Console.WriteLine("Current state of buckets:");
            for (int i = 0; i < buckets.Length; i++)
            {
                Console.Write($"Bucket {i}: ");
                foreach (var item in buckets[i])
                {
                    Console.Write($"{item} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static double[] BucketSort_Double(double[] array)
        {
            // Crear buckets vacíos
            List<double>[] buckets = new List<double>[array.Length];
            for (int i = 0; i < buckets.Length; i++)
            {
                buckets[i] = new List<double>();
            }

            // Insertar elementos en sus respectivos buckets
            foreach (double element in array)
            {
                buckets[(int)(element * array.Length)].Add(element);
            }

            // Imprimir el estado de los buckets después de la inserción
            PrintBucketState(buckets);

            // Ordenar los elementos de cada cubo
            for (int i = 0; i < array.Length; i++)
            {
                buckets[i].Sort();
            }

            // Imprimir el estado de los buckets después de la ordenación
            PrintBucketState(buckets);

            // Obtener los elementos ordenados
            int k = 0;
            for (int i = 0; i < array.Length; i++)
            {
                foreach (var item in buckets[i])
                {
                    array[k++] = item;
                }
            }

            return array;
        }
    }
}
