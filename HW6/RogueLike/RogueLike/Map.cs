using System;
using System.IO;

namespace RogueLike
{
    /// <summary>
    /// Class for interacting with the map
    /// </summary>
    public class Map
    {
        private bool[,] mainMap;
        private int playerPositionX;
        private int playerPositionY;

        /// <summary>
        /// Map constructor from file
        /// </summary>
        public Map(string pathToMap)
        {
            LoadMapFromFile(pathToMap);
        }

        /// <summary>
        /// Loading borders, map walls and character positions
        /// </summary>
        private void LoadMapFromFile(string pathToMapFile)
        {
            int lines = File.ReadAllLines(pathToMapFile).Length;
            int columns = File.ReadAllLines(pathToMapFile)[0].Length;
            string[] stringMap = File.ReadAllLines(pathToMapFile);
            var map = new bool[lines, columns];
            using FileStream fileMap = File.OpenRead(pathToMapFile);
            int playerX = -1;
            int playerY = -1;
            bool flag = false;

            for (int i = 0; i < lines; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    map[i, j] = stringMap[i][j] == '#' ? true : false;

                    if (stringMap[i][j] == '@')
                    {
                        if (flag)
                        {
                            throw new MoreThanOnePlayerOnTheMap();
                        }

                        playerX = i;
                        playerY = j;
                        flag = true;
                    }
                }
            }

            if (playerX == -1 && playerY == -1)
            {
                throw new PlayerNotFoundException("The player is not on the map!");
            }

            mainMap = map;
            playerPositionX = playerX;
            playerPositionY = playerY;
        }

        /// <summary>
        /// Receiving a map
        /// </summary>
        public bool[,] GetMap()
            => mainMap;

        /// <summary>
        /// Getting the starting coordinates of the character
        /// </summary>
        public (int playerPositionX, int playerPositionY) GetPositions()
            => (playerPositionX, playerPositionY);

        /// <summary>
        /// Printing a map by a bool array
        /// </summary>
        public static void PrintMap(bool[,] mainMap)
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < mainMap.GetLength(0); i++)
            {
                for (int j = 0; j < mainMap.GetLength(1); j++)
                {
                    Console.Write(mainMap[i, j] ? "#" : " ");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Draw the character at the desired coordinates
        /// </summary>
        public static void PrintPlayerOnPosition(int playerPositionX, int playerPositionY)
        {
            Console.SetCursorPosition(playerPositionY, playerPositionX);
            Console.Write("@");
            Console.SetCursorPosition(playerPositionY, playerPositionX);
        }
    }
}