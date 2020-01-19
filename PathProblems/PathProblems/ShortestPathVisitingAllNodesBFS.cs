using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

/*
 https://leetcode.com/problems/shortest-path-visiting-all-nodes/
 An undirected, connected graph of N nodes (labeled 0, 1, 2, ..., N-1) is given as graph.

graph.length = N, and j != i is in the list graph[i] exactly once, if and only if nodes i and j are connected.

Return the length of the shortest path that visits every node. You may start and stop at any node, you may revisit nodes multiple times, and you may reuse edges.
 */
public class ShortestPathVisitingAllNodesBFS
{
    /// <summary>
    /// Returns the shortest path visiting all nodes
    /// </summary>
    /// <param name="graph">The graph</param>
    /// <returns>Length of the shortest path visiting all nodes</returns>
    public static int ShortestPathLength(int[][] graph)
    {

        int n = graph.Length;
        //we'll do bfs, need queue to keep track of neighbors
        Queue<Node> queue = new Queue<Node>();
        //Dictionary of visited nodes
        Dictionary<Node, bool> visited = new Dictionary<Node, bool>(); ;

        for (int i = 0; i < n; i++)
        {
            var tmpChain = new List<int>(){i};
            //mark top level chain as visited
            visited.Add(new Node(tmpChain.GetHashCode(), i, new List<int>() {  }), true);
            //add all the nodes to the queue for processing since we can start anywhere
            queue.Enqueue(new Node(tmpChain.GetHashCode(), i, new List<int>() {  }));
        }

        while (queue.Count() != 0)
        {
            Node curr = queue.Dequeue();
            //are we done?
            if (curr.AllVisted(n))
            {
                return curr.Chain.Count - 1;
            }
            else
            {
                //what are this node's neighbors?
                int[] neighbors = graph[curr.Value];

                foreach (var v in neighbors)
                {
                    //calculate the chain's hashcode
                    var tmpChain = new List<int>();
                    tmpChain.AddRange(curr.Chain);
                    tmpChain.Add(v);
                    var bitMask = tmpChain.GetHashCode();
                    Node t = new Node(bitMask, v, curr.Chain);
                    if (!visited.ContainsKey(t))
                    {
                        //hasn't been visited, add to the list
                        queue.Enqueue(new Node(bitMask, v, curr.Chain));
                        visited.Add(t, true);
                    }
                }


            }
        }
        return -1;
    }
}

class Node
{
    public int HashCode { get; set; }
    public int Value { get; set; }
    public List<int> Parents { get; set; }
    public List<int> Chain { get; set; }

    public Node(int hashCode, int current, List<int> parents)
    {
        this.HashCode = hashCode;
        Value = current;
        Parents = parents;
        Chain = new List<int>();
        foreach (var parent in parents)
        {
            Chain.Add(parent);
        }

        Chain.Add(current);
    }

    public bool AllVisted(int n)
    {
        for (int i = 0; i < n; i++)
        {
            if (!Chain.Contains(i))
            {
                return false;
            }
        }

        return true;
    }
   
}