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

    internal class Binarytreesort : ImethodAlgorithms
    {
        public Binarytreesort() { }

        private BinarytreeNode root;

        public void Sort(int[] arr)
        {
            // Construir el árbol binario
            foreach (var value in arr)
            {
                root = Insert(root, value);
            }

            // Recorrer el árbol en orden para obtener los elementos ordenados
            InOrderTraversal(root, arr, ref index);
        }

        public void Sort(double[] arr)
        {

        }

        private BinarytreeNode Insert(BinarytreeNode node, int value)
        {
            if (node == null)
            {
                return new BinarytreeNode(value);
            }

            if (value < node.Value)
            {
                node.Left = Insert(node.Left, value);
            }
            else if (value > node.Value)
            {
                node.Right = Insert(node.Right, value);
            }

            return node;
        }

        private int index = 0;

        private void InOrderTraversal(BinarytreeNode node, int[] arr, ref int index)
        {
            if (node != null)
            {
                InOrderTraversal(node.Left, arr, ref index);
                arr[index++] = node.Value;
                InOrderTraversal(node.Right, arr, ref index);
            }
        }
    }
}
