using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms_InCSharp.Interfaces
{
    internal interface ImethodQueues<T>
    {
        void Enqueue(T? value);
        void EnqueueRear(T? value);
        void Dequeue();
        void DequeueRear();
        void Peek();
        void PeekRear();
        void Display();
        int Count();

    }
}
