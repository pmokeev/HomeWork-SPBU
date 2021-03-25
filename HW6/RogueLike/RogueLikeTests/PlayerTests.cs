using NUnit.Framework;
using RogueLike;

namespace RogueLikeTests
{
    /// <summary>
    /// Tests for class player
    /// </summary>
    public class PlayerTests
    {
        [Test]
        public void InitPlayerTest()
        {
            var player = new Player((1, 2));

            Assert.AreEqual(1, player.PositionX);
            Assert.AreEqual(2, player.PositionY);
        }

        [Test]
        public void ChangePlayerPositionTest()
        {
            var player = new Player((1, 2));

            player.ChangePosition((5, 6));

            Assert.AreEqual(5, player.PositionX);
            Assert.AreEqual(6, player.PositionY);
        }
    }
}
