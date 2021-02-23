using System;

namespace Treetraversal
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            var tree = new BinaryTree();

            tree.Root = new Node(100);
            
            // LEFT
            tree.Root.Left = new Node(50);
            tree.Root.Left.Right = new Node(75);
            tree.Root.Left.Right.Left = new Node(74);
            tree.Root.Left.Right.Left.Left = new Node(73);
            tree.Root.Left.Right.Right = new Node(76);
            
            // RIGHT
            tree.Root.Right = new Node(150);
            tree.Root.Right.Left = new Node(125);
            tree.Root.Right.Left.Left = new Node(124);
            tree.Root.Right.Left.Right = new Node(130);
            tree.Root.Right.Left.Right.Right = new Node(131);
            
            Console.WriteLine("Pre order Traversal: ");
            tree.TraversePreOrder(tree.Root);
            
            Console.WriteLine("\n In order Traversal: ");
            tree.TraverseInOrder(tree.Root);
            
            Console.ReadKey();
        }
    }
    
    public class BinaryTree
    {
        private Node _root;

        public Node Root
        {
            get
            {
                return _root;
            }
            set
            {
                _root = value;
            }
        }
        
        public BinaryTree()
        {
            _root = null;
        }
        
        public BinaryTree(int key)
        {
            _root = new Node(key);
        }

        public void TraverseInOrder(Node node)
        {
            if(node == null)
                return;
            
            TraverseInOrder(node.Left);
            Console.Write($" {node.Key}");
            TraverseInOrder(node.Right);
        }
        
        public void TraversePreOrder(Node node)
        {
            if(node == null)
                return;
            
            Console.Write($" {node.Key}");
            TraversePreOrder(node.Left);
            TraversePreOrder(node.Right);
        }        
    }
    
    public class Node
    {
        public int Key;
        public Node Right; 
        public Node Left;

        public Node(int key)
        {
            Key = key;
        }
    }
}