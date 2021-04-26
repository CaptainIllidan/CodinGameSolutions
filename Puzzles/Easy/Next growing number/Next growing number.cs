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
        public static void Main(string[] args)
        {
            var initNumber = Console.ReadLine();
            if (initNumber.All(d => d == '9'))
                Console.WriteLine(new string('1', initNumber.Length+1));

            Console.Error.WriteLine($"n: {initNumber}");

            var growingIndex = -1;
            for (int i = 0; i < initNumber.Length - 1; i++)
            {
                if (initNumber[i] <= initNumber[i + 1])
                    growingIndex = i+1;
                else 
                    break;
            }
              
            for (int i = growingIndex; i >= 0; i--)
            {
                if (initNumber[i]=='9')
                    continue;
                var fillDigit = int.Parse(initNumber[i].ToString());
                if (initNumber[i] <= initNumber[i + 1])
                    fillDigit++;
                Console.WriteLine($"{initNumber.Substring(0,i)}{new string(fillDigit.ToString()[0],initNumber.Length-i)}");
                break;
            }
        }
}