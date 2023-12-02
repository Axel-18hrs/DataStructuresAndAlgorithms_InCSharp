﻿using DataStructuresAndAlgorithms_InCSharp.Classes.Lists;
using DataStructuresAndAlgorithms_InCSharp.Classes.Queues;
using DataStructuresAndAlgorithms_InCSharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms_InCSharp.Classes.Operations
{
    internal class OperationsQueue
    {
        public static void ALQueueOperation<T>(ImethodQueues<T> queue)
        {

        }
        public static void MenuQueue()
        {
            // Esta en proceso
            do
            {
                Console.Clear();
                Console.WriteLine("Types of lists: \n"
                + "1. Simple \n"
                + "2. Circular \n"
                + "3. Doubly linked \n"
                + "4. Circular Doubly linked \n"
                + "5. Exit \n");

                if (int.TryParse(Console.ReadLine(), out int opt))
                {
                    if (opt == 5) { return; }

                    switch (opt)
                    {
                        case 1:
                            ALQueueOperation(new RegularQueue<object>());
                            break;

                        case 2:
                            ALQueueOperation(new DoubleQueue<object>());
                            break;

                        case 3:
                            ALQueueOperation(new PriorityQueue<object>());
                            break;

                        case 4:
                            Console.WriteLine("De que tamaño desea que sea su Queue?");
                            if (!int.TryParse(Console.ReadLine(), out int lenght)) { Deffault(); continue; }

                            ALQueueOperation(new CircularQueue<object>(lenght));
                            break;

                        default:
                            Deffault();
                            continue;
                    }
                }
                else { Deffault(); }
            } while (true);
        }

        public static void Deffault()
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
            Console.ReadKey();
        }
    }
}