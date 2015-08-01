using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSchedule2 {
    class Program {
        static void Main(string[] args) {
            int[,] prerequisites = new int[1, 2];
            prerequisites[0, 0] = 1;
            prerequisites[0, 1] = 0;

            var result = (new Solution()).FindOrder(2, prerequisites);
        }
    }

    public class Solution {
        public int[] FindOrder(int numCourses, int[,] prerequisites) {
            if (numCourses <= 0) {
                return new int[] { };
            }

            int[,] prerequisitesMatrix = new int[numCourses, numCourses];
            for (int i = 0; i < prerequisites.GetLength(0); i++) {
                int column = prerequisites[i, 0];
                int row = prerequisites[i, 1];
                prerequisitesMatrix[row, column] = 1;
            }

            int courseCount = 0;
            int[] values = new int[numCourses];
            Queue<int> candidate = new Queue<int>();
            List<int> courses = new List<int>();

            // init the values
            for (int columnIndex = 0; columnIndex < numCourses; columnIndex++) {
                int count = 0;

                for (int rowIndex = 0; rowIndex < numCourses; rowIndex++) {
                    count += prerequisitesMatrix[rowIndex, columnIndex];
                }

                values[columnIndex] = count;

                if (count == 0) {
                    candidate.Enqueue(columnIndex);
                }
            }

            while (candidate.Any()) {
                int columnIndex = candidate.Dequeue();
                courseCount++;
                courses.Add(columnIndex);

                values[columnIndex] = -1;

                // we check all columns for the row (which is specified by columnIndex)
                for (int i = 0; i < numCourses; i++) {
                    if (prerequisitesMatrix[columnIndex, i] == 1) {
                        values[i]--;

                        // this course is ready to go
                        if (values[i] == 0) {
                            candidate.Enqueue(i);
                        }
                    }
                }
            }

            return courseCount == numCourses ? courses.ToArray() : (new int[] { });
        }
    }
}
