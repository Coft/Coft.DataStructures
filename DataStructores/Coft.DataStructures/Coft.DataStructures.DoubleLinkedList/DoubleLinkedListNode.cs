using System;
using System.Collections.Generic;
using System.Text;

namespace Coft.DataStructures.DoubleLinkedList
{
    public class DoubleLinkedListNode<T> where T : class
    {
        public DoubleLinkedListNode<T> NextNode { get; set; }
        public DoubleLinkedListNode<T> PrevNode { get; set; }
        public T Data { get; set; }
    }
}