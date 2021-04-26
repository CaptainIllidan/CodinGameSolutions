using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Don't let the machines win. You are humanity's last hope...
 **/
class Player
{
    enum Cell
        {
            Empty,
            Node,
            VisitedNode
        }

        public static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine()); // the number of cells on the X axis
            int height = int.Parse(Console.ReadLine()); // the number of cells on the Y axis
            var map = new Cell[width, height]; 
            for (int i = 0; i < height; i++)
            {
                string line = Console.ReadLine(); // width characters, each either 0 or .
                for (int j = 0; j < line.Length; j++)
                {
                    if (line[j] == '0')
                        map[j, i] = Cell.Node;
                }
            }

            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");

            ProcessMap(map, width, height);
            // Three coordinates: a node, its right neighbor, its bottom neighbor
            //Console.WriteLine("0 0 1 0 0 1");
        }

        static void ProcessMap(Cell[,] map, int width, int height)
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (map[j, i] == Cell.Node)
                    {
                        var cellOutput = new StringBuilder();
                        cellOutput.Append($"{j} {i} ");
                        //right neighbor
                        var dx = 1;
                        bool isRightNeighborFound = false;
                        for (dx=1; j + dx < width; dx++)
                        {
                            if (map[j + dx, i] != Cell.Node)
                                continue;
                            isRightNeighborFound = true;
                            cellOutput.Append($"{j + dx} {i} ");
                            break;
                        }
                        if (!isRightNeighborFound)
                        {
                            cellOutput.Append("-1 -1 ");
                        }
                        //bottom neighbor
                        var dy = 1;
                        bool isBottomNeighborFound = false;
                        for (dy=1; i + dy < height; dy++)
                        {
                            if (map[j, i+dy] != Cell.Node)
                                continue;
                            isBottomNeighborFound = true;
                            cellOutput.Append($"{j} {i+dy} ");
                            break;
                        }
                        if (!isBottomNeighborFound)
                        {
                            cellOutput.Append("-1 -1 ");
                        }

                        map[j, i] = Cell.VisitedNode;

                        Console.WriteLine(cellOutput.ToString());
                    }
                }
            }
        }
}