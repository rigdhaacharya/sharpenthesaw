using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordSearchProblemTest
{
    using WordSearchProblem;

    [TestClass]
    public class WordSearchBFSTest
    {
        [TestMethod]
        public void TestMethod_MultipleWords()
        {
            string[] validWords = new[] {"oath", "pea", "eat", "rain"};
            char[][] grid = new[]
            {
                new []{'o', 'a', 'a', 'n'}, new []{'e', 't', 'a', 'e'},
                new []{'i', 'h', 'k','r'}, new []{'i','f','l','v'}
            };
            var bfs = new WordSearchBFS();
            var foundWords = bfs.FindWords(grid, validWords);
            Assert.AreEqual(2, foundWords.Count);
            Assert.IsTrue(foundWords.Contains("oath"));
            Assert.IsTrue(foundWords.Contains("eat"));

        }

        [TestMethod]
        public void TestMethod_SingleWord()
        {
            string[] validWords = new[] { "a" };
            char[][] grid = new[]
            {
                new []{'a'}
            };
            var bfs = new WordSearchBFS();
            var foundWords = bfs.FindWords(grid, validWords);
            Assert.AreEqual(1, foundWords.Count);
            Assert.IsTrue(foundWords.Contains("a"));

        }

        [TestMethod]
        public void TestMethod_NoPossibleWord()
        {
            string[] validWords = new[] { "ab" };
            char[][] grid = new[]
            {
                new []{'a'}
            };
            var bfs = new WordSearchBFS();
            var foundWords = bfs.FindWords(grid, validWords);
            Assert.AreEqual(0, foundWords.Count);

        }

        [TestMethod]
        public void TestMethod_NoPossibleWord2()
        {
            string[] validWords = new[] { "aaa" };
            char[][] grid = new[]
            {
                new []{'a', 'a'}
            };
            var bfs = new WordSearchBFS();
            var foundWords = bfs.FindWords(grid, validWords);
            Assert.AreEqual(0, foundWords.Count);

        }
    }
}
