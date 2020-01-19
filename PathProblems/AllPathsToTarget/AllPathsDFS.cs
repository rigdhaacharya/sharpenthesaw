namespace AllPathsToTarget
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Finds all paths from source to target using depth first search
    /// </summary>
    public class AllPathsDFS
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
            
            return FindAllPaths(source, target, graph, new List<int>());
        }

        /// <summary>
        /// Find all paths from given source to target recursively
        /// </summary>
        /// <param name="source">The current source</param>
        /// <param name="target">The target</param>
        /// <param name="graph">Graph</param>
        /// <param name="sourceList">Chain for the current node</param>
        /// <returns></returns>
        private static IList<IList<int>> FindAllPaths(int source, int target, int[][] graph, List<int> sourceList)
        {
            //validate inputs
            if (graph == null)
            {
                throw new ArgumentNullException(nameof(graph));
            }
            if (sourceList == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (source == target)
            {
                return new List<IList<int>>() { new List<int>() { 0, 0 } };
            }
            //get all connections from current node
            var connections = graph[source];
            //list will contain all paths to target from current node
            var list = new List<IList<int>>();
            foreach (var connection in connections)
            {
                var sourceChain = new List<int>();
                //is this target?
                if (connection == target)
                {
                    //if we found target, add all the sources that led to current node
                    var chain = new List<int>();
                    foreach (var i in sourceList)
                    {
                        chain.Add(i);
                    }
                    //add the current source
                    chain.Add(source);
                    //add the connection
                    chain.Add(connection);
                    list.Add(chain);

                }
                else
                {
                    //if not, build a new source chain with everything so far and the current node
                    foreach (var i in sourceList)
                    {
                        sourceChain.Add(i);
                    }
                    sourceChain.Add(source);
                    //search from current node recursively
                    list.AddRange(FindAllPaths(connection, target, graph, sourceChain));

                }
            }
            //finally return the list of paths from source to target
            return list;
        }
    }
}
