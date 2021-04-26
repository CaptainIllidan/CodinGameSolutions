using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * The while loop represents the game.
 * Each iteration represents a turn of the game
 * where you are given inputs (the heights of the mountains)
 * and where you have to print an output (the index of the mountain to fire on)
 * The inputs you are given are automatically updated according to your last actions.
 **/
class Player
{
    static void Main(string[] args)
    {

        // game loop
        while (true)
        {
            int maxValue = int.MinValue;
            int maxValueIndex = -1;
            
            for (int i = 0; i < 8; i++)
            {
                var curHeigth = int.Parse(Console.ReadLine());
                if (curHeigth > maxValue)
                {
                    maxValue = curHeigth;
                    maxValueIndex = i;
                }
            }

            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");

            Console.WriteLine(maxValueIndex); // The index of the mountain to fire on.

            maxValue = int.MinValue;
            maxValueIndex = -1;
        }
    }
}