using System;
using System.IO;

namespace RogueLike
{
    public class Map
    {
        private bool[,] mainMap;
        private int playerPositionX;
        private int playerPositionY;

        public Map(string pathToMap)
        {
            LoadMapFromFile(pathToMap);
        }

        public void LoadMapFromFile(string pathToMapFile)
        {
            int lines = File.ReadAllLines(pathToMapFile).Length;
            int columns = File.ReadAllLines(pathToMapFile)[0].Length;
            string[] stringMap = File.ReadAllLines(pathToMapFile);
            var map = new bool[lines, columns];
            using FileStream fileMap = File.OpenRead(pathToMapFile);
            int playerX = -1;
            int playerY = -1;

            for (int i = 0; i < lines; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    map[i, j] = stringMap[i][j] == '#' ? true : false;

                    if (stringMap[i][j] == '@')
                    {
                        playerX = i;
                        playerY = j;
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

        public bool[,] GetMap()
            => mainMap;

        public (int playerPositionX, int playerPositionY) GetPositions()
            => (playerPositionX, playerPositionY);

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

        public static void PrintPlayerOnPosition(int playerPositionX, int playerPositionY)
        {
            Console.SetCursorPosition(playerPositionY, playerPositionX);
            Console.Write("@");
            Console.SetCursorPosition(playerPositionY, playerPositionX);
        }
    }
}