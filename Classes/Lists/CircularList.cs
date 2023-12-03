using DataStructuresAndAlgorithms_InCSharp.Classes.Nodes;
using Listas.Interfaces;
using System;
using System.Security.Permissions;

namespace DataStructuresAndAlgorithms_InCSharp.Classes.Lists
{
    public class CircularList<T> : ImethodLists<T>
    {
        private Node<T> Head { get; set; }
        private Node<T> LastNode { get; set; }

        public CircularList()
        {
            Clear();
        }

        public void Add(T data)
        {
            // Case 0: Create a new node
            Node<T> NewNode = new Node<T>(data);

            // Case 1: Insert at the beginning
            if (IsEmpty())
            {
                Head = NewNode;
                Head.Next = Head;
                LastNode = NewNode;
                return;
            }

            // Case 2: Prevent duplicate data
            if (Exist(NewNode.Data))
            {
                return;
            }

            // Case 3: Place the data after the first node
            if (NewNode.CompareTo(Head) <= 0)
            {
                NewNode.Next = Head;
                Head = NewNode;
                LastNode.Next = Head;
                return;
            }

            // Case 4: Insert at the end if the data is greater
            if (NewNode.CompareTo(LastNode) >= 0)
            {
                LastNode.Next = NewNode;
                NewNode.Next = Head;
                LastNode = NewNode;
                return;
            }

            // Case 5: Traverse the list
            Node<T> CurrentNode = Head;
            while (CurrentNode.Next != Head && CurrentNode.Next.CompareTo(NewNode) <= 0)
            {
                CurrentNode = CurrentNode.Next;
            }

            NewNode.Next = CurrentNode.Next;
            CurrentNode.Next = NewNode;
        }

        public void Delete(T data)
        {
            // Case 1: If the list is empty
            if (IsEmpty())
            {
                Console.WriteLine("Empty list");
                return;
            }

            // Case 2: The data is at the beginning of the list
            if (Head.CompareTo(data) == 0)
            {
                Head = Head.Next;
                LastNode.Next = Head;
                Console.WriteLine($"- Data[{data}] deleted from the list");
                return;
            }

            // Case 3: Traverse the list
            Node<T> CurrentNode = Head;
            while (CurrentNode.Next != Head && CurrentNode.Next.CompareTo(data) < 0)
            {
                CurrentNode = CurrentNode.Next;
            }

            // Case 4: The data is at the end of the list
            if (CurrentNode.Next == LastNode && LastNode.CompareTo(data) == 0)
            {
                CurrentNode.Next = CurrentNode.Next.Next;
                LastNode = CurrentNode;
                LastNode.Next = Head;
                Console.WriteLine($"- Data[{data}] deleted from the list");
                return;
            }

            // Case 5: The data is at X position in the list
            if (CurrentNode.Next.CompareTo(data) == 0)
            {
                CurrentNode.Next = CurrentNode.Next.Next;
                Console.WriteLine($"- Data[{data}] deleted from the list");
                return;
            }

            // Case 6: The data was not found
            Console.WriteLine($"- Data[{data}] not found/deleted from the list");
        }

        public void Search(T data)
        {
            // Case 1: If the list is empty
            if (IsEmpty())
            {
                Console.WriteLine("Empty list");
                return;
            }

            // Case 2: If the data is at the beginning of the list
            if (Head.CompareTo(data) == 0)
            {
                Console.WriteLine($"- Data[{data}] exists in the list");
                return;
            }

            // Case 3: Traverse the list
            Node<T> CurrentNode = Head;
            while (CurrentNode.Next != Head && CurrentNode.CompareTo(data) < 0)
            {
                CurrentNode = CurrentNode.Next;
            }

            // Case 4: The entered data exists at X position
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
            // Case 1: Check if the list is empty
            if (IsEmpty())
            {
                Console.WriteLine("Empty list");
                return;
            }

            // Case 2: Traverse the list
            Node<T> CurrentNode = Head;
            int i = 0;
            Console.WriteLine("=== My Circular List ===");
            do
            {
                Console.WriteLine($"- Node[{i}] and data: " + (CurrentNode.Data is Person ? CurrentNode.Data.ToString() : CurrentNode.Data));
                CurrentNode = CurrentNode.Next;
                i++;
            } while (CurrentNode != Head);
        }

        public void ShowRevers()
        {
            Stack<T> stack = new Stack<T>();
            Node<T> CurrentNode = Head;
            int i = 0;
            do
            {
                i++;
                stack.Push(CurrentNode.Data);
                CurrentNode = CurrentNode.Next;
            } while (CurrentNode != Head);

            // Create a copy of the stack before iterating
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

            // Case 2: If the data already exists at the beginning
            if (Head.CompareTo(data) == 0)
            {
                return true;
            }

            // Case 3: Traverse the list
            Node<T> CurrentNode = Head;
            while (CurrentNode.Next != Head && CurrentNode.CompareTo(data) < 0)
            {
                CurrentNode = CurrentNode.Next;
            }

            // Case 4: If the data already exists at X position / or at the end
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
            LastNode = null;
        }
    }
}