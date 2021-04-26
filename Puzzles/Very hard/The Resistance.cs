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
    readonly static string[] Alphabet = 
    {
        ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....",
        "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.",
        "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-",
        "-.--", "--.."
    };

    static string Morse(string s)
    {
        var res = "";
        for (var i =0; i< s.Length; i++){
            res+=Alphabet[(int)s[i] - 65];
        }
        return res;
    }

    static long Solve(int start,string str, List<string> words, IDictionary<int, long> dp) 
    {
        if (start == str.Length)
            return 1;

        if (dp.ContainsKey(start))
            return dp[start];

        var res = 0l;

        for (var i = 0; i < words.Count; i++) {
            if (words[i].Length+start>str.Length)
                continue;
            if (str.Substring(start, words[i].Length) == words[i])
            {
                res+= Solve(start + words[i].Length, str, words, dp);
            }
        }
        return dp[start] = res;
}

    static void Main(string[] args)
    {
        string L = Console.ReadLine();
        int N = int.Parse(Console.ReadLine());
        var words = new List<string>();
        for (long i = 0; i < N; i++)
        {
            words.Add(Morse(Console.ReadLine()));
        }

        Console.WriteLine(Solve(0,L, words, new Dictionary<int, long>()));
    }
}