using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NumberOfIslandsTest
{
    using NumberOfIslands;

    [TestClass]
    public class NumberOfIslandsTest
    {
        [TestMethod]
        public void NumIslands_SingleIsland()
        {
            char[][] grid = new[]
            {
                new []{'1', '1', '1', '1', '0'}, new []{'1', '1', '0', '1', '0'},
                new []{'1', '1', '0','0','0'}, new []{'0','0','0','0','0'}
            };
            var bfs = new NumberOfIslandsBFS();
            Assert.AreEqual(1, bfs.NumIslands(grid));
        }

        [TestMethod]
        public void NumIslands_MultipleIsland()
        {
            char[][] grid = new[]
            {
                new []{'1', '1', '0', '0', '0'}, new []{'1', '1', '0', '0', '0'},
                new []{'0', '0', '1','0','0'}, new []{'0','0','0','1','1'}
            };
            var bfs = new NumberOfIslandsBFS();
            Assert.AreEqual(3, bfs.NumIslands(grid));
        }

        [TestMethod]
        public void NumIslands_LooseConnection()
        {
            char[][] grid = new[]
            {
                new []{'1', '1', '1'}, new []{'0', '1', '0'},
                new []{'1', '1', '1'}
            };
            var bfs = new NumberOfIslandsBFS();
            Assert.AreEqual(1, bfs.NumIslands(grid));
        }
    }
}
