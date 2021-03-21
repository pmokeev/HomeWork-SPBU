using System;

namespace RogueLike
{
    public class Player
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }

        public Player((int x, int y) positions)
        {
            PositionX = positions.x;
            PositionY = positions.y;
        }

        public void ChangePosition(int newPositionX, int newPositionY)
        {
            PositionX = newPositionX;
            PositionY = newPositionY;
        }
    }
}
