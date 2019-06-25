using System;

namespace Coft.DataStructures.DoubleLinkedList
{
    public class CircularDoubleLinkedList<T> : IDoubleLinkedList<T> where T : class
    {
        public DoubleLinkedListNode<T> LastNode { get; set; }

        public void InsertAfter(DoubleLinkedListNode<T> node, DoubleLinkedListNode<T> newNode)
        {
            newNode.NextNode = node.NextNode;
            newNode.PrevNode = node;
            node.NextNode.PrevNode = newNode;
            node.NextNode = newNode;
        }

        public void InsertBefore(DoubleLinkedListNode<T> node, DoubleLinkedListNode<T> newNode)
        {
            if (node?.NextNode != null)
            {
                InsertAfter(node.PrevNode, newNode);
            }
            else
            {
                InsertEnding(newNode);
            }
        }

        public void InsertBegining(DoubleLinkedListNode<T> newNode)
        {
            InsertAfter(LastNode, newNode);
        }

        public void InsertEnding(DoubleLinkedListNode<T> newNode)
        {
            if (LastNode == null)
            {
                newNode.NextNode = newNode;
                newNode.PrevNode = newNode;
            }
            else
            {
                InsertAfter(LastNode, newNode);
            }

            LastNode = newNode;
        }

        public void Remove(DoubleLinkedListNode<T> node)
        {
            if (node.NextNode == node)
            {
                LastNode = null;
            }
            else
            {
                node.NextNode.PrevNode = node.PrevNode;
                node.PrevNode.NextNode = node.NextNode;

                if (node == LastNode)
                {
                    LastNode = node.PrevNode;
                }
            }
        }

        public void Restore(DoubleLinkedListNode<T> node)
        {
            node.PrevNode.NextNode = node;
            node.NextNode.PrevNode = node;
        }
    }
}