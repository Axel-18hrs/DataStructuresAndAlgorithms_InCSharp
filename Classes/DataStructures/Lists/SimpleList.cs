using DataStructuresAndAlgorithms_InCSharp.Classes.DataStructures.Nodes;
using DataStructuresAndAlgorithms_InCSharp.Interfaces.DataStructures;
using System;
using System.Collections.Generic;

namespace DataStructuresAndAlgorithms_InCSharp.Classes.DataStructures.Lists
{
    public class SimpleList<T> : ImethodLists<T>
    {
        private static Node<T> Head { get; set; }
        private static Random r;

        public SimpleList()
        {
            Clear();
            r = new Random();
        }

        public void Add(T data)
        {
            // Case 0: Create a new node
            Node<T> NewNode = new Node<T>(data);

            // Case 1: Insert at the beginning
            if (IsEmpty())
            {
                Head = NewNode;
                return;
            }

            // Case 2: Prevent duplicate data
            if (Exist(NewNode.Data))
            {
                return;
            }

            // Case 3: Insert the data at the beginning of the list
            if (NewNode.CompareTo(Head) <= 0)
            {
                NewNode.Next = Head;
                Head = NewNode;
                return;
            }

            // Case 4: Traverse the list
            Node<T> CurrentNode = Head;
            while (CurrentNode.Next != null && CurrentNode.Next.CompareTo(NewNode) <= 0)
            {
                CurrentNode = CurrentNode.Next;
            }

            // Case 5: Insert at X position or at the end of the list
            NewNode.Next = CurrentNode.Next;
            CurrentNode.Next = NewNode;
        }

        public void Delete(T data)
        {
            // Case 1: If the list is empty
            if (IsEmpty())
            {
                Console.WriteLine("Empty list.");
                return;
            }

            // Case 2: If the data is at the beginning
            if (Head.CompareTo(data) == 0)
            {
                Head = Head.Next;
                Console.WriteLine($"- Data[{data}] deleted from the list");
                return;
            }

            // Case 3: Traverse the list
            Node<T> CurrentNode = Head;
            while (CurrentNode.Next != null && !Equals(CurrentNode.Next.Data, data))
            {
                CurrentNode = CurrentNode.Next;
            }

            // Case 4: If the data is at X position
            if (CurrentNode.Next != null && Equals(CurrentNode.Next.Data, data))
            {
                CurrentNode.Next = CurrentNode.Next.Next;
                Console.WriteLine($"- Data[{data}] deleted from the list");
                return;
            }

            // Case 5: The data was not found
            Console.WriteLine($"- Data[{data}] not found/deleted from the list");
        }

        public void Search(T data)
        {
            // Case 1: If the list is empty
            if (IsEmpty())
            {
                Console.WriteLine("Empty list.");
                return;
            }

            // Case 2: If the data is at the beginning
            if (Head.CompareTo(data) == 0)
            {
                Console.WriteLine($"- Data[{data}] exists in the list");
                return;
            }

            // Case 3: Traverse the list
            Node<T> CurrentNode = Head;
            while (CurrentNode.Next != null && CurrentNode.Next.CompareTo(data) <= 0)
            {
                CurrentNode = CurrentNode.Next;
            }

            // Case 4: If the data is at X position
            if (CurrentNode.CompareTo(data) == 0)
            {
                Console.WriteLine($"- Data[{data}] exists in the list");
                return;
            }

            // Case 5: The data does not exist
            Console.WriteLine($"- Data[{data}] does not exist in the list ");
        }

        public void Show()
        {
            // Case 1: If the list is empty
            if (IsEmpty())
            {
                Console.WriteLine("Empty list.");
                return;
            }

            // Case 2: Traverse the list
            int i = 0;
            Node<T> CurrentNode = Head;
            Console.WriteLine("=== My simple list ===");
            while (CurrentNode != null)
            {
                Console.WriteLine($"- Node[{i}] and data: " + CurrentNode.Data);
                CurrentNode = CurrentNode.Next;
                i++;
            }
        }

        public void ShowRevers()
        {
            // Case 1: If the list is empty
            if (IsEmpty())
            {
                Console.WriteLine("Empty list.");
                return;
            }

            Stack<T> stack = new Stack<T>();
            Node<T> CurrentNode = Head;
            int i = 0;
            while (CurrentNode != null)
            {
                i++;
                stack.Push(CurrentNode.Data);
                CurrentNode = CurrentNode.Next;
            }

            T[] stackArray = stack.ToArray();

            foreach (T node in stackArray)
            {
                Console.WriteLine($"- Node[{--i}] and data: " + node.ToString());
            }
        }

        public bool Exist(T data)
        {
            // Case 1: If the list is empty
            if (IsEmpty())
            {
                return false;
            }

            // Case 2: If the first node contains the data
            if (Head.CompareTo(data) == 0)
            {
                return true;
            }

            // Case 3: Start traversing the list
            Node<T> CurrentNode = Head;
            while (CurrentNode.Next != null && CurrentNode.CompareTo(data) < 0)
            {
                CurrentNode = CurrentNode.Next;
            }

            // Case 4: The data exists in the last element
            if (CurrentNode.CompareTo(data) == 0)
            {
                return true;
            }

            // Case 5: The data does not exist in the list
            return false;
        }

        public bool IsEmpty()
        {
            return Head == null;
        }

        public void Clear()
        {
            Head = null;
        }
    }
}