using Listas.Interfaces;
using System;
using System.Collections.Generic;

namespace DataStructuresAndAlgorithms_InCSharp.Classes.Lists
{
    public class SimpleList<T> : ImethodLists<T>
    {
        private static Node<T> Head { get; set; }
        private static Random r;

        public SimpleList()
        {
            Clear();
            r = new Random();
        }

        public void Add(T data)
        {
            //Caso 0: Creamos un nuevo nodo
            Node<T> NewNode = new Node<T>(data);
            //Caso 1: Insertamso al inicio
            if (IsEmpty())
            {
                Head = NewNode;
                return;
            }
            //Caso 2: Impedimos datos repetidos
            if (Exist(NewNode.Data))
            {
                return;
            }
            //Caso 3: Insertamos el dato al inicio de la lista
            if (NewNode.CompareTo(Head) <= 0)
            {
                NewNode.Next = Head;
                Head = NewNode;
                return;
            }
            //Caso 4: Recorremos la lista
            Node<T> CurrentNode = Head;
            while (CurrentNode.Next != null && CurrentNode.Next.CompareTo(NewNode) <= 0)
            {
                CurrentNode = CurrentNode.Next;
            }
            //Caso 5: Insertamos en X posicion o al final de la lista
            NewNode.Next = CurrentNode.Next;
            CurrentNode.Next = NewNode;
        }

        public void Delete(T data)
        {
            //Caso 1: Si la lista esta vacia
            if (IsEmpty())
            {
                return;
            }
            //Caso 2: Si el dato esta al inicio
            if (object.Equals(Head.Data, data))
            {
                Head = Head.Next;
                Console.WriteLine($"- Dato[{data}] Eliminado de la lista");
                return;
            }
            //Caso 3: Recorremos la lista
            Node<T> CurrentNode = Head;
            while (CurrentNode.Next != null && !object.Equals(CurrentNode.Next.Data, data))
            {
                CurrentNode = CurrentNode.Next;
            }
            //Caso 4: Si el dato esta en X posicion
            if (CurrentNode.Next != null && object.Equals(CurrentNode.Next.Data, data))
            {
                CurrentNode.Next = CurrentNode.Next.Next;
                Console.WriteLine($"- Dato[{data}] Eliminado de la lista");
                return;
            }
            //Caso 5: No se encontro el dato
            Console.WriteLine($"- Dato[{data}] No encontrado/eliminado de la lista");
        }

        public void Search(T data)
        {
            //Caso 1: Si la lista esta vacia
            if (IsEmpty())
            {
                return;
            }
            //Case 2: Si el dato esta al inicio
            if (object.Equals(Head.Data, data))
            {
                Console.WriteLine($"- Dato[{data}] Existe en la lista");
                return;
            }
            //Caso 3: Recorremos la lista
            Node<T> CurrentNode = Head;
            while (CurrentNode.Next != null && CurrentNode.CompareTo(data) < 0)
            {
                CurrentNode = CurrentNode.Next;
            }
            //Caso 4: Si el dato esta en X posicion
            if (object.Equals(CurrentNode.Data, data))
            {
                Console.WriteLine($"- Dato[{data}] Existe en la lista");
                return;
            }
            //Caso 5: No existe el dato
            Console.WriteLine($"- Dato[{data}] No Existe en la lista ");
        }

        public void Show()
        {
            //Caso 1: Si la lista esta vacia
            if (IsEmpty())
            {
                Console.WriteLine("Lista vacia");
                return;
            }
            //Caso 2: Recorremos la lista
            int i = 0;
            Node<T> CurrentNode = Head;
            Console.WriteLine("=== Mi lista simple ===");
            while (CurrentNode != null)
            {
                Console.WriteLine($"- Nodo[{i}] y dato: " + CurrentNode.Data);
                CurrentNode = CurrentNode.Next;
                i++;
            }
        }

        public void ShowRevers() { }

        public bool Exist(T data)
        {
            //Caso 1: Si la lista esta vacia
            if (IsEmpty())
            {
                return false;
            }
            //Caso 2: Si el primer nodo contiene el dato
            if (object.Equals(Head.Data, data))
            {
                return true;
            }
            //Caso 3: Empezamos a recorrer la lista
            Node<T> CurrentNode = Head;
            while (CurrentNode.Next != null && CurrentNode.CompareTo(data) < 0)
            {
                CurrentNode = CurrentNode.Next;
            }
            //Caso 4: El dato existe en el ultimo elemento
            if (object.Equals(CurrentNode.Data, data))
            {
                return true;
            }
            //Caso 5: El dato no existe en la lista
            return false;
        }

        public bool IsEmpty()
        {
            return Head == null;
        }

        public void Clear()
        {
            Head = null;
        }

       
    }
}