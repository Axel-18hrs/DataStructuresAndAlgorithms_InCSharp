using DataStructuresAndAlgorithms_InCSharp.Classes;
using DataStructuresAndAlgorithms_InCSharp.Classes.Lists;
using DataStructuresAndAlgorithms_InCSharp.Classes.Operations;
using Listas.Interfaces;
using System.Xml.Linq;

namespace DataStructuresAndAlgorithms_InCSharp
{
    public enum DataStructures
    {
        Lists = 1,
        Stacks = 2,
        Queue = 3,
        Trees = 4,
        Graphs = 5
    }
    
    internal class Program
    {
        
        public Program() 
        { 

        }

        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Select an data struct:");
                Console.WriteLine("1. Lists \n"
                    + "2. Stacks \n"
                    + "3. Queue \n"
                    + "4. Trees \n"
                    + "5. Graphs \n"
                    + "0. Salir \n");

                if (int.TryParse(Console.ReadLine(), out int option))
                {
                    switch (option)
                    {
                        case 1:
                            OperationsList.menuList();
                            break;
                        case (int)DataStructures.Stacks:
                            
                            break;
                        case (int)DataStructures.Queue:
                            
                            break;
                        case (int)DataStructures.Trees:
                            
                            break;
                        case (int)DataStructures.Graphs:
                            
                            break;
                        case 0:

                            break;
                        default:
                            Console.WriteLine("Opción no válida.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada no válida. Debe ingresar un número.");
                }

            } while (true);
        }
    }
}