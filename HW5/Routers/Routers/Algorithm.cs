using System;
using System.Collections.Generic;
using System.Linq;

namespace Routers
{
    /// <summary>
    /// A class that finds the best route between routers
    /// </summary>
    public static class Algorithm
    {
        /// <summary>
        /// The function creates a sorted list of pairs of vertices and weights between them
        /// </summary>
        private static IEnumerable<(int firstVertex, int secondVertex, int weight)> GetSortedArrayWeights(int[,] matrix)
        {
            var listToSort = new List<(int firstVertex, int secondVertex, int weight)>();

            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = i + 1; j < matrix.GetLength(0); j++)
                {
                    if (matrix[i, j] != 0)
                    {
                        listToSort.Add((i, j, matrix[i, j]));
                    }
                }
            }

            return listToSort.OrderByDescending(x => x.weight).ToList();
        }

        /// <summary>
        /// Helper function for finding a cycle in a graph
        /// </summary>
        private static bool IsCyclicUtility(int currentVertex, bool[] visited, int parent, List<int>[] adjacencyList)
        {
            visited[currentVertex] = true;

            foreach (var nextVertex in adjacencyList[currentVertex])
            {
                if (!visited[nextVertex])
                {
                    if (IsCyclicUtility(nextVertex, visited, currentVertex, adjacencyList))
                    {
                        return true;
                    }
                }
                else if (nextVertex != parent)
                {
                    return true;
                }
            }

            return false;

        }

        /// <summary>
        /// Function that checks the presence of a cycle in a graph
        /// </summary>
        private static bool HasCycle(int size, List<int>[] adjacencyList)
        {
            bool[] visited = new bool[size];

            for (int currentVertex = 0; currentVertex < size; currentVertex++)
            {
                if (!visited[currentVertex])
                {
                    if (IsCyclicUtility(currentVertex, visited, -1, adjacencyList))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Function that implements Kruskal's algorithm by the current adjacency matrix
        /// </summary>
        /// <param name="matrix">adjacency matrix</param>
        /// <returns>The most weighted matrix between two vertices</returns>
        public static int[,] KruskullsAlgorithm(int[,] matrix)
        {
            IEnumerable<(int firstVertex, int secondVertex, int weight)> weightsArray = GetSortedArrayWeights(matrix);

            var resultMatrix = new int[matrix.GetLength(0), matrix.GetLength(0)];
            var adjacencyList = new List<int>[matrix.GetLength(0)];
            var setVertices = new Set(matrix.GetLength(0));

            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                adjacencyList[i] = new List<int>();
            }

            foreach (var item in weightsArray)
            {
                resultMatrix[item.firstVertex, item.secondVertex] = item.weight;
                resultMatrix[item.secondVertex, item.firstVertex] = item.weight;
                adjacencyList[item.firstVertex].Add(item.secondVertex);
                adjacencyList[item.secondVertex].Add(item.firstVertex);

                if (HasCycle(matrix.GetLength(0), adjacencyList))
                {
                    resultMatrix[item.firstVertex, item.secondVertex] = 0;
                    resultMatrix[item.secondVertex, item.firstVertex] = 0;
                    adjacencyList[item.firstVertex].Remove(item.secondVertex);
                    adjacencyList[item.secondVertex].Remove(item.firstVertex);
                    continue;
                }

                setVertices.Union(item.firstVertex, item.secondVertex);
            }

            if (!setVertices.IsOnlySet())
            {
                throw new DisconnectedNetworkException("Disconnected network!");
            }

            return resultMatrix;
        }
    }
}