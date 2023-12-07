using DataStructuresAndAlgorithms_InCSharp.Classes.Algorithms;
using DataStructuresAndAlgorithms_InCSharp.Classes.Operations.DataStructures;
using DataStructuresAndAlgorithms_InCSharp.Interfaces.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms_InCSharp.Classes.Operations.Algorithms
{
    internal class OperationsAlgorithm
    {
        private Random _rand = new Random();
        public double[] GenerarVectorDouble(int Minon = 0, int Lenght = 10, int values = 5)
        {
            List<double> _List = new List<double>();

            for (int i = Minon; i < Lenght; i++)
            {
                if (i < values)
                {
                    double NewValor = _rand.NextDouble();
                    _List.Add(NewValor);
                }
                else
                {
                    break;
                }
            }
            return _List.ToArray();
        }

        public int[] GenerarVector(int Minon = 0, int Lenght = 10, int values = 5)
        {
            List<int> _List = new List<int>();

            for (int i = Minon; i < Lenght; i++)
            {
                if (i < values)
                {
                    int NewValor = _rand.Next(Minon, Lenght + 1);
                    if (_List.Contains(NewValor))
                    {
                        i--;
                        continue;
                    }
                    _List.Add(NewValor);
                }
                else
                {
                    break;
                }
            }
            return _List.ToArray();
        }

        public void Algorithm(ImethodAlgorithms algorithm)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Ingresa el rango minimo desde donde quieres generar tu arreglo desordenado:");
                if (!int.TryParse(Console.ReadLine(), out int minon))
                {
                    OperationsList.Deffault();
                    continue;
                }

                Console.WriteLine("\nIngresa el rango maximo o limite donde quieres generar tu arreglo desordenado:");
                if (!int.TryParse(Console.ReadLine(), out int lenght))
                {
                    OperationsList.Deffault();
                    continue;
                }

                Console.WriteLine("\nIngresa la cantidad de valores que deseas en tu arreglo:");
                if (!int.TryParse(Console.ReadLine(), out int valores))
                {
                    OperationsList.Deffault();
                    continue;
                }

                if (algorithm is BucketSort)
                {
                    double[] arr = GenerarVectorDouble(minon, lenght, valores);

                    Console.WriteLine("\nArreglo desordenado: ");
                    Console.Write("[ " + string.Join(", ", arr) + " ]");
                    DateTime startTime = DateTime.Now;
                    algorithm.Sort(arr);
                    Console.WriteLine("\nArreglo ordenado: ");
                    Console.Write("[ " + string.Join(", ", arr) + " ]");
                    Console.WriteLine("Tiempo: " + (DateTime.Now - startTime));
                }
                else
                {
                    int[] arr = GenerarVector(minon, lenght, valores);

                    Console.WriteLine("\nArreglo desordenado: ");
                    Console.Write("[ " + string.Join(", ", arr) + " ]");
                    DateTime startTime = DateTime.Now;
                    algorithm.Sort(arr);
                    Console.WriteLine("\nArreglo ordenado: ");
                    Console.Write("[ " + string.Join(", ", arr) + " ]");
                    Console.WriteLine("Tiempo: " + (DateTime.Now - startTime));
                }

                Console.ReadKey();

            } while (true);
        }

        public void MenuAlgorithms()
        {
            do
            {
                if (!int.TryParse(Console.ReadLine(), out int num))
                {
                    OperationsList.Deffault();
                    continue;
                }

                switch (num)
                {
                    case 1:
                        Algorithm(new Binarytreesort());
                        break;
                    case 2:
                        Algorithm(new BubbleSort());
                        break;
                    case 3:
                        Algorithm(new BucketSort());
                        break;
                    case 4:
                        Algorithm(new Cocktailsort());
                        break;
                    case 5:
                        Algorithm(new Combsort());
                        break;
                    case 6:
                        Algorithm(new Countingsort());
                        break;
                    case 7:
                        Algorithm(new Gnomesort());
                        break;
                    case 8:
                        Algorithm(new Heapsort());
                        break;
                    case 9:
                        Algorithm(new Insertionsort());
                        break;
                    case 10:
                        Algorithm(new Mergesort());
                        break;
                    case 11:
                        Algorithm(new Pigeonhole());
                        break;
                    case 12:
                        Algorithm(new QuickSort());
                        break;
                    case 13:
                        Algorithm(new Radixsort());
                        break;
                    case 14:
                        Algorithm(new Selectionsort());
                        break;
                    case 15:
                        Algorithm(new Shellsort());
                        break;
                    case 16:
                        Algorithm(new Smoothsort());
                        break;
                    case 0:
                        return;
                    default:
                        break;
                }
                Console.ReadKey();
            } while (true);
        }

    }
}
