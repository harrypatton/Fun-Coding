using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseWordsInString {
    class Program {
        static void Main(string[] args) {
            var result = (new Solution()).ReverseWords("  ");
        }
    }

    public class Solution {
        public string ReverseWords(string s) {

            if (s == null || s.Length == 0) {
                return s;
            }

            char[] chars = s.ToCharArray();
            char[] result = new char[chars.Length];

            // reverse the whole string
            Reverse(chars, 0, chars.Length - 1);

            // reverse individual words
            int start = 0;
            int end = 0;
            int index = 0;

            while(true) { 
                // find start of word
                while(start < chars.Length && chars[start] == ' ') {
                    start++;
                }

                if (start == chars.Length) { // cannot find any more words
                    break;
                }

                // find end of word
                end = start;

                while(end + 1 < chars.Length && chars[end + 1] != ' ') {
                    end++;
                }

                // reverse current word
                Reverse(chars, start, end);

                // save to final string
                Array.Copy(chars, start, result, index, end - start + 1);
                index += end - start + 1;

                // check condition before adding a space.
                if (index < result.Length) {
                    result[index++] = ' ';
                }

                if (end + 1 == chars.Length) { // cannot find any more words                    
                    break;
                }

                start = end + 1;
            }

            int length = 0;

            // no result
            if (index == 0) {
                length = 0;
            }else {
                // update last index
                index = index - 1;
                if (result[index] == ' ') {
                    index--;
                }

                length = index + 1;
            }
            

            return new string(result, 0 /*startIndex*/, length);
        }

        public void Reverse(char[] array, int startIndex, int endIndex) {
            if (startIndex == endIndex) {
                return;
            }

            int middleIndex = (startIndex + endIndex - 1) / 2;

            for(int i = startIndex; i <= middleIndex; i++) {
                char temp = array[i];
                array[i] = array[endIndex + startIndex - i];
                array[endIndex + startIndex - i] = temp;
            }
        }
    }
}
