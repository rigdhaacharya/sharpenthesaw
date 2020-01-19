namespace AllPathsToTarget
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http.Headers;

    /// <summary>
    /// LC 797: https://leetcode.com/problems/all-paths-from-source-to-target/
    /// Finds all paths from source to target using depth first search
    /// </summary>
    public class AllPathsBFS
    {
        /// <summary>
        /// Find all paths from source to target given a graph
        /// </summary>
        /// <param name="graph">Graph represented by adjacency list</param>
        /// <returns></returns>
        public static IList<IList<int>> AllPathsSourceTarget(int[][] graph)
        {
            //validate inputs
            if (graph == null)
            {
                throw new ArgumentNullException(nameof(graph));
            }
            var graphLength = graph.Length;

            //problem definition says source is always 0 and target is always n-1
            var source = 0;
            var target = graphLength - 1;

            return FindAllPaths(source, target, graph);
        }

        /// <summary>
        /// Find all paths from given source to target recursively
        /// </summary>
        /// <param name="source">The current source</param>
        /// <param name="target">The target</param>
        /// <param name="graph">Graph</param>
        /// <param name="sourceList">Chain for the current node</param>
        /// <returns></returns>
        private static IList<IList<int>> FindAllPaths(int source, int target, int[][] graph)
        {
            //validate inputs
            if (graph == null)
            {
                throw new ArgumentNullException(nameof(graph));
            }

            if (source == target)
            {
                return new List<IList<int>>() { new List<int>() { 0, 0 } };
            }
            //get all connections from current node
            Queue<Tuple<int, List<int>>> nodeQueue = new Queue<Tuple<int, List<int>>>();

            var connections = graph[source];

            foreach (var connection in connections)
            {
                nodeQueue.Enqueue(new Tuple<int, List<int>>(connection, new List<int>() { source }));

            }
            //list will contain all paths to target from current node
            var list = new List<IList<int>>();
            while (nodeQueue.Count > 0)
            {
                var connection = nodeQueue.Dequeue();

                //is this target?
                if (connection.Item1 == target)
                {
                    //if we found target, add all the sources that led to current node
                    var chain = new List<int>();
                    foreach (var i in connection.Item2)
                    {
                        if (!chain.Any() || chain.Last() != i)
                        {
                            chain.Add(i);
                        }
                    }
                    //if there's a direct connection between source and target, chain may not be fully initialized
                    if (chain.Last() != connection.Item1)
                    {
                        chain.Add(connection.Item1);
                    }
                    list.Add(chain);

                }
                else
                {
                    var sourceChain = connection.Item2;
                    sourceChain.Add(connection.Item1);
                    //if not, build a new source chain with everything so far and the current node

                    //add current node to queue for bfs
                    foreach (var connectedNode in graph[connection.Item1])
                    {
                        var localChain = new List<int>();
                        foreach (var i in sourceChain)
                        {
                            localChain.Add(i);
                        }

                        if (localChain.Last() != connectedNode)
                        {
                            localChain.Add(connectedNode);

                        }
                        nodeQueue.Enqueue(new Tuple<int, List<int>>(connectedNode, localChain));
                    }
                }
            }
            //finally return the list of paths from source to target
            return list;
        }
    }
}
