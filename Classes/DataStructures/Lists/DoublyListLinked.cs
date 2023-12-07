using DataStructuresAndAlgorithms_InCSharp.Classes.DataStructures.Nodes;
using DataStructuresAndAlgorithms_InCSharp.Interfaces.DataStructures;
using System;

namespace DataStructuresAndAlgorithms_InCSharp.Classes.DataStructures.Lists
{
    public class DoublyListLinked<T> : ImethodLists<T>
    {
        private DoubleNode<T> Head { get; set; }
        private DoubleNode<T> LastNode { get; set; }

        public DoublyListLinked()
        {
            Clear();
        }

        public void Add(T data)
        {
            // Case 0: Create a new node
            DoubleNode<T> NewNode = new DoubleNode<T>(data);

            // Case 1: Insert at the beginning
            if (IsEmpty())
            {
                Head = NewNode;
                LastNode = NewNode;
                return;
            }

            // Case 2: Prevent duplicate data
            if (Exist(NewNode.Data))
            {
                return;
            }

            // Case 3: The new data is inserted at the beginning
            if (NewNode.CompareTo(Head) <= 0)
            {
                Head.Back = NewNode;
                NewNode.Next = Head;
                Head = NewNode;
                return;
            }

            // Case 4: The new data is inserted at the end
            if (NewNode.CompareTo(LastNode) >= 0)
            {
                LastNode.Next = NewNode;
                NewNode.Back = LastNode;
                LastNode = NewNode;
                return;
            }

            // Case 5: Traverse the list
            DoubleNode<T> CurrentNode = Head;
            while (CurrentNode.Next != null && CurrentNode.Next.CompareTo(NewNode) <= 0)
            {
                CurrentNode = CurrentNode.Next;
            }

            // Case 6: Insert at X position
            NewNode.Next = CurrentNode.Next;
            NewNode.Back = CurrentNode;
            CurrentNode.Next.Back = NewNode;
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

            // Case 2: The data to delete is at the beginning of the list
            if (Head.CompareTo(data) == 0)
            {
                Head = Head.Next;
                Head.Back = null;
                Console.WriteLine($"- Data[{data}] deleted from the list");
                return;
            }

            // Case 3: The data to delete is at the end of the list
            if (LastNode.CompareTo(data) == 0)
            {
                LastNode = LastNode.Back;
                LastNode.Next = null;
                Console.WriteLine($"- Data[{data}] deleted from the list");
                return;
            }

            // Case 4: Traverse the list
            DoubleNode<T> CurrentNode = Head;
            while (CurrentNode.Next != null && CurrentNode.CompareTo(data) < 0)
            {
                CurrentNode = CurrentNode.Next;
            }

            // Case 5: The data is at X position in the list
            if (CurrentNode.CompareTo(data) == 0)
            {
                CurrentNode.Back.Next = CurrentNode.Next;
                CurrentNode.Next.Back = CurrentNode.Back;
                Console.WriteLine($"- Data[{data}] deleted from the list");
                return;
            }

            // Case 6: The data was not found
            Console.WriteLine($"- Data[{data}] does not exist/deleted from the list");
        }

        public void Search(T data)
        {
            // Case 1: If the list is empty
            if (IsEmpty())
            {
                Console.WriteLine("Empty list");
                return;
            }

            // Case 2: If the data is at the beginning
            if (Head.CompareTo(data) == 0)
            {
                Console.WriteLine($"- Data[{data}] exists in the list");
                return;
            }

            // Case 3: If the data is at the end
            if (LastNode.CompareTo(data) == 0)
            {
                Console.WriteLine($"- Data[{data}] exists in the list");
                return;
            }

            // Case 4: Traverse the list
            DoubleNode<T> CurrentNode = Head;
            while (CurrentNode.Next != null && CurrentNode.CompareTo(data) < 0)
            {
                CurrentNode = CurrentNode.Next;
            }

            // Case 5: If the data exists at X position
            if (CurrentNode.CompareTo(data) == 0)
            {
                Console.WriteLine($"- Data[{data}] exists in the list");
                return;
            }

            // Case 6: The data does not exist in the list
            Console.WriteLine($"- Data[{data}] Does not exist in the list ");
        }

        public void Show()
        {
            // Case 1: If the list is empty
            if (IsEmpty())
            {
                Console.WriteLine("Empty list");
                return;
            }

            // Case 2: Traverse the list
            DoubleNode<T> CurrentNode = Head;
            int i = 0;
            Console.WriteLine("=== My Doubly Linked List ===");
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
                Console.WriteLine("Empty list");
                return;
            }

            // Case 2: Traverse the list
            DoubleNode<T> CurrentNode = LastNode;
            int i = 0;
            Console.WriteLine("=== My Reversed Doubly Linked List ===");
            do
            {
                Console.WriteLine($"- Node[{i}] and data: " + CurrentNode.Data);
                CurrentNode = CurrentNode.Back;
                i++;
            } while (CurrentNode != null);
        }

        public bool Exist(T data)
        {
            // Case 1: If the list is empty
            if (IsEmpty())
            {
                Console.WriteLine("Empty list");
                return false;
            }

            // Case 2: If the first element already exists
            if (Head.CompareTo(data) == 0)
            {
                return true;
            }

            // Case 3: If the data is at the end
            if (LastNode.CompareTo(data) == 0)
            {
                return true;
            }

            // Case 4: Traverse the list
            DoubleNode<T> CurrentNode = Head;
            while (CurrentNode.Next != null && CurrentNode.CompareTo(data) < 0)
            {
                CurrentNode = CurrentNode.Next;
            }

            // Case 5: The entered data exists at X position
            if (CurrentNode.CompareTo(data) == 0)
            {
                return true;
            }

            // Case 6: The data does not exist in the list
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