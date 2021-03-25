using NUnit.Framework;
using RogueLike;
using System;

namespace RogueLikeTests
{
    /// <summary>
    /// Tests for class game
    /// </summary>
    public class GameTests
    {
        private Game game;

        [SetUp]
        public void Setup()
        {
            game = new Game("../../../Map4.txt");
        }

        [Test]
        public void PlayerMoveLeftTest()
        {
            game.OnLeft(this, EventArgs.Empty);

            Assert.AreEqual(2, game.player.PositionX);
            Assert.AreEqual(1, game.player.PositionY);
        }

        [Test]
        public void PlayerMoveDownTest()
        {
            game.OnDown(this, EventArgs.Empty);

            Assert.AreEqual(3, game.player.PositionX);
            Assert.AreEqual(2, game.player.PositionY);
        }

        [Test]
        public void PlayerMoveUpTest()
        {
            game.OnUp(this, EventArgs.Empty);

            Assert.AreEqual(1, game.player.PositionX);
            Assert.AreEqual(2, game.player.PositionY);
        }

        [Test]
        public void PlayerMoveRightTest()
        {
            game.OnRight(this, EventArgs.Empty);

            Assert.AreEqual(2, game.player.PositionX);
            Assert.AreEqual(3, game.player.PositionY);
        }

        [Test]
        public void IsColissionTest()
        {
            game.OnRight(this, EventArgs.Empty);
            game.OnRight(this, EventArgs.Empty);

            Assert.AreEqual(2, game.player.PositionX);
            Assert.AreEqual(3, game.player.PositionY);
        }
    }
}
