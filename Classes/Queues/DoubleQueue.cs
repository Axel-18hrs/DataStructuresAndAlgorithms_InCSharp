using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms_InCSharp.Classes.Queues
{
    internal class DoubleQueue<T>
    {
        private LinkedList<T> myDeque = new LinkedList<T>();

        public void EnqueueFront(T value)
        {
            myDeque.AddFirst(value);
            Console.WriteLine($"Enqueued at the front: {value}");
        }

        public void EnqueueRear(T value)
        {
            myDeque.AddLast(value);
            Console.WriteLine($"Enqueued at the rear: {value}");
        }

        public void DequeueFront()
        {
            if (myDeque.Count > 0)
            {
                T value = myDeque.First.Value;
                myDeque.RemoveFirst();
                Console.WriteLine($"Dequeued from the front: {value}");
                return;
            }

            Console.WriteLine("Deque is empty. Unable to dequeue from the front.");
        }

        public void DequeueRear()
        {
            if (myDeque.Count > 0)
            {
                T value = myDeque.Last.Value;
                myDeque.RemoveLast();
                Console.WriteLine($"Dequeued from the rear: {value}");
                return;
            }

            Console.WriteLine("Deque is empty. Unable to dequeue from the rear.");
        }

        public void PeekFront()
        {
            if (myDeque.Count > 0)
            {
                T frontValue = myDeque.First.Value;
                Console.WriteLine($"Front element: {frontValue}");
                return;
            }

            Console.WriteLine("Deque is empty. No elements at the front to peek.");
        }

        public void PeekRear()
        {
            if (myDeque.Count > 0)
            {
                T rearValue = myDeque.Last.Value;
                Console.WriteLine($"Rear element: {rearValue}");
                return;
            }

            Console.WriteLine("Deque is empty. No elements at the rear to peek.");
        }

        public void DisplayDeque()
        {
            Console.Write("Deque elements: ");
            foreach (var item in myDeque)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }

        public int Count()
        {
            return myDeque.Count;
        }
    }
}
