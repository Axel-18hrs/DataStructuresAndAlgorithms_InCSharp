
namespace DataStructuresAndAlgorithms_InCSharp.Classes.Queues
{
    internal class PriorityQueue<T>
    {
        private SortedDictionary<int, Queue<T>> myPriorityQueue = new SortedDictionary<int, Queue<T>>();

        public void Enqueue(int priority, T value)
        {
            if (!myPriorityQueue.ContainsKey(priority))
            {
                myPriorityQueue[priority] = new Queue<T>();
            }

            myPriorityQueue[priority].Enqueue(value);

            Console.WriteLine($"Enqueued with priority {priority}: {value}");
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

        public void DisplayPriorityQueue()
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
