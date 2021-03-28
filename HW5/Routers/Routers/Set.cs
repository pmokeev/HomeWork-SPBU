using System;

namespace Routers
{
    /// <summary>
    /// A class that implements a disjoint set
    /// </summary>
    public class Set
    {
        private int[] arraySets;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="countsVertices">Number of vertices in the graph</param>
        public Set(int countsVertices)
        {
            arraySets = new int[countsVertices];

            for (int i = 0; i < countsVertices; i++)
            {
                arraySets[i] = i;
            }
        }

        /// <summary>
        /// The function returns the minimum element in the desired set
        /// </summary>
        public int Find(int currentVertex)
        {
            if (currentVertex == arraySets[currentVertex])
            {
                return currentVertex;
            }

            return Find(arraySets[currentVertex]);
        }

        /// <summary>
        /// Checking that there is only one set
        /// </summary>
        public bool IsOnlySet()
        {
            for (int i = 0; i < arraySets.Length; i++)
            {
                if (Find(0) != Find(i))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Union of two sets
        /// </summary>
        public void Union(int firstVertex, int secondVertex)
        {
            int firstElement = Find(firstVertex);
            int secondElement = Find(secondVertex);

            if (firstElement != secondElement)
            {
                arraySets[secondElement] = firstElement;
            }
        }
    }
}