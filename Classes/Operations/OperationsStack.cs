using DataStructuresAndAlgorithms_InCSharp.Classes.Stacks;
using DataStructuresAndAlgorithms_InCSharp.Interfaces;

namespace DataStructuresAndAlgorithms_InCSharp.Classes.Operations
{
    internal static class OperationsStack
    {
        public static void AllStackOperation<T>(ImethodStacks<T> stack)
        {
            string stackTypeMessage = stack is DinamicStack<T> ? "Dynamic stack" : "Static stack";

            do
            {
                Console.Clear();
                Console.WriteLine($"{stackTypeMessage} Menu \n"
                    + "1. Push \n"
                    + "2. Pop \n"
                    + "3. Peek \n"
                    + "4. Count \n"
                    + "5. Show Stack \n"
                    + "6. Exit \n");

                if (!int.TryParse(Console.ReadLine(), out int option)) { Deffault(); continue; }

                switch (option)
                {
                    case 1:
                        Console.WriteLine("\nEnter a value: ");
                        string input = Console.ReadLine();

                        try
                        {
                            T newElement = (T)Convert.ChangeType(input, typeof(T));
                            stack.Push(newElement);
                            Console.WriteLine($"Element '{newElement}' added to the stack.");
                        }
                        catch (InvalidCastException)
                        {
                            Console.WriteLine($"Could not convert '{input}' to type {typeof(T).Name}.");
                        }
                        break;

                    case 2:
                        Console.WriteLine($"Element '{stack.Pop()}' removed from the stack.");
                        break;

                    case 3:
                        Console.WriteLine($"Element '{stack.Peek()}' is at the top of the stack.");
                        break;

                    case 4:
                        Console.WriteLine($"Number of elements in the stack: {stack.Count()}");
                        break;

                    case 5:
                        stack.Show();
                        break;

                    case 6:
                        return;

                    default:
                        Deffault();
                        continue;
                }
                Console.ReadKey();
            } while (true);
        }

        public static void MenuStack()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Types of stacks: \n"
                + "1. Static stack \n"
                + "2. Dynamic stack \n"
                + "3. Exit \n");

                if (!int.TryParse(Console.ReadLine(), out int opt)) { Deffault(); continue; }

                switch (opt)
                {
                    case 1:
                        Console.WriteLine("How many data do you want to store in the static stack?");
                        if (!int.TryParse(Console.ReadLine(), out int cant)) { Deffault(); continue; }

                        AllStackOperation(new StaticStack<object>(cant));
                        break;

                    case 2:
                        AllStackOperation(new DinamicStack<object>());
                        break;

                    case 3:
                        return;

                    default:
                        Deffault();
                        continue;
                }
            } while (true);
        }

        public static void Deffault()
        {
            Console.WriteLine("\nInvalid input. Please enter a valid number.");
            Console.ReadKey();
        }
    }
}
