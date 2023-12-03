using DataStructuresAndAlgorithms_InCSharp.Classes.Queues;
using DataStructuresAndAlgorithms_InCSharp.Interfaces;

namespace DataStructuresAndAlgorithms_InCSharp.Classes.Operations
{
    internal class OperationsQueue
    {
        public static void ALQueueOperation<T>(ImethodQueues<T> queue)
        {
            string queueTypeMessage = queue is RegularQueue<T> ? "Regular" : queue is DoubleQueue<T> ? "Double" :
                                    queue is PriorityQueue<T> ? "Priority" : "Circle";
            bool operationCircularQueue = queue is CircularQueue<T>;

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

                switch (choice)
                {
                    case 1:
                        if (operationCircularQueue)
                        {
                            Console.WriteLine("What type of enqueue do you want to perform?"
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
                        if (operationCircularQueue)
                        {
                            Console.WriteLine("What type of 'Dequeue' do you want to perform?"
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
                        if (operationCircularQueue)
                        {
                            Console.WriteLine("What type of 'Peek' do you want to perform?"
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

                    case 5:
                        return;

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
                Console.WriteLine("Types of queues: \n"
                + "1. Regular queue \n"
                + "2. Doubly queue \n"
                + "3. Priority queue \n"
                + "4. Circular queue \n"
                + "5. Exit \n");

                if (!int.TryParse(Console.ReadLine(), out int opt)) { Deffault(); continue; }

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