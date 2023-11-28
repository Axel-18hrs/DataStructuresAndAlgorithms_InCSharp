using DataStructuresAndAlgorithms_InCSharp.Classes.Lists;
using Listas.Interfaces;
using System;

namespace DataStructuresAndAlgorithms_InCSharp.Classes.Operations
{
    public enum OptionLists_Simple
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
            for (int i = 0; i < cant; i++)
            {
                yield return new Random().Next(25);
            }
        }

        public static void AListOperation<T>(ImethodLists<object> list)
        {
            string listTypeMessage = list is SimpleList<T> ? "Simple" : list is CircularList<T> ? "Circular" :
                                    list is DoublyListLinked<T> ? "Doubly" : list is CircularDoublyLinkedList<T> ? "Doubly circle" : "Unknown";
            do
            {
                Console.Clear();
                Console.WriteLine($"{listTypeMessage} list \n"
                    + "1. Add value \n"
                    + "2. Delete value \n"
                    + "3. Search value \n"
                    + "4. Show list \n"
                    + "5. Show reverse \n"
                    + "6. Clear \n");

                if (int.TryParse(Console.ReadLine(), out int opti))
                {
                    switch (opti)
                    {
                        case (int)OptionLists_Simple.Add:
                            do
                            {
                                Console.Clear();
                                Console.WriteLine("¿Quieres añadir datos de manera aleatoria? \n"
                                    + "1. Si \n"
                                    + "2. No \n");
                                if (int.TryParse(Console.ReadLine(), out int optio))
                                {
                                    switch (optio)
                                    {
                                        case 1:
                                            AddElements(DataNumeric(), list);
                                            break;
                                        case 2:
                                            // añadir la opcion de poder agregar clases de tipo persona
                                            Console.WriteLine("Ingresa un valor: ");
                                            list.Add(Console.ReadLine());
                                            break;
                                        default:
                                            Console.WriteLine("Entrada no válida. Debe ingresar un número valido.");
                                            continue;
                                    }
                                }
                                break;
                            } while (true);
                            break;
                        case (int)OptionLists_Simple.Delete:
                            do
                            {
                                Console.Clear();
                                Console.WriteLine("¿Quieres eliminar datos de manera aleatoria? \n"
                                    + "1. Si \n"
                                    + "2. No \n");
                                if (int.TryParse(Console.ReadLine(), out int optio))
                                {
                                    switch (optio)
                                    {
                                        case 1:
                                            //list.AddElements(list.DataNumeric());
                                            AddElements(DataNumeric(), list);
                                            break;
                                        case 2:
                                            Console.WriteLine("Ingresa un valor: ");
                                            list.Add(Console.ReadLine());
                                            break;
                                        default:
                                            Console.WriteLine("Entrada no válida. Debe ingresar un número valido.");
                                            break;
                                    }
                                }
                                Console.WriteLine("Ingresa un valor a remover: ");
                                list.Delete(Console.ReadLine());

                                break;
                            } while (true);
                            break;
                        case (int)OptionLists_Simple.Search:
                            Console.WriteLine("Ingresa un valor: ");
                            list.Search(Console.ReadLine());
                            Console.ReadKey();
                            break;
                        case (int)OptionLists_Simple.Show:
                            list.Show();
                            Console.ReadKey();
                            break;
                        case (int)OptionLists_Simple.ShowRevers:
                            list.ShowRevers();
                            Console.ReadKey();
                            break;
                        case (int)OptionLists_Simple.Clear:
                            list.Clear();
                            Console.ReadKey();
                            break;
                        case 7:
                            return;
                        default:
                            Console.WriteLine("Entrada no válida. Debe ingresar un número valido.");
                            Console.ReadKey();
                            break;
                    }
                }
            } while (true);
        }

        public static void menuList()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Tipos de listas: \n"
                + "1. Simple \n"
                + "2. Circular \n"
                + "3. Doblemente enlazada \n"
                + "4. Circular Doblemente enlazada \n"
                + "5. Salir \n");

                if (int.TryParse(Console.ReadLine(), out int opt))
                {
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
                            Console.WriteLine("Entrada no válida. Debe ingresar un número valido.");
                            Console.ReadKey();
                            continue;
                    }
                }
            } while (true);
        }
    }
}
