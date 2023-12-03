using DataStructuresAndAlgorithms_InCSharp.Classes.Lists;
using Listas.Interfaces;
using System;

namespace DataStructuresAndAlgorithms_InCSharp.Classes.Operations
{
    public enum OptionLists
    {
        Add = 1,
        Delete = 2,
        Search = 3,
        Show = 4,
        ShowRevers = 5,
        Clear = 6
    }

    public static class OperationsList
    {
        private static Random r;
        static OperationsList()
        {
            r = new Random();
        }

        public static void AddElements(IEnumerable<object> elementsToAdd, ImethodLists<object> list)
        {
            foreach (var element in elementsToAdd)
            {
                list.Add(element);
            }
        }

        public static IEnumerable<object> DataNumeric()
        {
            Console.Write("How many data do you want to add: ");
            int cant = int.Parse(Console.ReadLine());

            Console.Write("Enter the minimum value for selecting data (default is 0): ");
            int minon = int.TryParse(Console.ReadLine(), out int minonResult) ? minonResult : 0;
            Console.WriteLine($"Selected value: {minon}");

            Console.Write("Enter the maximum value for selecting data (default is 100): ");
            int length = int.TryParse(Console.ReadLine(), out int lengthResult) ? lengthResult : 100;
            Console.WriteLine($"Selected value: {length}");

            if (minon > length)
            {
                Console.WriteLine("Error: The minimum value cannot be greater than the maximum value. Using default values.");
                minon = 0;
                length = 100;
            }

            if (cant > (length - minon + 1))
            {
                Console.WriteLine("Error: The number of data requested exceeds the available range. Using the available range.");
                cant = length - minon + 1;
            }

            int[] data = new int[cant];
            for (int i = 0; i < cant; i++)
            {
                if (i < cant)
                {
                    int newValue = r.Next(minon, length + 1);
                    if (data.Contains(newValue))
                    {
                        i--;
                        continue;
                    }
                    data[i] = newValue;
                }
                else
                {
                    break;
                }
            }

            for (int i = 0; i < cant; i++)
            {
                yield return data[i];
            }
        }

        public static void AListOperation<T>(ImethodLists<object> list)
        {
            string listTypeMessage = list is SimpleList<T> ? "Simple" : list is CircularList<T> ? "Circular" :
                                    list is DoublyListLinked<T> ? "Doubly" : "Doubly circle";
            do
            {
                Console.Clear();
                Console.WriteLine($"{listTypeMessage} list \n"
                    + "1. Add value \n"
                    + "2. Delete value \n"
                    + "3. Search value \n"
                    + "4. Show list \n"
                    + "5. Show reverse \n"
                    + "6. Clear \n"
                    + "7. Exit \n");

                if (!int.TryParse(Console.ReadLine(), out int opti)) { Deffault(); continue; }

                switch (opti)
                {
                    case (int)OptionLists.Add:
                        Console.Clear();
                        Console.WriteLine("Do you want to add data randomly? \n"
                            + "1. Yes \n"
                            + "2. No \n");
                        if (!int.TryParse(Console.ReadLine(), out int optio_)) { Deffault(); continue; }

                        switch (optio_)
                        {
                            case 1:
                                AddElements(DataNumeric(), list);
                                continue;

                            case 2:
                                Console.WriteLine("Enter a value: ");
                                list.Add(Console.ReadLine());
                                continue;

                            default:
                                Deffault();
                                continue;
                        }

                    case (int)OptionLists.Delete:
                        Console.Clear();
                        Console.WriteLine("Do you want to delete data randomly (only numbers)? \n"
                            + "1. Yes \n"
                            + "2. No \n");
                        if (!int.TryParse(Console.ReadLine(), out int optio)) { Deffault(); continue; }

                        switch (optio)
                        {
                            case 1:
                                list.Delete(DataNumeric());
                                continue;
                            case 2:
                                Console.WriteLine("Enter a value to delete: ");
                                list.Delete(Console.ReadLine());
                                continue;
                            default:
                                Deffault();
                                continue;
                        }

                    case (int)OptionLists.Search:
                        Console.WriteLine("Enter a value to search: ");
                        list.Search(Console.ReadLine());
                        continue;

                    case (int)OptionLists.Show:
                        list.Show();
                        break;

                    case (int)OptionLists.ShowRevers:
                        list.ShowRevers();
                        break;

                    case (int)OptionLists.Clear:
                        list.Clear();
                        continue;

                    case 7:
                        return;

                    default:
                        Deffault();
                        continue;
                }
                Console.ReadKey();
            } while (true);
        }

        public static void MenuList()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Types of lists: \n"
                + "1. Simple \n"
                + "2. Circular \n"
                + "3. Doubly linked \n"
                + "4. Circular Doubly linked \n"
                + "5. Exit \n");

                if (!int.TryParse(Console.ReadLine(), out int opt)) { Deffault(); continue; }

                switch (opt)
                {
                    case 1:
                        AListOperation<object>(new SimpleList<object>());
                        break;

                    case 2:
                        AListOperation<object>(new CircularList<object>());
                        break;

                    case 3:
                        AListOperation<object>(new DoublyListLinked<object>());
                        break;

                    case 4:
                        AListOperation<object>(new CircularDoublyLinkedList<object>());
                        break;

                    case 5:
                        return;

                    default:
                        Deffault();
                        continue;
                }
            } while (true);
        }

        public static void Deffault()
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
            Console.ReadKey();
        }
    }
}