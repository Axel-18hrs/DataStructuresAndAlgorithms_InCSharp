using DataStructuresAndAlgorithms_InCSharp.Classes.Lists;
using DataStructuresAndAlgorithms_InCSharp.Classes.Queues;
using DataStructuresAndAlgorithms_InCSharp.Interfaces;

namespace DataStructuresAndAlgorithms_InCSharp.Classes.Operations
{
    internal class OperationsQueue
    {
        public static void ALQueueOperation<T>(ImethodQueues<T> queue)
        {
            // Esta en proceso
            string queueTypeMessage = queue is RegularQueue<T> ? "Regular" : queue is CircularList<T> ? "Double" :
                                    queue is DoublyListLinked<T> ? "Priority" : "Circle";

            do
            {
                Console.Clear();
                Console.WriteLine($"{queueTypeMessage} queue \n"
                    + "1. Add value \n"
                    + "2. Delete value \n"
                    + "3. Search value \n"
                    + "4. Show list \n"
                    + "5. Show reverse \n"
                    + "6. Clear \n"
                    + "7. Exit \n");

                if (!int.TryParse(Console.ReadLine(), out int choice)) { Deffault(); continue; }

                switch (choice)
                {

                }
                Console.ReadKey();
            } while (true);
        }

        public static void MenuQueue()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Types of lists: \n"
                + "1. Regular queue \n"
                + "2. Doubly queue \n"
                + "3. Priority queue \n"
                + "4. Circular queue \n"
                + "5. Exit \n");

                if (int.TryParse(Console.ReadLine(), out int opt))
                {
                    if (opt == 5) { return; }

                    switch (opt)
                    {
                        case 1:
                            ALQueueOperation(new RegularQueue<object>());
                            break;

                        case 2:
                            ALQueueOperation(new DoubleQueue<object>());
                            break;

                        case 3:
                            ALQueueOperation(new PriorityQueue<object>());
                            break;

                        case 4:
                            Console.WriteLine("De que tamaño desea que sea su Queue?");
                            if (!int.TryParse(Console.ReadLine(), out int lenght)) { Deffault(); continue; }

                            ALQueueOperation(new CircularQueue<object>(lenght));
                            break;

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
