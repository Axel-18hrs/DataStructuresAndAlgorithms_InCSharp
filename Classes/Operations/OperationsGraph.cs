using DataStructuresAndAlgorithms_InCSharp.Classes.Graphs;
using DataStructuresAndAlgorithms_InCSharp.Classes.Lists;
using DataStructuresAndAlgorithms_InCSharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DataStructuresAndAlgorithms_InCSharp.Classes.Operations
{
    internal class OperationsGraph<T>
    {
        public static void AllOperationGraph<T>(ImethodGraphs<T> graph)
        {
            do
            {
                Console.WriteLine("\nUndirected Graph Menu:");
                Console.WriteLine("1. Add Vertex");
                Console.WriteLine("2. Remove Vertex");
                Console.WriteLine("3. Add Edge");
                Console.WriteLine("4. Remove Edge");
                Console.WriteLine("5. Check Vertex Existence");
                Console.WriteLine("6. Check Edge Existence");
                Console.WriteLine("7. Get All Vertices");
                Console.WriteLine("8. Get All Edges");
                Console.WriteLine("9. Traverse BFS");
                Console.WriteLine("10. Calculate Vertex Degree");
                Console.WriteLine("11. Calculate BFS Levels");
                Console.WriteLine("12. Exit");
                if (!int.TryParse(Console.ReadLine(), out int choice)) { OperationsList.Deffault(); continue; }

                switch(choice)
                {
                    case 1:
                        graph.AddVertex(Console.ReadLine());
                        break;
                        
                }
            } while (true);


        }
        public static void MenuGraph()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Types of graphs: \n"
                + "1. Graph \n"
                + "2. Directed graph \n"
                + "3. Exit \n");

                if (!int.TryParse(Console.ReadLine(), out int opt)) { OperationsList.Deffault(); continue; }

                switch (opt)
                {
                    case 1:
                        AllOperationGraph(new Graph<object>());
                        break;

                    case 2:
                        AllOperationGraph(new DirectedGraph<object>());
                        break;

                    case 3:
                        return;

                    default:
                        OperationsList.Deffault();
                        continue;
                }
            } while (true);
        }
    }
}