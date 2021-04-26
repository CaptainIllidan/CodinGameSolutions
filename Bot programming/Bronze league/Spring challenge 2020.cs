using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Markup;
using System.Dynamic;

/**
 * Grab the pellets as fast as you can!
 **/

class Point
{
    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X { get; set; }
    public int Y { get; set; }

    public override bool Equals(object obj)
    {
        var p = (Point)obj;
        return p.X == this.X && p.Y == this.Y;
    }

    public static bool operator ==(Point p1, Point p2)
    {
        return Equals(p1, p2);
    }

    public static bool operator !=(Point p1, Point p2)
    {
        return !Equals(p1, p2);
    }
}

class DFSPoint
{
    public DFSPoint(Point point, int depth, DFSPoint parent = null)
    {
        Point = point;
        Depth = depth;
        Parent = parent;
    }

    public Point Point { get; set; }
    public int Depth { get; set; }

    public DFSPoint Parent { get; set; }

    public DFSPoint GetFirstParent()
    {
        var parent = Parent;
        if (parent == null || parent.Depth <= 1) return this;
        while (parent.Depth > 1)
        {
            parent = parent.Parent;
        }
        Console.Error.WriteLine($"FirstParent at {parent.Point.X},{parent.Point.Y}");
        return parent;
    }
}

enum CellType
{
    Empty,
    Wall,
    SmallPellet,
    HugePellet,
    Pacman
}

class PacManPosition
{
    public PacManPosition(Point point, int pacmanId)
    {
        Point = point;
        PacmanId = pacmanId;
    }

    public Point Point { get; set; }
    public int PacmanId { get; set; }
}

class ToGoCell
{
    public ToGoCell(Point point, CellType cellType, bool needToUpdate = false)
    {
        Point = point;
        CellType = cellType;
        NeedToUpdate = needToUpdate;
    }

    public Point Point { get; set; }
    public CellType CellType { get; set; }

    public bool NeedToUpdate { get; set; }
}
class Map
{
    public Map(int width, int height)
    {
        Width = width;
        Height = height;
        values = new CellType[Width, Height];
        priority = new CellType[] { CellType.HugePellet, CellType.SmallPellet };
        PacmanPrevPositions = new Dictionary<int, Point>();
    }

    public int Width { get; set; }
    public int Height { get; set; }
    private CellType[,] values { get; set; }
    private CellType[] priority { get; set; }
    public Dictionary<int,Point> PacmanPrevPositions { get; set; }

    public void UpdateValue(int x, int y, CellType cell)
    {
        values[x, y] = cell;
    }

    public CellType GetCellAt(Point p)
    {
        return GetCellAt(p.X, p.Y);
    }

    public CellType GetCellAt(int x, int y)
    {
        if (x < 0 || x >= Width || y < 0 || y >= Height)
        {
            throw new ArgumentOutOfRangeException();
        }

        return values[x, y];
    }

    public ToGoCell WhereToGo(Point pacmanPosition)
    {

        var nextPosition = pacmanPosition;
        var pointToCheck = pacmanPosition;
        var maxDepth = 9;
        bool found = false;
        foreach (var curPriority in priority)
        {
            #region BFS
            //int depth = 0;
            //var stack = new Queue<DFSPoint>();
            //stack.Enqueue(new DFSPoint(pacmanPosition, depth));
            //var visitedPoints = new List<Point>();
            //if (found) break;
            //while (stack.Count != 0)
            //{
            //    var dfsPoint = stack.Dequeue();
            //    var pos = dfsPoint.Point;
            //    var cellValue = GetCellAt(pos.X, pos.Y);
            //    //Console.Error.WriteLine($"CellValue at {dfsPoint.Point.X},{dfsPoint.Point.Y}: {cellValue.ToString()}");
            //    if (cellValue == CellType.Wall || cellValue == CellType.Pacman) continue;
            //    if (cellValue == curPriority)
            //    {
            //        nextPosition = dfsPoint.GetFirstParent().Point;
            //        found = true;
            //        break;
            //    }
            //    visitedPoints.Add(dfsPoint.Point);

            //    for (var dy = -1; dy <= 1; dy++)
            //        for (var dx = -1; dx <= 1; dx++)
            //        {
            //            if (dx != 0 && dy != 0) continue;
            //            var nextPos = new Point(pos.X + dx, pos.Y + dy);
            //            if (nextPos.X < 0 || nextPos.X >= Width || nextPos.Y < 0 || nextPos.Y >= Height) continue;
            //            if (!visitedPoints.Any(p => p.X == nextPos.X && p.Y == nextPos.Y)
            //                && dfsPoint.Depth < maxDepth)
            //                stack.Enqueue(new DFSPoint(nextPos, depth + 1));
            //        }
            //}
            #endregion
            for (int radius = 1; radius <= maxDepth; radius++)
            {
                for (int y = -radius; y <= radius; y++)
                {
                    if (found) break;
                    for (int x = -radius; x <= radius; x++)
                    {
                        if (Math.Abs(x) != radius && Math.Abs(y) != radius)
                            continue;
                        pointToCheck = new Point(pacmanPosition.X + x, pacmanPosition.Y + y);
                        if (pointToCheck.X < 0 || pointToCheck.X >= Width || pointToCheck.Y < 0 || pointToCheck.Y >= Height)
                            continue;
                        if (GetCellAt(pointToCheck) == curPriority)
                        {
                            nextPosition = pointToCheck;
                            found = true;
                            break;
                        }
                    }
                }
            }
        }

        var prevCellValue = GetCellAt(nextPosition);
        return new ToGoCell(nextPosition, prevCellValue);
    }
}

class Player
{
    static void Main(string[] args)
    {
        string[] inputs;
        inputs = Console.ReadLine().Split(' ');
        int width = int.Parse(inputs[0]); // size of the grid
        int height = int.Parse(inputs[1]); // top left corner is (x=0, y=0)
        var map = new Map(width, height);
        for (int y = 0; y < height; y++)
        {
            string row = Console.ReadLine(); // one line of the grid: space " " is floor, pound "#" is wall
            for (int x = 0; x < row.Length; x++)
            {
                var el = row.ElementAt(x);
                if (el == '#')
                {
                    map.UpdateValue(x, y, CellType.Wall);
                }
                else if (el == ' ')
                {
                    map.UpdateValue(x, y, CellType.Empty);
                }
            }
        }

        // game loop
        while (true)
        {
            inputs = Console.ReadLine().Split(' ');
            bool isWait = true;
            int myScore = int.Parse(inputs[0]);
            int opponentScore = int.Parse(inputs[1]);
            int visiblePacCount = int.Parse(Console.ReadLine()); // all your pacs and enemy pacs in sight
            var myPacmansPositions = new List<PacManPosition>();
            for (int i = 0; i < visiblePacCount; i++)
            {
                inputs = Console.ReadLine().Split(' ');
                int pacId = int.Parse(inputs[0]); // pac number (unique within a team)
                bool mine = inputs[1] != "0"; // true if this pac is yours
                int x = int.Parse(inputs[2]); // position in the grid
                int y = int.Parse(inputs[3]); // position in the grid
                if (mine)
                {
                    myPacmansPositions.Add(new PacManPosition(new Point(x, y), pacId));
                }
                //pacman eat pellet
                map.UpdateValue(x, y, CellType.Empty);
                string typeId = inputs[4]; // unused in wood leagues
                int speedTurnsLeft = int.Parse(inputs[5]); // unused in wood leagues
                int abilityCooldown = int.Parse(inputs[6]); // unused in wood leagues
            }
            int visiblePelletCount = int.Parse(Console.ReadLine()); // all pellets in sight
            for (int i = 0; i < visiblePelletCount; i++)
            {
                inputs = Console.ReadLine().Split(' ');
                int x = int.Parse(inputs[0]);
                int y = int.Parse(inputs[1]);
                int value = int.Parse(inputs[2]); // amount of points this pellet is worth
                if (value == 1)
                {
                    map.UpdateValue(x, y, CellType.SmallPellet);
                }
                else if (value == 10)
                {
                    map.UpdateValue(x, y, CellType.HugePellet);
                }
            }
            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");
            var output = new StringBuilder();
            var pacmansTogoPositions = new List<ToGoCell>();
            foreach (var pacman in myPacmansPositions)
            {
                var togoPosition = map.WhereToGo(pacman.Point);
                if (map.PacmanPrevPositions.ContainsKey(pacman.PacmanId) && map.PacmanPrevPositions[pacman.PacmanId] == togoPosition.Point)
                {
                    if (isWait) togoPosition.Point = map.PacmanPrevPositions[pacman.PacmanId];
                    isWait = !isWait;
                    pacmansTogoPositions.Add(new ToGoCell(togoPosition.Point, togoPosition.CellType));
                }
                else
                    pacmansTogoPositions.Add(new ToGoCell(togoPosition.Point, togoPosition.CellType, true));
                map.PacmanPrevPositions[pacman.PacmanId] = pacman.Point;
                output.Append($"MOVE {pacman.PacmanId} {togoPosition.Point.X} {togoPosition.Point.Y}|"); // MOVE <pacId> <x> <y>
            }
            pacmansTogoPositions.ForEach(p => { if (p.NeedToUpdate) map.UpdateValue(p.Point.X, p.Point.Y, p.CellType);});
            Console.WriteLine(output.ToString().Trim('|'));
        }
    }
}