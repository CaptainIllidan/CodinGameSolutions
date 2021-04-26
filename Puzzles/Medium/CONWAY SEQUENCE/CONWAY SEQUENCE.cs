using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Solution
{
    static void Main(string[] args)
    {
        var regex = new Regex(@"(\d)\1\1");
        int R = int.Parse(Console.ReadLine());
        int L = int.Parse(Console.ReadLine());
        var prevLine = R.ToString();

        for (int i = 1; i<L; i++)
        {
            prevLine = GetNextLine(prevLine);
        }

        // Write an answer using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        Console.WriteLine(prevLine.Trim());
    }

    public static string GetNextLine(string line) 
    {
        var numbers = line.Contains(' ') 
            ? line.Split(' ').Select(l=>int.Parse(l)).ToList()
            : new List<int>{int.Parse(line)};
        var prevNum = numbers[0];
        var prevCharCount = 1;
        var sb = new StringBuilder();
        for (int i = 1; i< numbers.Count; i++)
        {
            if (numbers[i] != prevNum)
            {
                sb.Append(prevCharCount+" ");
                sb.Append(prevNum+" ");
                prevNum = numbers[i];
                prevCharCount = 1;
            }
            else
                prevCharCount++;
        }
        sb.Append(prevCharCount+" ");
        sb.Append(prevNum+" ");
        Console.Error.WriteLine(sb.ToString());

        return sb.ToString().Trim();
    }
}