using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRUCache {
    class Program {
        static void Main(string[] args) {

            LRUCache cache = new LRUCache(3);

            int result = cache.Get(10);

            cache.Set(1, 2);
            cache.Set(2, 4);
            cache.Set(3, 6);
            cache.Set(2, -1);
        }
    }

    public class LRUCache {

        private int index = 0;
        private int[] values;
        private Dictionary<int, int> keyIndexMapping;
        private Queue<int> recentUsedQ;
        private Dictionary<int, int> depriorityCount;

        public LRUCache(int capacity) {
            values = new int[capacity];
            keyIndexMapping = new Dictionary<int, int>();
            recentUsedQ = new Queue<int>();
            depriorityCount = new Dictionary<int, int>();
        }

        public int Get(int key) {
            if (keyIndexMapping.ContainsKey(key)) {
                // change priority
                depriorityCount[key] = depriorityCount.ContainsKey(key) ? depriorityCount[key] + 1 : 1;
                recentUsedQ.Enqueue(key);

                return values[keyIndexMapping[key]];
            }
            else {
                return -1;
            }
        }

        public void Set(int key, int value) {

            if (keyIndexMapping.ContainsKey(key)) { // update existing element.
                values[keyIndexMapping[key]] = value;

                // mark this one as deprecated.
                depriorityCount[key] = depriorityCount.ContainsKey(key) ? depriorityCount[key] + 1 : 1;
                
                // the following code is too slow and cause time out.

                //// remove it from priority queue.
                //// to remove an element from queue, I just re-add them (except the one) to the queue again
                //int markValue = recentUsedQ.Dequeue();

                //if (markValue == key) { // if first element is key, just remove it.
                //    // nothing, we already removed it.
                //}
                //else {
                //    recentUsedQ.Enqueue(markValue);
                //    while (recentUsedQ.Peek() != markValue) {
                //        int otherKey = recentUsedQ.Dequeue();
                //        if (otherKey != key) {
                //            recentUsedQ.Enqueue(otherKey);
                //        }
                //    }
                //}                
            }
            else { // insert new element.
                if (index < values.Length) { // space is still available
                    values[index] = value;
                    keyIndexMapping.Add(key, index);
                    index++;
                }
                else { // invalidate the least used one and replace it.
                    // dequeue from priority queue

                    // handle the deprecated one.
                    while (depriorityCount.ContainsKey(recentUsedQ.Peek())) {
                        int tempKey = recentUsedQ.Dequeue();
                        int count = depriorityCount[tempKey];

                        if (count == 1) {
                            depriorityCount.Remove(tempKey);
                        }
                        else {
                            depriorityCount[tempKey]--;
                        }
                    }

                    int invalidatedKey = recentUsedQ.Dequeue();
                    int invalidatedIndex = keyIndexMapping[invalidatedKey];

                    keyIndexMapping.Remove(invalidatedKey);

                    values[invalidatedIndex] = value;
                    keyIndexMapping.Add(key, invalidatedIndex);                    
                }
            }

            // put it to priority queue
            recentUsedQ.Enqueue(key);
        }
    }
}
