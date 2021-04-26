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
class Player
{
    static void Main(string[] args)
    {
        string[] inputs;
        inputs = Console.ReadLine().Split(' ');
        int W = int.Parse(inputs[0]); // width of the building.
        int H = int.Parse(inputs[1]); // height of the building.
        int N = int.Parse(Console.ReadLine()); // maximum number of turns before game over.
        inputs = Console.ReadLine().Split(' ');
        int X0 = int.Parse(inputs[0]);
        int Y0 = int.Parse(inputs[1]);

        var bombFinder = new BombFinder(W, H);
        string firstBombDir = Console.ReadLine();
        var firstJump = bombFinder.Init(X0, Y0, firstBombDir);

        Console.WriteLine(firstJump);

        // game loop
        while (true)
        {
            string bombDir = Console.ReadLine(); // the direction of the bombs from batman's current location (U, UR, R, DR, D, DL, L or UL)


            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");
            var direction = bombFinder.GetBombDirection(bombDir);
            bombFinder.UpdateMap(direction.Item1, direction.Item2);

            // the location of the next window Batman should jump to.
            Console.WriteLine(bombFinder.CalculateNextJumpPosition());
        }
    }

    public class BombFinder
    {
        private Point UpperLeft { get; set; }
        private Point LowerRigth { get; set; }
        private Point BatmanPosition { get; set; }

        public BombFinder(int width, int height)
        {
            UpperLeft = new Point(0, 0);
            LowerRigth = new Point(width-1, height-1);
        }

        /// <summary>
        /// Возвращает первый прыжок
        /// </summary>
        /// <param name="batmanX"></param>
        /// <param name="batmanY"></param>
        /// <param name="dir"></param>
        /// <returns></returns>
        public string Init(int batmanX, int batmanY, string dir)
        {
                        BatmanPosition = new Point(batmanX, batmanY);
            var direction = GetBombDirection(dir);
            //instead UpdateMap at first time
            switch (direction.Item1)
            {
                case XDirection.None:
                    UpperLeft.X = BatmanPosition.X;
                    LowerRigth.X = BatmanPosition.X;
                    break;
                case XDirection.Left:
                    LowerRigth.X = BatmanPosition.X - 1;
                    break;
                case XDirection.Right:
                    UpperLeft.X = BatmanPosition.X + 1;
                    break;
            }

            switch (direction.Item2)
            {
                case YDirection.None:
                    UpperLeft.Y = BatmanPosition.Y;
                    LowerRigth.Y = BatmanPosition.Y;
                    break;
                case YDirection.Up:
                    LowerRigth.Y = BatmanPosition.Y - 1;
                    break;
                case YDirection.Down:
                    UpperLeft.Y = BatmanPosition.Y + 1;
                    break;
            }

            return CalculateNextJumpPosition();
        }

        public string CalculateNextJumpPosition()
        {
            BatmanPosition.X = UpperLeft.X + (LowerRigth.X - UpperLeft.X) / 2;
            BatmanPosition.Y = UpperLeft.Y + (LowerRigth.Y - UpperLeft.Y) / 2;
            return $"{BatmanPosition.X} {BatmanPosition.Y}";
        }

        public (XDirection, YDirection) GetBombDirection(string dir)
        {
            var dirX = XDirection.None;
            if (dir.Contains("R")) dirX = XDirection.Right;
            else if (dir.Contains("L")) dirX = XDirection.Left;

            var dirY = YDirection.None;
            if (dir.Contains("D")) dirY = YDirection.Down;
            else if (dir.Contains("U")) dirY = YDirection.Up;
            return (dirX, dirY);
        }

        public void UpdateMap(XDirection dirX, YDirection dirY)
        {
            switch (dirX)
            {
                case XDirection.None:
                    LowerRigth.X = BatmanPosition.X;
                    UpperLeft.X = BatmanPosition.X;
                    break;
                case XDirection.Left:
                    LowerRigth.X = BatmanPosition.X - 1;
                    break;
                case XDirection.Right:
                    UpperLeft.X = BatmanPosition.X + 1;
                    break;
            }

            switch (dirY)
            {
                case YDirection.None:
                    UpperLeft.Y = BatmanPosition.Y;
                    LowerRigth.Y = BatmanPosition.Y;
                    break;
                case YDirection.Up:
                    LowerRigth.Y = BatmanPosition.Y - 1;
                    break;
                case YDirection.Down:
                    UpperLeft.Y = BatmanPosition.Y + 1;
                    break;
            }
        }
    }

    public enum XDirection
    {
        None = 0,
        Left,
        Right
    }

    public enum YDirection
    {
        None = 0,
        Up,
        Down
    }

    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}