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
        class Node
        {
            public int Index { get; set; }
            public List<Node> Children { get; set; } = new List<Node>();
            public bool IsGateway { get; set; }

            public Node(int index)
            {
                Index = index;
            }

            public void CreateLink(Node node, bool bidirect = true)
            {
                Children.Add(node);
                node.Children.Add(this);
            }
        }
        
        public static void Main(string[] args)
        {
            string[] inputs;
            inputs = Console.ReadLine().Split(' ');
            int N = int.Parse(inputs[0]); // the total number of nodes in the level, including the gateways
            int L = int.Parse(inputs[1]); // the number of links
            int E = int.Parse(inputs[2]); // the number of exit gateways
            var nodes = new Node[N];
            for (int i = 0; i < nodes.Length; i++)
            {
                nodes[i] = new Node(i);
            }
            for (int i = 0; i < L; i++)
            {
                inputs = Console.ReadLine().Split(' ');
                int N1 = int.Parse(inputs[0]); // N1 and N2 defines a link between these nodes
                int N2 = int.Parse(inputs[1]);
                nodes[N1].CreateLink(nodes[N2]);
            }
            for (int i = 0; i < E; i++)
            {
                int EI = int.Parse(Console.ReadLine()); // the index of a gateway node
                nodes[EI].IsGateway = true;
            }

            // game loop
            while (true)
            {
                int SI = int.Parse(Console.ReadLine()); // The index of the node on which the Skynet agent is positioned this turn

                var visited = new List<int>();
                var queue = new Queue<Node>();
                queue.Enqueue(nodes[SI]);
                while (queue.Count > 0)
                {
                    var next = queue.Dequeue();
                    if (visited.Contains(next.Index))
                        continue;
                    
                    visited.Add(next.Index);

                    foreach (var child in next.Children)
                    {
                        if (child.IsGateway)
                        {
                            Console.WriteLine(next.Index + " " + child.Index);
                            queue.Clear();
                            break;
                        }
                        if (!visited.Contains(child.Index))
                            queue.Enqueue(child);
                    }
                }
                // Write an action using Console.WriteLine()
                // To debug: Console.Error.WriteLine("Debug messages...");


                // Example: 0 1 are the indices of the nodes you wish to sever the link between
                //Console.WriteLine("0 1");
            }
        }
    }