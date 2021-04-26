using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;


public enum PointType
    {
        Land,
        Water
    }
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public PointType Type { get; set; }

        public Point(int x, int y, PointType type = PointType.Land)
        {
            X = x;
            Y = y;
            Type = type;
        }

        public override bool Equals(object obj)
        {
            var p = (Point)obj;
            return p.X == X && p.Y == Y;
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() * 427 + Y.GetHashCode();
        }
    }

    public class Map
    {
        public int Width { get; set; }
        public int Height { get; set; }
        private Point[,] points;

        public Map(int width, int height)
        {
            Width = width;
            Height = height;
            points = new Point[width, height];
        }

        public bool IsInMap(int x, int y)
        {
            return x >= 0 && x < Width && y >= 0 && y < Height;
        }

        public void Parse(string[] map)
        {
            for (int i = 0; i < Height; i++)
            {
                var str = map[i];
                for (int j = 0; j < Width; j++)
                {
                    points[j, i] = new Point(j, i, str[j] == '#' ? PointType.Land : PointType.Water);
                }
            }
        }

        public int GetSurfaceArea(int x, int y)
        {
            var visited = new HashSet<Point>();
            var count = 0;
            var queue = new Queue<Point>();
            queue.Enqueue(points[x, y]);

            while (queue.Count > 0)
            {
                var point = queue.Dequeue();
                if (visited.Contains(point))
                    continue;
                visited.Add(point);
                if (point.Type == PointType.Water)
                {
                    count++;
                    var nextPoint = new Point(point.X + 1, point.Y);
                    if (!visited.Contains(nextPoint) && IsInMap(nextPoint.X, nextPoint.Y) && points[nextPoint.X,nextPoint.Y].Type==PointType.Water)
                        queue.Enqueue(points[nextPoint.X,nextPoint.Y]);
                    nextPoint = new Point(point.X - 1, point.Y);
                    if (!visited.Contains(nextPoint) && IsInMap(nextPoint.X, nextPoint.Y) && points[nextPoint.X, nextPoint.Y].Type == PointType.Water)
                        queue.Enqueue(points[nextPoint.X, nextPoint.Y]);
                    nextPoint = new Point(point.X, point.Y+1);
                    if (!visited.Contains(nextPoint) && IsInMap(nextPoint.X, nextPoint.Y) && points[nextPoint.X, nextPoint.Y].Type == PointType.Water)
                        queue.Enqueue(points[nextPoint.X, nextPoint.Y]);
                    nextPoint = new Point(point.X, point.Y-1);
                    if (!visited.Contains(nextPoint) && IsInMap(nextPoint.X, nextPoint.Y) && points[nextPoint.X, nextPoint.Y].Type == PointType.Water)
                        queue.Enqueue(points[nextPoint.X, nextPoint.Y]);
                }
            }

            return count;
        }

    }


/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Solution
{
    static void Main(string[] args)
    {
        int L = int.Parse(Console.ReadLine());
            int H = int.Parse(Console.ReadLine());
            var map = new Map(L,H);
            var rows = new List<string>();
            for (int i = 0; i < H; i++)
            {
                rows.Add(Console.ReadLine());
            }
            map.Parse(rows.ToArray());

            int N = int.Parse(Console.ReadLine());
            var pointsToCheck = new List<Point>();
            for (int i = 0; i < N; i++)
            {
                string[] inputs = Console.ReadLine().Split(' ');
                int X = int.Parse(inputs[0]);
                int Y = int.Parse(inputs[1]);
                pointsToCheck.Add(new Point(X,Y));
            }
            for (int i = 0; i < N; i++)
            {

                // Write an answer using Console.WriteLine()
                // To debug: Console.Error.WriteLine("Debug messages...");
                var p = pointsToCheck[i];
                Console.WriteLine(map.GetSurfaceArea(p.X,p.Y));
            }
    }
}