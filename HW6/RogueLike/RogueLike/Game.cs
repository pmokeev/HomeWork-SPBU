using System;

namespace RogueLike
{
    /// <summary>
    /// A game class that implements a simple roguelike
    /// </summary>
    public class Game
    {
        public bool[,] mainMap { get; }
        public Player player { get; }

        /// <summary>
        /// Game constructor, we get the map and position of the player
        /// </summary>
        public Game(string pathToMap)
        {
            var map = new Map(pathToMap);

            mainMap = map.GetMap();
            player = new Player(map.GetPositions());

            Map.PrintMap(mainMap);
            Map.PrintPlayerOnPosition(player.PositionX, player.PositionY);
        }

        /// <summary>
        /// Player movement to the left
        /// </summary>
        public void OnLeft(object sender, EventArgs args)
            => TryToMove(player.PositionX, player.PositionY - 1);

        /// <summary>
        /// Player movement to the right
        /// </summary>
        public void OnRight(object sender, EventArgs args)
            => TryToMove(player.PositionX, player.PositionY + 1);

        /// <summary>
        /// Player movement up
        /// </summary>
        public void OnUp(object sender, EventArgs args)
            => TryToMove(player.PositionX - 1, player.PositionY);

        /// <summary>
        /// Player movement down
        /// </summary>
        public void OnDown(object sender, EventArgs args)
            => TryToMove(player.PositionX + 1, player.PositionY);

        /// <summary>
        /// Checking a step on the wall
        /// </summary>
        private bool IsColision(int newPositionX, int newPositionY)
        {
            if (newPositionX < 0 || newPositionY < 0 || newPositionX > mainMap.GetLength(0) || newPositionY > mainMap.GetLength(1))
            {
                return false;
            }

            return mainMap[newPositionX, newPositionY];
        }

        private void EasterEgg()
        {
            Console.Clear();
            Console.WriteLine("CREATED BY WARREN ROBINETT");
            System.Threading.Thread.Sleep(2000);
            Console.Clear();
            Map.PrintMap(mainMap);
        }

        /// <summary>
        /// Redrawing the character and changing coordinates
        /// </summary>
        private void MovePlayer(int newPositionX, int newPositionY)
        {
            if (newPositionX == 1 && newPositionY == 12)
            {
                EasterEgg();
            }

            mainMap[player.PositionX, player.PositionY] = false;
            Console.SetCursorPosition(player.PositionY, player.PositionX);
            Console.Write(" ");
            player.ChangePosition((newPositionX, newPositionY));
            Map.PrintPlayerOnPosition(newPositionX, newPositionY);
        }

        /// <summary>
        /// Trying to move the map
        /// </summary>
        private void TryToMove(int newPositionX, int newPositionY)
        {
            if (IsColision(newPositionX, newPositionY))
            {
                return;
            }

            MovePlayer(newPositionX, newPositionY);
        }
    }
}