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
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        string[] inputs = Console.ReadLine().Split(' ');
        var values = new List<int>(n);
        var maxLoss = 0;
        for (int i = 0; i < n; i++)
        {
            values.Add(int.Parse(inputs[i]));
        }
        var curMax = int.MinValue;
        for (int i = 0; i<values.Count; i++)
        {
            var curValue = values[i];
            if (curValue > curMax)
                curMax=curValue;
            var diff = curValue - curMax; 
            if (diff < maxLoss)
                maxLoss= diff; 
        }


        // Write an answer using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        Console.WriteLine(maxLoss);
    }
}