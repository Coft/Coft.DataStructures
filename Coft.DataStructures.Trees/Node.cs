using System;
using System.Collections.Generic;
using System.Text;

namespace Coft.DataStructures.Trees
{
    public class Node<T>
    {
        public decimal Value { get; set; }
        public T Element { get; set; }

        public Node<T> LeftNode { get; set; }
        public Node<T> RightNode { get; set; }
        public Node<T> Parent { get; set; }

        public bool HasBothChildren => HasLeftChild && HasRightChild;
        public bool HasParent => Parent != null;
        public bool HasChildren => LeftNode != null || RightNode != null;
        public bool HasLeftChild => LeftNode != null;
        public bool HasRightChild => RightNode != null;
    }
}