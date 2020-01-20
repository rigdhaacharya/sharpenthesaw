using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LongestPalindromeTest
{
    using LongestPalindrome;

    [TestClass]
    public class PalindromeTest
    {
        [TestMethod]
        public void FindPalindrome_Multiple()
        {
            var input = "babad";
            var helper = new Palindrome();
            var palindrome = helper.LongestPalindrome(input);
            Assert.AreEqual("bab", palindrome);
        }

        [TestMethod]
        public void FindPalindrome_Single()
        {
            var input = "cbbd";
            var helper = new Palindrome();
            var palindrome = helper.LongestPalindrome(input);
            Assert.AreEqual("bb", palindrome);
        }

        [TestMethod]
        public void FindPalindrome_3()
        {
            var input = "abcdbbfcba";
            var helper = new Palindrome();
            var palindrome = helper.LongestPalindrome(input);
            Assert.AreEqual("bb", palindrome);
        }
    }
}
