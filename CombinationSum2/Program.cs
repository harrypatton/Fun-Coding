using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombinationSum2
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            var result = s.CombinationSum2(new int[] { 1, 2, 2, 2, 5 }, 5);
        }
    }

    public class Solution
    {
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            // sort the candidate. 
            // TODO: need to remove duplicates.
            candidates = candidates.OrderBy(item => item).ToArray();

            List<IList<int>> result = new List<IList<int>>();
            List<IList<int>> intermediateResult = new List<IList<int>>();
            intermediateResult.Add(new List<int>());

            FindSum(candidates, target, 0, intermediateResult, result);

            return result;
        }

        public void FindSum(int[] candidates, int target, int index, List<IList<int>> intermediateResult, List<IList<int>> result)
        {
            // no luck
            if (target < 0)
            {
                return;
            }

            // we find the solution, add to final result list
            if (target == 0)
            {
                result.AddRange(intermediateResult);
                return;
            }

            // we need to make target smaller by each candidate from the index one. the elements on the left of index one is already covered by previous recursion calls.
            for (int i = index; i < candidates.Length; i++)
            {
                // skip the same character in this search.
                if (i != index && candidates[i] == candidates[i - 1])
                {
                    continue;
                }

                int value = candidates[i];
                int newTarget = target - value;

                List<IList<int>> tempIntermediateResult = new List<IList<int>>();

                // add value to intermediate result
                foreach (IList<int> list in intermediateResult)
                {
                    IList<int> tempList = new List<int>(list);
                    tempList.Add(value);
                    tempIntermediateResult.Add(tempList);
                }

                FindSum(candidates, newTarget, i + 1, tempIntermediateResult, result);
            }
        }
    }
}
