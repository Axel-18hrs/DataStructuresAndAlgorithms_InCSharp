
using DataStructuresAndAlgorithms_InCSharp.Classes.Operations;
using DataStructuresAndAlgorithms_InCSharp.Interfaces;

namespace DataStructuresAndAlgorithms_InCSharp.Classes.Queues
{
    internal class PriorityQueue<T> : ImethodQueues<T>
    {
        private SortedDictionary<int, Queue<T>> myPriorityQueue = new SortedDictionary<int, Queue<T>>();

        public void Enqueue(T? value)
        {
            Console.WriteLine("\nDesired priority level?");
            if (!int.TryParse(Console.ReadLine(), out int priority))
            {
                OperationsQueue.Deffault();
                return;
            }

            if (!myPriorityQueue.ContainsKey(priority))
            {
                myPriorityQueue[priority] = new Queue<T>();
            }

            myPriorityQueue[priority].Enqueue(value);

            Console.WriteLine($"Enqueued with priority {priority}: {value}");
        }

        public void EnqueueRear(T? priority)
        {

        }

        public void Dequeue()
        {
            if (myPriorityQueue.Count > 0)
            {
                var highestPriority = myPriorityQueue.First();
                var value = highestPriority.Value.Dequeue();

                if (highestPriority.Value.Count == 0)
                {
                    myPriorityQueue.Remove(highestPriority.Key);
                }

                Console.WriteLine($"Dequeued with priority {highestPriority.Key}: {value}");
                return;
            }

            Console.WriteLine("Priority Queue is empty. Unable to dequeue.");
        }

        public void DequeueRear()
        {

        }

        public void Peek()
        {
            if (myPriorityQueue.Count > 0)
            {
                var highestPriority = myPriorityQueue.First();
                var value = highestPriority.Value.Peek();

                Console.WriteLine($"Front element with priority {highestPriority.Key}: {value}");
                return;
            }

            Console.WriteLine("Priority Queue is empty. No elements to peek.");
        }

        public void PeekRear()
        {

        }

        public void Display()
        {
            Console.Write("Priority Queue elements: ");
            foreach (var priorityGroup in myPriorityQueue)
            {
                foreach (var item in priorityGroup.Value)
                {
                    Console.Write($"{item} (Priority {priorityGroup.Key}) ");
                }
            }
            Console.WriteLine();
        }

        public int Count()
        {
            return myPriorityQueue.Sum(priorityGroup => priorityGroup.Value.Count);
        }
    }
}
