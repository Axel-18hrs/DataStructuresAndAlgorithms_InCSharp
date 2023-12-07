using DataStructuresAndAlgorithms_InCSharp.Classes.Operations.DataStructures;
using DataStructuresAndAlgorithms_InCSharp.Interfaces.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms_InCSharp.Classes.Operations.Algorithms
{
    internal class OperationsAlgorithm
    {
        public void Algorithm(ImethodAlgorithms algorithm)
        {
            do
            {
                if (!int.TryParse(Console.ReadLine(), out int option))
                {
                    OperationsList.Deffault(); continue;
                }

                switch (algorithm)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    default:
                        OperationsList.Deffault();
                        continue;
                }
                Console.ReadKey();
            } while (true);
        }
    }
}
