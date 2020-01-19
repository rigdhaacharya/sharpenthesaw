using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AllPathsToTargetTest
{
    using System.Collections.Generic;
    using System.Linq;
    using AllPathsToTarget;

    [TestClass]
    public class AllPathsBFSTest
    {
        [TestMethod]
        public void FindAllPaths()
        {
            int[][] graph = new[]
                {new int[] {1,2}, new int[] {3}, new int[] {3}, new int[] {}};
            var shortestPath = AllPathsBFS.AllPathsSourceTarget(graph);
            Assert.IsTrue(shortestPath.Count == 2);
            var first = shortestPath.First();
            Assert.IsTrue(first.Contains(0));
            Assert.IsTrue(first.Contains(1));
            Assert.IsTrue(first.Contains(3));

            var second = shortestPath.Last();
            Assert.IsTrue(second.Contains(0));
            Assert.IsTrue(second.Contains(2));
            Assert.IsTrue(second.Contains(3));


        }

        [TestMethod]
        public void FindAllPaths_2()
        {
            int[][] graph = new[]
                {new int[] {4,3,1}, new int[] {3,2,4}, new int[] {3}, new int[] {4}, new int[]{} };
            var shortestPath = AllPathsBFS.AllPathsSourceTarget(graph);
            Assert.IsTrue(shortestPath.Count == 5);
            var first = shortestPath.First();
            Assert.IsTrue(first.Contains(0));
            Assert.IsTrue(first.Contains(4));

            var second = shortestPath[1];
            Assert.IsTrue(second.Contains(0));
            Assert.IsTrue(second.Contains(3));
            Assert.IsTrue(second.Contains(4));


        }
    }
}
