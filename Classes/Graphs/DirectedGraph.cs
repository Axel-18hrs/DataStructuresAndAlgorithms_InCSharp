using DataStructuresAndAlgorithms_InCSharp.Interfaces;

namespace DataStructuresAndAlgorithms_InCSharp.Classes.Graphs
{
    public class DirectedGraph<T> : ImethodGraphs<T>
    {
        private Dictionary<T, List<T>> adjacencyList;

        public DirectedGraph()
        {
            adjacencyList = new Dictionary<T, List<T>>();
        }

        // Add a vertex to the directed graph
        public void AddVertex(T vertex)
        {
            if (!adjacencyList.ContainsKey(vertex))
            {
                adjacencyList[vertex] = new List<T>();
                Console.WriteLine($"Vertex {vertex} added to the graph.");
                return;
            }

            Console.WriteLine($"Vertex {vertex} already exists in the graph.");
        }

        // Remove a vertex and all outgoing edges associated with it
        public void RemoveVertex(T vertex)
        {
            if (adjacencyList.ContainsKey(vertex))
            {
                adjacencyList.Remove(vertex);
                Console.WriteLine($"Vertex {vertex} removed from the graph.");

                foreach (var otherVertex in adjacencyList.Keys)
                {
                    adjacencyList[otherVertex].Remove(vertex);
                }
                return;
            }
            Console.WriteLine($"Vertex {vertex} does not exist in the graph.");
        }

        // Add a directed edge from vertexStart to vertexEnd
        public void AddEdge(T vertexStart, T vertexEnd)
        {
            if (adjacencyList.ContainsKey(vertexStart) && adjacencyList.ContainsKey(vertexEnd))
            {
                adjacencyList[vertexStart].Add(vertexEnd);
                Console.WriteLine($"Directed edge added from {vertexStart} to {vertexEnd}.");
                return;
            }
            Console.WriteLine($"Vertices {vertexStart} or {vertexEnd} do not exist in the graph.");
        }

        // Remove a directed edge from vertexStart to vertexEnd
        public void RemoveEdge(T vertexStart, T vertexEnd)
        {
            if (adjacencyList.ContainsKey(vertexStart) && adjacencyList.ContainsKey(vertexEnd))
            {
                adjacencyList[vertexStart].Remove(vertexEnd);
                Console.WriteLine($"Directed edge removed from {vertexStart} to {vertexEnd}.");
                return;
            }
            Console.WriteLine($"Vertices {vertexStart} or {vertexEnd} do not exist in the graph.");
        }

        // Check the existence of a vertex in the directed graph
        public bool VertexExists(T vertex)
        {
            bool exists = adjacencyList.ContainsKey(vertex);
            Console.WriteLine($"Vertex {vertex} exists in the graph: {exists}.");
            return exists;
        }

        // Check the existence of a directed edge from vertexStart to vertexEnd
        public bool EdgeExists(T vertexStart, T vertexEnd)
        {
            bool exists = adjacencyList.ContainsKey(vertexStart) && adjacencyList[vertexStart].Contains(vertexEnd);
            Console.WriteLine($"Directed edge from {vertexStart} to {vertexEnd} exists: {exists}.");
            return exists;
        }

        // Get all vertices in the directed graph
        public List<T> GetAllVertices()
        {
            List<T> vertices = new List<T>(adjacencyList.Keys);
            Console.WriteLine("All vertices in the graph: " + string.Join(", ", vertices));
            return vertices;
        }

        // Get all directed edges in the graph
        public List<(T, T)> GetAllEdges()
        {
            List<(T, T)> edges = new List<(T, T)>();

            foreach (var vertex in adjacencyList.Keys)
            {
                foreach (var neighbor in adjacencyList[vertex])
                {
                    edges.Add((vertex, neighbor));
                }
            }

            Console.WriteLine("All directed edges in the graph: " + string.Join(", ", edges));
            return edges;
        }

        // Traverse the directed graph using BFS
        public List<T> TraverseBFS(T startVertex)
        {
            List<T> visited = new List<T>();
            Queue<T> queue = new Queue<T>();

            if (!adjacencyList.ContainsKey(startVertex))
            {
                Console.WriteLine($"Vertex {startVertex} does not exist in the graph.");
                return visited;
            }

            visited.Add(startVertex);
            queue.Enqueue(startVertex);

            while (queue.Count > 0)
            {
                T currentVertex = queue.Dequeue();

                foreach (var neighbor in adjacencyList[currentVertex])
                {
                    if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        queue.Enqueue(neighbor);
                    }
                }
            }

            Console.WriteLine("BFS traversal result: " + string.Join(", ", visited));
            return visited;
        }

        // Calculate the out-degree of a vertex in the directed graph
        public int CalculateDegree(T vertex)
        {
            int outDegree = adjacencyList.ContainsKey(vertex) ? adjacencyList[vertex].Count : -1;
            Console.WriteLine($"Out-degree of vertex {vertex}: {outDegree}.");
            return outDegree;
        }

        // Calculate the breadth of the directed graph and the level at which a node is located
        public Dictionary<T, int> CalculateBFSLevels(T startVertex)
        {
            Dictionary<T, int> levels = new Dictionary<T, int>();
            Queue<T> queue = new Queue<T>();

            if (!adjacencyList.ContainsKey(startVertex))
            {
                Console.WriteLine($"Vertex {startVertex} does not exist in the graph.");
                return levels;
            }

            levels[startVertex] = 0;
            queue.Enqueue(startVertex);

            while (queue.Count > 0)
            {
                T currentVertex = queue.Dequeue();

                foreach (var neighbor in adjacencyList[currentVertex])
                {
                    if (!levels.ContainsKey(neighbor))
                    {
                        levels[neighbor] = levels[currentVertex] + 1;
                        queue.Enqueue(neighbor);
                    }
                }
            }

            Console.WriteLine("BFS levels: " + string.Join(", ", levels.Select(pair => $"{pair.Key}:{pair.Value}")));
            return levels;
        }
    }
}