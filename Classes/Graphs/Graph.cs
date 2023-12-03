using DataStructuresAndAlgorithms_InCSharp.Interfaces;

namespace DataStructuresAndAlgorithms_InCSharp.Classes.Graphs
{
    internal class Graph<T> : ImethodGraphs<T>
    {
        private Dictionary<T, List<T>> adjacencyList;

        public Graph()
        {
            adjacencyList = new Dictionary<T, List<T>>();
        }

        // Add a vertex to the graph
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

        // Remove a vertex and all associated edges
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

        // Add an edge between two existing vertices
        public void AddEdge(T vertexStart, T vertexEnd)
        {
            if (adjacencyList.ContainsKey(vertexStart) && adjacencyList.ContainsKey(vertexEnd))
            {
                adjacencyList[vertexStart].Add(vertexEnd);
                adjacencyList[vertexEnd].Add(vertexStart); // If the graph is undirected
                Console.WriteLine($"Edge added between {vertexStart} and {vertexEnd}.");
                return;
            }
            Console.WriteLine($"Vertices {vertexStart} or {vertexEnd} do not exist in the graph.");
        }

        // Remove an edge between two existing vertices
        public void RemoveEdge(T vertexStart, T vertexEnd)
        {
            if (adjacencyList.ContainsKey(vertexStart) && adjacencyList.ContainsKey(vertexEnd))
            {
                adjacencyList[vertexStart].Remove(vertexEnd);
                adjacencyList[vertexEnd].Remove(vertexStart); // If the graph is undirected
                Console.WriteLine($"Edge removed between {vertexStart} and {vertexEnd}.");
                return;
            }
            Console.WriteLine($"Vertices {vertexStart} or {vertexEnd} do not exist in the graph.");
        }

        // Check the existence of a vertex
        public bool VertexExists(T vertex)
        {
            bool exists = adjacencyList.ContainsKey(vertex);
            Console.WriteLine($"Vertex {vertex} exists in the graph: {exists}.");
            return exists;
        }

        // Check the existence of an edge
        public bool EdgeExists(T vertexStart, T vertexEnd)
        {
            bool exists = adjacencyList.ContainsKey(vertexStart) && adjacencyList[vertexStart].Contains(vertexEnd);
            Console.WriteLine($"Edge between {vertexStart} and {vertexEnd} exists: {exists}.");
            return exists;
        }

        // Get all vertices
        public List<T> GetAllVertices()
        {
            List<T> vertices = new List<T>(adjacencyList.Keys);
            Console.WriteLine("All vertices in the graph: " + string.Join(", ", vertices));
            return vertices;
        }

        // Get all edges
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

            Console.WriteLine("All edges in the graph: " + string.Join(", ", edges));
            return edges;
        }

        // Traverse the graph using BFS
        public List<T> TraverseBFS(T startVertex)
        {
            List<T> visited = new List<T>();
            Queue<T> queue = new Queue<T>();

            // Check if startVertex is in adjacencyList
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

                // Check if currentVertex is in adjacencyList
                if (adjacencyList.ContainsKey(currentVertex))
                {
                    foreach (var neighbor in adjacencyList[currentVertex])
                    {
                        if (!visited.Contains(neighbor))
                        {
                            visited.Add(neighbor);
                            queue.Enqueue(neighbor);
                        }
                    }
                }
            }

            Console.WriteLine("BFS traversal result: " + string.Join(", ", visited));
            return visited;
        }

        // Calculate the degree of a vertex
        public int CalculateDegree(T vertex)
        {
            int degree = adjacencyList.ContainsKey(vertex) ? adjacencyList[vertex].Count : -1;
            Console.WriteLine($"Degree of vertex {vertex}: {degree}.");
            return degree;
        }

        // Calculate the breadth of the graph and the level of a node
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

                // Verificar si currentVertex está en adjacencyList
                if (adjacencyList.ContainsKey(currentVertex))
                {
                    foreach (var neighbor in adjacencyList[currentVertex])
                    {
                        if (!levels.ContainsKey(neighbor))
                        {
                            levels[neighbor] = levels[currentVertex] + 1;
                            queue.Enqueue(neighbor);
                        }
                    }
                }
            }

            Console.WriteLine("Niveles BFS: " + string.Join(", ", levels.Select(pair => $"{pair.Key}:{pair.Value}")));
            return levels;
        }
    }
}