using NUnit.Framework;
using RogueLike;

namespace RogueLikeTests
{
    /// <summary>
    /// Class for testing interaction with the map
    /// </summary>
    public class MapTests
    {
        [Test]
        public void LoadMapTest()
        {
            var map = new Map("../../../Map1.txt");

            var arrayBorders = new bool[,] { { true, true, true }, { true, false, true }, { true, true, true } };

            Assert.AreEqual(arrayBorders, map.GetMap());
        }

        [Test]
        public void PlayerPositionsTest()
        {
            var map = new Map("../../../Map1.txt");

            var positions = (1, 1);

            Assert.AreEqual(positions, map.GetPositions());
        }

        [Test]
        public void NoPlayerExceptionTest()
        {
            Assert.Catch<PlayerNotFoundException>(() => new Map("../../../Map2.txt"));
        }

        [Test]
        public void TwoPlayersExceptionTest()
        {
            Assert.Catch<MoreThanOnePlayerOnTheMap>(() => new Map("../../../Map3.txt"));
        }
    }
}