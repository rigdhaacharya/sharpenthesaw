using System;

namespace LongestPalindrome
{
    public class Palindrome
    {
        public string LongestPalindrome(string s)
        {
            if (s.Length < 2)
            {
                return s;
            }
            var len = s.Length;
            var longestPalindrome = s[0].ToString();
            for (int i = 0; i < s.Length; i++)
            {
                if (longestPalindrome.Length == s.Length) return longestPalindrome;
                //find palindromes starting with s[i]
                for (int j = i + 1; j < s.Length; j++)
                {
                    if (IsPalindrome(s, i, j))
                    {
                        if (s.Substring(i, j-i+1).Length > longestPalindrome.Length)
                        {
                            longestPalindrome = s.Substring(i, j-i+1);
                        }
                    }
                }
            }

            return longestPalindrome;
        }

        private bool IsPalindrome(string s, int start, int end)
        {
            var len = s.Length;
            int i = start;
            int j = end;
            while (i <= end && j > 0)
            {
                if (s[i] != s[j])
                {
                    return false;
                }

                i++;
                j--;
            }

            return true;

        }
    }
}
