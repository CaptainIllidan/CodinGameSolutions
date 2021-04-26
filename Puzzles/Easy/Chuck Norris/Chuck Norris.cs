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
public static byte[] ConvertToByteArray(string str, Encoding encoding)
{
    return encoding.GetBytes(str);
}

public static String ToBinary(Byte[] data)
{
    return string.Join("", data.Select(byt => Convert.ToString(byt, 2).PadLeft(7, '0')));
}

    static void Main(string[] args)
    {
        string MESSAGE = ToBinary(ConvertToByteArray(Console.ReadLine(), Encoding.ASCII));
        Console.Error.WriteLine(MESSAGE);
        var output = new StringBuilder();

        while (MESSAGE.Length > 0){
            var firstDigit = MESSAGE[0];
            var subs = string.Empty;
            var anotherBitIndex = -1;
            if (firstDigit == '0')
            {
                anotherBitIndex = MESSAGE.IndexOf('1');
                if (anotherBitIndex < 0)
                    anotherBitIndex = MESSAGE.Length;
                output.Append("00 "+new string('0',anotherBitIndex)+" ");
            }
            else
            {
                anotherBitIndex = MESSAGE.IndexOf('0');
                if (anotherBitIndex < 0)
                    anotherBitIndex = MESSAGE.Length;
                output.Append("0 "+new string('0',anotherBitIndex)+" ");
            }
            MESSAGE = MESSAGE.Substring(anotherBitIndex);
        }
        // Write an answer using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        Console.WriteLine(output.ToString().TrimEnd(' '));
    }
}