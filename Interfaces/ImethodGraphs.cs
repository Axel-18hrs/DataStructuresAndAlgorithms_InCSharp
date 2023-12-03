using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms_InCSharp.Interfaces
{
    internal interface ImethodGraphs<T>
    {
        void AddVertex(T vertex);
        void RemoveVertex(T vertex);
        void AddEdge(T vertexStart, T vertexEnd);
        void RemoveEdge(T vertexStart, T vertexEnd);
        bool VertexExists(T vertex);
        bool EdgeExists(T vertexStart, T vertexEnd);
        List<T> GetAllVertices();
        List<(T, T)> GetAllEdges();
        List<T> TraverseBFS(T startVertex);
        int CalculateDegree(T vertex);
        Dictionary<T, int> CalculateBFSLevels(T startVertex);
    }
}
