using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratePascalTriangle {
    class Program {
        static void Main(string[] args) {
        }
    }

    public class Solution {
        public IList<IList<int>> Generate(int numRows) {

            List<IList<int>> result = new List<IList<int>>();

            if (numRows == 0) {
                return result;
            }

            if (numRows >= 1) {
                result.Add(new List<int>(new int[] { 1 }));
            }

            if (numRows >= 2) {
                result.Add(new List<int>(new int[] { 1, 1 }));
            }

            if (numRows >= 3) {
                for(int i = 3; i <= numRows; i++) {

                    // create the list
                    List<int> tempList = new List<int>();
                    tempList.Add(1);

                    IList<int> lastList = result.Last();
                    for(int j = 1; j < lastList.Count; j ++) {
                        tempList.Add(lastList[j - 1] + lastList[j]);
                    }

                    tempList.Add(1);

                    // add it back to result
                    result.Add(tempList);
                }
            }

            return result;
        }
    }
}
