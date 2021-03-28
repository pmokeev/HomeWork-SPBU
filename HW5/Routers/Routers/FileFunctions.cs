using System;
using System.IO;

namespace Routers
{
    /// <summary>
    /// A class containing functions for interacting with a file
    /// </summary>
    public static class FileFunctions
    {
        /// <summary>
        /// The function finds out the number of vertices in the graph
        /// </summary>
        public static int CountsVertices(string pathToGraph)
        {
            var maxVertix = 1;
            int lines = File.ReadAllLines(pathToGraph).Length;
            string[] stringsArray = File.ReadAllLines(pathToGraph);

            for (int i = 0; i < lines; i++)
            {
                stringsArray[i] = stringsArray[i].Replace(',', ' ');

                string[] currentLine = stringsArray[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var currentVertex = Int32.Parse(currentLine[0].Substring(0, currentLine[0].Length - 1));

                maxVertix = Math.Max(currentVertex, maxVertix);

                for (int j = 0; j < currentLine.Length / 2; j++)
                {
                    var secondVertex = Int32.Parse(currentLine[2 * j + 1]);

                    maxVertix = Math.Max(secondVertex, maxVertix);
                }
            }

            return maxVertix;
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

        /// <summary>
        /// Function that prints the result to a new file
        /// </summary>
        public static void WriteInFile(int[,] matrix, string newPath)
        {
            FileInfo fileOut = new FileInfo(newPath);

            if (fileOut.Exists)
            {
                fileOut.Delete();
            }

            FileStream currentFile = new FileStream(newPath, FileMode.Create);
            StreamWriter writer = new StreamWriter(currentFile);

            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                var newLine = $"{i + 1}: ";

                for (int j = i + 1; j < matrix.GetLength(0); j++)
                {
                    if (matrix[i, j] != 0)
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
            if (fileOut.Exists)
            {
                fileOut.MoveTo(newPath);
            }
        }
    }
}