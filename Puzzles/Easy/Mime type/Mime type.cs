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
    static void Main(string[] args)
            {
            var mimeTypesDict = new Dictionary<string, string>();
            int N = int.Parse(Console.ReadLine()); // Number of elements which make up the association table.
            int Q = int.Parse(Console.ReadLine()); // Number Q of file names to be analyzed.
            for (int i = 0; i < N; i++)
            {
                string[] inputs = Console.ReadLine().Split(' ');
                string EXT = inputs[0].ToLower(); // file extension
                string MT = inputs[1]; // MIME type.
                mimeTypesDict.Add(EXT, MT);
                Console.Error.WriteLine($"{EXT} : {MT}");
            }
            for (int i = 0; i < Q; i++)
            {
                string FNAME = Console.ReadLine().ToLower(); // One file name per line.
                int dotIndex = FNAME.LastIndexOf('.');
                if (dotIndex < 0)
                {
                    Console.WriteLine("UNKNOWN");  
                    continue;
                }
                var fileExtension = FNAME.Substring(dotIndex + 1);
                if (mimeTypesDict.ContainsKey(fileExtension))
                    Console.WriteLine(mimeTypesDict[fileExtension]);
                else
                    Console.WriteLine("UNKNOWN");                    
            }

            // Write an answer using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");


            // For each of the Q filenames, display on a line the corresponding MIME type. If there is no corresponding type, then display UNKNOWN.
            //Console.WriteLine("UNKNOWN");
        }
}