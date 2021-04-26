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
    static double GetDistance(decimal long1, decimal long2, decimal lat1, decimal lat2)
    {
        var x = (double)(long2 - long1) * (Math.Cos(Convert.ToDouble((lat1+lat2)/2)));
        var y = (double)(lat2 - lat1);
        return Math.Sqrt(x*x + y*y) * 6371;
    }

    static void Main(string[] args)
    {
        var LON = decimal.Parse(Console.ReadLine().Replace(',', '.'));
        var LAT = decimal.Parse(Console.ReadLine().Replace(',', '.'));
        Console.Error.WriteLine(LON + " "+ LAT);
        int N = int.Parse(Console.ReadLine());
        var closestDistance = double.MaxValue;
        var closestName = string.Empty;
        for (int i = 0; i < N; i++)
        {
            string DEFIB = Console.ReadLine();
            var parsed = DEFIB.Split(';');
            var dlong = decimal.Parse(parsed[4].Replace(',', '.'));
            var dlat = decimal.Parse(parsed[5].Replace(',', '.'));
            var dist = GetDistance(LON, dlong, LAT, dlat);
            if (dist < closestDistance){
                closestDistance = dist;
                closestName = parsed[1];
            }
        }

        // Write an answer using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        Console.WriteLine(closestName);
    }
}