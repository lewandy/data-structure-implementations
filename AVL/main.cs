using System;

class Program
{
    static void Main(string[] args)
    {
        var tree = new AVLTree();
        tree.Add(4);
        tree.Add(2);
        tree.Add(8);
        tree.Add(6);
        tree.Add(12);
        tree.Add(10);
        tree.DisplayTree();
    }
}