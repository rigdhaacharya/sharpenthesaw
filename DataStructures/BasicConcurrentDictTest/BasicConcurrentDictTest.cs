using ConcurrentDictionary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BasicConcurrentDictTest
{
    using System.Threading.Tasks;

    [TestClass]
    public class BasicConcurrentDictTest
    {
        [TestMethod]
        public void BasicAdd()
        {
            var dict = new BasicConcurrentDict();
            dict.AddOrUpdate("r", 1);
            var value = dict.Get("r");
            Assert.AreEqual(1, value);
            dict.AddOrUpdate("o", 2);
            value = dict.Get("r");
            Assert.AreEqual(1, value);
            value = dict.Get("o");
            Assert.AreEqual(2, value);
        }

        [TestMethod]
        public void BasicUpdate()
        {
            var dict = new BasicConcurrentDict();
            dict.AddOrUpdate("r", 1);
            var value = dict.Get("r");
            Assert.AreEqual(1, value);
            dict.AddOrUpdate("r", 20);
            value = dict.Get("r");
            Assert.AreEqual(20, value);
        }


        [TestMethod]
        public void ConcurrentGet()
        {
            var dict = new BasicConcurrentDict();
            var numTasks = 128;
            dict.AddOrUpdate("r", 1);
            Parallel.For(0, numTasks, (index) =>
            {
                var value = dict.Get("r");
                Assert.AreEqual(1, value);
            });

        }

        [TestMethod]
        public void ConcurrentUpdate()
        {
            var dict = new BasicConcurrentDict();
            var numTasks = 128;
            dict.AddOrUpdate("r", 1);
            int lastThread = 0;
            Parallel.For(0, numTasks, (index) =>
            {
                dict.AddOrUpdate("r", index);
                lastThread = index;
            });
            var value = dict.Get("r");
            Assert.AreEqual(lastThread, value);

        }
    }
}
