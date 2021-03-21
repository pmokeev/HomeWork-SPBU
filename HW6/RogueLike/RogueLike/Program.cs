using System;
using System.Collections.Generic;

namespace RogueLike
{
    class Program
    {
        static void Main(string[] args)
        {
            var eventLoop = new EventLoop();
            Game game;

            try
            {
                game = new Game("../../../Map.txt");
            }
            catch (PlayerNotFoundException)
            {
                Console.WriteLine("The player is not on the map!");
                return;
            }

            eventLoop.LeftHandler += game.OnLeft;
            eventLoop.RightHandler += game.OnRight;
            eventLoop.UpHandler += game.OnUp;
            eventLoop.DownHandler += game.OnDown;

            eventLoop.Run();
        }
    }
}