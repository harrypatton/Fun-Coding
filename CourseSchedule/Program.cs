using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSchedule {
    class Program {
        static void Main(string[] args) {
        }
    }

    public class Solution {
        public bool CanFinish(int numCourses, int[,] prerequisites) {

            if (numCourses <= 1) {
                return true;
            }

            int[,] prerequisitesMatrix = new int[numCourses, numCourses];
            for (int i = 0; i < prerequisites.GetLength(0); i++) {
                int row = prerequisites[i, 0];
                int column = prerequisites[i, 1];
                prerequisitesMatrix[row, column] = 1;
            }

            int courseCount = 0;
            int[] values = new int[numCourses];
            Queue<int> candidate = new Queue<int>();

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

            return courseCount == numCourses;
        }
    }
}
