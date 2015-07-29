using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareVersion {
    class Program {
        static void Main(string[] args) {
            var result = (new Solution()).CompareVersion("1.0", "1");
        }
    }

    public class Solution {
        public int CompareVersion(string version1, string version2) {

            if (version1 == null && version2 == null) {
                return 0;
            }
            else if (version1 == null || version2 == null) {
                return version1 == null ? -1 : 1;
            }
            else if (version1.Length == 0 && version2.Length == 0) {
                return 0;
            }
            else if (version1.Length == 0 || version2.Length == 0) {
                return version1.Length == 0 ? -1 : 1;
            }

            int left1 = 0;
            int right1 = 0;

            int left2 = 0;
            int right2 = 0;

            while (true) {
                bool found1 = FindPart(version1, left1, out left1, out right1);
                bool found2 = FindPart(version2, left2, out left2, out right2);

                if (found1 && found2) {
                    int result = CompareVersionPart(version1, left1, right1, version2, left2, right2);

                    if (result != 0) {
                        return result;
                    }
                    else {
                        left1 = right1 + 2;
                        left2 = right2 + 2;
                    }
                }
                else if (!found1 && !found2) {
                    return 0;
                }
                else {
                    // need to handle tailing part which just has 0.
                    if (found1) {
                        bool hasZeroTailingPart = true;
                        for (int i = left1; i < version1.Length; i++) {
                            if (version1[i] != '.' && version1[i] != '0') {
                                hasZeroTailingPart = false;
                                break;
                            }
                        }

                        return hasZeroTailingPart ? 0 : 1;
                    }
                    else {
                        bool hasZeroTailingPart = true;
                        for (int i = left2; i < version2.Length; i++) {
                            if (version2[i] != '.' && version2[i] != '0') {
                                hasZeroTailingPart = false;
                                break;
                            }
                        }

                        return hasZeroTailingPart ? 0 : -1;
                    }
                }
            }

            throw new InvalidOperationException("Cannot reach this line.");
        }

        public bool FindPart(string version, int index, out int left, out int right) {

            left = index;
            right = -1;

            if (index >= version.Length) {
                return false;
            }

            while (index < version.Length && version[index] != '.') {

                if (version[index] < '0' || version[index] > '9') {
                    return false;
                }

                index++;
            }

            right = index - 1;

            return right >= left;
        }

        public int CompareVersionPart(string version1, int left1, int right1, string version2, int left2, int right2) {
            // handle leading zero. left1 < right1 is to make sure it can uses the last element when the part is all zeros.
            while (left1 < right1 && version1[left1] == '0') {
                left1++;
            }

            while (left2 < right2 && version2[left2] == '0') {
                left2++;
            }

            if (right1 - left1 > right2 - left2) { // longer length
                return 1;
            }
            else if (right1 - left1 < right2 - left2) {
                return -1;
            }

            while (left1 <= right1) {
                if (version1[left1] > version2[left2]) {
                    return 1;
                }
                else if (version1[left1] < version2[left2]) {
                    return -1;
                }
                else {
                    left1++;
                    left2++;
                }
            }

            return 0;
        }
    }
}
