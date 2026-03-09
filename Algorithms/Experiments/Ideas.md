
First non-repeating character index
Given a string s, return the index of the first character that appears exactly once. If none exist, return -1.
Examples: "leetcode" → 0, "aabb" → -1, "loveleetcode" → 2.

Valid parentheses
Given a string containing only ()[]{}, determine if it’s valid (properly opened/closed and nested). Return true/false.
Examples: "()[]{}" → true, "(]" → false, "{[]}" → true.

Longest substring without repeating characters (this one is sliding window)
Given a string s, return the length of the longest substring with all unique characters.
Examples: "abcabcbb" → 3, "bbbbb" → 1, "pwwkew" → 3.

Move zeros to end (stable)
Given an int array, move all 0s to the end while keeping the order of non-zero elements. Do it in-place.
Example: [0,1,0,3,12] → [1,3,12,0,0].

Maximum sum of a fixed-size window
Given an int array nums and an int k, return the maximum sum of any contiguous subarray of length k.
Example: [2,1,5,1,3,2], k=3 → 9 (from [5,1,3]). (Sliding window)

Run-length encode a string
Compress consecutive repeating characters into char + count.
Example: "aaabbc" → "a3b2c1". (Decide what to do with empty string.)

Count occurrences of each word
Given a sentence, return a map of word → count (case-insensitive, ignore punctuation optionally).
Example: "Hello, hello world!" → { hello: 2, world: 1 }.