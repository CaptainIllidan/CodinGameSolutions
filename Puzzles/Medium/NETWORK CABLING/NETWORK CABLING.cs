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
    public class Point
    {
        public int X {get;set;}
        public int Y {get;set;}

        public Point(int x, int y)
        {
            X=x;
            Y=y;
        }
    }

    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        var houses = new List<Point>(N);
        for (int i = 0; i < N; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            int X = int.Parse(inputs[0]);
            int Y = int.Parse(inputs[1]);
            houses.Add(new Point(X,Y));
        }

        var ys = houses.Select(h=>h.Y).ToArray();
        Array.Sort(ys);
        var size = ys.Length;
        var mid = size / 2;
        var median = (size % 2 != 0) ? ys[mid] : (int)(((double)ys[mid] + ys[mid - 1]) / 2);

        var xCableLength = houses.Max(h=>h.X) - houses.Min(h=>h.X);
        var yCableLength =0l;
        for (int i = 0; i< houses.Count; i++)
        {
            yCableLength += Math.Abs(houses[i].Y - median); 
        }
        // Write an answer using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        Console.WriteLine(xCableLength + yCableLength);
    }
}