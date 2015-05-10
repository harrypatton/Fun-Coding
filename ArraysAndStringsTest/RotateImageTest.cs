using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArraysAndStrings;

namespace ArraysAndStringsTest
{
    [TestClass]
    public class RotateImageTest
    {
        [TestMethod]
        public void RotateImage1()
        {
            int[,] images = {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9}
            };

            RotateImage.Rotate(images);

            int[,] expectedImages = {
                {7, 4, 1},
                {8, 5, 2},
                {9, 6, 3}
            };

            Assert.IsTrue(IsEqual(images, expectedImages));
        }

        [TestMethod]
        public void RotateImage2()
        {
            int[,] images = {
                {1, 2, 3, 4},
                {5, 6, 7, 8},
                {9, 10 ,11, 12},
                {13, 14, 15, 16 }
            };

            RotateImage.Rotate(images);

            int[,] expectedImages = {
                {13, 9, 5, 1},
                {14, 10, 6, 2},
                {15, 11, 7, 3},
                {16, 12, 8, 4},
            };

            Assert.IsTrue(IsEqual(images, expectedImages));
        }

        public bool IsEqual(int[,] images1, int[,] images2)
        {
            for(int i = 0; i < images1.GetLength(0); i ++)
            {
                for(int j = 0; j < images1.GetLength(1); j++)
                {
                    if (images1[i, j] != images2[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
