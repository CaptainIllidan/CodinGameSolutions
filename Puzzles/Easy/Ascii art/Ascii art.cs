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
 public class Character
{
    public char Symbol { get; set; }
    public string[] Lines { get; set; }
}
 
class Solution
{
    static void Main(string[] args)
    {
        int width, height, alphabetLength;
        Dictionary<char, Character> alphabet;
        string expectedOutput;
        Init(out width, out height, out alphabetLength, out alphabet, out expectedOutput);
        ReadAlphabet(width, height, alphabetLength, alphabet);

        var output = new StringBuilder();
        for (int i = 0; i < height; i++)
        {
            for (int k = 0; k < expectedOutput.Length; k++)
            {
                var symbol = char.ToLower(expectedOutput[k]);
                if (alphabet.ContainsKey(symbol))
                {
                    output.Append(alphabet[symbol].Lines[i]);
                }
                else
                {
                    output.Append(alphabet['?'].Lines[i]);
                }
            }
            output.AppendLine();
        }

        // Write an answer using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        Console.WriteLine(output);
    }

    private static void ReadAlphabet(int width, int height, int alphabetLength, Dictionary<char, Character> alphabet)
    {
        for (int i = 0; i < height; i++)
        {
            string ROW = Console.ReadLine();
            for (int k = 0; k < alphabetLength - 1; k++)
            {
                alphabet[Convert.ToChar('a' + k)].Lines[i] = ROW.Substring(k * width, width);
            }
            alphabet[Convert.ToChar('?')].Lines[i] = ROW.Substring((alphabetLength-1) * width, width);
        }
    }

    private static void Init(out int width, out int height, out int alphabetLength, out Dictionary<char, Character> alphabet, out string expectedOutput)
    {
        width = int.Parse(Console.ReadLine());
        height = int.Parse(Console.ReadLine());
        expectedOutput = Console.ReadLine();
        alphabetLength = 'z' - 'a' + 2;
        alphabet = new Dictionary<char, Character>();
        for (int k = 0; k < alphabetLength - 1; k++)
        {
            alphabet.Add(Convert.ToChar('a' + k),
                new Character()
                {
                    Lines = new string[height]
                });
        }
        alphabet.Add(Convert.ToChar('?'),
                new Character()
                {
                    Lines = new string[height]
                });
    }
}