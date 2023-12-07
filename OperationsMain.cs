﻿using DataStructuresAndAlgorithms_InCSharp.Classes.Operations.Algorithms;
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
        public void MenuDataStructurs()
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

        public void MenuAlgorithms_()
        {
            OperationsAlgorithm.MenuAlgorithms();
        }

        public void MainDS()
        {

        }
    }
}