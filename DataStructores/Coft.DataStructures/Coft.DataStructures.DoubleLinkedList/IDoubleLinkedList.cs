using System;
using System.Collections.Generic;
using System.Text;

namespace Coft.DataStructures.DoubleLinkedList
{
    public interface IDoubleLinkedList<T> where T : class
    {
        void InsertAfter(DoubleLinkedListNode<T> node, DoubleLinkedListNode<T> newNode);

        void InsertBefore(DoubleLinkedListNode<T> node, DoubleLinkedListNode<T> newNode);

        void InsertBegining(DoubleLinkedListNode<T> newNode);

        void InsertEnding(DoubleLinkedListNode<T> newNode);

        void Remove(DoubleLinkedListNode<T> node);

        void Restore(DoubleLinkedListNode<T> node);
    }
}