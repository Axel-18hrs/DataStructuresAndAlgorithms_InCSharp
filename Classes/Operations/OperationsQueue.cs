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
            string queueTypeMessage = queue is RegularQueue<T> ? "Regular" : queue is DoubleQueue<T> ? "Double" :
                                    queue is PriorityQueue<T> ? "Priority" : "Circle";
            bool operationCircularqueue = queue is CircularQueue<T>;

            do
            {
                Console.Clear();
                Console.WriteLine($"{queueTypeMessage} queue \n"
                    + "1. Enqueue value \n"
                    + "2. Dequeue value \n"
                    + "3. Peek value\n"
                    + "4. Display \n"
                    + "5. Exit \n");

                if (!int.TryParse(Console.ReadLine(), out int choice)) { Deffault(); continue; }

                if (choice == 5) { return; }

                switch (choice)
                {
                    case 1:
                        if (operationCircularqueue)
                        {
                            Console.WriteLine("Que tipo de encolado deseas hacer?"
                                + "\n1. Enqueue simple"
                                + "\n2. Enqueue rear");

                            if (!int.TryParse(Console.ReadLine(), out int option)) { Deffault(); continue; }

                            if (option == 2)
                            {
                                try
                                {
                                    Console.WriteLine("Enter a value to enqueue at the rear:");
                                    T convertedValue = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));
                                    queue.EnqueueRear(convertedValue);
                                }
                                catch (InvalidCastException)
                                {
                                    Deffault();
                                }
                                continue;
                            }

                            if (option != 1) { Deffault(); continue; }

                        }

                        try
                        {
                            Console.WriteLine("Enter a value to enqueue:");
                            T convertedValue = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));
                            queue.Enqueue(convertedValue);
                        }
                        catch (InvalidCastException)
                        {
                            Deffault();
                        }
                        break;
                    case 2:
                        if (operationCircularqueue)
                        {
                            Console.WriteLine("Que tipo de 'Dequeue' deseas hacer?"
                                + "\n1. Dequeue simple"
                                + "\n2. Dequeue rear");

                            if (!int.TryParse(Console.ReadLine(), out int option)) { Deffault(); continue; }

                            if (option == 2)
                            {
                                queue.DequeueRear();
                                continue;
                            }

                            if (option != 1) { Deffault(); continue; }
                        }

                        queue.Dequeue();
                        continue;
                    case 3:
                        if (operationCircularqueue)
                        {
                            Console.WriteLine("Que tipo de 'Peek' deseas hacer?"
                                + "\n1. Peek simple"
                                + "\n2. Peek rear");

                            if (!int.TryParse(Console.ReadLine(), out int option)) { Deffault(); continue; }

                            if (option == 2)
                            {
                                queue.PeekRear();
                                continue;
                            }

                            if (option != 1) { Deffault(); continue; }
                        }

                        queue.Peek();
                        break;
                    case 4:
                        queue.Display();
                        break;
                    default:
                        Deffault();
                        continue;
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

                if (!int.TryParse(Console.ReadLine(), out int opt)) { Deffault(); continue; }

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
                        Console.WriteLine("How large do you want your Queue to be?");
                        if (!int.TryParse(Console.ReadLine(), out int lenght)) { Deffault(); continue; }

                        ALQueueOperation(new CircularQueue<object>(lenght));
                        break;

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