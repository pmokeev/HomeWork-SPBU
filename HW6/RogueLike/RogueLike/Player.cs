using System;

namespace RogueLike
{
    /// <summary>
    /// The class that implements the character
    /// </summary>
    public class Player
    {
        /// <summary>
        /// X coordinate
        /// </summary>
        public int PositionX { get; set; }

        /// <summary>
        /// Y coordinate
        /// </summary>
        public int PositionY { get; set; }

        /// <summary>
        /// Character constructor
        /// </summary>
        public Player((int x, int y) positions)
        {
            PositionX = positions.x;
            PositionY = positions.y;
        }

        /// <summary>
        /// Changing the position of the character to new
        /// </summary>
        public void ChangePosition(int newPositionX, int newPositionY)
        {
            PositionX = newPositionX;
            PositionY = newPositionY;
        }
    }
}
