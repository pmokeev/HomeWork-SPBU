using System;
using System.Collections.Generic;
using System.IO;

namespace Routers
{
    public static class ReadGraph
    {
        /// <summary>
        /// The function finds out the number of vertices in the graph
        /// </summary>
        private static int CountsVertices(string pathToGraph)
        {
            var set = new HashSet<int>();
            int lines = File.ReadAllLines(pathToGraph).Length;
            string[] stringsArray = File.ReadAllLines(pathToGraph);

            for (int i = 0; i < lines; i++)
            {
                stringsArray[i] = stringsArray[i].Replace(',', ' ');

                string[] currentLine = stringsArray[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var currentVertex = Int32.Parse(currentLine[0].Substring(0, currentLine[0].Length - 1));

                set.Add(currentVertex);

                for (int j = 0; j < currentLine.Length / 2; j++)
                {
                    var secondVertex = Int32.Parse(currentLine[2 * j + 1]);

                    set.Add(secondVertex);
                }
            }

            return set.Count;
        }

        /// <summary>
        /// The function gets the adjacency matrix from the input file
        /// </summary>
        public static int[,] CreateGraph(string pathToGraph)
        {
            int countsVertices = CountsVertices(pathToGraph);
            var graph = new int[countsVertices, countsVertices];

            int lines = File.ReadAllLines(pathToGraph).Length;
            string[] stringsArray = File.ReadAllLines(pathToGraph);

            for (int i = 0; i < stringsArray.Length; i++)
            {
                stringsArray[i] = stringsArray[i].Replace(',', ' ');

                string[] currentLine = stringsArray[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var currentVertex = Int32.Parse(currentLine[0].Substring(0, currentLine[0].Length - 1)) - 1;

                for (int j = 0; j < currentLine.Length / 2; j++)
                {
                    var secondVertex = Int32.Parse(currentLine[2 * j + 1]) - 1;

                    var distance = Int32.Parse(currentLine[2 * j + 2].Substring(1, currentLine[2 * j + 2].Length - 2));

                    graph[currentVertex, secondVertex] = distance;
                    graph[secondVertex, currentVertex] = distance;
                }
            }

            return graph;
        }

        public static void WriteInFile(int[,] matrix, string pathToGraph)
        {
            string newPath = pathToGraph.Substring(0, pathToGraph.Length - 4) + "Result" + ".txt";
            FileInfo fileIn = new FileInfo(newPath);

            if (fileIn.Exists)
            {
                fileIn.Delete();
            }

            FileStream file1 = new FileStream(newPath, FileMode.Create);
            StreamWriter writer = new StreamWriter(file1);

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var newLine = $"{i + 1}: ";

                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[i, j] != 0 && j > i)
                    {
                        newLine += $"{j + 1} ({matrix[i, j]}), ";
                    }
                }

                if (newLine != $"{i + 1}: ")
                {
                    writer.WriteLine(newLine.Substring(0, newLine.Length - 2));
                }
            }

            writer.Close();
            FileInfo fileOut = new FileInfo(newPath);
            if (fileOut.Exists)
            {
                fileOut.MoveTo(newPath);
            }
        }
    }
}
