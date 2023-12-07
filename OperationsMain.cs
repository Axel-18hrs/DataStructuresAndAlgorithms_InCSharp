using DataStructuresAndAlgorithms_InCSharp.Classes.Operations.Algorithms;
using DataStructuresAndAlgorithms_InCSharp.Classes.Operations.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms_InCSharp
{
    internal class OperationsMain
    {
        public static void MenuDataStructurs()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Select an data struct:");
                Console.WriteLine("1. Lists \n"
                    + "2. Stacks \n"
                    + "3. Queue \n"
                    + "4. Trees \n"
                    + "5. Graphs \n"
                    + "0. Salir \n");

                if (!int.TryParse(Console.ReadLine(), out int option)) { OperationsList.Deffault(); continue; }

                switch (option)
                {
                    case 1:
                        OperationsList.MenuList();
                        break;
                    case 2:
                        OperationsStack.MenuStack();
                        break;
                    case 3:
                        OperationsQueue.MenuQueue();
                        break;
                    case 4:
                        OperationsTree.TreeMenu();
                        break;
                    case 5:
                        OperationsGraph.MenuGraphs();
                        break;

                    default:
                        OperationsList.Deffault();
                        continue;
                }
            } while (true);
        }

        public static void MenuAlgorithms_()
        {
            OperationsAlgorithm.MenuAlgorithms();
        }

        public static void MainDS()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Select a data structure or algorithm:");
                Console.WriteLine("1. Algorithms\n"
                    + "2. Data Structures\n"
                    + "0. Exit\n");

                if (!int.TryParse(Console.ReadLine(), out int num))
                {
                    OperationsList.Deffault();
                    continue;
                }

                switch (num)
                {
                    case 1:
                        MenuAlgorithms_();
                        break;
                    case 2:
                        MenuDataStructurs();
                        break;
                    case 0:
                        return; // Exit the loop and method
                    default:
                        OperationsList.Deffault();
                        break;
                }
            } while (true);
        }
    }
}
