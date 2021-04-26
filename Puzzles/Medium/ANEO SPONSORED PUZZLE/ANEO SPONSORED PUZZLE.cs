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
    static bool isRed(int speed, int dist, int dur)
    {
        return (18 * dist) % (10 * speed * dur) >= (5 * speed * dur);
    }

    static void Main(string[] args)
    {
        int speed = int.Parse(Console.ReadLine());
        int lightCount = int.Parse(Console.ReadLine());
        var lights = new int[lightCount, 2];
        for (int i = 0; i < lightCount; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            lights[i, 0] = int.Parse(inputs[0]);
            lights[i, 1] = int.Parse(inputs[1]);
        }

        for (var i = 0; i < lightCount; i++)
        {
            if (isRed(speed, lights[i, 0], lights[i, 1])) 
            {
				speed--; // Reduce speed
				= -1; // Start again
			}
    }


    // Write an answer using Console.WriteLine()
    // To debug: Console.Error.WriteLine("Debug messages...");

    Console.WriteLine(speed);
    }
}