using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysAndStrings
{
    public class RotateImage
    {
        public static void Rotate(int[,] images)
        {
            int n = images.GetLength(0);
            for(int i = 0; i < n / 2; i ++)
            {
                for(int j = i; j < n - i - 1; j ++)
                {
                    int temp = images[n - j - 1, i];
                    images[n - j - 1, i] = images[n - i - 1, n - j - 1];
                    images[n - i - 1, n - j - 1] = images[j, n - i - 1];
                    images[j, n - i - 1] = images[i, j];
                    images[i, j] = temp;
                }
            }
        }
    }
}
