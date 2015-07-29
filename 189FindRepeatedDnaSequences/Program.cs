using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _189FindRepeatedDnaSequences {
    class Program {
        static void Main(string[] args) {
            var result = (new Solution()).FindRepeatedDnaSequences("AAAAAAAAAAA");
        }
    }

    public class Solution {

        Dictionary<char, int> intMapping = new Dictionary<char, int>();
        Dictionary<int, char> charMapping = new Dictionary<int, char>();

        public Solution() {
            intMapping.Add('A', 0);
            intMapping.Add('C', 1);
            intMapping.Add('G', 2);
            intMapping.Add('T', 3);

            foreach(var pair in intMapping) {
                charMapping.Add(pair.Value, pair.Key);
            }
        }

        public IList<string> FindRepeatedDnaSequences(string s) {
            Dictionary<int, int> list = new Dictionary<int, int>();

            for (int i = 0; i <= s.Length - 10; i++) {
                string str = s.Substring(i, 10);
                int num = ToInt(str); // TODO: this part we can improve, because each time we move 1 digit to left and add new one in the end.
                list[num] = list.ContainsKey(num) ? list[num] + 1 : 1;
            }

            return list.Where(pair => pair.Value > 1).Select(pair => ToString(pair.Key)).ToList();
        }

        public int ToInt(string str) {
            
            int result = 1;
            
            foreach(var c in str) {
                result = (result << 2) + intMapping[c]; // move 2 bits every time
            }

            return result;
        }

        public string ToString(int num) {
            string result = string.Empty;

            while(num != 1) {
                result = charMapping[num % 4].ToString() + result;
                num = num / 4;
            }

            return result;
        }
    }

}