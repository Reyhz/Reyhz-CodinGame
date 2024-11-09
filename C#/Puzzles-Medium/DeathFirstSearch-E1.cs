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
    public class Node
    {
        public Node(int cur, Node prev)
        {
            pos = cur;
            previous = prev;
        }
        
        public int pos;
        public Node previous;
    }

    static string BFS(int start, List<int> gateway, Dictionary<int, List<int>> graph){
        List<int> visited = new List<int>();

        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(new Node(start, null));
        
        while(queue.Count > 0){
            var node = queue.Dequeue();
            // Found gateway, we backtrack to severe link
            if(gateway.Contains(node.pos)){
                while( node.previous != null && node.previous.previous != null) node = node.previous;
                graph[node.previous.pos].Remove(node.pos);
                graph[node.pos].Remove(node.previous.pos);
                return $"{node.pos} {node.previous.pos}";
            }

            if(!visited.Contains(node.pos)){
                visited.Add(node.pos);
                foreach(var neighbor in graph[node.pos]){
                    queue.Enqueue(new Node(neighbor, node));
                }
            }
        }
        return "0 0";
    }

    static void Main(string[] args)
    {
        Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();
        List<int> gateways = new List<int>();
        
        string[] inputs;
        inputs = Console.ReadLine().Split(' ');
        int N = int.Parse(inputs[0]); // the total number of nodes in the level, including the gateways
        int L = int.Parse(inputs[1]); // the number of links
        int E = int.Parse(inputs[2]); // the number of exit gateways
        for (int i = 0; i < L; i++)
        {
            inputs = Console.ReadLine().Split(' ');
            int N1 = int.Parse(inputs[0]); // N1 and N2 defines a link between these nodes
            int N2 = int.Parse(inputs[1]);

            if(!map.ContainsKey(N1)){
                map.Add(N1, new List<int>());
            }
            map[N1].Add(N2);

            if(!map.ContainsKey(N2)){
                map.Add(N2, new List<int>());
            }
            map[N2].Add(N1);
        }
        for (int i = 0; i < E; i++)
        {
            int EI = int.Parse(Console.ReadLine()); // the index of a gateway node
            gateways.Add(EI);
        }

        // game loop
        while (true)
        {
            int SI = int.Parse(Console.ReadLine()); // The index of the node on which the Bobnet agent is positioned this turn      
            // Example: 0 1 are the indices of the nodes you wish to sever the link between
            Console.WriteLine(BFS(SI,gateways,map));
        }
    }
}