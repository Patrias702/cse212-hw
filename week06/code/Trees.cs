using System;
using System.Collections.Generic;

public class Node
{
    public int Value;
    public Node Left;
    public Node Right;

    public Node(int value)
    {
        Value = value;
        Left = null;
        Right = null;
    }

    // Problem 1: Insert Unique Values Only
    public void Insert(int value)
    {
        if (value < this.Value)
        {
            if (Left == null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else if (value > this.Value) // Prevent duplicates by checking if value is equal
        {
            if (Right == null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    // Problem 2: Contains Function
    public bool Contains(int value)
    {
        if (value == this.Value)
            return true;
        else if (value < this.Value && Left != null)
            return Left.Contains(value);
        else if (value > this.Value && Right != null)
            return Right.Contains(value);

        return false;
    }

    // Problem 4: Get Tree Height
    public int GetHeight()
    {
        int leftHeight = Left != null ? Left.GetHeight() : 0;
        int rightHeight = Right != null ? Right.GetHeight() : 0;

        return 1 + Math.Max(leftHeight, rightHeight);
    }
}

public class BinarySearchTree
{
    private Node Root;

    public BinarySearchTree()
    {
        Root = null;
    }

    public void Insert(int value)
    {
        if (Root == null)
            Root = new Node(value);
        else
            Root.Insert(value);
    }

    public bool Contains(int value)
    {
        return Root != null && Root.Contains(value);
    }

    // Problem 3: Traverse Backwards
    public void TraverseBackward(Action<int> action)
    {
        TraverseBackwardHelper(Root, action);
    }

    private void TraverseBackwardHelper(Node node, Action<int> action)
    {
        if (node == null)
            return;

        if (node.Right != null)
            TraverseBackwardHelper(node.Right, action);

        action(node.Value);

        if (node.Left != null)
            TraverseBackwardHelper(node.Left, action);
    }

    public IEnumerable<int> Reversed()
    {
        var values = new List<int>();
        TraverseBackward(values.Add);
        return values;
    }

    public int GetHeight()
    {
        return Root != null ? Root.GetHeight() : 0;
    }
}

public static class Trees
{
    /// <summary>
    /// Given a sorted list (sorted_list), create a balanced BST.
    /// </summary>
    public static BinarySearchTree CreateTreeFromSortedList(int[] sortedNumbers)
    {
        var bst = new BinarySearchTree(); // Create an empty BST to start with 
        InsertMiddle(sortedNumbers, 0, sortedNumbers.Length - 1, bst);
        return bst;
    }

    /// <summary>
    /// This function inserts the middle element of a given sorted range into the BST recursively.
    /// </summary>
    private static void InsertMiddle(int[] sortedNumbers, int first, int last, BinarySearchTree bst)
    {
        if (first > last)
            return;

        int mid = (first + last) / 2;
        bst.Insert(sortedNumbers[mid]);

        InsertMiddle(sortedNumbers, first, mid - 1, bst); // Insert left subarray
        InsertMiddle(sortedNumbers, mid + 1, last, bst);  // Insert right subarray
    }
}

// Example Usage
class Program
{
    static void Main()
    {
        BinarySearchTree bst = new BinarySearchTree();

        // Insert values
        bst.Insert(50);
        bst.Insert(30);
        bst.Insert(70);
        bst.Insert(20);
        bst.Insert(40);
        bst.Insert(60);
        bst.Insert(80);
        bst.Insert(70); // Duplicate, should not be inserted

        Console.WriteLine("Contains 40: " + bst.Contains(40)); // True
        Console.WriteLine("Contains 90: " + bst.Contains(90)); // False

        Console.WriteLine("Tree Height: " + bst.GetHeight()); // Expected height

        Console.WriteLine("Reversed Order Traversal:");
        foreach (var value in bst.Reversed())
        {
            Console.WriteLine(value);
        }

        Console.WriteLine("Creating balanced BST from sorted list...");
        int[] sortedNumbers = { 10, 20, 30, 40, 50, 60, 70 };
        var balancedBst = Trees.CreateTreeFromSortedList(sortedNumbers);

        Console.WriteLine("Balanced BST Traversal:");
        foreach (var value in balancedBst.Reversed())
        {
            Console.WriteLine(value);
        }
    }
}
