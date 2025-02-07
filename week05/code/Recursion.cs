using System;
using System.Collections.Generic;

public static class Recursion
{
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0) return 0;
        return (n * n) + SumSquaresRecursive(n - 1);
    }

    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        for (int i = 0; i < letters.Length; i++)
        {
            string remaining = letters.Remove(i, 1);
            PermutationsChoose(results, remaining, size, word + letters[i]);
        }
    }

    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        if (remember == null) remember = new Dictionary<int, decimal>();
        if (s == 0) return 0;
        if (s == 1) return 1;
        if (s == 2) return 2;
        if (s == 3) return 4;
        
        if (remember.ContainsKey(s)) return remember[s];
        
        decimal ways = CountWaysToClimb(s - 1, remember) + CountWaysToClimb(s - 2, remember) + CountWaysToClimb(s - 3, remember);
        remember[s] = ways;
        return ways;
    }

    public static void WildcardBinary(string pattern, List<string> results)
    {
        int index = pattern.IndexOf('*');
        if (index == -1)
        {
            results.Add(pattern);
            return;
        }
        
        WildcardBinary(pattern.Substring(0, index) + "0" + pattern.Substring(index + 1), results);
        WildcardBinary(pattern.Substring(0, index) + "1" + pattern.Substring(index + 1), results);
    }

    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        if (currPath == null)
            currPath = new List<ValueTuple<int, int>>();
        
        if (!maze.IsValidMove(x, y, currPath))
            return;
        
        currPath.Add((x, y));
        
        if (maze.IsEnd(x, y))
        {
            results.Add(string.Join(" -> ", currPath));
            return;
        }
        
        SolveMaze(results, maze, x + 1, y, new List<ValueTuple<int, int>>(currPath));
        SolveMaze(results, maze, x - 1, y, new List<ValueTuple<int, int>>(currPath));
        SolveMaze(results, maze, x, y + 1, new List<ValueTuple<int, int>>(currPath));
        SolveMaze(results, maze, x, y - 1, new List<ValueTuple<int, int>>(currPath));
    }
}
  
