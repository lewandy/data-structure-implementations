using System;

public class AVLTree
{
    Node root;

    public AVLTree()
    { 
    }

    public void Add(int data)
    {
        Node newItem = new Node(data);
        if (root == null)
            root = newItem; 
        else
            root = RecursiveInsert(root, newItem);
    }

    private Node RecursiveInsert(Node current, Node n)
    {
        if (current == null)
        {
            current = n;
            return current;
        }
        else if (n.data < current.data)
        {
            current.left = RecursiveInsert(current.left, n);
            current = BalanceTree(current);
        }
        else if (n.data > current.data)
        {
            current.right = RecursiveInsert(current.right, n);
            current = BalanceTree(current);
        }

        return current;
    }

    private Node BalanceTree(Node current)
    {
        int b_factor = BalanceFactor(current);
        if (b_factor > 1)
        {
            if (BalanceFactor(current.left) > 0)
            {
                current = RotateLL(current);
            }
            else
            {
                current = RotateLR(current);
            }
        }
        else if (b_factor < -1)
        {
            if (BalanceFactor(current.right) > 0)
            {
                current = RotateRL(current);
            }
            else
            {
                current = RotateRR(current);
            }
        }

        return current;
    }

    public void Delete(int target)
    {
        root = Delete(root, target);
    }

    private Node Delete(Node current, int target)
    {
        Node parent;
        if (current == null)
          return null;
        else
        {
            if (target < current.data)
            {
                current.left = Delete(current.left, target);
                if (BalanceFactor(current) == -2)
                {
                    if (BalanceFactor(current.right) <= 0)
                        current = RotateRR(current);
                    else
                        current = RotateRL(current);
                }
            }
            
            else if (target > current.data)
            {
                current.right = Delete(current.right, target);
                if (BalanceFactor(current) == 2)
                {
                    if (BalanceFactor(current.left) >= 0)
                        current = RotateLL(current);
                    else
                        current = RotateLR(current);
                }
            }
            else
            {
                if (current.right != null)
                {
                    parent = current.right;
                    while (parent.left != null)
                    {
                        parent = parent.left;
                    }
                    current.data = parent.data;
                    current.right = Delete(current.right, parent.data);

                    if (BalanceFactor(current) == 2)
                    {
                        if (BalanceFactor(current.left) >= 0)
                            current = RotateLL(current);
                        else
                          current = RotateLR(current);
                    }
                }
                else
                    return current.left;
            }
        }

        return current;
    }
    public void Find(int key)
    {
        if (Find(key, root).data == key)
            Console.WriteLine($"{key} was found!");
        else
            Console.WriteLine("Nothing found!");
    }

    private Node Find(int target, Node current)
    {
            if (target < current.data)
            {
                if (target == current.data)
                  return current;
                else
                  return Find(target, current.left);
            }
            else
            {
                if (target == current.data)
                  return current;
                else
                  return Find(target, current.right);
            }
            
    }
    public void DisplayTree()
    {
        if (root == null)
        {
            Console.WriteLine("Tree is empty");
            return;
        }

        InOrderDisplayTree(root);
        Console.WriteLine();
    }
    private void InOrderDisplayTree(Node current)
    {
        if (current != null)
        {
            InOrderDisplayTree(current.left);
            Console.Write("({0}) ", current.data);
            InOrderDisplayTree(current.right);
        }
    }
    
    private int max(int l, int r)
    {
        return l > r ? l : r;
    }

    private int getHeight(Node current)
    {
        int height = 0;
        if (current != null)
        {
            int l = getHeight(current.left);
            int r = getHeight(current.right);
            int m = max(l, r);
            height = m + 1;
        }
        return height;
    }

    private int BalanceFactor(Node current)
    {
        int l = getHeight(current.left);
        int r = getHeight(current.right);
        int b_factor = l - r;
        return b_factor;
    }

    private Node RotateRR(Node parent)
    {
        var pivot = parent.right;
        parent.right = pivot.left;
        pivot.left = parent;
        return pivot;
    }

    private Node RotateLL(Node parent)
    {
        var pivot = parent.left;
        parent.left = pivot.right;
        pivot.right = parent;
        return pivot;
    }

    private Node RotateLR(Node parent)
    {
        var pivot = parent.left;
        parent.left = RotateRR(pivot);
        return RotateLL(parent);
    }

    private Node RotateRL(Node parent)
    {
        var pivot = parent.right;
        parent.right = RotateLL(pivot);
        return RotateRR(parent);
    }
}