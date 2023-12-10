using DataStructuresAndAlgorithms_InCSharp.Interfaces.Algorithms;

namespace DataStructuresAndAlgorithms_InCSharp.Classes.Algorithms
{
    internal class BinarytreeNode
    {
        public int Value;
        public BinarytreeNode Left, Right;

        public BinarytreeNode(int value)
        {
            Value = value;
            Left = Right = null;
        }
    }

    public class BinaryTreeSort : ImethodAlgorithms
    {
        public BinaryTreeSort() { }

        private BinarytreeNode root;
        private int swaps = 0;
        private int recursions = 0;

        public void Sort(int[] arr)
        {
            foreach (var value in arr)
            {
                root = Insert(root, value);
            }
            InOrderTraversal(root, arr, ref index);
            Console.WriteLine($"Number of swaps: {swaps}");
            Console.WriteLine($"Number of recursions: {recursions}");
        }

        private BinarytreeNode Insert(BinarytreeNode node, int value)
        {
            if (node == null)
            {
                return new BinarytreeNode(value);
            }

            if (value < node.Value)
            {
                swaps++; // Incrementa el número de intercambios
                node.Left = Insert(node.Left, value);
            }
            else if (value > node.Value)
            {
                swaps++; // Incrementa el número de intercambios
                node.Right = Insert(node.Right, value);
            }

            return node;
        }

        private int index = 0;

        private void InOrderTraversal(BinarytreeNode node, int[] arr, ref int index)
        {
            recursions++; // Incrementa el número de recursiones
            if (node != null)
            {
                InOrderTraversal(node.Left, arr, ref index);
                arr[index++] = node.Value;
                PrintTree(node);
                InOrderTraversal(node.Right, arr, ref index);
            }
        }

        private void PrintTree(BinarytreeNode node, string indent = "", bool last = true)
        {
            if (node != null)
            {
                Console.WriteLine($"{indent}|- {node.Value}");
                indent += last ? "   " : "|  ";
                PrintTree(node.Left, indent, false);
                PrintTree(node.Right, indent, true);
            }
        }

        public void Sort(double[] arr)
        {
            // Implementación para ordenar un array de doubles
        }

    }
}
