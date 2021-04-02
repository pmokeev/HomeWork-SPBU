using System;
using System.Collections.Generic;
using System.Linq;

namespace TestTask
{
    /// <summary>
    /// A class that implements interaction with a sparse vector.
    /// </summary>
    public class SparseVector
    {
        public List<(int index, float value)> VectorList { get; set; }

        /// <summary>
        /// Sparse Vector Constructor
        /// </summary>
        /// <param name="vector">Full vector</param>
        public SparseVector(float[] vector)
        {
            VectorList = new List<(int index, float value)>();

            for (int i = 0; i < vector.Length; i++)
            {
                if (vector[i] != 0)
                {
                    VectorList.Add((i, vector[i]));
                }
            }
        }

        /// <summary>
        /// Sparse vector print
        /// </summary>
        public void PrintSparseVector()
        {
            foreach (var item in VectorList)
            {
                Console.Write($"({item.index}, {item.value}) ");
            }
        }

        /// <summary>
        /// Checking for a null vector
        /// </summary>
        public bool IsNull()
            => VectorList.Count == 0;

        /// <summary>
        /// The sum of two sparse vectors
        /// </summary>
        public void SumSparseVectors(SparseVector secondSparseVector)
        {
            foreach (var item in secondSparseVector.VectorList)
            {
                bool flag = false;

                for (int i = 0; i < VectorList.Count; i++)
                {
                    if (item.index == VectorList[i].index)
                    {
                        VectorList[i] = (item.index, item.value + VectorList[i].value);
                        flag = true;
                        break;
                    }
                }

                if (!flag)
                {
                    VectorList.Add((item.index, item.value));
                }
            }

            VectorList = VectorList.OrderBy(x => x.index).ToList();
        }

        /// <summary>
        /// Difference of two sparse vectors
        /// </summary>
        public void SubtractionSparseVectors(SparseVector secondSparseVector)
        {
            foreach (var item in secondSparseVector.VectorList)
            {
                bool flag = false;

                for (int i = 0; i < VectorList.Count; i++)
                {
                    if (item.index == VectorList[i].index)
                    {
                        VectorList[i] = (item.index, VectorList[i].value - item.value);
                        flag = true;
                        break;
                    }
                }

                if (!flag)
                {
                    VectorList.Add((item.index, item.value));
                }
            }

            VectorList = VectorList.OrderBy(x => x.index).ToList();
        }

        /// <summary>
        /// Scalar multiplication function of two vectors
        /// </summary>
        public float ScalarMultiplicationSparseVectors(SparseVector secondSparseVector)
        {
            float result = 0;

            foreach (var firstItem in VectorList)
            {
                foreach (var secondItem in secondSparseVector.VectorList)
                {
                    if (firstItem.index == secondItem.index)
                    {
                        result += firstItem.value * secondItem.value;
                    }
                }
            }

            return result;
        }
    }
}