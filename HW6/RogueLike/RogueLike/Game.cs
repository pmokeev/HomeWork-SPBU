using System;

namespace RogueLike
{
    public class Game
    {
        private readonly bool[,] mainMap;
        private readonly Player player;

        public Game(string pathToMap)
        {
            var map = new Map(pathToMap);

            mainMap = map.GetMap();
            player = new Player(map.GetPositions());

            Map.PrintMap(mainMap);
            Map.PrintPlayerOnPosition(player.PositionX, player.PositionY);
        }

        public void OnLeft(object sender, EventArgs args)
            => TryToMove(player.PositionX, player.PositionY - 1);

        public void OnRight(object sender, EventArgs args)
            => TryToMove(player.PositionX, player.PositionY + 1);

        public void OnUp(object sender, EventArgs args)
            => TryToMove(player.PositionX - 1, player.PositionY);

        public void OnDown(object sender, EventArgs args)
            => TryToMove(player.PositionX + 1, player.PositionY);

        private bool IsColision(int newPositionX, int newPositionY)
        {
            if (newPositionX < 0 || newPositionY < 0 || newPositionX > mainMap.GetLength(0) || newPositionY > mainMap.GetLength(1))
            {
                return false;
            }

            return mainMap[newPositionX, newPositionY];
        }

        private void MovePlayer(int newPositionX, int newPositionY)
        {
            mainMap[player.PositionX, player.PositionY] = false;
            Console.SetCursorPosition(player.PositionY, player.PositionX);
            Console.Write(" ");
            player.ChangePosition(newPositionX, newPositionY);
            Map.PrintPlayerOnPosition(newPositionX, newPositionY);
        }

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