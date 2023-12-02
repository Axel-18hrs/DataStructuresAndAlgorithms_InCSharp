using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms_InCSharp.Classes.Queues
{
    internal class RegularQueue<T>
    {
        private Queue<T> myQueue = new Queue<T>();

        public void Enqueue(T value)
        {
            myQueue.Enqueue(value);
            Console.WriteLine($"Enqueued: {value}");
        }

        public void Dequeue()
        {
            if (myQueue.Count > 0)
            {
                T value = myQueue.Dequeue();
                Console.WriteLine($"Dequeued: {value}");
                return;
            }

            Console.WriteLine("Queue is empty. Unable to dequeue.");
        }

        public void Peek()
        {
            if (myQueue.Count > 0)
            {
                T frontValue = myQueue.Peek();
                Console.WriteLine($"Front element: {frontValue}");
                return;
            }

            Console.WriteLine("Queue is empty. No elements to peek.");
        }

        public void DisplayQueue()
        {
            Console.Write("Queue elements: ");
            foreach (var item in myQueue)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }

        public int Count()
        {
            return myQueue.Count;
        }

    }
}
