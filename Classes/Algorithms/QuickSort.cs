using System;
using System.Collections.Generic;

namespace DataStructuresAndAlgorithms_InCSharp.Classes.Algorithms
{
    internal class QuickSort
    {
        private static Random _Random = new Random();

        private static int _Option, _ContainExchange, _ContainPartition, _ContainRecursive;

        public QuickSort() { }

        private static void Swap(ref int IndexOnew, ref int IndexTwo)
        {
            int Temporary = IndexOnew;
            IndexOnew = IndexTwo;
            IndexTwo = Temporary;
        }

        private static int Partition(ref int[] Array, int FirstIndex, int LastIndex)
        {
            _ContainPartition++;
            int IndexPivot;
            switch (_Option)
            {
                case 1:
                    IndexPivot = FirstIndex;
                    break;

                case 2:
                    IndexPivot = (int)Math.Floor((double)(LastIndex + FirstIndex) / 2);
                    break;

                case 3:
                    IndexPivot = LastIndex;
                    break;

                default:
                    IndexPivot = _Random.Next(FirstIndex, LastIndex);
                    break;
            }
            Swap(ref Array[FirstIndex], ref Array[IndexPivot]);
            PrintSwap(ref Array, FirstIndex, IndexPivot);
            _ContainExchange++;
            int Pivot = Array[FirstIndex];
            int Left = FirstIndex + 1;
            int Right = LastIndex;
            while (true)
            {
                while (Left <= Right && Array[Left] <= Pivot)
                {
                    Left += 1;
                }
                while (Left <= Right && Array[Right] >= Pivot)
                {
                    Right -= 1;
                }
                if (Right < Left)
                {
                    break;
                }
                Swap(ref Array[Left], ref Array[Right]);
                PrintSwap(ref Array, Left, Right);
                _ContainExchange++;
                Left += 1;
                Right -= 1;
            }
            Swap(ref Array[FirstIndex], ref Array[Right]);
            PrintSwap(ref Array, FirstIndex, Right);
            _ContainExchange++;
            return Right;
        }

        public static void quicksort(ref int[] Array, int FirstIndex, int LastIndex)
        {
            if (FirstIndex < LastIndex)
            {
                _ContainRecursive++;
                int IndexPivot = Partition(ref Array, FirstIndex, LastIndex);
                quicksort(ref Array, FirstIndex, IndexPivot - 1);
                quicksort(ref Array, IndexPivot + 1, LastIndex);
            }
        }

        public static void Print(ref int[] arr)
        {
            quicksort(ref arr, 0, arr.Length - 1);
            Console.Write("\nResult: [ " + string.Join(", ", arr) + " ]");
            Console.WriteLine("\nSwap: " + _ContainExchange + "\nParticiones: " + _ContainPartition + "\nRecursividad: " + _ContainRecursive);
            _ContainExchange = 0;
            _ContainPartition = 0;
            _ContainRecursive = 0;
        }

        private static void PrintSwap(ref int[] array, int Left, int Right)
        {
            Console.Write("[ ");
            for (int i = 0; i < array.Length; i++)
            {
                if (Right == i && Left == i)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(array[i]);
                    Console.ResetColor();
                }
                else if (i == Left || i == Right)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(array[i]);
                    Console.ResetColor();
                }
                else
                {
                    Console.Write(array[i]);
                }
                if (i < array.Length - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.Write(" ]\n");
        }

        public static int[] GenerarVector(int Minon, int Lenght, int Val = 5)
        {
            List<int> _List = new List<int>();
            for (int i = Minon; i < Lenght; i++)
            {
                if (i < Val)
                {
                    int NewValor = _Random.Next(Minon, Lenght + 1);
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
    }
}
