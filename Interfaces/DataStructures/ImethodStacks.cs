using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms_InCSharp.Interfaces.DataStructures
{
    internal interface ImethodStacks<T>
    {
        void Push(T? element);
        T Pop();
        T Peek();
        void Show();
        int Count();
    }
}
