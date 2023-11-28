
using Listas.Interfaces;
using System;
using System.ComponentModel;


namespace DataStructuresAndAlgorithms_InCSharp.Classes.Lists
{
    public class CircularDoublyLinkedList<T> : ImethodLists<T>
    {
        private DoubleNode<T> Head { get; set; }
        private DoubleNode<T> LastNode { get; set; }
         
        public CircularDoublyLinkedList()
        { 
            Clear();
        }

        public void Add(T data)   
        {
            //Caso 0: Creamos un nuevo nodo
            DoubleNode<T> NewNode = new DoubleNode<T>(data);

            //Caso 1: Insertamso al inicio
            if (IsEmpty())
            {
                Head = NewNode;
                LastNode = NewNode;
                Head.Back = LastNode;
                LastNode.Next = Head;
                return;
            }

            //Caso 2: Impedimos datos repetidos
            if (Exist(NewNode.Data))
            {
                Console.WriteLine("// Ya existe: " + data);
                return;
            }

            //Caso 3: Insertamos al incio si el dato es menor
            if (NewNode.CompareTo(Head) <= 0)
            {
                NewNode.Next = Head;
                NewNode.Back = LastNode;
                Head.Back = NewNode;
                Head = NewNode;
                LastNode.Next = Head;
                return;
            }

            //Caso 4: Insertamos al final si el dato es mayor
            if (NewNode.CompareTo(LastNode) >= 0)
            {
                LastNode.Next = NewNode;
                NewNode.Back = LastNode;
                NewNode.Next = Head;
                LastNode = NewNode;
                Head.Back = LastNode;
                return;
            }

            // caso 5: Recorremos la lista
            DoubleNode<T> CurrentNode = Head;
            while (CurrentNode.Next != Head && CurrentNode.Next.CompareTo(NewNode) <= 0)
            {
                CurrentNode = CurrentNode.Next;
            }

            //Caso 6: Insertamso en X posicion
            NewNode.Next = CurrentNode.Next;
            NewNode.Back = CurrentNode;
            CurrentNode.Next.Back = NewNode;
            CurrentNode.Next = NewNode;
        }

        public void Delete(T data)
        {
            //Caso 1: Si la lista esta vacia
            if (IsEmpty())
            {
                return;
            }

            //Caso 2: Elimnamos y comprobamso si hay solo un elemento
            if (object.Equals(Head.Data, LastNode.Data))
            {
                Clear();
                Console.WriteLine($"- Dato[{data}] Eliminado de la lista");
                return;
            }

            //Caso 3: El dato esta al inicio de la lista
            if (object.Equals(Head.Data, data))
            {
                Head = Head.Next;
                Head.Back = LastNode;
                LastNode.Next = Head;
                Console.WriteLine($"- Dato[{data}] Eliminado de la lista");
                return;
            }

            //Caso 4: El dato esta al final de la lista
            if (object.Equals(LastNode.Data, data))
            {
                LastNode = LastNode.Back;
                LastNode.Next = Head;
                Head.Back = LastNode;
                Console.WriteLine($"- Dato[{data}] Eliminado de la lista");
                return;
            }

            //Caso 5: Recorremos la lista
            DoubleNode<T> CurrentNode = Head;
            while (CurrentNode.Next != Head && !object.Equals(CurrentNode.Next.Data, data))
            {
                CurrentNode = CurrentNode.Next;
            }

            //Caso 6: El dato esta en X posicion de la lista
            if (object.Equals(CurrentNode.Next.Data, data))
            {
                CurrentNode.Next.Next.Back = CurrentNode;
                CurrentNode.Next = CurrentNode.Next.Next;
                Console.WriteLine($"- Dato[{data}] Eliminado de la lista");
                return;
            }

            //Caso 7: No se encontro el dato a eliminar
            Console.WriteLine($"- Dato[{data}] No encontrado/eliminado de la lista");
        }

        public void Search(T data)
        {
            //Caso 1: Si la lista esta vacia
            if (IsEmpty())
            {
                return;
            }

            //Caso 2: Si es dato esta al inicio
            if (object.Equals(Head.Data, data))
            {
                Console.WriteLine($"- Dato[{data}] Existe en la lista");
                return;
            }

            //Caso 3: Si es dato esta al final
            if (object.Equals(LastNode.Data, data))
            {
                Console.WriteLine($"- Dato[{data}] Existe en la lista");
                return;
            }

            //Caso 4: Recorremos la lista
            DoubleNode<T> CurrentNode = Head;
            while (CurrentNode.Next != Head && !object.Equals(CurrentNode.Next.Data, data))
            {
                CurrentNode = CurrentNode.Next;
            }

            //Caso 5: Si existe el dato en la lista
            if (object.Equals(CurrentNode.Data, data))
            {
                Console.WriteLine($"- Dato[{data}] Existe en la lista");
                return;
            }

            //Caso 6: No existe el dato en la lista
            Console.WriteLine($"- Dato[{data}] No Existe en la lista ");
        }

        public void Show()
        {
            //Caso 1: Si al lista esta vacia
            if (IsEmpty())
            {
                Console.WriteLine("Lista vacia");
                return;
            }

            //Caso 2: Recorremos la lista
            DoubleNode<T> CurrentNode = Head;
            int i = 0;
            Console.WriteLine("=== Mi Lista circular doblemente enlazada ===");
            do
            {
                Console.WriteLine($"- Nodo[{i}] y dato: " + CurrentNode.Data);
                CurrentNode = CurrentNode.Next;
                i++;
            } while (CurrentNode != Head);
        }

        public void ShowRevers()
        {
            //Caso 1: Si la lsita esta vacia
            if (IsEmpty())
            {
                Console.WriteLine("Lista vacia");
                return;
            }

            //Caso 2: Recorremos la lista
            DoubleNode<T> CurrentNode = LastNode;
            int i = 0;
            Console.WriteLine("=== Mi Lista circular doblemente enlazada Reversa ===");
            do
            {
                Console.WriteLine($"- Nodo[{i}] y dato: " + CurrentNode.Data);
                CurrentNode = CurrentNode.Back;
                i++;
            } while (CurrentNode != LastNode);
        }

        public bool Exist(T data)
        {
            //Caso 1: Si la lista esta vacia
            if (IsEmpty())
            {
                return false;
            }

            //Caso 2: Si el primer elemento ya existe
            if (object.Equals(Head.Data, data))
            {
                return true;
            }

            //Caso 3: Si es dato esta al final
            if (object.Equals(LastNode.Data, data))
            {
                return true;
            }

            //Caso 4: Recorremos la lista
            DoubleNode<T> CurrentNode = Head;
            while (CurrentNode.Next != Head && !object.Equals(CurrentNode.Data, data))
            {
                CurrentNode = CurrentNode.Next;
            }


            //Caso 5: El dato ingresado existe en X posicion
            if (object.Equals(CurrentNode.Data, data))
            {
                return true;
            }

            //Caso 6: El dato no existe en la lista
            return false;
        }

        public bool IsEmpty()
        {
            return Head == null;
        }

        public void Clear()
        {
            Head = null;
            LastNode = null;
        }

    }
}