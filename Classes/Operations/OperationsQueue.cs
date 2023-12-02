using DataStructuresAndAlgorithms_InCSharp.Classes.Lists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms_InCSharp.Classes.Operations
{
    internal class OperationsQueue
    {
        public void ALQueueOperation<T>()
        {

        }
        public static void MenuQueue()
        {
            // Esta en proceso
            do
            {
                Console.Clear();
                Console.WriteLine("Types of lists: \n"
                + "1. Simple \n"
                + "2. Circular \n"
                + "3. Doubly linked \n"
                + "4. Circular Doubly linked \n"
                + "5. Exit \n");

                if (int.TryParse(Console.ReadLine(), out int opt))
                {
                    switch (opt)
                    {
                        case 1:
                            ALQueueOperation<object>(new SimpleList<object>());
                            break;

                        case 2:
                            ALQueueOperation<object>(new CircularList<object>());
                            break;

                        case 3:
                            ALQueueOperation<object>(new DoublyListLinked<object>());
                            break;

                        case 4:
                            ALQueueOperation<object>(new CircularDoublyLinkedList<object>());
                            break;

                        case 5:
                            return;

                        default:
                            Deffault();
                            continue;
                    }
                }
                else { Deffault(); }
            } while (true);
        }

        public static void Deffault()
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
            Console.ReadKey();
        }
    }
}
