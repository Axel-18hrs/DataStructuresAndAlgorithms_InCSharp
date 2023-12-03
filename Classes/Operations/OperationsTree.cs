using DataStructuresAndAlgorithms_InCSharp.Classes.Tree;

namespace DataStructuresAndAlgorithms_InCSharp.Classes.Operations
{
    internal static class OperationsTree
    {
        public static void TreeMenu()
        {
            BinaryTree tree = new BinaryTree();

            do
            {
                Console.Clear();
                Console.WriteLine("Binary Tree \n"
                    + "1. Add node\n"
                    + "2. Search node\n"
                    + "3. Delete node\n"
                    + "4. Display tree\n"
                    + "5. PreOrder Traversal\n"
                    + "6. PostOrder Traversal\n"
                    + "7. InOrder Traversal\n"
                    + "8. Exit\n");

                if (!int.TryParse(Console.ReadLine(), out int choice)) { Default(); continue; }

                //if (choice == 8) { return; }

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter a value: ");
                        if (int.TryParse(Console.ReadLine(), out int opt))
                        {
                            tree.Add(opt);
                        }
                        else { Default(); continue; }
                        break;

                    case 2:
                        Console.Write("Enter the value of the node to search: ");
                        if (int.TryParse(Console.ReadLine(), out int opti))
                        {
                            tree.Search(opti);
                        }
                        else { Default(); continue; }
                        break;

                    case 3:
                        Console.Write("Enter the value of the node to delete: ");
                        if (int.TryParse(Console.ReadLine(), out int option))
                        {
                            tree.Delete(option);
                        }
                        else { Default(); continue; }
                        break;

                    case 4:
                        Console.Clear();
                        tree.PrintTree();
                        Console.WriteLine("Press a key to exit");
                        break;

                    case 5:
                        Console.Clear();
                        Console.WriteLine("PreOrder Traversal: " + string.Join(" ", tree.GetPreOrden()));
                        break;

                    case 6:
                        Console.Clear();
                        Console.WriteLine("PostOrder Traversal: " + string.Join(" ", tree.GetPostOrden()));
                        break;

                    case 7:
                        Console.Clear();
                        Console.WriteLine("InOrder Traversal: " + string.Join(" ", tree.GetInOrden()));
                        break;

                    case 8:
                        return;

                    default:
                        Default();
                        continue;
                }
                Console.ReadKey();
            } while (true);
        }

        public static void Default()
        {
            Console.WriteLine("\nInvalid input. Please enter a valid number.");
            Console.ReadKey();
        }
    }
}
