using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AllPathsToTargetTest
{
    using System.Collections.Generic;
    using System.Linq;
    using AllPathsToTarget;

    [TestClass]
    public class AllPathsDFSTest
    {
        [TestMethod]
        public void FindAllPaths()
        {
            int[][] graph = new[]
                {new int[] {1,2}, new int[] {3}, new int[] {3}, new int[] {}};
            var shortestPath = AllPathsDFS.AllPathsSourceTarget(graph);
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
    }
}
