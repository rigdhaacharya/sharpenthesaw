using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MergeSortedLinkedListTest
{
    using System.Collections.Generic;
    using MergeSortedLinkedList;

    [TestClass]
    public class MergeSortedLinkedListTest
    {
        [TestMethod]
        public void MergeSortedList()
        {
            var l1 = new MergeSortedLinkedList.ListNode(1);
            l1.Next = new MergeSortedLinkedList.ListNode(4);
            l1.Next.Next= new MergeSortedLinkedList.ListNode(5);

            var l2 = new MergeSortedLinkedList.ListNode(1);
            l2.Next=new MergeSortedLinkedList.ListNode(3);
            l2.Next.Next=new MergeSortedLinkedList.ListNode(4);

            var l3 = new MergeSortedLinkedList.ListNode(2);
            l3.Next= new MergeSortedLinkedList.ListNode(6);
            var lists = new List<MergeSortedLinkedList.ListNode>(){l1, l2, l3};

            var merger = new MergeSortedLinkedList();
            var result = merger.MergeKLists(lists.ToArray());

            Assert.AreEqual(1, result.Value);
            Assert.AreEqual(1, result.Next.Value);
            Assert.AreEqual(2, result.Next.Next.Value);
            Assert.AreEqual(3, result.Next.Next.Next.Value);
            Assert.AreEqual(4, result.Next.Next.Next.Next.Value);
            Assert.AreEqual(4, result.Next.Next.Next.Next.Next.Value);
            Assert.AreEqual(5, result.Next.Next.Next.Next.Next.Next.Value);
            Assert.AreEqual(6, result.Next.Next.Next.Next.Next.Next.Next.Value);

        }
    }
}
