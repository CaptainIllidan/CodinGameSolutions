using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Solution
{
        class Node
        {
            public Node LeftNode { get; set; }
            public Node RightNode { get; set; }
            public int Data { get; set; }
        }
        
        class BinaryTree
{
    public Node Root { get; set; }
    
    public int minDelta = Int32.MaxValue;
 
    public bool Add(int value)
    {
        Node before = null, after = this.Root;
 
        while (after != null)
        {
            before = after;
            if (value < after.Data) //Is new node in left tree? 
                  after = after.LeftNode; 
            else if (value > after.Data) //Is new node in right tree?
                after = after.RightNode;
            else
            {
                //Exist same value
                return false;
            }
        }
 
        Node newNode = new Node();
        newNode.Data = value;

        var upperValue = before?.Data ?? 0;
        minDelta = Math.Min(minDelta,Math.Abs(upperValue - value));
 
        if (this.Root == null)//Tree ise empty
            this.Root = newNode;
        else
        {
            if (value < before.Data)
                before.LeftNode = newNode;
            else
                before.RightNode = newNode;
        }
 
        return true;
    }
 
    public Node Find(int value)
    {
        return this.Find(value, this.Root);            
    }
 
    public void Remove(int value)
    {
        this.Root = Remove(this.Root, value);
    }
 
    private Node Remove(Node parent, int key)
    {
        if (parent == null) return parent;
 
        if (key < parent.Data) parent.LeftNode = Remove(parent.LeftNode, key); else if (key > parent.Data)
            parent.RightNode = Remove(parent.RightNode, key);
 
        // if value is same as parent's value, then this is the node to be deleted  
        else
        {
            // node with only one child or no child  
            if (parent.LeftNode == null)
                return parent.RightNode;
            else if (parent.RightNode == null)
                return parent.LeftNode;
 
            // node with two children: Get the inorder successor (smallest in the right subtree)  
            parent.Data = MinValue(parent.RightNode);
 
            // Delete the inorder successor  
            parent.RightNode = Remove(parent.RightNode, parent.Data);
        }
 
        return parent;
    }
 
    private int MinValue(Node node)
    {
        int minv = node.Data;
 
        while (node.LeftNode != null)
        {
            minv = node.LeftNode.Data;
            node = node.LeftNode;
        }
 
        return minv;
    }
 
    private Node Find(int value, Node parent)
    {
        if (parent != null)
        {
            if (value == parent.Data) return parent;
            if (value < parent.Data)
                return Find(value, parent.LeftNode);
            else
                return Find(value, parent.RightNode);
        }
 
        return null;
    }
 
    public int GetTreeDepth()
    {
        return this.GetTreeDepth(this.Root);
    }
 
    private int GetTreeDepth(Node parent)
    {
        return parent == null ? 0 : Math.Max(GetTreeDepth(parent.LeftNode), GetTreeDepth(parent.RightNode)) + 1;
    }
 
    public void TraversePreOrder(Node parent)
    {
        if (parent != null)
        {
            Console.Write(parent.Data + " ");
            TraversePreOrder(parent.LeftNode);
            TraversePreOrder(parent.RightNode);
        }
    }
 
    public void TraverseInOrder(Node parent)
    {
        if (parent != null)
        {
            TraverseInOrder(parent.LeftNode);
            Console.Write(parent.Data + " ");
            TraverseInOrder(parent.RightNode);
        }
    }
 
    public void TraversePostOrder(Node parent)
    {
        if (parent != null)
        {
            TraversePostOrder(parent.LeftNode);
            TraversePostOrder(parent.RightNode);
            Console.Write(parent.Data + " ");
        }
    }
}
        public static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
        
            var tree = new BinaryTree();
            var inputs = new int[N];
            for (int i = 0; i < N; i++)
            {
                int pi = int.Parse(Console.ReadLine());
                inputs[i]=pi;
                //tree.Add(pi);
            }
            Array.Sort(inputs);
            foreach (var i in inputs)
            {
                Console.Error.Write($"{i} ");
            }
            Console.Error.WriteLine();
            var minDelta = int.MaxValue;
            for (int i=0;i<inputs.Length-1;i++)
            {
                minDelta = Math.Min(minDelta, Math.Abs(inputs[i]-inputs[i+1]));
            }

                Console.WriteLine(minDelta);
        }
    }