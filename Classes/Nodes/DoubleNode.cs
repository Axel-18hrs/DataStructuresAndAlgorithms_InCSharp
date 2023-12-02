using System;
using System.Collections.Generic;

namespace DataStructuresAndAlgorithms_InCSharp.Classes.Nodes
{
    internal class DoubleNode<T> : IComparable<DoubleNode<T>>
    {
        public DoubleNode<T> Back { get; set; }
        public DoubleNode<T> Next { get; set; }
        public T Data { get; set; }

        public DoubleNode(T data)
        {
            Data = data;
            Next = null;
            Back = null;
        }

        public int CompareTo(DoubleNode<T> otroData)
        {
            // Caso 1: Ambos tipos son numericos
            if (EsNumero(Data) && EsNumero(otroData.Data))
            {
                long valor1 = Convert.ToInt64(Data);
                long valor2 = Convert.ToInt64(otroData.Data);
                return valor1.CompareTo(valor2);
            }

            // Caso 2: Solo el dato del nodo que esta comparando es numerico
            if (EsNumero(Data) && otroData.Data is string || otroData.Data is char)
            {
                long valor1 = Convert.ToInt64(Data);
                long valor2 = Convert.ToInt64(otroData.Data.ToString().Length);
                return valor1.CompareTo(valor2);
            }

            // Caso 3: Solo el dato del nodo a comparar es numerico
            if (EsNumero(otroData.Data) && Data is string || Data is char)
            {
                long valor1 = Convert.ToInt64(Data.ToString().Length);
                long valor2 = Convert.ToInt64(otroData.Data);
                return valor1.CompareTo(valor2);
            }

            // Case 4: Son diferentes tipos que se pueden comparar
            if (Data is IComparable comparableData && otroData.Data is IComparable comparableOtroData)
            {
                return comparableData.ToString().Length.CompareTo(comparableOtroData.ToString().Length);
            }

            return 0;
        }

        public int CompareTo(T otroData)
        {
            // Caso 1: Ambos tipos son numericos
            if (EsNumero(Data) && EsNumero(otroData))
            {
                long valor1 = Convert.ToInt64(Data);
                long valor2 = Convert.ToInt64(otroData);
                return valor1.CompareTo(valor2);
            }

            // Caso 2: Solo el dato del nodo que esta comparando es numerico
            if (EsNumero(Data) && otroData is string || otroData is char)
            {
                long valor1 = Convert.ToInt64(Data);
                long valor2 = Convert.ToInt64(otroData.ToString().Length);
                return valor1.CompareTo(valor2);
            }

            // Caso 3: Solo el dato del nodo a comparar es numerico
            if (EsNumero(otroData) && Data is string || Data is char)
            {
                long valor1 = Convert.ToInt64(Data.ToString().Length);
                long valor2 = Convert.ToInt64(otroData);
                return valor1.CompareTo(valor2);
            }

            // Case 4: Son diferentes tipos que se pueden comparar
            if (Data is IComparable comparableData && otroData is IComparable comparableOtroData)
            {
                return comparableData.ToString().Length.CompareTo(comparableOtroData.ToString().Length);
            }

            return 0;
        }
        private bool EsNumero(object value)
        {
            return value is sbyte || value is byte || value is short || value is ushort ||
                   value is int || value is uint || value is long || value is ulong ||
                   value is float || value is double || value is decimal;
        }
    }
}