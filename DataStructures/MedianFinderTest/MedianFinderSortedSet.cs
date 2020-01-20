using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MedianFinderTest
{
    using MedianFinder;

    [TestClass]
    public class MedianFinderSortedSetTest
    {
        [TestMethod]
        public void FindMedian_Odd()
        {
            var obj = new MedianFinderSortedSet();
            obj.AddNum(1);
            obj.AddNum(3);
            obj.AddNum(2);
            double res = obj.FindMedian();
            Assert.AreEqual(2, res);
        }

        [TestMethod]
        public void FindMedian_Even()
        {
            var obj = new MedianFinderSortedSet();
            obj.AddNum(1);
            obj.AddNum(2);
            double res = obj.FindMedian();
            Assert.AreEqual(1.5, res);
        }
    }
}
