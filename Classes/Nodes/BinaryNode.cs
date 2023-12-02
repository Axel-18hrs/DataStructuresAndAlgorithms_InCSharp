using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms_InCSharp.Classes.Nodes
{
    public class BinaryNode
    {
        public BinaryNode Left { get; set; }
        public BinaryNode Right { get; set; }
        public int Data { get; set; }

        public BinaryNode(int Data)
        {
            this.Data = Data;
            Left = null;
            Right = null;
        }
    }
}
