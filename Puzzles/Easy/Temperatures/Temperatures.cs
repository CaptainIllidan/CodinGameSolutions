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
        int n = int.Parse(Console.ReadLine()); // the number of temperatures to analyse
        string[] inputs = Console.ReadLine().Split(' ');
        int closest = int.MaxValue;
        int absClosest = closest;
        for (int i = 0; i < n; i++)
        {
            int t = int.Parse(inputs[i]);// a temperature expressed as an integer ranging from -273 to 5526
            int absT = Math.Abs(t);
            if (absT < absClosest) 
            {
                absClosest = absT;
                closest = t;
            }
            else if (absT == absClosest && t > closest)
            {
                closest = t;   
            }
        }
        
        if (closest == int.MaxValue) closest = 0;

        // Write an answer using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        Console.WriteLine(closest);
    }
}