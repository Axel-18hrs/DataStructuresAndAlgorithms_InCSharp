using DataStructuresAndAlgorithms_InCSharp.Interfaces;

namespace DataStructuresAndAlgorithms_InCSharp.Classes.Stacks
{
    internal class DinamicStack<T> : ImethodStacks<T>
    {
        private List<T> stackList;

        public DinamicStack()
        {
            stackList = new List<T>();
        }

        public void Push(T? item)
        {
            stackList.Add(item);
        }

        public T Pop()
        {
            if (stackList.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty.");
            }

            int lastIndex = stackList.Count - 1;
            T poppedItem = stackList[lastIndex];
            stackList.RemoveAt(lastIndex);

            return poppedItem;
        }

        public T Peek()
        {
            if (stackList.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty.");
            }

            return stackList[stackList.Count - 1];
        }
        public int Count()
        {
            return Convert.ToInt32(stackList.ToArray().Length);
        }

        public void Show()
        {
            Console.WriteLine("\nElements in the stack:");
            for (int i = stackList.Count - 1; i >= 0; i--)
            {
                Console.WriteLine(stackList[i]);
            }
        }
    }
}
