using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrefixTree {
    class Program {
        static void Main(string[] args) {
            Trie trie = new Trie();
            trie.Insert("somestring");
            trie.Search("key");
        }
    }

    class TrieNode {

        public List<TrieNode> Children { get; private set; }
        public char Value { get; private set; }
        public string Word { get; set; }

        // Initialize your data structure here.
        public TrieNode(char nodeValue, string wordValue) {
            this.Value = nodeValue;
            this.Word = wordValue;
            this.Children = new List<TrieNode>();
        }
    }

    public class Trie {
        private TrieNode root;

        public Trie() {
            root = new TrieNode(char.MinValue, null);
        }

        // Inserts a word into the trie.
        public void Insert(String word) {

            if (word == null || word.Length < 1) {
                return;
            }

            TrieNode node = root;
            foreach(var c in word) {
                var target = node.Children.FirstOrDefault(item => item.Value == c);

                if (target == null) {
                    target = new TrieNode(c, null);
                    node.Children.Add(target);
                }

                node = target;
            }

            node.Word = word;
        }

        // Returns if the word is in the trie.
        public bool Search(string word) {
            TrieNode node = root;
            foreach (var c in word) {
                var target = node.Children.FirstOrDefault(item => item.Value == c);

                if (target == null) {
                    return false;
                }

                node = target;
            }

            return node.Word == word;
        }

        // Returns if there is any word in the trie
        // that starts with the given prefix.
        public bool StartsWith(string word) {
            TrieNode node = root;
            foreach (var c in word) {
                var target = node.Children.FirstOrDefault(item => item.Value == c);

                if (target == null) {
                    return false;
                }

                node = target;
            }

            return true;
        }
    }

    // Your Trie object will be instantiated and called as such:
    // Trie trie = new Trie();
    // trie.Insert("somestring");
    // trie.Search("key");
}
