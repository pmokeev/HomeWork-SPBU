using System;
using System.Collections.Generic;
using System.Linq;

namespace Routers
{
    public static class Algorithm
    {
        private static IEnumerable<(int firstVertex, int secondVertex, int weight)> GetSortedArrayWeights(int[,] matrix)
        {
            var listToSort = new List<(int firstVertex, int secondVertex, int weight)>();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j > i)
                    {
                        listToSort.Add((i, j, matrix[i, j]));
                    }
                }
            }

            return listToSort.OrderByDescending(element => element.weight);
        }

        private static List<int>[] GetAdjacencyList(int[,] matrix)
        {
            var currentList = new List<int>[matrix.GetUpperBound(0) + 1];

            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                currentList[i] = new List<int>();
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] != 0)
                    {
                        currentList[i].Add(j);
                    }
                }
            }

            return currentList;
        }

        private static bool IsCyclicUtil(int v, bool[] visited, int parent, int[,] matrix)
        {
            List<int>[] currentList = GetAdjacencyList(matrix);
            visited[v] = true;

            foreach (var i in currentList[v])
            {
                if (!visited[i])
                {
                    if (IsCyclicUtil(i, visited, v, matrix))
                    {
                        return true;
                    }
                }
                else if (i != parent)
                {
                    return true;
                }
            }

            return false;

        }

        public static bool HasCycle(int size, int[,] matrix)
        {
            bool[] visited = new bool[size];

            for (int u = 0; u < size; u++)
            {
                if (!visited[u])
                {
                    if (IsCyclicUtil(u, visited, -1, matrix))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static int[,] KruskullsAlgorithm(int[,] matrix)
        {
            IEnumerable<(int firstVertex, int secondVertex, int weight)> weightsArray = GetSortedArrayWeights(matrix);

            var resultMatrix = new int[matrix.GetLength(0), matrix.GetLength(1)];

            foreach (var item in weightsArray)
            {
                resultMatrix[item.firstVertex, item.secondVertex] = item.weight;
                resultMatrix[item.secondVertex, item.firstVertex] = item.weight;

                if (HasCycle(matrix.GetLength(0), resultMatrix))
                {
                    resultMatrix[item.firstVertex, item.secondVertex] = 0;
                    resultMatrix[item.secondVertex, item.firstVertex] = 0;
                }
            }

            return resultMatrix;
        }
    }
}
