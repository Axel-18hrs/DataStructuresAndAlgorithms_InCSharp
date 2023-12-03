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
    internal class OperationsGraph
    {
        public static void AllOperationGraph<T>(ImethodGraphs<T> graph)
        {
            string graphMessage = graph is Graph<T> ? "Graph" : "Directed graph";
            do
            {
                Console.Clear();
                Console.WriteLine($"{graphMessage} Menu: \n"
                    + "1. Add Vertex\n"
                    + "2. Remove Vertex\n"
                    + "3. Add Edge\n"
                    + "4. Remove Edge\n"
                    + "5. Check Vertex Existence\n"
                    + "6. Check Edge Existence\n"
                    + "7. Get All Vertices\n"
                    + "8. Get All Edges\n"
                    + "9. Traverse BFS\n"
                    + "10. Calculate Vertex Degree\n"
                    + "11. Calculate BFS Levels\n"
                    + "12. Exit\n");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    OperationsList.Deffault();
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter vertex value: ");
                        graph.AddVertex((T)Convert.ChangeType(Console.ReadLine(), typeof(T)));
                        Console.WriteLine("Vertex added successfully.");
                        break;

                    case 2:
                        Console.Write("Enter vertex value to remove: ");
                        graph.RemoveVertex((T)Convert.ChangeType(Console.ReadLine(), typeof(T)));
                        break;

                    case 3:
                        Console.Write("Enter starting vertex: ");
                        T vertexStart_1 = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));
                        Console.Write("Enter ending vertex: ");
                        T vertexEnd_1 = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));
                        graph.AddEdge(vertexStart_1, vertexEnd_1);
                        Console.WriteLine("Edge added successfully.");
                        break;

                    case 4:
                        Console.Write("Enter starting vertex: ");
                        T vertexStart_2 = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));
                        Console.Write("Enter ending vertex: ");
                        T vertexEnd_3 = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));
                        graph.RemoveEdge(vertexStart_2, vertexEnd_3);
                        break;

                    case 5:
                        Console.Write("Enter vertex to check existence: ");
                        graph.VertexExists((T)Convert.ChangeType(Console.ReadLine(), typeof(T)));
                        break;

                    case 6:
                        Console.Write("Enter starting vertex: ");
                        T vertexStart = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));
                        Console.Write("Enter ending vertex: ");
                        T vertexEnd = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));
                        graph.EdgeExists(vertexStart, vertexEnd);
                        break;

                    case 7:
                        graph.GetAllVertices();
                        break;

                    case 8:
                        graph.GetAllEdges();
                        break;

                    case 9:
                        Console.Write("Enter starting vertex for BFS traversal: ");
                        graph.TraverseBFS((T)Convert.ChangeType(Console.ReadLine(), typeof(T)));
                        break;

                    case 10:
                        Console.Write("Enter vertex to calculate degree: ");
                        graph.CalculateDegree((T)Convert.ChangeType(Console.ReadLine(), typeof(T)));
                        break;

                    case 11:
                        Console.Write("Enter starting vertex for BFS levels: ");
                        graph.CalculateBFSLevels((T)Convert.ChangeType(Console.ReadLine(), typeof(T)));
                        break;

                    case 12:
                        return;

                    default:
                        OperationsList.Deffault();
                        continue;
                }
                Console.ReadKey();
            } while (true);
        }
        public static void MenuGraphs()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Types of graphs: \n"
                  + "1. Graph \n"
                  + "2. Directed graph \n"
                  + "3. Exit \n");

                if (!int.TryParse(Console.ReadLine(), out int opt))
                {
                    OperationsList.Deffault();
                    continue;
                }

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