using System;
using System.Collections.Generic;
using System.Text;

namespace Coft.DataStructures.Trees
{
    public class EvaluatorNullException : Exception { };

    public class Tree<T>
    {
        private Node<T> root;

        public IElementEvaluator<T> Evaluator { get; set; }

        public void Insert(T element)
        {
            decimal value = Evaluator?.Evaluate(element) ?? throw new EvaluatorNullException();

            Node<T> newNode = new Node<T>() { Element = element, Value = value };

            if (root == null)
            {
                root = newNode;
            }
            else
            {
                var node = root;
                while (node != null)
                {
                    Node<T> nextNode;

                    if (node.Value > newNode.Value)
                    {
                        nextNode = node.LeftNode;
                        if (node.LeftNode == null)
                        {
                            newNode.Parent = node;
                            node.LeftNode = newNode;
                        }
                    }
                    else
                    {
                        nextNode = node.RightNode;
                        if (node.RightNode == null)
                        {
                            newNode.Parent = node;
                            node.RightNode = newNode;
                        }
                    }
                    node = nextNode;
                }
            }
        }

        public void Remove(T element)
        {
            var node = Find(element);
            if (node != null)
            {
                Remove(node);
            }
        }

        public void Remove(Node<T> nodeToRemove)
        {
            if (nodeToRemove == null)
            {
                throw new ArgumentNullException();
            }

            // Has none or one children, or it has two children but right node is the next in order (has no left child)
            if (!nodeToRemove.HasBothChildren ||
                (nodeToRemove.HasChildren && !nodeToRemove.RightNode.HasLeftChild))
            {
                Node<T> child = nodeToRemove.RightNode ?? nodeToRemove.LeftNode;
                Node<T> parent = null;

                if (nodeToRemove.HasParent)
                {
                    parent = nodeToRemove.Parent;

                    if (parent.LeftNode == nodeToRemove)
                    {
                        parent.LeftNode = child;
                    }
                    else
                    {
                        parent.RightNode = child;
                    }
                }
                else
                {
                    root = child;
                }

                if (child != null)
                {
                    child.Parent = parent;
                }
            }
            // Has both children and right node is not next in order
            else
            {
                Node<T> nextNode = FindNext(nodeToRemove.RightNode);

                nodeToRemove.Element = nextNode.Element;
                nodeToRemove.Value = nextNode.Value;

                Node<T> parent = nextNode.Parent;

                if (parent.LeftNode == nextNode)
                {
                    parent.LeftNode = nextNode.RightNode;
                }
                else
                {
                    parent.RightNode = nextNode.RightNode;
                }

                if (nextNode.HasRightChild)
                {
                    nextNode.RightNode.Parent = parent;
                }
            }
        }

        public Node<T> Find(Node<T> node)
        {
            return Find(node.Value);
        }

        public Node<T> Find(T element)
        {
            decimal value = Evaluator?.Evaluate(element) ?? throw new EvaluatorNullException();

            return Find(value);
        }

        public Node<T> Find(decimal value)
        {
            var node = root;
            while (node != null)
            {
                if (node.Value == value)
                {
                    return node;
                }
                else if (node.Value > value)
                {
                    node = node.LeftNode;
                }
                else
                {
                    node = node.RightNode;
                }
            }

            return default(Node<T>);
        }

        public Node<T> FindNext(T element)
        {
            Node<T> node = Find(element);

            return node != null ? FindNext(node) : default(Node<T>);
        }

        public Node<T> FindNext(Node<T> node)
        {
            Node<T> nextNode = node.LeftNode;
            while (nextNode.HasLeftChild)
            {
                nextNode = nextNode.LeftNode;
            }

            return nextNode;
        }
    }
}