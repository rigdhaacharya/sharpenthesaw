using System;

namespace MergeSortedLinkedList
{
    public class MergeSortedLinkedList
    {
        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists.Length == 0)
            {
                throw new Exception($"List must contain at least 1 linked list");
            }

            if (lists.Length == 1)
            {
                return lists[0];
            }

            ListNode resultList = lists[0];
            for (int i = 1; i < lists.Length; i++)
            {
                var listToMerge = lists[i];
                resultList = MergeKLists(resultList, listToMerge);
            }

            return resultList;
        }

        private ListNode MergeKLists(ListNode resultList, ListNode listToMerge)
        {
            if (resultList == null)
            {
                return listToMerge;
            }
            else if (listToMerge == null)
            {
                return resultList;
            }

            //keep track of head
            ListNode head = null;
            //keep track of prev
            ListNode prev = new ListNode(-1);

            //merging logic
            while (resultList != null && listToMerge != null)
            {
                if (resultList.Value < listToMerge.Value)
                {
                    if (head == null)
                    {
                        head = resultList;
                    }

                    prev.Next = resultList;

                    resultList = resultList.Next;
                }
                else
                {
                    if (head == null)
                    {
                        head = listToMerge;
                    }

                    prev.Next = listToMerge;


                    listToMerge = listToMerge.Next;
                }

                prev = prev.Next; //set prev to current
            }

            //we're done with merging, simply add the rest of any list remaining
            if (resultList != null)
            {
                prev.Next = resultList;
            }
            else if (listToMerge != null)
            {
                prev.Next = listToMerge;
            }



            return head;


        }

        public class ListNode
        {
            public int Value;
            public ListNode Next;

            public ListNode(int x)
            {
                Value = x;
            }
        }
    }
}
