using Listas.Interfaces;
using System;

namespace DataStructuresAndAlgorithms_InCSharp.Classes.Lists
{
    public class DoublyListLinked<T> : ImethodLists<T>
    {
        private DoubleNode<T> Head { get; set; }
        private DoubleNode<T> LastNode { get; set; }

        public DoublyListLinked()
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
                return;
            }

            //Caso 2: Impedimos datos repetidos
            if (Exist(NewNode.Data))
            {
                return;
            }

            //Caso 3: El dato nuevo se inserta al inicio
            if (NewNode.CompareTo(Head) <= 0)
            {
                Head.Back = NewNode;
                NewNode.Next = Head;
                Head = NewNode;
                return;
            }

            //Caso 4: El dato nuevo se inserta al final
            if (NewNode.CompareTo(LastNode) >= 0)
            {
                LastNode.Next = NewNode;
                NewNode.Back = LastNode;
                LastNode = NewNode;
                return;
            }

            //Caso 5: Recorrermos la lista
            DoubleNode<T> CurrentNode = Head;
            while (CurrentNode.Next != null && CurrentNode.Next.CompareTo(NewNode) <= 0)
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
            //Caso 2: El dato a eliminar esta al inicio de la lista
            if (object.Equals(Head.Data, data))
            {
                Head = Head.Next;
                Head.Back = null;
                Console.WriteLine($"- Dato[{data}] Eliminado de la lista");
                return;
            }
            //Caso 3: El dato a eliminar esta al final de la lista
            if (object.Equals(LastNode.Data, data))
            {
                LastNode = LastNode.Back;
                LastNode.Next = null;
                Console.WriteLine($"- Dato[{data}] Eliminado de la lista");
                return;
            }
            //Caso 4: Recorremos la lista
            DoubleNode<T> CurrentNode = Head;
            while (CurrentNode.Next != null && CurrentNode.Next.CompareTo(data) <= 0)
            {
                CurrentNode = CurrentNode.Next;
            }
            //Caso 5: El dato esta en X posicion de la lista
            if (object.Equals(CurrentNode.Data, data))
            {
                CurrentNode.Back.Next = CurrentNode.Next;
                CurrentNode.Next.Back = CurrentNode.Back;
                Console.WriteLine($"- Dato[{data}] Eliminado de la lista");
                return;
            }
            //Caso 6: No se encontro el dato
            Console.WriteLine($"- Dato[{data}] No existe/eliminado de la lista");
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
            while (CurrentNode.Next != null && CurrentNode.CompareTo(data) < 0)
            {
                CurrentNode = CurrentNode.Next;
            }
            //Caso 5: Si existe el dato en X posicion
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
            Console.WriteLine("=== Mi Lista doblemente enlazada ===");
            while (CurrentNode != null)
            {
                Console.WriteLine($"- Nodo[{i}] y dato: " + CurrentNode.Data);
                CurrentNode = CurrentNode.Next;
                i++;
            }
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
            Console.WriteLine("=== Mi Lista doblemente enlazada Reversa===");
            do
            {
                Console.WriteLine($"- Nodo[{i}] y dato: " + CurrentNode.Data);
                CurrentNode = CurrentNode.Back;
                i++;
            } while (CurrentNode != null);
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
            while (CurrentNode.Next != null && CurrentNode.CompareTo(data) < 0)
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