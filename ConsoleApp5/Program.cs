using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp5
{
    public static class Program
    {
        public static List<Node<char>> endNodes = new List<Node<char>>();
        public static void Main()
        {
            var strings = new List<string>();
            Permutation("космос".ToCharArray().ToList());
            foreach (var node in endNodes)
                strings.Add(WriteNodes(node, new StringBuilder()).ToString());
            var uniquleStrings = strings.ToHashSet().ToList();
            var doubleSymbolStrings = new List<string>();

            foreach(var unString in uniquleStrings)
                for(var i = 0; i < unString.Length - 1; i++)
                    if (unString[i] == unString[i + 1])
                    {
                        doubleSymbolStrings.Add(unString);
                        break;
                    }
            Console.ReadKey();
        }

        public static void Permutation(List<char> freeSymbols, Node<char> previousNode = null)
        {
            if (freeSymbols.Count == 0)
                endNodes.Add(previousNode);

            for (var i = 0; i < freeSymbols.Count; i++)
            {
                var actualNode = new Node<char> { previousNode = previousNode, item = freeSymbols[i] };
                var actualFreeSymbols = new List<char>(freeSymbols);
                actualFreeSymbols.RemoveAt(i);
                Permutation(actualFreeSymbols, actualNode);
            }
        }

        public static StringBuilder WriteNodes<T>(Node<T> endNode, StringBuilder builder)
        {
            if (endNode != null)
            {
                builder.Append(endNode.item);
                WriteNodes(endNode.previousNode, builder);
            }

            return builder;
        }
    }

    public class Node<T>
    {
        public Node<T> previousNode;
        public T item;
    }
}