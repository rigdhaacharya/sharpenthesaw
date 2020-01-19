using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShortestPathTest
{
    [TestClass]
    public class ShortestPathVisitingAllNodesTest
    {
       
        [TestMethod]
        public void FindShortestPath_2()
        {
            int[][] graph = new[]
                {new int[] {1}, new int[] {0, 2, 4}, new int[] {1, 3, 4}, new int[] {2}, new int[] {1, 2}};
            var shortestPath = ShortestPathVisitingAllNodesBFS.ShortestPathLength(graph);
            Assert.AreEqual(shortestPath, 4);

        }

        [TestMethod]
        public void FindShortestPath_1()
        {
            int[][] graph = new[]
                {new int[] {1,2,3}, new int[] {0}, new int[] {0}, new int[] {0}};
            var shortestPath = ShortestPathVisitingAllNodesBFS.ShortestPathLength(graph);
            Assert.AreEqual(shortestPath, 4);

        }
    }
}
